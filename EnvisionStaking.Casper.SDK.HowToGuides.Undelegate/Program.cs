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

                //Amount to Undelegate in CSPR tokens
                double amountToUndelegate = 10;
                //The account to undelegate tokens
                string delegateAccount = "01da19d95aae08da9df0c3a7ba8fbb368af4fb99e7f522b6471963473295955031";
                //The validator account
                string validatorAccount = "01c4328cde0ce19e18e8bf61cb0f62af889b928a1b958ce69c401e21b07fb7acd6";
                //The id of the Undelegate
                ulong id = 1;
                //The public key pem file location in disk. This key should match the sender account
                string publicKeyLocation = @"C:\tmp\Keys\public_key.pem";
                //The private key pem file location in disk. This key should match the sender account
                string privateKeyLocation = @"C:\tmp\Keys\secret_key.pem";

                CasperClient client = new CasperClient(rpcUrl);
                //Deploy the Undelegate
                var transferResult = client.DeployService.Undelegate(amountToUndelegate, delegateAccount, validatorAccount, id, publicKeyLocation, privateKeyLocation, Enums.SignAlgorithmEnum.ed25519);

                Console.WriteLine($"Delegate Executed, Deploy Hash: {transferResult.result.deploy_hash}");
                //Wait until undelegation is completed. This may take few seconds\minutes
                var deployResult = await client.RpcService.AwaitUntilDeployCompletedAsync(transferResult.result.deploy_hash);

                if (deployResult.result.execution_results[0].result.Success != null)
                {
                    Console.WriteLine($"Deploy Undelegate Completed Succefully");
                    Console.WriteLine($"Json Result");
                    Console.WriteLine(JsonConvert.SerializeObject(deployResult));
                }
                else
                {
                    Console.WriteLine($"Deploy Undelegate Failed");
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
    }
}
