using EnvisionStaking.Casper.SDK.Utils;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Services
{
    public class SigningService
    {
        public AsymmetricCipherKeyPair GetKeyPairFromFile(string publicKeyFilePath, string privateKeyFilePath)
        {
            return GetKeyPair(File.OpenRead(publicKeyFilePath), File.OpenRead(privateKeyFilePath));
        }

        public AsymmetricCipherKeyPair GetKeyPair(Stream publicKeyIn, Stream privateKeyIn)
        {
            byte[] publicBytes = ReadPem(publicKeyIn);
            byte[] secretBytes = ReadPem(privateKeyIn);

            byte[] publicLastBytes = ByteUtil.GetLastNBytes(publicBytes, 32);
            byte[] secretLastBytes = ByteUtil.GetLastNBytes(secretBytes, 32);


            return new AsymmetricCipherKeyPair(new Ed25519PublicKeyParameters(publicLastBytes, 0), new Ed25519PrivateKeyParameters(secretLastBytes, 0));
        }

        public AsymmetricCipherKeyPair GenerateKeyPair()
        {
            SecureRandom random = new SecureRandom();
            Ed25519KeyPairGenerator keyPairGenerator = new Ed25519KeyPairGenerator();
            keyPairGenerator.Init(new Ed25519KeyGenerationParameters(random));
            return keyPairGenerator.GenerateKeyPair();
        }

        private Ed25519Signer GenerateKeyPair(byte[] privateKeyBytes)
        {
            Ed25519PrivateKeyParameters privateKeyParameters = new Ed25519PrivateKeyParameters(privateKeyBytes, 0);
            Ed25519Signer ed25519Signer = new Ed25519Signer();
            ed25519Signer.Init(true, privateKeyParameters);
            return ed25519Signer;
        }

        public byte[] GetSignature(AsymmetricKeyParameter privateKey, byte[] toSign)
        {
            Ed25519Signer signer = new Ed25519Signer();
            signer.Init(true, privateKey);
            signer.BlockUpdate(toSign, 0, toSign.Length);
            return signer.GenerateSignature();
        }

        public bool VerifySignature(AsymmetricKeyParameter publicKeyParameters, byte[] message, byte[] signed)
        {
            Ed25519Signer verifier = new Ed25519Signer();
            verifier.Init(false, publicKeyParameters);
            verifier.BlockUpdate(message, 0, message.Length);
            return verifier.VerifySignature(signed);
        }

        private byte[] ReadPem(Stream keyStream)
        {
            TextReader textReader = new StreamReader(keyStream);
            var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(textReader);
            var pemObject = pemReader.ReadPemObject();
            return pemObject.Content;
        }

        public string ConvertPrivateKeyToPem(AsymmetricKeyParameter privateKey)
        {
            using (var stringWriter = new StringWriter())
            {
                var pemWriter = new Org.BouncyCastle.OpenSsl.PemWriter(stringWriter);
                pemWriter.WriteObject(privateKey);
                pemWriter.Writer.Flush();
                return stringWriter.ToString();
            }
        }       

        public string ConvertPublicKeyToPem(AsymmetricKeyParameter publicKey)
        {
            using (var stringWriter = new StringWriter())
            {
                Org.BouncyCastle.OpenSsl.PemWriter pemWriter = new Org.BouncyCastle.OpenSsl.PemWriter(stringWriter);
                pemWriter.WriteObject(publicKey);
                pemWriter.Writer.Flush();
                return stringWriter.ToString();
            }
        }
    }
}
