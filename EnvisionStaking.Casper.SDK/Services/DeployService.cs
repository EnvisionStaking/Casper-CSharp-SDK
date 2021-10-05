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


        public PutDeployResult PutDeploy(double amount, string fromAccount, string toAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation)
        {
            PutDeployRequest request = MakeDeploy(amount, fromAccount, toAccount, id, publicKeyLocation, privateKeyLocation);
            return rpcSvc.PutDeploy(request);
        }

        public PutDeployRequest MakeDeploy(double amount, string fromAccount, string toAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation)
        {
            var normAmount = (ulong)(amount * 1000000000);
            PutDeployRequest putDeployRequest = new PutDeployRequest();
            putDeployRequest.id = rpcSvc.JsonRpcId;
            putDeployRequest.jsonrpc = rpcSvc.JsonRpcVersion;
            putDeployRequest.Parameters = new PutDeployParameters();
            putDeployRequest.Parameters.deploy = new PutDeployDeploy();

            //Set Payment
            putDeployRequest.Parameters.deploy.payment = NewPayment();

            //Set Transfer
            putDeployRequest.Parameters.deploy.session = new PutDeploySession();
            putDeployRequest.Parameters.deploy.session.Transfer = NewTransfer(normAmount, toAccount, id);

            //Set Header
            putDeployRequest.Parameters.deploy.header = new PutDeployHeader();
            putDeployRequest.Parameters.deploy.header.account = fromAccount;
            putDeployRequest.Parameters.deploy.header.timestamp = DateTime.Parse("2021-10-04T09:59:27.534000Z");
            putDeployRequest.Parameters.deploy.header.ttl = "30m";
            putDeployRequest.Parameters.deploy.header.gas_price = 10;
            putDeployRequest.Parameters.deploy.header.body_hash = GetBodyHash(putDeployRequest.Parameters.deploy.payment, putDeployRequest.Parameters.deploy.session.Transfer);
            putDeployRequest.Parameters.deploy.header.dependencies = new List<string>();
            putDeployRequest.Parameters.deploy.header.chain_name = "casper";

            byte[] serializedHeader = GetSerializedHeader(putDeployRequest.Parameters.deploy.header);
            string hashedHeader = hashSvc.GetHashToHexFixedSize(serializedHeader, 32);

            //Set Deploy Hash
            putDeployRequest.Parameters.deploy.hash = hashedHeader;

            //Set Approval
            var keys = signingSvc.GetKeyPairFromFile(publicKeyLocation, privateKeyLocation);
            putDeployRequest.Parameters.deploy.approvals = new List<Approval>();
            putDeployRequest.Parameters.deploy.approvals.Add(CreateAndSignApproval(fromAccount, putDeployRequest.Parameters.deploy.hash, keys));
            
            return putDeployRequest;
        }

        private Approval CreateAndSignApproval(string fromAccount, string deployHash, Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair keys)
        {
            byte[] hashValueByte = ByteUtil.HexToByteArray(deployHash);
            byte[] algorithm = hashSvc.GetAlgorithmBytes(fromAccount);

            //Sign hash value
            byte[] signature = signingSvc.GetSignature(keys.Private, hashValueByte);

            //The fist byte within the signature is 1 in the case of an Ed25519 signature or 2 in the case of Secp256k1.
            byte[] bytes = ByteUtil.CombineBytes(algorithm, signature);
          
            var approval = new Approval();
            approval.signature = ByteUtil.ByteArrayToHex(bytes);
            approval.signer = fromAccount;

            return approval;
        }

        public string MakeDeployToJson(double amount, string fromAccount, string toAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation)
        {
            return JsonConvert.SerializeObject(MakeDeploy(amount, fromAccount, toAccount, id, publicKeyLocation, privateKeyLocation), JsonUtil.JsonSerializerSettings());
        }

        public void SignDeploy()
        {

        }

        public void DispatchDeploy()
        {

        }

        private byte[] GetSerializedHeader(PutDeployHeader header)
        {
            byte[] bytes;

            //bytes = TypesSerializer.GetPublicKeySerializer(hashSvc.GetAccountHash(header.account))
            bytes = TypesSerializer.GetPublicKeySerializer(header.account);
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetTimeSerializerEpochBytes(header.timestamp));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetTTLSerializer(header.ttl));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.Getu64Serializer(header.gas_price));
            bytes = ByteUtil.CombineBytes(bytes,ByteUtil.HexToByteArray(header.body_hash));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetListSerializer(header.dependencies));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetStringSerializerWithLength(header.chain_name));

            return bytes;
        }

        private string GetBodyHash(PutDeployPayment payment, DeployTransfer transfer)
        {
            byte[] paymentBytes = payment.ModuleBytes.ToBytes();

            byte[] transferBytes = transfer.ToBytes();                 
            
            byte[] combined = ByteUtil.CombineBytes(paymentBytes, transferBytes);

            return hashSvc.GetHashToHexFixedSize(combined, 32);
        }

        private PutDeployPayment NewPayment()
        {
            decimal standardPayment = 10000000000;
            string standardPaymentByte = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(standardPayment));

            var argsPayment = new List<DeployNamedArg>();
            argsPayment.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = standardPaymentByte, parsed = standardPayment.ToString() }));

            var payment = new PutDeployPayment();
            payment.ModuleBytes = new DeployModuleBytes(argsPayment);
            payment.ModuleBytes.module_bytes = "";
                      

            return payment;
        }

        private DeployTransfer NewTransfer(ulong amount, string toAccount, ulong id)
        {
            string amountBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(amount));
            string idBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu64SerializerWithPrefixOption(id));

            var argsTransfer = new List<DeployNamedArg>();
            argsTransfer.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = amountBytes, parsed = amount.ToString() }));
            argsTransfer.Add(new DeployNamedArg("target", new CLValue() { cl_type = CLType.CLTypeEnum.BYTE_ARRAY, bytes = hashSvc.GetAccountHash(toAccount), parsed = toAccount }));
            argsTransfer.Add(new DeployNamedArg("id", new CLValue() { cl_type = CLType.CLTypeEnum.OPTION, bytes = idBytes, parsed = id.ToString() }));

            return new DeployTransfer(argsTransfer);
        }
    }
}
