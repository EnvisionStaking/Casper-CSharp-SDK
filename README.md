# Casper C# SDK

Our contribution towards the global adoption of the Casper Network.

## Getting Started
### Casper Client
The Casper client is the main class, in which you can interact with Casper Network. 

The following services are available:
* RPC Service
* SSE Service
* Hash Service
* Signing Service

You can instantiate the Casper client as shown below
```C#
//The constructor parameter(rpcUrl) is the address of a Connected Peer in Casper Network.
//For RPC calls please use port 7777
//Set the Node Ip and Port, i.e http://54.183.43.215:7777/rpc
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
CasperClient casperClient = new CasperClient(rpcUrl);
```

> You cand find the available Connected Peers [here](https://cspr.live/tools/peers)

## Remote Procedure Calls Service
The RPC service uses Remote Procedure Calls (RPC) in Casper Network nodes. 
RPC enables the integartion with Capser Network.
The SDK available methods utilizing the RPC protocol in Casper Network are:
### Quering Casper Network
#### GetStateRootHash
This method returns the latest state root hash
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetStateRootHash();
```

#### GetStateRootHashByBlockHash
This method returns a state root hash at a given Block by using the block hash
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHash = "eae069dcc4888da536dfc3f33509025a936d14bf09c012cc8073ee0d91e3ce84";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetStateRootHashByBlockHash(blockHash);
```
#### GetStateRootHashByHeight
This method returns a state root hash at a given Block by using the block height
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHeight = "223873";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetStateRootHashByHeight(blockHeight);
```
#### GetAccountInfo
This method returns an Account from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetAccountInfo(accountKey);
```
#### GetAccountHash
This method returns the Account Hash of an Account from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetAccountHash(accountKey);
```
#### GetAccountMainPurse
This method returns the Main Purse of an Account from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetAccountMainPurse(accountKey);
```
#### GetAccountBalance
This method returns a purse's balance from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetAccountBalance(accountKey);
```
#### GetAuctionInfo
This method returns the bids and validators as of either a specific block (by height or hash), or the most recently added block
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetAuctionInfo();
```
#### GetBlockLast
This method returns the latest Block from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetBlockLast();
```
#### GetBlockByHash
This method returns a Block from the network for a specific block hash
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHash = "3566b6cdc30d0d9871cc6b208a7b17acefa1e22107800a098c4cd88e82a6fee2";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetBlockByHash(blockHash);
```
#### GetBlockByHeight
This method returns a Block from the network for a specific block height
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHeight = "222938";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetBlockByHeight(blockHeight);
```
#### GetBlockTransfersLast
This method returns the latest Block Transfers from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetBlockTransfersLast();
```
#### GetBlockTransfersByHash
This method returns Block Transfers from the network for a specific block hash
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHash = "3566b6cdc30d0d9871cc6b208a7b17acefa1e22107800a098c4cd88e82a6fee2";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetBlockByHash(blockHash);
```
#### GetBlockTransfersByHeight
This method returns Block Transfers from the network for a specific block height
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHeight = "222938";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetBlockTransfersByHeight(blockHeight);
```
#### GetDeploy
This method returns a Deploy from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string deployHash = "bc4b4fa65eb906e6d4e383adacb8e8ba14b768029a535b5b1381b2b47847c32e";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetDeploy(deployHash);
```
#### GetNodeMetrics
This method returns the Node Metrics for a specifict network node
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
//For Metric calls please use port 8888
string metricsUrl = "http://{NodeIp}:{8888}/metrics";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetNodeMetrics(metricsUrl);
```
#### GetNodeStatus
This method returns the current Node Status for a specific network node
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetNodeStatus();
```
#### GetShema
This method returns the OpenRPC Schema. The schema describes the JSON-RPC API of a node on the Casper network.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetRPCShema();
```
#### GetStateItem
This method returns a stored value from the network. Stored values can be Account, Deploy, CLVAlue, Transfer, Contract, ContractPackage, ContractWasm, Bid, Withdraw, EraInfo etc.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string hash = "account-hash-18afc5167d3e815c80cd0742f615dddfebee2a2f5e8285015b23b8d134292a5c";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetStateItem(hash);
```

> ##### Stored Value examples
> * For Account you can use hash -> "account-hash-18afc5167d3e815c80cd0742f615dddfebee2a2f5e8285015b23b8d134292a5c"
> * For Deploy you can use hash -> "deploy-bc4b4fa65eb906e6d4e383adacb8e8ba14b768029a535b5b1381b2b47847c32e"
> * For CLVAlue you can use hash -> "uref-fdb1ba9c73573817ff05674e8d488a2eea95fd8d22942c250035e1063c899fa8-007"
> * For Transfer you can use hash -> "transfer-8083a53dd4d911eabefb83004eab3537aee8d8b9a340dced9826f1397b3b0bee"
> * For Contract you can use hash -> "hash-7cc1b1db4e08bbfe7bacf8e1ad828a5d9bcccbb33e55d322808c3a88da53213a"
> * For ContractPackage you can use hash -> "hash-4475016098705466254edd18d267a9dad43e341d4dafadb507d0fe3cf2d4a74b"
> * For ContractWasm you can use hash -> "hash-41c6f5bad412de7e16af7943b0c751f0dc9152a337c8b024313057dd8d707f99"
> * For Bid you can use hash -> "bid-0f57db4471e7ace70bc45c23ee87d287d0eabfe1090b813e3e7cb73657efce8e"
> * For Withdraw you can use hash -> "withdraw-6e999553ae78baf7799c6a10136888509d3f54cd896b0fe67376f45474180337"
> * For Balance you can use hash -> "balance-15afef2c401a62397cd7a91a7d1d077cb8c71f2ec9a75449d1cd32658f9c3806"
> * 
#### GetNodePeers
This method returns a list of peers connected to the node
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetNodePeers();
```

* GetEraInfoLast
* GetEraInfoByHash
* GetEraInfoByHeight
#### Deploy Operations
* Transfer
* Delegate
* Undelegate
#### Asynchronous Operations
* GetNextBlockAsync
* AwaitNBlockAsync
* AwaitUntilDeployCompleted
* AwaitUntilNBlockAsync
* GetNextEraAsync
* AwaitNEraAsync
* AwaitUntilNEraAsync
* 
### Server-Sent Events Service
Asynchronous Operations
* ApiVersionUpdated
* BlockAdded
* DeployProcessed
* Fault
* Step
* DeployAccepted
* FinalitySignature

#### Hash Service
* GetAccountHash
* GetHashToHex
* GetHashToBinary
* 
#### Signing Service
* GetKeyPairFromFile
* GetKeyPair
* GenerateKeyPair
* GetSignature
* VerifySignature
* ConvertPrivateKeyToPemAndSaveToDisk
* ConvertPublicKeyToPemAndSaveToDisk
* Signing Service - secp256k1  -> GetKeyPairFromFile


## How To Guides

### How to query Casper Network 
### How to get events on Casper Network
### How to make a transfer
### How to Delegate Tokens
### How to Undelegate Tokens

