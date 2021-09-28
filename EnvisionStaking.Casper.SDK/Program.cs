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

                CasperClient casperClient = new CasperClient(rpcUrl);      

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


