using EnvisionStaking.Casper.SDK.Services;

namespace EnvisionStaking.Casper.SDK
{
    public class CasperClient
    {
        public readonly string url;
       
        public CasperClient(string rpcUrl)
        {
            url = rpcUrl;
            SigningService = new SigningService();
            RpcService = new RpcService(rpcUrl);
            HashService = new HashService();
            DeployService = new DeployService(RpcService, HashService);
        }

        public SigningService SigningService { get; }

        public RpcService RpcService { get; }

        public HashService HashService { get; }
        public DeployService DeployService  { get; }

    }
}
