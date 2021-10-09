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
//The constructor parameter (rpcUrl) is the address of a Connected Peer in Casper Network.
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

#### GetNodePeers
This method returns a list of peers connected to the node
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetNodePeers();
```
#### GetEraInfoLast
This method returns the last EraInfo from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetEraInfoLast();
```
#### GetEraInfoByHash
This method returns an EraInfo from the network from Era hash
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHash = "d0b3f52c02f8dfee84bdc5cb2e00d803d2dc36f3ed325cf556412baef6ead722";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetEraInfoByHash(blockHash);
```
#### GetEraInfoByHeight
This method returns an EraInfo from the network
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHeight = "223692";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = casperClient.RpcService.GetEraInfoByHeight(blockHeight);
```

### Common Deploy Operations
These are the common operations available on casper Network. 
With these operations available in the SDK you can transfer, delegate and undelegate tokens.
The following operations are defined as ExecutableDeployItems.
> For further information please reference Casper Network [Documentation](https://docs.casperlabs.io/en/latest/implementation/serialization-standard.html#payment-session)
#### Transfer Tokens
This deploys a Transfer in Casper Network.
The operation uses the Transfer ExecutableDeployItem
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHeight = "223692";

CasperClient casperClient = new CasperClient(rpcUrl);

/// <param name="amount">The amount to transfer in CSPR tokens</param>
/// <param name="fromAccount">From the Account Key to transfer tokens</param>
/// <param name="toAccount">To the Account Key to transfer tokens</param>
/// <param name="id">Id of ttransfer</param>
/// <param name="publicKeyLocation">Public Key location of pem file located on disk</param>
/// <param name="privateKeyLocation">Secret Key location of pem file located on disk</param>
/// <param name="signAlgorithm">The signature algorith. You can use either ed25519 or secp256k1 algorithm. The algorithm should macth the keys provided</param>
var result = casperClient.DeployService.Transfer(amount, fromAccount, toAccountKey, id, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);
```
#### Delegate Tokens
This method Delegate tokens to a Validator
This operation uses the ExecutableDeployItem StoredContractByHash
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHeight = "223692";

CasperClient casperClient = new CasperClient(rpcUrl);

/// <param name="amount">The amount to transfer in CSPR tokens</param>
/// <param name="fromAccount">Delegator Account Key</param>
/// <param name="toAccount">validator Account Key</param>
/// <param name="id">Id of ttransfer</param>
/// <param name="publicKeyLocation">Public Key location of pem file located on disk</param>
/// <param name="privateKeyLocation">Secret Key location of pem file located on disk</param>
/// <param name="signAlgorithm">The signature algorith. You can use either ed25519 or secp256k1 algorithm. The algorithm should macth the keys provided</param>
var result = casperClient.DeployService.Delegate(amount, fromAccountKey, toAccountKey, id, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);
```
#### Undelegate Tokens
This method Undelegate tokens from a Validator
This operation uses the ExecutableDeployItem StoredContractByHash
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
string blockHeight = "223692";

CasperClient casperClient = new CasperClient(rpcUrl);

/// <param name="amount">The amount to transfer in CSPR tokens</param>
/// <param name="fromAccount">Delegator Account Key</param>
/// <param name="toAccount">Validator Account Key</param>
/// <param name="id">Id of ttransfer</param>
/// <param name="publicKeyLocation">Public Key location of pem file located on disk</param>
/// <param name="privateKeyLocation">Secret Key location of pem file located on disk</param>
/// <param name="signAlgorithm">The signature algorith. You can use either ed25519 or secp256k1 algorithm. The algorithm should macth the keys provided</param>
var result = casperClient.DeployService.Undelegate(amount, fromAccountKey, toAccountKey, id, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);
```
### Other Deploy Operations
Many other Deploy operations are available on Casper Network. 
You have the freedom to construct your own request and deploy the Contract by using the SDK methods following.
#### Put Deploy Stored Contract By Hash
This method deploys StoredContractByHash operation.
The Delegate and Undelegate methods described above uses the StoredContractByHash operation.
This operation uses the ExecutableDeployItem StoredContractByHash.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
CasperClient casperClient = new CasperClient(rpcUrl);

//Costruct the Deploy executable item and set the Object parameters 
PutDeployStoredContractByHashRequest request = new PutDeployStoredContractByHashRequest();
PutDeployResult result = casperClient.RpcService.PutDeploy(request);
```
> For a complete example please reference the How To Guides section.
 #### Put Deploy Stored Contract By Name
This method deploys StoredContractByName operation.
This operation uses the ExecutableDeployItem StoredContractByName.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
CasperClient casperClient = new CasperClient(rpcUrl);

//Costruct the Deploy executable item and set the Object parameters 
PutDeployStoredContractByNameRequest request = new PutDeployStoredContractByNameRequest();
PutDeployResult result = casperClient.RpcService.PutDeploy(request);
```
#### Put Deploy Stored Versioned Contract By Hash
This method deploys StoredVersionedContractByHash operation.
This operation uses the ExecutableDeployItem StoredVersionedContractByHash.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
CasperClient casperClient = new CasperClient(rpcUrl);

//Costruct the Deploy executable item and set the Object parameters 
PutDeployStoredVersionedContractByHashRequest request = new PutDeployStoredVersionedContractByHashRequest();
PutDeployResult result = casperClient.RpcService.PutDeploy(request);
```
#### Put Deploy Stored Versioned Contract By Name
This method deploys StoredVersionedContractByName operation.
This operation uses the ExecutableDeployItem StoredVersionedContractByName.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
CasperClient casperClient = new CasperClient(rpcUrl);

//Costruct the Deploy executable item and set the Object parameters 
PutDeployStoredVersionedContractByNameRequest request = new PutDeployStoredVersionedContractByNameRequest();
PutDeployResult result = casperClient.RpcService.PutDeploy(request);
```
#### Put Deploy Transfer
This method deploys Transfer operation.
The Transfer method described above uses the Transfer operation.
This operation uses the ExecutableDeployItem Transfer.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
CasperClient casperClient = new CasperClient(rpcUrl);

//Costruct the Deploy executable item and set the Object parameters 
PutDeployTransferRequest request = new PutDeployTransferRequest();
PutDeployResult result = casperClient.RpcService.PutDeploy(request);
```
> For a complete example please reference the How To Guides section.

### Asynchronous Operations
You can use the following asynchronous operations.
#### Get Next Block Async
This async method returns a result once a block is generated in Casper Network

```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);
var result = await casperClient.RpcService.GetNextBlockAsync();
```
#### Get Next N Block Async
This async method returns a result once next N block is generated in Casper Network

```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);

//The result will be completed after the generation of 2 blocks from the time method triggered.
var result = await casperClient.RpcService.AwaitNBlockAsync(2);
```
#### Await Until Height Block Generated Async
This async method returns a result when a block is generated for a specific height

```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);

//Get current block Height
var currentBlock = casperClient.RpcService.GetBlockLast();
//After getting the current block height, add 2 blocks and wait until block generated with that specific height
var result = await casperClient.RpcService.AwaitUntilNBlockAsync(currentBlock.result.block.header.height+2);
```
#### Get Next Era Async
This async method returns a result once an Era is completed in Casper Network
Please note that an Era is generated every two hours
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

 CasperClient casperClient = new CasperClient(rpcUrl);
var result = await casperClient.RpcService.GetNextEraAsync();
```
#### Get Next N Era Async
This async method returns a result once next N Era is completed in Casper Network
Please note that an Era is generated every two hours
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);

//The result will be completed after the completion of 2 Eras from the time method triggered.
var result = await casperClient.RpcService.AwaitNEraAsync(1);
```
#### Await Until Era with Id Completed Async
This async method returns a result when an Era is completed with a specific id.
Please note that an Era is generated every two hours
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";

CasperClient casperClient = new CasperClient(rpcUrl);

//Get current Era from last block
var currentBlock = casperClient.RpcService.GetBlockLast();
//After getting the current Era, add 1 Era and wait until Era completed with that specific id
var result = await casperClient.RpcService.AwaitUntilNEraAsync(currentBlock.result.block.header.era_id + 1);
```
#### Await Until Deploy is Completed Async
This async method returns a result when a Deployment is completed.
You can use this async method to wait until  Deployment completion.
```C#
string rpcUrl = "http://{NodeIp}:{7777}/rpc";
var deployHash = "b96bc0f44dd79c6793d16c52e53760004367c8400de0eb17e46edda75289a856";

CasperClient casperClient = new CasperClient(rpcUrl);
var deployResult = await casperClient.RpcService.AwaitUntilDeployCompletedAsync(deployHash);
```

### Event Driven Operations
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

