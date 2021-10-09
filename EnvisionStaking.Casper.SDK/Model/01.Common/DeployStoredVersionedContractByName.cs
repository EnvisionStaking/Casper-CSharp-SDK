using EnvisionStaking.Casper.SDK.Interfaces;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class DeployStoredVersionedContractByName : DeployExecutable,IHasTag
    {        
        public string name { get; set; }

        public int version { get; set; }

        public string entry_point { get; set; }

        [JsonConstructor]
        public DeployStoredVersionedContractByName()
        {

        }
        public DeployStoredVersionedContractByName(List<DeployNamedArg> args) : base(args)
        {
           
        }

        public int GetTag()
        {
            return 4;
        }

        public string GetName()
        {
            if(string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            else
            {
                return name;
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

            //Add Name
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetStringSerializerWithLength(GetName()));
            
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
