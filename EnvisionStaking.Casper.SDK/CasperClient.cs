using EnvisionStaking.Casper.SDK.Services;

namespace EnvisionStaking.Casper.SDK
{
    public class CasperClient
    {
        public readonly string url;
        /// <summary>
        /// The Casper client is the main class, in which you can interact with Casper Network. Through the client you can use the SigningService, RpcService, HashService, DeployService and SseService
        /// </summary>
        /// <param name="rpcUrl">The RPC URL of a Casper Network Node</param>
        public CasperClient(string rpcUrl)
        {
            url = rpcUrl;
            SigningService = new SigningService();
            RpcService = new RpcService(rpcUrl);
            HashService = new HashService();
            DeployService = new DeployService(RpcService, HashService, SigningService);
        }
        /// <summary>
        /// Signing Service
        /// </summary>
        public SigningService SigningService { get; }

        /// <summary>
        /// The RPC service uses Remote Procedure Calls (RPC) in Casper Network nodes. RPC enables the integartion with Capser Network.
        /// </summary>
        public RpcService RpcService { get; }

        /// <summary>
        /// Hash Service
        /// </summary>
        public HashService HashService { get; }

        /// <summary>
        /// Deploy Service
        /// </summary>
        public DeployService DeployService  { get; }

        /// <summary>
        /// SSE Service
        /// </summary>
        public SseService SseService { get; set; }

    }
}
