using EnvisionStaking.Casper.SDK.Interfaces;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
    public class DeployTransfer : DeployExecutable,IHasTag
    {

        public DeployTransfer(byte[] moduleBytes, List<DeployNamedArg> args) : base(moduleBytes, args)
        {
        }

        public DeployTransfer(List<DeployNamedArg> amountArg) : base(new byte[0], amountArg)
        {
        }

        public int GetTag()
        {
            return 5;
        }

        public byte[] ToBytes()
        {
            // Append the type of the 'Deploy Executable' in a single byte
            byte[] bytes = new byte[1];
            bytes[1] = (byte)this.GetTag();
            bytes = ByteUtil.CombineBytes(bytes, this.GetModuleBytes());
            bytes = ByteUtil.CombineBytes(bytes, this.ToBytes(this.GetArgs()));

            return bytes;
        }

        private byte[] ToBytes(List<DeployNamedArg> args)
        {
            byte[] bytes = TypesSerializer.Getu32Serializer(args.Count);

            //ByteUtil.CombineBytes(bytes, TypesSerializer.Getu32Serializer(this.GetModuleBytes());

            foreach(var arg in args)
            {
                bytes = ByteUtil.CombineBytes(bytes, arg.ToBytes());
            }
           
            return bytes;
        }
    }

}
