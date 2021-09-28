using EnvisionStaking.Casper.SDK.Model.Common;
using EnvisionStaking.Casper.SDK.Model.DeployObject;
using EnvisionStaking.Casper.SDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Services
{
    public class DeployService
    {
        private readonly RpcService rpcSvc;
        private readonly HashService hashSvc;
        public DeployService(RpcService rpcService, HashService hashService)
        {
            rpcSvc = rpcService;
            hashSvc = hashService;
        }

        public DeployResult GetDeploy(string deployHash)
        {
            return rpcSvc.GetDeploy(deployHash);
        }


        public PutDeployResult PutDeploy(Deploy deploy)
        {
            return rpcSvc.PutDeploy(deploy);
        }

        public PutDeployRequest MakeDeploy(float amount, string fromAccount, int id)
        {
            PutDeployRequest putDeployRequest = new PutDeployRequest();
            putDeployRequest.id = rpcSvc.JsonRpcId;
            putDeployRequest.jsonrpc = rpcSvc.JsonRpcVersion;
            putDeployRequest.Parameters = new PutDeployParameters();
            putDeployRequest.Parameters.deploy = new PutDeployDeploy();
            //Set Deploy Hash
            putDeployRequest.Parameters.deploy.hash = "bce3326a8bc2104e0acafde7f7bb154aa258265e563fb37b3386220942bdb368";
            //Set Header
            putDeployRequest.Parameters.deploy.header = new PutDeployHeader();
            putDeployRequest.Parameters.deploy.header.account = fromAccount;
            putDeployRequest.Parameters.deploy.header.timestamp = DateTime.Now;
            putDeployRequest.Parameters.deploy.header.ttl = "30m";
            putDeployRequest.Parameters.deploy.header.gas_price = 1;
            putDeployRequest.Parameters.deploy.header.body_hash = "418c521b564a606b0de4b5bfc572c0b93e4d7e6d1a20abb5d4d957d239dd9d9b";
            putDeployRequest.Parameters.deploy.header.dependencies = new List<string>();
            putDeployRequest.Parameters.deploy.header.chain_name = "casper";

            //Set Approval
            putDeployRequest.Parameters.deploy.approvals = new List<Approval>();
            putDeployRequest.Parameters.deploy.approvals.Add(new Approval()
            {
                signature = "012dbf03817a51794a8e19e0724884075e6d1fbec326b766ecfa6658b41f81290da85e23b24e88b1c8d9761185c961daee1adab0649912a6477bcd2e69bd91bd08",
                signer = fromAccount

            });

            //Set Payment
            putDeployRequest.Parameters.deploy.payment = new PutDeployPayment();
            putDeployRequest.Parameters.deploy.payment.ModuleBytes = new ModuleBytes();
            putDeployRequest.Parameters.deploy.payment.ModuleBytes.module_bytes = "";

            var argsPayment = new List<KeyValuePair<string, CLValue>>();
            argsPayment.Add(new KeyValuePair<string, CLValue>("amount", new CLValue() { cl_type = "U512", bytes = ByteUtil.ByteArrayToString(BitConverter.GetBytes(amount)), parsed = amount.ToString() }));

            putDeployRequest.Parameters.deploy.payment.ModuleBytes.argsObject = argsPayment;


            //Set Transfer
            putDeployRequest.Parameters.deploy.transfer = new PutDeployTransfer();
            putDeployRequest.Parameters.deploy.transfer.ModuleBytes = new ModuleBytes();
            putDeployRequest.Parameters.deploy.transfer.ModuleBytes.module_bytes = "";

            var argsTransfer = new List<KeyValuePair<string, CLValue>>();
            argsTransfer.Add(new KeyValuePair<string, CLValue>("amount", new CLValue() { cl_type = "U512", bytes = ByteUtil.ByteArrayToString(BitConverter.GetBytes(amount)), parsed = amount.ToString() }));
            argsTransfer.Add(new KeyValuePair<string, CLValue>("target", new CLValue() { cl_type = "PublicKey", bytes = hashSvc.GetAccountHash(fromAccount) , parsed = hashSvc.GetAccountHash(fromAccount) }));
            argsTransfer.Add(new KeyValuePair<string, CLValue>("id", new CLValue() { cl_type = "U64", bytes = ByteUtil.ByteArrayToString(BitConverter.GetBytes(id)), parsed = id.ToString() }));

            putDeployRequest.Parameters.deploy.transfer.ModuleBytes.argsObject = argsTransfer;
            return putDeployRequest;
        }

        public string MakeDeployToJson(float amount, string fromAccount, int id)
        {
            return JsonConvert.SerializeObject(MakeDeploy(amount, fromAccount, id));
        }

        public void SignDeploy()
        {

        }

        public void DispatchDeploy()
        {

        }

        public Transfer NewTransfer(float amount, string fromAccount, int id)
        {

            byte[] amountBytes = BitConverter.GetBytes(id);

            // Prefix the option bytes with OPTION_NONE or OPTION_SOME
            byte[] idBytes = PrefixOption(BitConverter.GetBytes(id));

            string accountKey = fromAccount;
            string accountHash = hashSvc.GetAccountHash(accountKey);

            //final DeployNamedArg amountArg = new DeployNamedArg("amount", new CLValue(amountBytes, CLType.U512, amount.toString()));
            //final DeployNamedArg targetArg = new DeployNamedArg("target", new CLValue(accountHash, new CLByteArrayInfo(32), target.toAccountHex()));
            //final DeployNamedArg idArg = new DeployNamedArg("id", new CLOptionValue(idBytes, new CLOptionTypeInfo(new CLTypeInfo(CLType.U64)), id.toString()));

            //return new Transfer(CollectionUtils.List.of(amountArg, targetArg, idArg));
            return null;
        }

        public static byte[] PrefixOption(byte[] bytes)
        {

            byte[] optionPrefix;
            //OPTION_NONE
            if (bytes == null || bytes.Length == 0)
            {
                optionPrefix = new byte[] { 0x00 };
            }
            //OPTION_SOME
            else
            {
                optionPrefix = new byte[] { 0x01 };
            }
            return ByteUtil.CombineBytes(optionPrefix, bytes);
        }
    }
}
