using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Base
{
    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
