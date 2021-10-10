using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Serialization
{
    /// <summary>
    /// Serialization class for generating the serialized requests
    /// </summary>
    public static class TypesSerializer
    {
        /// <summary>
        /// Get the 32 byte serialized value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Getu512Serializer(object value)
        {
            int maxBytes = 32;
            BigInteger bigInt = new BigInteger((decimal)value);
            byte[] bytes = bigInt.ToByteArray();

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            // Remove trailing zeros
            bytes = ByteUtil.RemoveTrailingZeros(bytes);

            return bytes;
        }
        /// <summary>
        /// Get the 32 byte serialized value including the length in first bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Getu512SerializerWithLength(decimal value)
        {
            byte[] bytes = Getu512Serializer(value);

            //Return the hex of the length byte, plus the byte array of the number
            byte[] lengthByte = new byte[1];
            lengthByte[0] = (byte)bytes.Length;

            bytes = ByteUtil.CombineBytes(lengthByte, bytes);
            return bytes;
        }
        /// <summary>
        /// Get the 8 byte serialized value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get the 8 byte serialized value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get the 8 byte serialized value with Prefix Option in first bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Getu64SerializerWithPrefixOption(ulong value)
        {
            byte[] result = Getu64Serializer(value);

            return ByteUtil.PrefixOption(result);
        }
        /// <summary>
        /// Get the 4 byte serialized value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get the 4 byte serialized value
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] Getu32Serializer(byte[] bytes)
        {
            int maxBytes = 4;

            if (bytes.Length > maxBytes)
            {
                throw new ArgumentOutOfRangeException($"Value is out of range");
            }

            return ByteUtil.ResizeByteArray(bytes, maxBytes);
        }
        /// <summary>
        /// Get the 4 byte serialized value with Prefix Option in first bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Getu32SerializerWithPrefixOption(int value)
        {
            byte[] result = Getu32Serializer(value);

            return ByteUtil.PrefixOption(result);
        }
      /// <summary>
      /// Get List serialized
      /// </summary>
      /// <param name="list"></param>
      /// <returns></returns>
        public static byte[] GetListSerializer(List<string> list)
        {
            byte[] bytes = Getu32Serializer(list.Count);
            foreach (string item in list)
            {
                bytes = ByteUtil.CombineBytes(bytes, ByteUtil.StringToByteArray(item));
            }
            return bytes;
        }
        /// <summary>
        /// Get Time epoch serialized
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static ulong GetTimeSerializerEpoch(DateTime date)
        {
            return (ulong)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
        /// <summary>
        /// Get Time epoch serialized
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static byte[] GetTimeSerializerEpochBytes(DateTime date)
        {
            return BitConverter.GetBytes(GetTimeSerializerEpoch(date));
        }
        /// <summary>
        /// Get string serialized including the length in leading bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetStringSerializerWithLength(string value)
        {
            byte[] valueBytes = ByteUtil.StringToByteArray(value);
            byte[] lengthBytes = TypesSerializer.Getu32Serializer(valueBytes.Length);

            byte[] bytes = ByteUtil.CombineBytes(lengthBytes, valueBytes);
            return bytes;

        }
        /// <summary>
        /// Get Time to Leave serialized
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetTTLSerializer(string value)
        {
            long convertedValue = 0;
            if (value.EndsWith("m"))
            {
                convertedValue = long.Parse(value.Replace("m", ""));
                convertedValue *= 60000;
            }
            else if (value.EndsWith("s"))
            {
                convertedValue = long.Parse(value.Replace("s", ""));
                convertedValue *= 1000;
            }
            else
            {
                throw new FormatException("Invalid format exception for TTL");
            }

            return BitConverter.GetBytes(convertedValue);
        }
    }
}