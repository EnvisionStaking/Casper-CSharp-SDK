using EnvisionStaking.Casper.SDK.Interfaces;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class DeployStoredVersionedContractByHash : DeployExecutable,IHasTag
    {        
        public string hash { get; set; }

        public int version { get; set; }

        public string entry_point { get; set; }

        public DeployStoredVersionedContractByHash(List<DeployNamedArg> args) : base(args)
        {
           
        }

        public int GetTag()
        {
            return 3;
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

        public int GetVersion()
        {
            return version;
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


            //Add Version
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.Getu32SerializerWithPrefixOption(GetVersion()));

            //Add Entry Point
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetStringSerializerWithLength(GetEntryPoint()));           

            //Add Deploy Executable to Array
            bytes = ByteUtil.CombineBytes(bytes, base.ToBytes());

            

            return bytes;
        }        
    }
}
