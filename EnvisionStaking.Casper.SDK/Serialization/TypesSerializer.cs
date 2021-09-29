using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Serialization
{
    public static class TypesSerializer
    {
        public static byte[] Getu512Serializer(decimal value)
        {
            int maxBytes = 32;
            BigInteger bigInt = new BigInteger(value);
            byte[] bytes = bigInt.ToByteArray();

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            // Remove tailing zeros
            bytes = ByteUtil.RemoveTrailingZeros(bytes);

            //Return the hex of the length byte, plus the reversed byte array of the number
            byte[] lengthByte = new byte[1];
            lengthByte[0] = (byte)bytes.Length;

            bytes = ByteUtil.CombineBytes(lengthByte, bytes);
            return bytes;
        }

        public static byte[] Getu64Serializer(ulong value)
        {
            int maxBytes = 8;
            byte[] bytes = BitConverter.GetBytes(value);

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            return ByteUtil.PrefixOption(bytes);
        }

    }
}