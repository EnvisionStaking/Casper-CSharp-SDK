using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Effect
    {
        public List<Operation> operations { get; set; }
        public List<Transform> transforms { get; set; }
    }
}
