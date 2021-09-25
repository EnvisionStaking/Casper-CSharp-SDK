using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Konscious.Security.Cryptography;

namespace EnvisionStaking.Casper.SDK.Services
{
    public class HashService
    {

        public string GetAccountHash(string accountKey)
        {           
            var valueKeyAlgorithm = CombineBytes(Encoding.UTF8.GetBytes(GetAlgorithm(accountKey).ToLower()), new byte[1]);            

            var valueKey = CombineBytes(valueKeyAlgorithm, StringToByteArray(accountKey.Substring(2)));

            var resultHex = GetHashToHex(valueKey);

            return resultHex;
        }

        public string GetHashToHex(byte[] bytes)
        {
            var resultByte = GetHashToBinary(bytes);

            var resultHex = BitConverter.ToString(resultByte).Replace("-", "").ToLower();

            return resultHex;
        }

        public byte[] GetHashToBinary(byte[] bytes)
        {
            var hashAlgorithm = new HMACBlake2B(256);
            hashAlgorithm.Initialize();

            var resultBytes = hashAlgorithm.ComputeHash(bytes);

            return resultBytes;
        }       

        private byte[] CombineBytes(byte[] first, byte[] second)
        {
            byte[] bytes = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, bytes, 0, first.Length);
            Buffer.BlockCopy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }

        private string GetAlgorithm(string key)
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
                }

            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException(String.Format("Unknown key prefix: [%s]", key.Substring(0, 2)));
            }

            return algoResult;
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
