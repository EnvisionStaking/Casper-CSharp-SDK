using EnvisionStaking.Casper.SDK.Model.Sse;
using EnvisionStaking.Casper.SDK.Services;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnvisionStaking.Casper.SDK
{
    class Program
    {      
        static async Task Main(string[] args)
        {
            try
            {
                string rpcUrl = "https://node-clarity-mainnet.make.services/rpc";
                string metricsUrl = "http://40.69.22.98:8888/metrics";
                string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";

                CasperClient casperClient = new CasperClient(rpcUrl);

                //var stateRootHashResult = casperClient.GetStateRootHash();
                //var stateRootHashByHashResult = casperClient.GetStateRootHashByBlockHash("eae069dcc4888da536dfc3f33509025a936d14bf09c012cc8073ee0d91e3ce84");
                //var stateRootHashByHeightResult = casperClient.GetStateRootHashByHeight("223873");

                //var getAccountInfoResult = casperClient.GetAccountInfo(accountKey);
                //var getAccountBalanceResult = casperClient.GetAccountBalance(accountKey);
                //var getAccountHashResult = casperClient.GetAccountHash(accountKey);
                //var getAccountMainPurseResult = casperClient.GetAccountMainPurse(accountKey);

                //var auctionInfoResult = casperClient.RpcService.GetAuctionInfo();

                //var getBlockLast = casperClient.GetBlockLast();
                //var getBlockByHeight = casperClient.GetBlockByHeight("222938");
                //var getBlockByHash = casperClient.GetBlockByHash("3566b6cdc30d0d9871cc6b208a7b17acefa1e22107800a098c4cd88e82a6fee2");

                //var getBlockTransfersLast = casperClient.GetBlockTransfersLast();
                //var getBlockTransfersByHeight = casperClient.GetBlockTransfersByHeight("223760");
                //var getBlockTransfersByHash = casperClient.GetBlockTransfersByHash("ef1dbf8fd1653afbf7163006be9e7a2d172790e44db67c0919c10c2a38144150");

                //var getDeploy = casperClient.GetDeploy("bc4b4fa65eb906e6d4e383adacb8e8ba14b768029a535b5b1381b2b47847c32e");

                //Not tested
                //var getEraInfoLast = casperClient.GetEraInfoLast();
                //var getEraInfoByHeight = casperClient.GetEraInfoByHeight("223692");
                //var getEraInfoByHeightLoop = casperClient.GetEraInfoByHeight("200000");
                //for (int i=200000; i<201000;i++)
                //{
                //    var getEraInfoByHeight = casperClient.GetEraInfoByHeight(i.ToString());
                //    if(getEraInfoByHeight.result.era_summary!=null)
                //    {
                //        break;
                //    }
                //}
                //var getEraInfoByHash = casperClient.GetEraInfoByHash("d0b3f52c02f8dfee84bdc5cb2e00d803d2dc36f3ed325cf556412baef6ead722");

                //var getNodeMetrics = casperClient.GetNodeMetrics(metricsUrl);

                //var getNodeStatus = casperClient.GetNodeStatus();

                //var getRPCSchema = casperClient.GetRPCShema();

                //var getStateItemAccount = casperClient.GetStateItem("account-hash-18afc5167d3e815c80cd0742f615dddfebee2a2f5e8285015b23b8d134292a5c");
                //var getStateItemDeploy = casperClient.GetStateItem("deploy-1498ee265159d1969ef5c404048358fbac7354909c03871d97011558eaf0a121");
                //var getStateItemCLVAlue = casperClient.GetStateItem("uref-fdb1ba9c73573817ff05674e8d488a2eea95fd8d22942c250035e1063c899fa8-007");
                //var getStateItemTransfer = casperClient.GetStateItem("transfer-8083a53dd4d911eabefb83004eab3537aee8d8b9a340dced9826f1397b3b0bee");
                //var getStateItemContract = casperClient.GetStateItem("hash-7cc1b1db4e08bbfe7bacf8e1ad828a5d9bcccbb33e55d322808c3a88da53213a");
                //var getStateItemContractPackage = casperClient.GetStateItem("hash-4475016098705466254edd18d267a9dad43e341d4dafadb507d0fe3cf2d4a74b");
                //var getStateItemContractWasm = casperClient.GetStateItem("hash-41c6f5bad412de7e16af7943b0c751f0dc9152a337c8b024313057dd8d707f99");
                //var getStateItemBid = casperClient.RpcService.GetStateItem("bid-0f57db4471e7ace70bc45c23ee87d287d0eabfe1090b813e3e7cb73657efce8e");
                //var getStateItemWithdraw = casperClient.GetStateItem("withdraw-6e999553ae78baf7799c6a10136888509d3f54cd896b0fe67376f45474180337");
                //TODO Test EraInfo
                //var getStateItemEraInfo = casperClient.GetStateItem("6e999553ae78baf7799c6a10136888509d3f54cd896b0fe67376f45474180337");

                //var getNodePeers = casperClient.GetNodePeers();

                //var hash = casperClient.HashService.GetAccountHash("01c4328cde0ce19e18e8bf61cb0f62af889b928a1b958ce69c401e21b07fb7acd6");

                //var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

                //var keyPair = casperClient.SigningService.GenerateKeyPair();

                //var privateKeyPem = casperClient.SigningService.ConvertPrivateKeyToPem(keyPair.Private);
                //var publicKeyPem = casperClient.SigningService.ConvertPublicKeyToPem(keyPair.Public);

                //var message = Encoding.UTF8.GetBytes("Bob Loblaw");
                //var messageSigned = Encoding.UTF8.GetBytes("Bob Loblaw");

                //var message = File.ReadAllBytes(@"keys\Test.txt");
                //var signed = casperClient.SigningService.GetSignature(keyPair.Private, message);

                //File.WriteAllBytes(@"keys\TestSigned.txt", signed);
                //message = File.ReadAllBytes(@"keys\Test.txt");
                //var signatureVerified = casperClient.SigningService.VerifySignature(keyPair.Public, message, signed);

                //var getNextBlockAsyncTask = casperClient.RpcService.GetNextBlockAsync();
                //var awaitNBlockAsyncTask = casperClient.RpcService.AwaitNBlockAsync(1);
                //var awaitUntilNBlockAsyncTask = casperClient.RpcService.AwaitUntilNBlockAsync(232275);

                //var getNextEraAsyncTask = casperClient.RpcService.GetNextEraAsync();

                //var getNextBlockAsyncTaskResult = await getNextBlockAsyncTask;

                //var awaitNBlockAsyncTaskResult = await awaitNBlockAsyncTask;
                //var awaitUntilNBlockAsyncTaskResult = await awaitUntilNBlockAsyncTask;

                //var getNextEraAsyncTaskResult = await getNextEraAsyncTask;

                var sse =  new SseService("http://195.201.142.76:9999", Enums.SseType.deploys);
                sse.ApiVersionUpdated += Sse_ApiVersionUpdated;
                sse.DeployProcessed += Sse_DeployProcessed;
                sse.BlockAdded += Sse_BlockAdded;
                sse.FinalitySignature += Sse_FinalitySignature;
                sse.DeployProcessed += Sse_DeployProcessed1;
                Thread.Sleep(600000);
                string test = "";


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

        }

        private static void Sse_DeployProcessed1(object sender, SseDeployProcessed e)
        {
            Console.WriteLine(e);
        }

        private static void Sse_FinalitySignature(object sender, SseFinalitySignature e)
        {
            Console.WriteLine(e);
        }

        private static void Sse_BlockAdded(object sender, SseBlockAdded e)
        {
            Console.WriteLine(e);
        }

        private static void Sse_DeployProcessed(object sender, SseDeployProcessed e)
        {
            Console.WriteLine(e);
        }

        static void Sse_ApiVersionUpdated(object sender, SseApiVersion e)
        {
            Console.WriteLine(e);
        }
    }
}


