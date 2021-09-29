using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Serialization
{
    public static class TypesSerializer
    {
        public static byte[] Getu512Serializer(ulong value)
        { 
            byte[] bytes = BitConverter.GetBytes(value);
            byte[] byteResult;

            // Remove tailing zeros
            if (bytes.Length > 1 && bytes[0] == 0)
            {
                bytes = ByteUtil.RemoveTrailingZeros(bytes);
            }

            //Return the hex of the length byte, plus the reversed byte array of the number
            byte[] lengthByte = new byte[1];
            lengthByte[0] = (byte)bytes.Length;

            byteResult = ByteUtil.CombineBytes(lengthByte, bytes);
            return byteResult;
        }

      

    }
}