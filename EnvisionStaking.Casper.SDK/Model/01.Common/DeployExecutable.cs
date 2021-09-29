using EnvisionStaking.Casper.SDK.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
    public abstract class DeployExecutable
    {

        [JsonProperty("module_bytes")]
        private byte[] moduleBytes;

        private List<DeployNamedArg> args;

        public DeployExecutable(byte[] moduleBytes, List<DeployNamedArg> args)
        {
            this.moduleBytes = moduleBytes;
            this.args = args;
        }

        public byte[] GetModuleBytes()
        {
            return this.moduleBytes;
        }

        public List<DeployNamedArg> GetArgs()
        {
            return this.args;
        }        

        public DeployNamedArg GetNamedArg(String name)
        {
            if ((this.args != null))
            {
                foreach (DeployNamedArg arg in this.args)
                {
                    if (string.Compare(arg.GetName(), name, true) ==0)
                    {
                        return arg;
                    }

                }

            }

            return null;
        }        
    }
}
