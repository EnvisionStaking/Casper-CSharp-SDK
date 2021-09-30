using EnvisionStaking.Casper.SDK.Model.Common;
using EnvisionStaking.Casper.SDK.Model.DeployObject;
using EnvisionStaking.Casper.SDK.Serialization;
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
        private readonly SigningService signingSvc;
        public DeployService(RpcService rpcService, HashService hashService, SigningService signingService)
        {
            rpcSvc = rpcService;
            hashSvc = hashService;
            signingSvc = signingService;
        }

        public DeployResult GetDeploy(string deployHash)
        {
            return rpcSvc.GetDeploy(deployHash);
        }


        public PutDeployResult PutDeploy(Deploy deploy)
        {
            return rpcSvc.PutDeploy(deploy);
        }

        public PutDeployRequest MakeDeploy(UInt64 amount, string fromAccount, UInt64 id)
        {
            PutDeployRequest putDeployRequest = new PutDeployRequest();
            putDeployRequest.id = rpcSvc.JsonRpcId;
            putDeployRequest.jsonrpc = rpcSvc.JsonRpcVersion;
            putDeployRequest.Parameters = new PutDeployParameters();
            putDeployRequest.Parameters.deploy = new PutDeployDeploy();                  

            //Set Payment
            putDeployRequest.Parameters.deploy.payment = NewPayment();

            //Set Transfer
            putDeployRequest.Parameters.deploy.session = new PutDeploySession();
            putDeployRequest.Parameters.deploy.session.Transfer = NewTransfer(amount, fromAccount, id);

            //Set Header
            putDeployRequest.Parameters.deploy.header = new PutDeployHeader();
            putDeployRequest.Parameters.deploy.header.account = fromAccount;
            putDeployRequest.Parameters.deploy.header.timestamp = DateTime.Now;
            putDeployRequest.Parameters.deploy.header.ttl = "30m";
            putDeployRequest.Parameters.deploy.header.gas_price = 10;
            putDeployRequest.Parameters.deploy.header.body_hash = GetBodyHash(putDeployRequest.Parameters.deploy.payment, putDeployRequest.Parameters.deploy.session.Transfer) ;
            putDeployRequest.Parameters.deploy.header.dependencies = new List<string>();
            putDeployRequest.Parameters.deploy.header.chain_name = "casper";

            byte[] serializedHeader = GetSerializedHeader(putDeployRequest.Parameters.deploy.header);
            string hashedHeader = hashSvc.GetHashToHex(serializedHeader);

            //Set Approval
            var keys = signingSvc.GenerateKeyPair();
            putDeployRequest.Parameters.deploy.approvals = new List<Approval>();
            putDeployRequest.Parameters.deploy.approvals.Add(new Approval()
            {
                signature = "012dbf03817a51794a8e19e0724884075e6d1fbec326b766ecfa6658b41f81290da85e23b24e88b1c8d9761185c961daee1adab0649912a6477bcd2e69bd91bd08",
                signer = hashSvc.GetHashToHex(signingSvc.GetSignature(keys.Private, serializedHeader))

            });           

            //Set Deploy Hash
            putDeployRequest.Parameters.deploy.hash = hashedHeader;
            return putDeployRequest;
        }

        private byte[] GetSerializedHeader(PutDeployHeader header)
        {
            byte[] bytes;

            //bytes = TypesSerializer.GetPublicKeySerializer(hashSvc.GetAccountHash(header.account))
            bytes = TypesSerializer.GetPublicKeySerializer(header.account);
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.Getu64Serializer(header.timestamp.ToBinary()));
            bytes = ByteUtil.CombineBytes(bytes,TypesSerializer.Getu64SerializerTtl(header.ttl, "m"));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.Getu64Serializer(header.gas_price));
            bytes = ByteUtil.CombineBytes(bytes,ByteUtil.HexToByteArray(header.body_hash));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetListSerializer(header.dependencies));
            bytes = ByteUtil.CombineBytes(bytes, ByteUtil.StringToByteArray(header.chain_name));

            return bytes;
        }

        private string GetBodyHash(PutDeployPayment payment, DeployTransfer transfer)
        {
            byte[] transferBytes = transfer.ToBytes();

            byte[] paymentBytes = payment.ModuleBytes.ToBytes();           
            

            byte[] combined = ByteUtil.CombineBytes(paymentBytes, transferBytes);

            return hashSvc.GetHashToHex(combined);
        }

        private PutDeployPayment NewPayment()
        {
            decimal standardPayment = 10000000000;
            string standardPaymentByte = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(standardPayment));

            var argsPayment = new List<DeployNamedArg>();
            argsPayment.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = standardPaymentByte, parsed = standardPaymentByte.ToString() }));

            var payment = new PutDeployPayment();
            payment.ModuleBytes = new DeployModuleBytes(argsPayment);
            payment.ModuleBytes.module_bytes = "";
                      

            return payment;
        }

        private DeployTransfer NewTransfer(ulong amount, string fromAccount, ulong id)
        {
            string amountBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(amount));
            string idBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu64SerializerWithPrefixOption(id));
            string accountHex = hashSvc.GetAccountHash(fromAccount);
            var argsTransfer = new List<DeployNamedArg>();
            argsTransfer.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = amountBytes, parsed = amount.ToString() }));
            argsTransfer.Add(new DeployNamedArg("target", new CLValue() { cl_type = CLType.CLTypeEnum.PUBLIC_KEY, bytes = accountHex, parsed = fromAccount }));
            argsTransfer.Add(new DeployNamedArg("id", new CLValue() { cl_type = CLType.CLTypeEnum.U64, bytes = idBytes, parsed = id.ToString() }));

            return new DeployTransfer(argsTransfer);
        }

        public string MakeDeployToJson(UInt64 amount, string fromAccount, UInt64 id)
        {          
            return JsonConvert.SerializeObject(MakeDeploy(amount, fromAccount, id), JsonUtil.JsonSerializerSettings());
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
