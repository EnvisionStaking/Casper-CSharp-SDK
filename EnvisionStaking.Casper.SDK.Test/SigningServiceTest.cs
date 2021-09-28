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
            var keyPair = casperClient.SigningService.GenerateKeyPair();

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSign, signedMessage);

            Assert.IsTrue(signatureIsVerified);
        }

        [TestMethod]
        public void VerifySignatureByGeneratedKeyPair2()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GenerateKeyPair();

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");
            var messageToSignChanged = Encoding.UTF8.GetBytes("Test Message Changed");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSignChanged, signedMessage);

            Assert.IsFalse(signatureIsVerified);
        }

        [TestMethod]
        public void VerifySignatureByKeyPairFromFile()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSign, signedMessage);

            Assert.IsTrue(signatureIsVerified);
        }

        [TestMethod]
        public void VerifySignatureByKeyPairFromFile2()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var keyPair = casperClient.SigningService.GetKeyPairFromFile(@"keys\public_key.pem", @"keys\secret_key.pem");

            var messageToSign = Encoding.UTF8.GetBytes("Test Message");
            var messageToSignChanged = Encoding.UTF8.GetBytes("Test Message Changed");

            var signedMessage = casperClient.SigningService.GetSignature(keyPair.Private, messageToSign);

            var signatureIsVerified = casperClient.SigningService.VerifySignature(keyPair.Public, messageToSignChanged, signedMessage);

            Assert.IsFalse(signatureIsVerified);
        }

        [TestMethod]
        public void GenerateAndSaveKeys()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);

            var keyPair = casperClient.SigningService.GenerateKeyPair();

            var privateKeyPem = casperClient.SigningService.ConvertPrivateKeyToPem(keyPair.Private);
            var publicKeyPem = casperClient.SigningService.ConvertPublicKeyToPem(keyPair.Public);

            File.WriteAllText(@"keys\secret_key.pem", privateKeyPem);
            File.WriteAllText(@"keys\public_key.pem", publicKeyPem);

            Assert.IsTrue(!string.IsNullOrEmpty(privateKeyPem));
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