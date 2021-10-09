using EnvisionStaking.Casper.SDK.Interfaces;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
    public class DeployModuleBytes : DeployExecutable,IHasTag
    {
        public DeployModuleBytes(string moduleBytesString, byte[] moduleBytes, List<DeployNamedArg> args) : base(args)
        {
            this.ModuleBytes = moduleBytes;
            this.module_bytes = moduleBytesString;
        }
        [JsonConstructor]
        public DeployModuleBytes()
        {           
        }

        public DeployModuleBytes(List<DeployNamedArg> amountArg) : base(amountArg)
        {
            this.ModuleBytes = new byte[0];
        }

        public string module_bytes { get; set; }

        private byte[] ModuleBytes;


        public byte[] GetModuleBytes()
        {
            return this.ModuleBytes;
        }

        public int GetTag()
        {
            return 0;
        }

        public byte[] ToBytes()
        {
            //Add the type of the 'Deploy Executable' in a single byte
            byte[] bytes = new byte[1];
            bytes[0] = (byte)this.GetTag();

            //Add Module Bytes to array
            bytes = ByteUtil.CombineBytes(bytes, Serialization.TypesSerializer.Getu32Serializer(this.GetModuleBytes()));           

            //Add Deploy Executable to byte array
            bytes = ByteUtil.CombineBytes(bytes, base.ToBytes());
            return bytes;
        }        
    }
}
