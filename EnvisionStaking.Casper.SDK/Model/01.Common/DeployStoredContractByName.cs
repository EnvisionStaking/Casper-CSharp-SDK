using EnvisionStaking.Casper.SDK.Interfaces;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{

    public class DeployStoredContractByName : DeployExecutable,IHasTag
    {        
        public string name { get; set; }

        public string entry_point { get; set; }
        
        public DeployStoredContractByName(List<DeployNamedArg> args) : base(args)
        {
           
        }

        public int GetTag()
        {
            return 2;
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

            //Add Entry Point
            bytes = ByteUtil.CombineBytes(bytes, TypesSerializer.GetStringSerializerWithLength(GetEntryPoint()));           

            //Add Deploy Executable to Array
            bytes = ByteUtil.CombineBytes(bytes, base.ToBytes());

            

            return bytes;
        }        
    }
}
