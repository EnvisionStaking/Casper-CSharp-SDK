using EnvisionStaking.Casper.SDK.Model.Common;
using EnvisionStaking.Casper.SDK.Model.DeployObject;
using EnvisionStaking.Casper.SDK.Utils;
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

        public void MakeDeploy(float amount, string fromAccount, int id)
        {
            //PutDeployParameters deploy = new PutDeployParameters();

            //deploy.hash = "bce3326a8bc2104e0acafde7f7bb154aa258265e563fb37b3386220942bdb368";
            //deploy.header.account = fromAccount;
            //deploy.header.timestamp = DateTime.Now;
            //deploy.header.ttl = "30m";
            //deploy.header.gas_price = 1;
            //deploy.header.body_hash = "418c521b564a606b0de4b5bfc572c0b93e4d7e6d1a20abb5d4d957d239dd9d9b";
            //deploy.header.dependencies = new List<string>();
            //deploy.header.chain_name = "casper";

            //deploy.
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
