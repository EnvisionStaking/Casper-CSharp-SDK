using EnvisionStaking.Casper.SDK.Enums;
using EnvisionStaking.Casper.SDK.Utils;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.IO;

namespace EnvisionStaking.Casper.SDK.Services
{
    public class SigningService
    {
        public AsymmetricCipherKeyPair GetKeyPairFromFile(string publicKeyFilePath, string privateKeyFilePath, SignAlgorithmEnum signAlgorithm)
        {
            return GetKeyPair(File.OpenRead(publicKeyFilePath), File.OpenRead(privateKeyFilePath), signAlgorithm);
        }

        public AsymmetricCipherKeyPair GetKeyPair(Stream publicKeyIn, Stream privateKeyIn, SignAlgorithmEnum signAlgorithm)
        {
            if (signAlgorithm == SignAlgorithmEnum.ed25519)
            {
                byte[] publicBytes = ReadPemToByte(publicKeyIn);
                byte[] secretBytes = ReadPemToByte(privateKeyIn);

                byte[] publicLastBytes = ByteUtil.GetLastNBytes(publicBytes, 32);
                byte[] secretLastBytes = ByteUtil.GetLastNBytes(secretBytes, 32);

                return new AsymmetricCipherKeyPair(new Ed25519PublicKeyParameters(publicLastBytes, 0), new Ed25519PrivateKeyParameters(secretLastBytes, 0));
            }
            else
            {
                var secretPem = ReadPemToObject(privateKeyIn);
                return (AsymmetricCipherKeyPair)secretPem;
            }
        }

        public AsymmetricCipherKeyPair GenerateKeyPair(SignAlgorithmEnum signAlgorithm)
        {
            if (signAlgorithm == SignAlgorithmEnum.ed25519)
            {
                SecureRandom random = new SecureRandom();
                Ed25519KeyPairGenerator keyPairGenerator = new Ed25519KeyPairGenerator();
                keyPairGenerator.Init(new Ed25519KeyGenerationParameters(random));
                return keyPairGenerator.GenerateKeyPair();
            }
            else if (signAlgorithm == SignAlgorithmEnum.secp256k1)
            {
                var curve = ECNamedCurveTable.GetByName(SignAlgorithmEnum.secp256k1.ToString());
                var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

                var secureRandom = new SecureRandom();
                var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);

                var generator = new ECKeyPairGenerator("ECDSA");
                generator.Init(keyParams);
                var keyPair = generator.GenerateKeyPair();

                return keyPair;
            }
            else
            {
                throw new NotSupportedException("Sign Algorithm not supported");
            }
        }

        private Ed25519Signer GenerateKeyPairEd25519(byte[] privateKeyBytes)
        {
            Ed25519PrivateKeyParameters privateKeyParameters = new Ed25519PrivateKeyParameters(privateKeyBytes, 0);
            Ed25519Signer ed25519Signer = new Ed25519Signer();
            ed25519Signer.Init(true, privateKeyParameters);
            return ed25519Signer;
        }

        public byte[] GetSignatureEd25519(AsymmetricKeyParameter privateKey, byte[] toSign)
        {
            Ed25519Signer signer = new Ed25519Signer();
            signer.Init(true, privateKey);
            signer.BlockUpdate(toSign, 0, toSign.Length);
            return signer.GenerateSignature();
        }
        public bool VerifySignatureEd25519(AsymmetricKeyParameter publicKeyParameters, byte[] message, byte[] signed)
        {
            Ed25519Signer verifier = new Ed25519Signer();
            verifier.Init(false, publicKeyParameters);
            verifier.BlockUpdate(message, 0, message.Length);
            return verifier.VerifySignature(signed);
        }

        public byte[] GetSignatureSecp256k1(AsymmetricKeyParameter privateKey, byte[] toSign)
        {
            var signer = SignerUtilities.GetSigner("SHA-256withPLAIN-ECDSA");
            signer.Init(true, privateKey);
            signer.BlockUpdate(toSign, 0, toSign.Length);
            var signature = signer.GenerateSignature();
            return signature;
        }       

        public bool VerifySignatureSecp256k1(AsymmetricKeyParameter publicKeyParameters, byte[] message, byte[] signed)
        {
            var signer = SignerUtilities.GetSigner("SHA-256withPLAIN-ECDSA");
            signer.Init(false, publicKeyParameters);
            signer.BlockUpdate(message, 0, message.Length);
            var signature = signer.VerifySignature(signed);
            return signature;
        }

        private byte[] ReadPemToByte(Stream keyStream)
        {
            TextReader textReader = new StreamReader(keyStream);
            var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(textReader);
            var pemObject = pemReader.ReadPemObject();
            return pemObject.Content;
        }

        private object ReadPemToObject(Stream keyStream)
        {
            TextReader textReader = new StreamReader(keyStream);
            var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(textReader);
            var pemObject = pemReader.ReadObject();
            return pemObject;
        }

        private PemObject ReadPemToPemObject(Stream keyStream)
        {
            TextReader textReader = new StreamReader(keyStream);
            var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(textReader);
            var pemObject = pemReader.ReadPemObject();
            return pemObject;
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
