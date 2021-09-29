using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployParameters
    {
        public PutDeployDeploy deploy { get; set; }
    }
    public class PutDeployDeploy
    {       
        public string hash { get; set; }
        public PutDeployHeader header { get; set; }
        public List<Approval> approvals { get; set; }
        public PutDeployPayment payment { get; set; }
        public PutDeploySession session { get; set; }
    }
    [Serializable]
    public class PutDeployHeader
    {
        public string account { get; set; }
        public string body_hash { get; set; }
        public string chain_name { get; set; }
        public long gas_price { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public List<string> dependencies { get; set; }

    }
    [Serializable]
    public class PutDeployPayment
    {
        public ModuleBytes ModuleBytes { get; set; }     
    }

    public class PutDeploySession
    {
        public PutDeployTransfer Transfer { get; set; }
    }
    [Serializable]
    public class PutDeployTransfer
    {
        [JsonProperty("args")]
        //[field: NonSerialized]
        public List<List<object>> argsJson { get; set; }

        [field: NonSerialized]
        [JsonIgnore]
        public List<KeyValuePair<string, CLValue>> argsObject
        {
            get
            {
                List<KeyValuePair<string, CLValue>> result = new List<KeyValuePair<string, CLValue>>();

                foreach (var row in argsJson)
                {
                    result.Add(new KeyValuePair<string, CLValue>(row[0].ToString(), JsonConvert.DeserializeObject<CLValue>(row[1].ToString())));
                }

                return result;
            }
            set
            {
                List<List<object>> jsonObject = new List<List<object>>();

                foreach (var row in value)
                {
                    List<object> temp = new List<object>();
                    temp.Add(row.Key);
                    temp.Add(row.Value);
                    jsonObject.Add(temp);
                }
                if (argsJson == null)
                {
                    argsJson = new List<List<object>>();
                }
                argsJson = jsonObject;
            }
        }
    }
}