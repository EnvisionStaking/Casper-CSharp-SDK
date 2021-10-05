using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvisionStaking.Casper.SDK.Utils;
using Konscious.Security.Cryptography;

namespace EnvisionStaking.Casper.SDK.Services
{
    public class HashService
    {

        public string GetAccountHash(string accountKey)
        {
            var valueKeyAlgorithm = ByteUtil.CombineBytes(Encoding.UTF8.GetBytes(GetAlgorithm(accountKey).ToLower()), new byte[1]);

            var valueKey = ByteUtil.CombineBytes(valueKeyAlgorithm, StringToByteArray(accountKey.Substring(2)));

            var resultHex = GetHashToHexFixedSize(valueKey, 32);

            return resultHex;
        }

        public string GetHashToHexFixedSize(byte[] bytes, int hashSize)
        {
            var resultByte = GetHashToBinaryFixedSize(bytes, hashSize);

            var resultHex = BitConverter.ToString(resultByte).Replace("-", "").ToLower();

            return resultHex;
        }

        public byte[] GetHashToBinaryFixedSize(byte[] bytes, int hashSize)
        {
            var hashAlgorithm = new HMACBlake2B(hashSize*8);
            hashAlgorithm.Initialize();

            var resultBytes = hashAlgorithm.ComputeHash(bytes);

            return resultBytes;
        }      

        public string GetAlgorithm(string key)
        {
            string keyStartingWith = key.Substring(0, 2);
            string algoResult = string.Empty;

            if (key == null || key.Length < 66)
            {
                throw new ArgumentOutOfRangeException("Key size must be equal or greater than 66 chars");
            }
            try
            {
                switch (keyStartingWith)
                {
                    case "01":
                        if (key.Length != 66)
                        {
                            throw new ArgumentOutOfRangeException("Key length must be 66 chars");
                        }
                        algoResult = "ED25519";
                        break;
                    case "02":
                        if (key.Length != 68)
                        {
                            throw new ArgumentOutOfRangeException("Key length must be 68 chars");
                        }
                        algoResult = "SECP256K1";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(String.Format("Unknown key prefix: [%s]", key.Substring(0, 2)));
                }

            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException(String.Format("Unknown key prefix: [%s]", key.Substring(0, 2)));
            }

            return algoResult;
        }

        public byte[] GetAlgorithmBytes(string key)
        {
            string keyStartingWith = key.Substring(0, 2);
            string algoResult = string.Empty;

            if (key == null || key.Length < 66)
            {
                throw new ArgumentOutOfRangeException("Key size must be equal or greater than 66 chars");
            }
            try
            {
                switch (keyStartingWith)
                {
                    case "01":
                        return new byte[] { 1 };
                    case "02":
                       return new byte[] { 2 };
                    default:
                        throw new ArgumentOutOfRangeException(String.Format("Unknown key prefix: [%s]", key.Substring(0, 2)));
                }

            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException(String.Format("Unknown key prefix: [%s]", key.Substring(0, 2)));
            }
        }

        public string GetAlgorithmHex(string key)
        {
            string keyStartingWith = key.Substring(0, 2);
            string algoResult = string.Empty;

            if (key == null || key.Length < 66)
            {
                throw new ArgumentOutOfRangeException("Key size must be equal or greater than 66 chars");
            }
            try
            {
                switch (keyStartingWith)
                {
                    case "01":
                        return keyStartingWith;
                    case "02":
                        return keyStartingWith;
                    default:
                        throw new ArgumentOutOfRangeException(String.Format("Unknown key prefix: [%s]", key.Substring(0, 2)));
                }

            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException(String.Format("Unknown key prefix: [%s]", key.Substring(0, 2)));
            }
        }

        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

    }
}
