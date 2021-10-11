using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using EnvisionStaking.Casper.SDK;
using EnvisionStaking.Casper.SDK.Model.DeployObject;
using EnvisionStaking.Casper.SDK.Enums;
using EnvisionStaking.Casper.SDK.Model.Common;
using System.Collections.Generic;
using EnvisionStaking.Casper.SDK.Utils;
using EnvisionStaking.Casper.SDK.Serialization;

namespace EnvisionStaking.Casper.SDK.HowToGuides.DeployContractByHash
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //The RPC url. You can use any node IP available, http://{NodeIp}:{7777}/rpc
                //You can find the connected nodes in https://cspr.live/tools/peers
                string rpcUrl = "https://node-clarity-mainnet.make.services/rpc";               

                CasperClient client = new CasperClient(rpcUrl);

                //Make the Deploy request
                PutDeployStoredContractByHashRequest request = MakeDeployStoredContractByHash(client);

                //Dispatch the Deploy
                var result = client.DeployService.PutDeploy(request);

                Console.WriteLine($"Transfer Executed, Deploy Hash: {result.result.deploy_hash}");
                //Wait until deploy is completed. This may take few seconds\minutes
                var deployResult = await client.RpcService.AwaitUntilDeployCompletedAsync(result.result.deploy_hash);

                if (deployResult.result.execution_results[0].result.Success != null)
                {
                    Console.WriteLine($"Deploy Completed Succefully");
                    Console.WriteLine($"Json Result");
                    Console.WriteLine(JsonConvert.SerializeObject(deployResult));
                }
                else
                {
                    Console.WriteLine($"Deploy Failed");
                    Console.WriteLine($"Json Result");
                    Console.WriteLine(JsonConvert.SerializeObject(deployResult));
                }
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        public static PutDeployStoredContractByHashRequest MakeDeployStoredContractByHash(CasperClient client)
        {           
            //Amount to transfer in CSPR tokens
            double amount = 10;
            //From Account
            string fromAccount = "01da19d95aae08da9df0c3a7ba8fbb368af4fb99e7f522b6471963473295955031";
            //To this Account
            string toAccount = "01c4328cde0ce19e18e8bf61cb0f62af889b928a1b958ce69c401e21b07fb7acd6";
            //The id of the transaction
            ulong id = 1;
            //The public key pem file location in disk. This key should match the sender account
            string publicKeyLocation = @"C:\tmp\Keys\public_key.pem";
            //The private key pem file location in disk. This key should match the sender account
            string privateKeyLocation = @"C:\tmp\Keys\secret_key.pem";

            //Set the amount in motes
            var normAmount = (ulong)(amount * 1000000000);

            //Create Stored Contract By Hash Request
            PutDeployStoredContractByHashRequest putDeployRequest = new PutDeployStoredContractByHashRequest();
            putDeployRequest.id = client.RpcService.JsonRpcId;
            putDeployRequest.jsonrpc = client.RpcService.JsonRpcVersion;
            putDeployRequest.Parameters = new PutDeployStoredContractByHashParameters();
            putDeployRequest.Parameters.deploy = new PutDeployStoredContractByHash();

            //Set Payment for Delegate
            decimal delegatePayment = 2500010000;
            string delegatePaymentByte = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(delegatePayment));
            //Set Payment arguments
            var argsPayment = new List<DeployNamedArg>();
            argsPayment.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = delegatePaymentByte, parsed = delegatePayment.ToString() }));
            //Set Deploy Payment
            var payment = new DeployPayment();
            payment.ModuleBytes = new DeployModuleBytes(argsPayment);
            payment.ModuleBytes.module_bytes = "";
            putDeployRequest.Parameters.deploy.payment = payment;

            //Set Transfer
            string amountBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(normAmount));
            //Set Trasfer Arguments
            var argsDelegate = new List<DeployNamedArg>();
            argsDelegate.Add(new DeployNamedArg("delegator", new CLValue() { cl_type = CLType.CLTypeEnum.PublicKey, bytes = fromAccount, parsed = fromAccount }));
            argsDelegate.Add(new DeployNamedArg("validator", new CLValue() { cl_type = CLType.CLTypeEnum.PublicKey, bytes = toAccount, parsed = toAccount }));
            argsDelegate.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = amountBytes, parsed = amount.ToString() }));

            putDeployRequest.Parameters.deploy.session = new DeploySessionStoredContractByHash();
            putDeployRequest.Parameters.deploy.session.StoredContractByHash = new DeployStoredContractByHash(argsDelegate);
            putDeployRequest.Parameters.deploy.session.StoredContractByHash.entry_point = StakingDeployEnum.Delegate.ToString().ToLower();

            //Set Hash Key of Delegate Contract
            putDeployRequest.Parameters.deploy.session.StoredContractByHash.hash = "ccb576d6ce6dec84a551e48f0d0b7af89ddba44c7390b690036257a04a3ae9ea";

            //Set Header
            putDeployRequest.Parameters.deploy.header = new DeployHeader();
            putDeployRequest.Parameters.deploy.header.account = fromAccount;
            putDeployRequest.Parameters.deploy.header.timestamp = DateTime.Now;
            putDeployRequest.Parameters.deploy.header.ttl = "30m";
            putDeployRequest.Parameters.deploy.header.gas_price = 1;
            //Get the Body hash
            byte[] paymentBytes = putDeployRequest.Parameters.deploy.payment.ModuleBytes.ToBytes();
            byte[] delegateBytes = putDeployRequest.Parameters.deploy.session.StoredContractByHash.ToBytes();
            byte[] combined = ByteUtil.CombineBytes(paymentBytes, delegateBytes);
            putDeployRequest.Parameters.deploy.header.body_hash = client.HashService.GetHashToHexFixedSize(combined, 32);
            
            putDeployRequest.Parameters.deploy.header.dependencies = new List<string>();
            putDeployRequest.Parameters.deploy.header.chain_name = "casper";

            //Get the serialized header
            byte[] serializedHeader = client.DeployService.GetSerializedHeader(putDeployRequest.Parameters.deploy.header);
            string hashedHeader = client.HashService.GetHashToHexFixedSize(serializedHeader, 32);

            //Set Deploy Hash
            putDeployRequest.Parameters.deploy.hash = hashedHeader;

            //Set Approval
            var keys = client.SigningService.GetKeyPairFromFile(publicKeyLocation, privateKeyLocation, SignAlgorithmEnum.ed25519);
            putDeployRequest.Parameters.deploy.approvals = new List<Approval>();
            putDeployRequest.Parameters.deploy.approvals.Add(client.DeployService.SignApproval(fromAccount, putDeployRequest.Parameters.deploy.hash, keys));

            return putDeployRequest;
        }

    }
}
