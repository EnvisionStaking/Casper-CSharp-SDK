using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
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

        public byte[] ToBytes()
        {
            byte[] name = Encoding.ASCII.GetBytes(this.GetName());
            byte[] bytes = BitConverter.GetBytes(name.Length);
            bytes = ByteUtil.CombineBytes(bytes, name);
            throw new NotImplementedException();
            //bytes = ByteUtil.CombineBytes(bytes, this.GetValue().ToBytes());

            return bytes;
        }
    }
}
