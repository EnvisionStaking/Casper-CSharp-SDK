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
                var result = casperClient.RpcService.GetStateRootHash();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

        }

    }
}


