using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Base
{
    public class Result
    {
        public string jsonrpc { get; set; }
        public string id { get; set; }
        public Error error { get; set; }
    }
}
