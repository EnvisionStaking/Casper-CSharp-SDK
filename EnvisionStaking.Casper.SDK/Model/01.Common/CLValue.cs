using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
    public class CLValue
    {
        public string cl_type { get; set; }
        public string bytes { get; set; }
        public object parsed { get; set; }
    }
}
