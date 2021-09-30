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
        public string module_bytes { get; set; }

        [JsonProperty("module_bytes")]
        private byte[] moduleBytes;

        public DeployModuleBytes(byte[] moduleBytes, List<DeployNamedArg> args) : base(moduleBytes, args)
        {
        }

        public DeployModuleBytes(List<DeployNamedArg> amountArg) : base(new byte[0], amountArg)
        {
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
