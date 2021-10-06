using EnvisionStaking.Casper.SDK.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Test
{

    [TestClass]
    public class SigningServiceTest
    {
        string rpcUrl = "http://40.69.22.98:7777/rpc";
        string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";

        [TestMethod]
        public void VerifySignatureByGeneratedKeyPair()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GenerateKeyPair(SignAlgorithmEnum.ed25519);

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign, SignAlgorithmEnum.ed25519);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSign, signedMessage);

            Assert.IsTrue(signatureIsVerified);
        }

        [TestMethod]
        public void VerifySignatureByGeneratedKeyPairChangeMessage()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GenerateKeyPair(SignAlgorithmEnum.ed25519);

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");
            var messageToSignChanged = Encoding.UTF8.GetBytes("Test Message Changed");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign, SignAlgorithmEnum.ed25519);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSignChanged, signedMessage);

            Assert.IsFalse(signatureIsVerified);
        }

        [TestMethod]
        public void VerifySignatureByKeyPairFromFile()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign, SignAlgorithmEnum.ed25519);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSign, signedMessage);

            Assert.IsTrue(signatureIsVerified);
        }

        [TestMethod]
        public void VerifySignatureByKeyPairFromFileChangeMessage()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");
            var messageToSignChanged = Encoding.UTF8.GetBytes("Test Message Changed");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign, SignAlgorithmEnum.ed25519);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSignChanged, signedMessage);

            Assert.IsFalse(signatureIsVerified);
        }

        [TestMethod]
        public void VerifySignatureByKeyPairFromFileFromDeployHash()
        {
            // Deploy hash in bytes
            byte[] message = {
                (byte) 153, (byte) 144, (byte) 19, (byte) 83, (byte) 219, (byte) 161, (byte) 143, (byte) 137, (byte) 59,
                (byte) 67, (byte) 187, (byte) 238, (byte) 65, (byte) 111, (byte) 80, (byte) 243, (byte) 142, (byte) 77,
                (byte) 113, (byte) 46, (byte) 2, (byte) 166, (byte) 121, (byte) 118, (byte) 34, (byte) 205, (byte) 123,
                (byte) 14, (byte) 215, (byte) 85, (byte) 234, (byte) 161
        };

            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, message, SignAlgorithmEnum.ed25519);           

            bool signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, message, signedMessage);

            Assert.AreEqual(signedMessage.Length, 64);
            Assert.IsTrue(signatureIsVerified);
        }       

        [TestMethod]
        public void ConvertPrivateKeyToPem()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

            var privateKeyPem = casperClient.SigningService.ConvertPrivateKeyToPem(keyPair.Private);

            Assert.IsTrue(!string.IsNullOrEmpty(privateKeyPem));
        }

        [TestMethod]
        public void ConvertPublicKeyToPem()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

            var publicKeyPem = casperClient.SigningService.ConvertPublicKeyToPem(keyPair.Public);

            Assert.IsTrue(!string.IsNullOrEmpty(publicKeyPem));
        }
    }
}