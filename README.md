# Development Status

##Completed Tasks - Unit Tests Completed -Regression Test pending
###RPC Service Synchronous Operations
* RPC Service -> GetStateRootHash
* RPC Service -> GetStateRootHashByBlockHash
* RPC Service -> GetStateRootHashByHeight
* RPC Service -> GetAccountInfo
* RPC Service -> GetAccountHash
* RPC Service -> GetAccountMainPurse
* RPC Service -> GetAccountBalance
* RPC Service -> GetAuctionInfo
* RPC Service -> GetBlockLast
* RPC Service -> GetBlockByHash
* RPC Service -> GetBlockByHeight
* RPC Service -> GetBlockTransfersLast
* RPC Service -> GetBlockTransfersByHash
* RPC Service -> GetBlockTransfersByHeight
* RPC Service -> GetDeploy
* RPC Service -> GetNodeMetrics
* RPC Service -> GetNodeStatus
* RPC Service -> GetShema
* RPC Service -> GetStateItem
* RPC Service -> GetNodePeers
###RPC Service Asynchronous Operations
* RPC Service - Async -> GetNextBlockAsync
* RPC Service - Async -> AwaitNBlockAsync
* RPC Service - Async -> AwaitUntilNBlockAsync
* RPC Service - Async -> GetNextEraAsync
* RPC Service - Async -> AwaitNEraAsync
* RPC Service - Async -> AwaitUntilNEraAsync
###SSE Asynchronous Operations
* SSE Service - Event -> ApiVersionUpdated
* SSE Service - Event -> BlockAdded
* SSE Service - Event -> DeployProcessed
* SSE Service - Event -> Fault
* SSE Service - Event -> Step
* SSE Service - Event -> DeployAccepted
* SSE Service - Event -> FinalitySignature
###Hash Service
* Hash Service - blake2b -> GetAccountHash
* Hash Service - blake2b  -> GetHashToHex
* Hash Service - blake2b  -> GetHashToBinary
###Signing Service
* Signing Service - Ed25519 -> GetKeyPairFromFile
* Signing Service - Ed25519  -> GetKeyPair
* Signing Service - Ed25519  -> GenerateKeyPair
* Signing Service - Ed25519  -> GetSignature
* Signing Service - Ed25519  -> VerifySignature

#Completed Tasks - Not able to Unit Test - Regression Test pending
GetEraInfoLast
GetEraInfoByHash
GetEraInfoByHeight

#Work In Progress
* Signing Service - Ed25519  -> ConvertPrivateKeyToPemAndSaveToDisk
* Signing Service - Ed25519  -> ConvertPublicKeyToPemAndSaveToDisk
* Signing Service - secp256k1  -> GetKeyPairFromFile
* Signing Service - secp256k1   -> GetKeyPair
* Signing Service - secp256k1   -> GenerateKeyPair
* Signing Service - secp256k1   -> GetSignature
* Signing Service - secp256k1   -> VerifySignature
* Signing Service - secp256k1  -> ConvertPrivateKeyToPemAndSaveToDisk
* Signing Service - secp256k1  -> ConvertPublicKeyToPemAndSaveToDisk
* RPC Service -> PutDeploy

#Not Started Tasks
*Add Comments in code
*End-to-end solution example
*How-to guides: make a transfer, delegate / undelegate, install/execute ERC-20 contract
*YouTube videos illustrating how-to guides
	
