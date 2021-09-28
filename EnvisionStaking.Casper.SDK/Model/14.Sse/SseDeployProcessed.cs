using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Sse
{
    public class SseDeployProcessed
    {
        public DeployProcessed DeployProcessed { get; set; }
    }
    public class DeployProcessed
    {
        public string deploy_hash { get; set; }
        public string account { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public List<object> dependencies { get; set; }
        public string block_hash { get; set; }
        public ExecutionResult execution_result { get; set; }
    }

    public class Operation
    {
        public string key { get; set; }
        public string kind { get; set; }
    }

    public class Transform
    {
        public string key { get; set; }
        public object transform { get; set; }
    }

    public class Effect
    {
        public List<Operation> operations { get; set; }
        public List<Transform> transforms { get; set; }
    }

    public class Success
    {
        public Effect effect { get; set; }
        public List<string> transfers { get; set; }
        public string cost { get; set; }
    }

    public class ExecutionResult
    {
        public Success Success { get; set; }
    }
}
