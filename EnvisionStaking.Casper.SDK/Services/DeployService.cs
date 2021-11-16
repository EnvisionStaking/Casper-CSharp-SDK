using EnvisionStaking.Casper.SDK.Enums;
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
    /// <summary>
    /// Deploy service is responsible to deploy contracts in Casper Network
    /// </summary>
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
        /// <summary>
        /// Get the Deploy from RPC call
        /// </summary>
        /// <param name="deployHash"></param>
        /// <returns></returns>
        public DeployResult GetDeploy(string deployHash)
        {
            return rpcSvc.GetDeploy(deployHash);
        }

        #region Transfer
        /// <summary>
        /// Deploys a Transfer in Casper Network. The operation uses the Transfer ExecutableDeployItem
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="fromAccount"></param>
        /// <param name="toAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <returns></returns>
        public PutDeployResult Transfer(double amount, string fromAccount, string toAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, string chainName)
        {
            PutDeployTransferRequest request = MakeDeployTransfer(amount, fromAccount, toAccount, id, publicKeyLocation, privateKeyLocation, signAlgorithm, chainName);
            return rpcSvc.PutDeploy(request);
        }
        /// <summary>
        /// Make the Transfer deploy Request in JSON
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="fromAccount"></param>
        /// <param name="toAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <returns></returns>
        public PutDeployTransferRequest MakeDeployTransfer(double amount, string fromAccount, string toAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, string chainName)
        {
            var normAmount = (ulong)(amount * 1000000000);
            PutDeployTransferRequest putDeployRequest = new PutDeployTransferRequest();
            putDeployRequest.id = rpcSvc.JsonRpcId;
            putDeployRequest.jsonrpc = rpcSvc.JsonRpcVersion;
            putDeployRequest.Parameters = new PutDeployTransferParameters();
            putDeployRequest.Parameters.deploy = new PutDeployTransfer();

            //Set Payment
            putDeployRequest.Parameters.deploy.payment = NewPayment(10000);

            //Set Transfer
            putDeployRequest.Parameters.deploy.session = new DeploySessionTransfer();
            putDeployRequest.Parameters.deploy.session.Transfer = NewTransfer(normAmount, toAccount, id);

            //Set Header
            putDeployRequest.Parameters.deploy.header = new DeployHeader();
            putDeployRequest.Parameters.deploy.header.account = fromAccount;
            putDeployRequest.Parameters.deploy.header.timestamp = DateTime.Now;
            putDeployRequest.Parameters.deploy.header.ttl = "30m";
            putDeployRequest.Parameters.deploy.header.gas_price = 1;
            putDeployRequest.Parameters.deploy.header.body_hash = GetBodyHashTransfer(putDeployRequest.Parameters.deploy.payment, putDeployRequest.Parameters.deploy.session.Transfer);
            putDeployRequest.Parameters.deploy.header.dependencies = new List<string>();
            putDeployRequest.Parameters.deploy.header.chain_name = chainName;

            byte[] serializedHeader = GetSerializedHeader(putDeployRequest.Parameters.deploy.header);
            string hashedHeader = hashSvc.GetHashToHexFixedSize(serializedHeader, 32);

            //Set Deploy Hash
            putDeployRequest.Parameters.deploy.hash = hashedHeader;

            //Set Approval
            var keys = signingSvc.GetKeyPairFromFile(publicKeyLocation, privateKeyLocation, signAlgorithm);
            putDeployRequest.Parameters.deploy.approvals = new List<Approval>();
            putDeployRequest.Parameters.deploy.approvals.Add(SignApproval(fromAccount, putDeployRequest.Parameters.deploy.hash, keys));

            return putDeployRequest;
        }
        /// <summary>
        /// Get Transfer deploy request in JSON format
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="fromAccount"></param>
        /// <param name="toAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <returns></returns>
        public string TransferToJson(double amount, string fromAccount, string toAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, string chainName)
        {
            return JsonConvert.SerializeObject(MakeDeployTransfer(amount, fromAccount, toAccount, id, publicKeyLocation, privateKeyLocation, signAlgorithm, chainName), JsonUtil.JsonSerializerSettings());
        }
        #endregion

        #region Delegate\Undelegate
        /// <summary>
        /// This method Delegate tokens to a Validator This operation uses the ExecutableDeployItem StoredContractByHash
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="delegatorAccount"></param>
        /// <param name="validatorAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <returns></returns>
        public PutDeployResult Delegate(double amount, string delegatorAccount, string validatorAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, string chainName)
        {
            var request = MakeDeployDelegateUndelegate(amount, delegatorAccount, validatorAccount, id, publicKeyLocation, privateKeyLocation, signAlgorithm, StakingDeployEnum.Delegate, chainName);
            return rpcSvc.PutDeploy(request);
        }
        /// <summary>
        /// This method Undelegate tokens from a Validator This operation uses the ExecutableDeployItem StoredContractByHash
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="delegatorAccount"></param>
        /// <param name="validatorAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <returns></returns>
        public PutDeployResult Undelegate(double amount, string delegatorAccount, string validatorAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, string chainName)
        {
            var request = MakeDeployDelegateUndelegate(amount, delegatorAccount, validatorAccount, id, publicKeyLocation, privateKeyLocation, signAlgorithm, StakingDeployEnum.Undelegate, chainName);
            return rpcSvc.PutDeploy(request);
        }
        /// <summary>
        /// Get Delegate deploy request in JSON format
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="delegatorAccount"></param>
        /// <param name="validatorAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <returns></returns>
        public string DelegateToJson(double amount, string delegatorAccount, string validatorAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, string chainName)
        {
            return JsonConvert.SerializeObject(MakeDeployDelegateUndelegate(amount, delegatorAccount, validatorAccount, id, publicKeyLocation, privateKeyLocation, signAlgorithm, StakingDeployEnum.Delegate, chainName), JsonUtil.JsonSerializerSettings());
        }
        /// <summary>
        /// Get Undelegate deploy request in JSON format
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="delegatorAccount"></param>
        /// <param name="validatorAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <returns></returns>
        public string UndelegateToJson(double amount, string delegatorAccount, string validatorAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, string chainName)
        {
            return JsonConvert.SerializeObject(MakeDeployDelegateUndelegate(amount, delegatorAccount, validatorAccount, id, publicKeyLocation, privateKeyLocation, signAlgorithm, StakingDeployEnum.Undelegate, chainName), JsonUtil.JsonSerializerSettings());
        }
        /// <summary>
        /// Make the Delegate or Undelegate deploy
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="delegatorAccount"></param>
        /// <param name="validatorAccount"></param>
        /// <param name="id"></param>
        /// <param name="publicKeyLocation"></param>
        /// <param name="privateKeyLocation"></param>
        /// <param name="signAlgorithm"></param>
        /// <param name="stakingDeploy"></param>
        /// <returns></returns>
        public PutDeployStoredContractByHashRequest MakeDeployDelegateUndelegate(double amount, string delegatorAccount, string validatorAccount, UInt64 id, string publicKeyLocation, string privateKeyLocation, SignAlgorithmEnum signAlgorithm, StakingDeployEnum stakingDeploy, string chainName)
        {
            var normAmount = (ulong)(amount * 1000000000);
            PutDeployStoredContractByHashRequest putDeployRequest = new PutDeployStoredContractByHashRequest();
            putDeployRequest.id = rpcSvc.JsonRpcId;
            putDeployRequest.jsonrpc = rpcSvc.JsonRpcVersion;
            putDeployRequest.Parameters = new PutDeployStoredContractByHashParameters();
            putDeployRequest.Parameters.deploy = new PutDeployStoredContractByHash();

            //Set Payment for Delegate or Undelegate
            if (stakingDeploy == StakingDeployEnum.Delegate)
            {
                putDeployRequest.Parameters.deploy.payment = NewPayment(2500010000);
            }
            else if (stakingDeploy == StakingDeployEnum.Undelegate)
            {
                putDeployRequest.Parameters.deploy.payment = NewPayment(10000);
            }

            //Set Transfer
            putDeployRequest.Parameters.deploy.session = new DeploySessionStoredContractByHash();
            putDeployRequest.Parameters.deploy.session.StoredContractByHash = NewDelegate(normAmount, delegatorAccount, validatorAccount, id);
            putDeployRequest.Parameters.deploy.session.StoredContractByHash.entry_point = stakingDeploy.ToString().ToLower();

            //Set Hash Key
            putDeployRequest.Parameters.deploy.session.StoredContractByHash.hash = "ccb576d6ce6dec84a551e48f0d0b7af89ddba44c7390b690036257a04a3ae9ea";

            //Set Header
            putDeployRequest.Parameters.deploy.header = new DeployHeader();
            putDeployRequest.Parameters.deploy.header.account = delegatorAccount;
            putDeployRequest.Parameters.deploy.header.timestamp = DateTime.Now;
            putDeployRequest.Parameters.deploy.header.ttl = "30m";
            putDeployRequest.Parameters.deploy.header.gas_price = 1;
            putDeployRequest.Parameters.deploy.header.body_hash = GetBodyHashDelegate(putDeployRequest.Parameters.deploy.payment, putDeployRequest.Parameters.deploy.session.StoredContractByHash);
            putDeployRequest.Parameters.deploy.header.dependencies = new List<string>();
            putDeployRequest.Parameters.deploy.header.chain_name = chainName;

            byte[] serializedHeader = GetSerializedHeader(putDeployRequest.Parameters.deploy.header);
            string hashedHeader = hashSvc.GetHashToHexFixedSize(serializedHeader, 32);

            //Set Deploy Hash
            putDeployRequest.Parameters.deploy.hash = hashedHeader;

            //Set Approval
            var keys = signingSvc.GetKeyPairFromFile(publicKeyLocation, privateKeyLocation, signAlgorithm);
            putDeployRequest.Parameters.deploy.approvals = new List<Approval>();
            putDeployRequest.Parameters.deploy.approvals.Add(SignApproval(delegatorAccount, putDeployRequest.Parameters.deploy.hash, keys));

            return putDeployRequest;
        }

        #endregion

        #region PutDeploy
        /// <summary>
        /// This method deploys Transfer operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployTransferRequest request)
        {
            return rpcSvc.PutDeploy(request);
        }

        /// <summary>
        /// This method deploys StoredContractByHash operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredContractByHashRequest request)
        {
            return rpcSvc.PutDeploy(request);
        }
        /// <summary>
        /// This method deploys StoredContractByName operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredContractByNameRequest request)
        {
            return rpcSvc.PutDeploy(request);
        }
        /// <summary>
        /// This method deploys StoredVersionedContractByHash operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredVersionedContractByHashRequest request)
        {
            return rpcSvc.PutDeploy(request);
        }
        /// <summary>
        /// This method deploys StoredVersionedContractByName operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredVersionedContractByNameRequest request)
        {

            return rpcSvc.PutDeploy(request);
        }
        #endregion

        #region Other
        /// <summary>
        /// Generate the Approval signature
        /// </summary>
        /// <param name="fromAccount"></param>
        /// <param name="deployHash"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public Approval SignApproval(string fromAccount, string deployHash, Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair keys)
        {
            byte[] hashValueByte = ByteUtil.HexToByteArray(deployHash);
            byte[] algorithmBytes = hashSvc.GetAlgorithmBytes(fromAccount);
            var algorithm = hashSvc.GetAlgorithm(fromAccount);

            //Sign hash value
            byte[] signature = null;
            if (algorithm == SignAlgorithmEnum.ed25519)
            {
                signature = signingSvc.GetSignatureEd25519(keys.Private, hashValueByte);
            }
            else if (algorithm == SignAlgorithmEnum.secp256k1)
            {
                signature = signingSvc.GetSignatureSecp256k1(keys.Private, hashValueByte);
            }


            //The fist byte within the signature is 1 in the case of an Ed25519 signature or 2 in the case of Secp256k1.
            byte[] bytes = ByteUtil.CombineBytes(algorithmBytes, signature);

            var approval = new Approval();
            approval.signature = ByteUtil.ByteArrayToHex(bytes);
            approval.signer = fromAccount;

            return approval;
        }
        /// <summary>
        /// Get the Header in Bytes
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public byte[] GetSerializedHeader(DeployHeader header)
        {
            byte[] bytes;

            bytes = ByteUtil.HexToByteArray(header.account);
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetTimeSerializerEpochBytes(header.timestamp));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetTTLSerializer(header.ttl));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.Getu64Serializer(header.gas_price));
            bytes = ByteUtil.CombineBytes(bytes, ByteUtil.HexToByteArray(header.body_hash));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetListSerializer(header.dependencies));
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetStringSerializerWithLength(header.chain_name));

            return bytes;
        }
        /// <summary>
        /// Get the Body hash for Transfer Deploy
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="transfer"></param>
        /// <returns></returns>
        public string GetBodyHashTransfer(DeployPayment payment, DeployTransfer transfer)
        {
            byte[] paymentBytes = payment.ModuleBytes.ToBytes();

            byte[] transferBytes = transfer.ToBytes();

            byte[] combined = ByteUtil.CombineBytes(paymentBytes, transferBytes);

            return hashSvc.GetHashToHexFixedSize(combined, 32);
        }

        /// <summary>
        /// Get the Body hash for Delegate Deploy
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="deployDelegate"></param>
        /// <returns></returns>
        public string GetBodyHashDelegate(DeployPayment payment, DeployStoredContractByHash deployDelegate)
        {
            byte[] paymentBytes = payment.ModuleBytes.ToBytes();

            byte[] delegateBytes = deployDelegate.ToBytes();

            byte[] combined = ByteUtil.CombineBytes(paymentBytes, delegateBytes);

            return hashSvc.GetHashToHexFixedSize(combined, 32);
        }

        /// <summary>
        /// Create a new Payment including the Deploy Arguments
        /// </summary>
        /// <param name="paymentAmount"></param>
        /// <returns></returns>
        public DeployPayment NewPayment(decimal paymentAmount)
        {
            decimal standardPayment = paymentAmount;
            string standardPaymentByte = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(standardPayment));

            var argsPayment = new List<DeployNamedArg>();
            argsPayment.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = standardPaymentByte, parsed = standardPayment.ToString() }));

            var payment = new DeployPayment();
            payment.ModuleBytes = new DeployModuleBytes(argsPayment);
            payment.ModuleBytes.module_bytes = "";

            return payment;
        }
        /// <summary>
        /// Create a new Transfer including the Deploy Arguments
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="toAccount"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeployTransfer NewTransfer(ulong amount, string toAccount, ulong id)
        {
            string amountBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(amount));
            string idBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu64SerializerWithPrefixOption(id));

            var argsTransfer = new List<DeployNamedArg>();
            argsTransfer.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = amountBytes, parsed = amount.ToString() }));
            argsTransfer.Add(new DeployNamedArg("target", new CLValue() { cl_type = CLType.CLTypeEnum.BYTE_ARRAY, bytes = hashSvc.GetAccountHash(toAccount), parsed = toAccount }));
            argsTransfer.Add(new DeployNamedArg("id", new CLValue() { cl_type = CLType.CLTypeEnum.OPTION, bytes = idBytes, parsed = id.ToString() }));

            return new DeployTransfer(argsTransfer);
        }

        /// <summary>
        /// Create a new Delegate including the Deploy Arguments
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="delegatorAccount"></param>
        /// <param name="validatorAccount"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeployStoredContractByHash NewDelegate(ulong amount, string delegatorAccount, string validatorAccount, ulong id)
        {
            string amountBytes = ByteUtil.ByteArrayToHex(TypesSerializer.Getu512SerializerWithLength(amount));

            var argsDelegate = new List<DeployNamedArg>();
            argsDelegate.Add(new DeployNamedArg("delegator", new CLValue() { cl_type = CLType.CLTypeEnum.PublicKey, bytes = delegatorAccount, parsed = delegatorAccount }));
            argsDelegate.Add(new DeployNamedArg("validator", new CLValue() { cl_type = CLType.CLTypeEnum.PublicKey, bytes = validatorAccount, parsed = validatorAccount }));
            argsDelegate.Add(new DeployNamedArg("amount", new CLValue() { cl_type = CLType.CLTypeEnum.U512, bytes = amountBytes, parsed = amount.ToString() }));

            return new DeployStoredContractByHash(argsDelegate);
        }
        #endregion
    }
}
