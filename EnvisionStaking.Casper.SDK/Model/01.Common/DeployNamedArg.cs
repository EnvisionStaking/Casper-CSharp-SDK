using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class DeployNamedArg
    {

        private string name;
        private CLValue value;

        public DeployNamedArg(string name, CLValue value)
        {
            this.name = name;
            this.value = value;
        }

        public String GetName()
        {
            return this.name;
        }

        public CLValue GetValue()
        {
            return this.value;
        }

        public CLType.CLTypeEnum GetCLTypeInfo()
        {
            return this.value.cl_type;
        }

        public byte[] ToBytes()
        {
            //Serialize name
            byte[] name = Encoding.ASCII.GetBytes(this.GetName());
            byte[] bytes = BitConverter.GetBytes(name.Length);
            bytes = ByteUtil.CombineBytes(bytes, name);

            //Get Arg Length and add to array
            bytes = ByteUtil.CombineBytes(bytes,TypesSerializer.Getu32Serializer(this.GetValue().ToBytes().Length));

            //Get Arg value and add to array
            bytes = ByteUtil.CombineBytes(bytes, this.GetValue().ToBytes());

            //Add CL Type Info
            if (this.value.cl_type == CLType.CLTypeEnum.BYTE_ARRAY)
            {
                bytes = ByteUtil.CombineBytes(bytes, new byte[] { (byte)GetCLTypeInfo() });
                bytes = ByteUtil.CombineBytes(bytes, BitConverter.GetBytes(ByteUtil.HexToByteArray(this.value.bytes).Length));
            }
            else if (this.value.cl_type == CLType.CLTypeEnum.OPTION)
            {
                bytes = ByteUtil.CombineBytes(bytes, new byte[] { (byte)GetCLTypeInfo() });
                bytes = ByteUtil.CombineBytes(bytes, new byte[] { (byte)CLType.CLTypeEnum.U64 });
            }
            else
            {
                bytes = ByteUtil.CombineBytes(bytes, new byte[] { (byte)GetCLTypeInfo() });
            }
            return bytes;
        }
    }
}

