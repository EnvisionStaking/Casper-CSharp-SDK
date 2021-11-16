using EnvisionStaking.Casper.SDK.Model.AccountBalance;
using EnvisionStaking.Casper.SDK.Model.AccountInfo;
using EnvisionStaking.Casper.SDK.Model.AuctionInfo;
using EnvisionStaking.Casper.SDK.Model.Base;
using EnvisionStaking.Casper.SDK.Model.Block;
using EnvisionStaking.Casper.SDK.Model.BlockTransfers;
using EnvisionStaking.Casper.SDK.Model.Common;
using EnvisionStaking.Casper.SDK.Model.DeployObject;
using EnvisionStaking.Casper.SDK.Model.Era;
using EnvisionStaking.Casper.SDK.Model.NodePeers;
using EnvisionStaking.Casper.SDK.Model.NodeStatus;
using EnvisionStaking.Casper.SDK.Model.StateItem;
using EnvisionStaking.Casper.SDK.Model.StateRootHash;
using EnvisionStaking.Casper.SDK.Model.Validator;
using EnvisionStaking.Casper.SDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Result = EnvisionStaking.Casper.SDK.Model.Base.Result;

namespace EnvisionStaking.Casper.SDK.Services
{
    /// <summary>
    /// The RPC service uses Remote Procedure Calls (RPC) in Casper Network nodes. RPC enables the integartion with Capser Network.
    /// </summary>
    public class RpcService
    {
        private const int BLOCKDELAY = 5000;
        private const int ERADELAY = 60000;
        private const int DEPLOYDELAY = 5000;
        public RpcService(string rpcUrl, string jsonRpcVersion = "2.0", string jsonRpcId = "0")
        {
            JsonRpcVersion = jsonRpcVersion;
            RpCUrl = rpcUrl;
            JsonRpcId = jsonRpcId;
        }

        public string JsonRpcId { get; set; }
        public string JsonRpcVersion { get; set; }
        public string RpCUrl { get; set; }

