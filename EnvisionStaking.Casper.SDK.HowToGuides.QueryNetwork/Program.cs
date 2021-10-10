using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using EnvisionStaking.Casper.SDK;

namespace EnvisionStaking.Casper.SDK.HowToGuides.Transfer
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

                //Account to Query
                string account = "01c4328cde0ce19e18e8bf61cb0f62af889b928a1b958ce69c401e21b07fb7acd6";
                //Deploy to Query
                string deployHash = "33a37dd39e5724ac707ecbc8cf9a142761bb14ef73dfe40425eb9d303766650d";
                //Account Hash
                string accountHash = "account-hash-0f57db4471e7ace70bc45c23ee87d287d0eabfe1090b813e3e7cb73657efce8e";
                //Transfer hash
                string transferHash = "transfer-8083a53dd4d911eabefb83004eab3537aee8d8b9a340dced9826f1397b3b0bee";

                CasperClient client = new CasperClient(rpcUrl);

                //Get account info
                var accountInfoResult = client.RpcService.GetAccountInfo(account);

                //Get account hash for Account
                var accountHashResult = client.RpcService.GetAccountHash(account);

                //Get the account balance of a specific account
                var accountBalanceResult = client.RpcService.GetAccountBalance(account);

                //Get the deploy
                var deployResult = client.RpcService.GetDeploy(deployHash);

                //Get Node Peers
                var nodePeersResult = client.RpcService.GetNodePeers();

                //Get Node Peers
                var stateRootHashResult = client.RpcService.GetStateRootHash();

                //Get last block
                var lastBlockResult = client.RpcService.GetBlockLast();

                //Get auction info
                var auctionInfoResult = client.RpcService.GetAuctionInfo();

                //Get node status
                var nodeStatusResult = client.RpcService.GetNodeStatus();

                //Get State Item for Account hash
                var stateItemAccountResult = client.RpcService.GetStateItem(accountHash);

                //Get State Item for Deploy hash
                var stateItemTransferResult = client.RpcService.GetStateItem(transferHash);

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
