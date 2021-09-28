using System;
using System.Collections.Generic;
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

        public static string ByteArrayToString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", "");
        }

        public static byte[] GetLastNBytes(byte[] toTruncate, int length)
        {
            byte[] secretBytes = new byte[length];
            var start = toTruncate.Length - length;
            Array.Copy(toTruncate, start, secretBytes, 0, length);
            return secretBytes;
        }
    }
}
