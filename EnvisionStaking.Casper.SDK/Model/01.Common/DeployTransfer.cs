using EnvisionStaking.Casper.SDK.Interfaces;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
    public class DeployTransfer : DeployExecutable,IHasTag    {

        public DeployTransfer(List<DeployNamedArg> args) : base(args)
        {
        }

        public int GetTag()
        {
            return 5;
        }

        public byte[] ToBytes()
        {
            //Add the type of the 'Deploy Executable' in a single byte
            byte[] bytes = new byte[1];
            bytes[0] = (byte)this.GetTag();         

            //Add Deploy Executable to Array
            bytes = ByteUtil.CombineBytes(bytes, base.ToBytes());
            return bytes;
        }        
    }
}
