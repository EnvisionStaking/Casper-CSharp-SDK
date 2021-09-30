using EnvisionStaking.Casper.SDK.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Utils
{
    public class ByteUtil
    {
        public static byte[] CombineBytes(byte[] first, byte[] second)
        {
            byte[] bytes = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, bytes, 0, first.Length);
            Buffer.BlockCopy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }

        public static byte[] StringToByteArray(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        public static string ByteArrayToHex(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", "").ToLower();
        }

        public static byte[] HexToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }

        public static byte[] GetLastNBytes(byte[] toTruncate, int length)
        {
            byte[] secretBytes = new byte[length];
            var start = toTruncate.Length - length;
            Array.Copy(toTruncate, start, secretBytes, 0, length);
            return secretBytes;
        }

        public static byte[] RemoveLeadingZeros(byte[] bytes)
        {
            Array.Reverse(bytes);
            for (int i = bytes.Length; i > 0; i--)
            {
                if (bytes[i] == 0)
                {
                    Array.Resize(ref bytes, i);
                }
            }
            Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] RemoveTrailingZeros(byte[] bytes)
        {
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                if (bytes[i] == 0)
                {
                    Array.Resize(ref bytes, i);
                }
                else
                {
                    break;
                }
            }
            return bytes;
        }

        public static byte[] PrefixOption(byte[] bytes)
        {

            byte[] optionPrefix = new byte[1];
            if (bytes == null || bytes.
                Length == 0)
            {
                optionPrefix[0] = (byte)PrefixOptionEnum.OptionNone;
            }
            else
            {
                optionPrefix[0] = (byte)PrefixOptionEnum.OptionSome;
            }
            return CombineBytes(optionPrefix, bytes);
        }

        public static byte[] SerializeToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T DeserializeFromByteArray<T>(byte[] byteArray) where T : class
        {
            if (byteArray == null)
            {
                return null;
            }
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(byteArray, 0, byteArray.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = (T)binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static byte[] ResizeByteArray(byte[] bytes, int newSize)
        {
            Array.Resize<byte>(ref bytes, newSize);
            return bytes;
        }
    }
}
