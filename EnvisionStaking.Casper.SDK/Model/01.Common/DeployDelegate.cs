using EnvisionStaking.Casper.SDK.Interfaces;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
    public class DeployDelegate : DeployExecutable,IHasTag
    {        
        public string hash { get; set; }

        public string entry_point { get; set; }
        
        public DeployDelegate(List<DeployNamedArg> args) : base(args)
        {
           
        }

        public int GetTag()
        {
            return 1;
        }

        public string GetHash()
        {
            if(string.IsNullOrEmpty(hash))
            {
                return string.Empty;
            }
            else
            {
                return hash;
            }
        }

        public string GetEntryPoint()
        {
            return entry_point;
        }

        public byte[] ToBytes()
        {
            //Add the type of the 'Deploy Executable' in a single byte
            byte[] bytes = new byte[1];
            bytes[0] = (byte)this.GetTag();

            //Add Hash
            bytes = ByteUtil.CombineBytes(bytes, ByteUtil.HexToByteArray(GetHash()));

            //Add Entry Point
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetStringSerializerWithLength(GetEntryPoint()));           

            //Add Deploy Executable to Array
            bytes = ByteUtil.CombineBytes(bytes, base.ToBytes());

            

            return bytes;
        }        
    }
}
