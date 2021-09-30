using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Serialization
{
    public static class TypesSerializer
    {
        public static byte[] Getu512Serializer(object value)
        {
            int maxBytes = 32;
            BigInteger bigInt = new BigInteger((decimal)value);
            byte[] bytes = bigInt.ToByteArray();

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            // Remove tailing zeros
            bytes = ByteUtil.RemoveTrailingZeros(bytes);
           
            return bytes;
        }

        public static byte[] Getu512SerializerWithLength(decimal value)
        {
            byte[] bytes = Getu512Serializer(value);

            //Return the hex of the length byte, plus the byte array of the number
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

            return bytes;
        }

        public static byte[] Getu64SerializerTtl(string value, string removeChar)
        {
            long convertedValue = long.Parse(value.Replace(removeChar, ""));

            int maxBytes = 8;
            byte[] bytes = BitConverter.GetBytes(convertedValue);

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            return bytes;
        }

        public static byte[] Getu64Serializer(long value)
        {
            int maxBytes = 8;
            byte[] bytes = BitConverter.GetBytes(value);

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            return bytes;
        }

        public static byte[] Getu64SerializerWithPrefixOption(ulong value)
        {
            byte[] result = Getu64Serializer(value);

            return ByteUtil.PrefixOption(result);
        }

        public static byte[] Getu32Serializer(int value)
        {
            int maxBytes = 4;
            byte[] bytes = BitConverter.GetBytes(value);

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            return bytes;
        }

        public static byte[] Getu32Serializer(byte[] bytes)
        {
            int maxBytes = 4;

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            return ByteUtil.ResizeByteArray(bytes, maxBytes);
        }

        public static byte[] Getu32SerializerWithPrefixOption(int value)
        {
            byte[] result = Getu32Serializer(value);

            return ByteUtil.PrefixOption(result);
        }

        public static byte[] GetPublicKeySerializer(string value)
        {
            byte[] bytes = new byte[] { (byte)1 };
            bytes = ByteUtil.CombineBytes(bytes, ByteUtil.HexToByteArray(value));
            return bytes;
        }

        public static byte[] GetListSerializer(List<string> list)
        {
            byte[] bytes = Getu32Serializer(list.Count);
            foreach(string item in list)
            {
                bytes = ByteUtil.CombineBytes(bytes, ByteUtil.StringToByteArray(item));
            }
            return bytes;
        }

    }
}