        #region StateRootHash
        /// <summary>
        /// This method returns the latest state root hash
        /// </summary>
        /// <returns></returns>
        public StateRootHashResult GetStateRootHash()
        {

            StateRootHashRequest request = new StateRootHashRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateRootHashRequest, StateRootHashResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns a state root hash at a given Block by using the block hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public StateRootHashResult GetStateRootHashByBlockHash(string hash)
        {
            StateRootHashRequest request = new StateRootHashRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateRootHashRequest, StateRootHashResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns a state root hash at a given Block by using the block height
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public StateRootHashResult GetStateRootHashByHeight(string height)
        {
            StateRootHashRequest request = new StateRootHashRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateRootHashRequest, StateRootHashResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Account
        /// <summary>
        /// This method returns an Account from the network
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public AccountInfoResult GetAccountInfo(string key)
        {
            AccountInfoRequest request = new AccountInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.public_key = key; ;

            return RpcClient<AccountInfoRequest, AccountInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns the Account Hash of an Account from the network
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetAccountHash(string key)
        {
            AccountInfoRequest request = new AccountInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.public_key = key; ;

            AccountInfoResult accountInforResult = RpcClient<AccountInfoRequest, AccountInfoResult>(RpCUrl, request, HttpMethod.Post);

            return accountInforResult.result.account.account_hash;
        }
        /// <summary>
        /// This method returns the Main Purse of an Account from the network
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetAccountMainPurse(string key)
        {
            AccountInfoRequest request = new AccountInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.public_key = key; ;

            AccountInfoResult accountInforResult = RpcClient<AccountInfoRequest, AccountInfoResult>(RpCUrl, request, HttpMethod.Post);

            return accountInforResult.result.account.main_purse;
        }
        /// <summary>
        /// This method returns a purse's balance from the network
        /// </summary>
        /// <param name="mainPurse"></param>
        /// <param name="stateRootHash"></param>
        /// <returns></returns>
        public AccountBalanceResult GetAccountBalance(string mainPurse, string stateRootHash)
        {
            AccountBalanceRequest request = new AccountBalanceRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.purse_uref = mainPurse;
            request.Parameters.state_root_hash = stateRootHash;

            return RpcClient<AccountBalanceRequest, AccountBalanceResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns a purse's balance from the network
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public AccountBalanceResult GetAccountBalance(string key)
        {
            AccountInfoResult acountInfoResult = GetAccountInfo(key);
            StateRootHashResult stateRootHashResult = GetStateRootHash();
            return GetAccountBalance(acountInfoResult.result.account.main_purse, stateRootHashResult.result.state_root_hash);
        }
        #endregion

        #region Auction
        /// <summary>
        /// This method returns the bids and validators as of either a specific block (by height or hash), or the most recently added block
        /// </summary>
        /// <returns></returns>
        public AuctionInfoResult GetAuctionInfo()
        {
            AuctionInfoRequest request = new AuctionInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<AuctionInfoRequest, AuctionInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Block

        #region Synchronous Operations
        /// <summary>
        /// This method returns the latest Block from the network
        /// </summary>
        /// <returns></returns>
        public BlockResult GetBlockLast()
        {
            BlockRequest request = new BlockRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockRequest, BlockResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns a Block from the network for a specific block hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public BlockResult GetBlockByHash(string hash)
        {
            BlockRequest request = new BlockRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockRequest, BlockResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns a Block from the network for a specific block height
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public BlockResult GetBlockByHeight(string height)
        {
            BlockRequest request = new BlockRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockRequest, BlockResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns the latest Block Transfers from the network
        /// </summary>
        /// <returns></returns>
        public BlockTransfersResult GetBlockTransfersLast()
        {
            BlockTransfersRequest request = new BlockTransfersRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockTransfersRequest, BlockTransfersResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns Block Transfers from the network for a specific block hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public BlockTransfersResult GetBlockTransfersByHash(string hash)
        {
            BlockTransfersRequest request = new BlockTransfersRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockTransfersRequest, BlockTransfersResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns Block Transfers from the network for a specific block height
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public BlockTransfersResult GetBlockTransfersByHeight(string height)
        {
            BlockTransfersRequest request = new BlockTransfersRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockTransfersRequest, BlockTransfersResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Asynchronous Operations
        /// <summary>
        /// The async method returns a result once a block is generated in Casper Network
        /// </summary>
        /// <returns></returns>
        public async Task<BlockResult> GetNextBlockAsync()
        {
            var block = GetBlockLast();
            var currentBlockHeight = block.result.block.header.height;

            while (block.result.block.header.height == currentBlockHeight)
            {
                await Task.Delay(BLOCKDELAY);
                block = GetBlockLast();
            }

            return block;
        }
        /// <summary>
        /// The async method returns a result once next N block is generated in Casper Network
        /// </summary>
        /// <param name="nBlock"></param>
        /// <returns></returns>
        public async Task<BlockResult> AwaitNBlockAsync(int nBlock = 1)
        {
            if (nBlock < 1)
            {
                throw new ArgumentOutOfRangeException("The number of Blocks to wait should be equal or more than one");
            }

            var block = GetBlockLast();
            var nextNBlock = block.result.block.header.height + nBlock;

            while (block.result.block.header.height < nextNBlock)
            {
                await Task.Delay(BLOCKDELAY);
                block = GetBlockLast();
            }

            return block;
        }
        /// <summary>
        /// The async method returns a result when a block is generated for a specific height
        /// </summary>
        /// <param name="untilNBlockHeight"></param>
        /// <returns></returns>
        public async Task<BlockResult> AwaitUntilNBlockAsync(int untilNBlockHeight)
        {
            var block = GetBlockLast();

            if (block.result.block.header.height >= untilNBlockHeight)
            {
                throw new ArgumentOutOfRangeException($"The Block Height selected should be bigger than current block height ({block.result.block.header.height})");
            }

            while (block.result.block.header.height < untilNBlockHeight)
            {
                await Task.Delay(BLOCKDELAY);
                block = GetBlockLast();
            }

            return block;
        }
        #endregion

        #endregion

        #region Deploy
        #region Synchronous Operations
        /// <summary>
        /// This method returns a Deploy from the network
        /// </summary>
        /// <param name="deployHash"></param>
        /// <returns></returns>
        public DeployResult GetDeploy(string deployHash)
        {
            DeployRequest request = new DeployRequest(deployHash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            return RpcClient<DeployRequest, DeployResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method deploys Transfer operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployTransferRequest request)
        {

            return RpcClient<PutDeployTransferRequest, PutDeployResult>(RpCUrl, request, HttpMethod.Post);
        }

        /// <summary>
        /// This method deploys StoredContractByHash operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredContractByHashRequest request)
        {

            return RpcClient<PutDeployStoredContractByHashRequest , PutDeployResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method deploys StoredContractByName operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredContractByNameRequest request)
        {

            return RpcClient<PutDeployStoredContractByNameRequest, PutDeployResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method deploys StoredVersionedContractByHash operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredVersionedContractByHashRequest request)
        {

            return RpcClient<PutDeployStoredVersionedContractByHashRequest, PutDeployResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method deploys StoredVersionedContractByName operation. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutDeployResult PutDeploy(PutDeployStoredVersionedContractByNameRequest request)
        {

            return RpcClient<PutDeployStoredVersionedContractByNameRequest, PutDeployResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion
        #region Async Operations
        /// <summary>
        /// The async method returns a result when a Deployment is completed. You can use this async method to wait until Deployment completion.
        /// </summary>
        /// <param name="deployHash"></param>
        /// <returns></returns>
        public async Task<DeployResult> AwaitUntilDeployCompletedAsync(string deployHash)
        {
            var deploy = GetDeploy(deployHash);

            while (deploy.result.execution_results == null || deploy.result.execution_results.Count == 0)
            {
                await Task.Delay(DEPLOYDELAY);
                deploy = GetDeploy(deployHash);
            }

            return await Task.FromResult<DeployResult>(deploy);
        }
        #endregion
        #endregion

        #region Era

        #region Synchronous Services
        /// <summary>
        /// This method returns the last EraInfo from the network
        /// </summary>
        /// <returns></returns>
        public EraInfoResult GetEraInfoLast()
        {
            EraInfoRequest request = new EraInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<EraInfoRequest, EraInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns an EraInfo from the network from Era hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public EraInfoResult GetEraInfoByHash(string hash)
        {
            EraInfoRequest request = new EraInfoRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<EraInfoRequest, EraInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        /// <summary>
        /// This method returns an EraInfo from the network
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public EraInfoResult GetEraInfoByHeight(string height)
        {
            EraInfoRequest request = new EraInfoRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<EraInfoRequest, EraInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Asynchronous Services
        /// <summary>
        /// The async method returns a result once an Era is completed in Casper Network. Please note that an Era is generated every two hours
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetNextEraAsync()
        {
            var block = GetBlockLast();
            var currentBlockEraId = block.result.block.header.era_id;

            while (block.result.block.header.era_id == currentBlockEraId)
            {
                await Task.Delay(ERADELAY);
                block = GetBlockLast();
            }

            return block.result.block.header.era_id;
        }
        /// <summary>
        /// The async method returns a result once next N Era is completed in Casper Network. Please note that an Era is generated every two hours
        /// </summary>
        /// <param name="nEra"></param>
        /// <returns></returns>
        public async Task<int> AwaitNEraAsync(int nEra = 1)
        {
            if (nEra < 1)
            {
                throw new ArgumentOutOfRangeException("The number of Eras to wait should be equal or more than one");
            }
            var block = GetBlockLast();

            var nextNEra = block.result.block.header.era_id + nEra;

            while (block.result.block.header.era_id < nextNEra)
            {
                await Task.Delay(ERADELAY);
                block = GetBlockLast();
            }

            return block.result.block.header.era_id;
        }

        /// <summary>
        /// The async method returns a result when an Era is completed with a specific id. Please note that an Era is generated every two hours
        /// </summary>
        /// <param name="untilNEraId"></param>
        /// <returns></returns>
        public async Task<int> AwaitUntilNEraAsync(int untilNEraId)
        {
            var block = GetBlockLast();

            if (block.result.block.header.era_id >= untilNEraId)
            {
                throw new ArgumentOutOfRangeException($"The Era Id selected should be bigger than current Era ({block.result.block.header.era_id})");
            }

            while (block.result.block.header.era_id < untilNEraId)
            {
                await Task.Delay(ERADELAY);
                block = GetBlockLast();
            }

            return block.result.block.header.era_id;
        }
        #endregion

        #endregion

        #region Metrics
        /// <summary>
        /// This method returns the Node Metrics for a specifict network node
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetNodeMetrics(string url)
        {
            return GetMetricsClient(url);
        }

        #endregion

        #region Node
        /// <summary>
        /// This method returns the current Node Status for a specific network node
        /// </summary>
        /// <returns></returns>
        public NodeStatusResult GetNodeStatus()
        {
            RPCSchemaRequest request = new RPCSchemaRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<RPCSchemaRequest, NodeStatusResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region RPCSchema
        /// <summary>
        /// This method returns the OpenRPC Schema. The schema describes the JSON-RPC API of a node on the Casper network.
        /// </summary>
        /// <returns></returns>
        public string GetRPCShema()
        {
            RPCSchemaRequest request = new RPCSchemaRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<RPCSchemaRequest>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region StateItem
        /// <summary>
        /// This method returns a stored value from the network. Stored values can be Account, Deploy, CLVAlue, Transfer, Contract, ContractPackage, ContractWasm, Bid, Withdraw, EraInfo etc.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public StateItemResult GetStateItem(string key)
        {
            var stateRootHash = GetStateRootHash();

            StateItemRequest request = new StateItemRequest(stateRootHash.result.state_root_hash, key);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateItemRequest, StateItemResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region NodePeers
        /// <summary>
        /// This method returns a list of peers connected to the node
        /// </summary>
        /// <returns></returns>
        public NodePeersResult GetNodePeers()
        {
            NodePeersRequest request = new NodePeersRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<NodePeersRequest, NodePeersResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Validators
        /// <summary>
        /// This method returns the information of Validator changes
        /// </summary>
        /// <returns></returns>
        public GetValidatorChangesResult GetValidatorChanges()
        {
            GetValidatorChangesRequest request = new GetValidatorChangesRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<GetValidatorChangesRequest, GetValidatorChangesResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Http Clients
        /// <summary>
        /// RPC client
        /// </summary>
        /// <typeparam name="T">Request</typeparam>
        /// <typeparam name="K">Response</typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        public K RpcClient<T, K>(string url, T request, HttpMethod httpMethod)
        {
            string result = RpcClient<T>(url, request, httpMethod);
            var temp = JsonConvert.DeserializeObject<K>(result, JsonUtil.JsonSerializerSettings());
            var tempResultObject = temp as Result;
            if (tempResultObject.error != null)
            {
                HandleRpcException(tempResultObject.error);
            }
            return temp;
        }
        /// <summary>
        /// RPC client 
        /// </summary>
        /// <typeparam name="T">Request</typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        public string RpcClient<T>(string url, T request, HttpMethod httpMethod)
        {
            string jsonString = JsonConvert.SerializeObject(request, JsonUtil.JsonSerializerSettings());
            var data = new StringContent(jsonString);
            using (var httpClient = new HttpClient())
            {

                HttpRequestMessage msg = new HttpRequestMessage(httpMethod, url);

                msg.Content = new StringContent(jsonString);
                msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = httpClient.SendAsync(msg).Result;

                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
        /// <summary>
        /// Get the metrics client
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string GetMetricsClient(string Url)
        {
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, Url);

                HttpResponseMessage response = httpClient.SendAsync(msg).Result;
                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
        #endregion

        /// <summary>
        /// Handles RPC Exception
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private string HandleRpcException(Error error)
        {
            throw new ApplicationException(error.message);
        }
    }
}
