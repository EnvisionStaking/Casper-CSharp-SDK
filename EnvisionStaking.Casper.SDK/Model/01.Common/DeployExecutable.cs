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
    public abstract class DeployExecutable
    {       

        private List<DeployNamedArg> argsObject;

        public DeployExecutable(List<DeployNamedArg> args)
        {
            this.argsObject = args;
        }       

        public List<DeployNamedArg> GetArgs()
        {
            return this.argsObject;
        }

        [JsonProperty("args")]
        public List<List<object>> argsJson
        {
            get
            {
                List<List<object>> jsonObject = new List<List<object>>();

                foreach (var row in argsObject)
                {
                    List<object> temp = new List<object>();
                    temp.Add(row.GetName());
                    if (row.GetValue().cl_type == CLType.CLTypeEnum.BYTE_ARRAY)
                    {
                        temp.Add(new {
                            cl_type = new { ByteArray = row.GetValue().ToBytes().Length },
                            bytes = row.GetValue().bytes,
                            parsed = row.GetValue().parsed
                        });
                    }
                    else if (row.GetValue().cl_type == CLType.CLTypeEnum.OPTION)
                    {
                        temp.Add(new
                        {
                            cl_type = new { Option = CLType.CLTypeEnum.U64.ToString() },
                            bytes = row.GetValue().bytes,
                            parsed = row.GetValue().parsed
                        });
                    }
                    else
                    {
                        temp.Add(row.GetValue());
                    }
                    jsonObject.Add(temp);
                }
                if (jsonObject == null || jsonObject.Count==0)
                {
                    return new List<List<object>>();
                }
                return jsonObject;
            }
        }
        public DeployNamedArg GetNamedArg(String name)
        {
            if ((this.argsObject != null))
            {
                foreach (DeployNamedArg arg in this.argsObject)
                {
                    if (string.Compare(arg.GetName(), name, true) == 0)
                    {
                        return arg;
                    }
                }
            }

            return null;
        }

        protected byte[] ToBytes()
        {
            byte[] bytes = TypesSerializer.Getu32Serializer(argsObject.Count);

            foreach (var arg in argsObject)
            {
                bytes = ByteUtil.CombineBytes(bytes, arg.ToBytes());
            }

            return bytes;
        }
    }
}
