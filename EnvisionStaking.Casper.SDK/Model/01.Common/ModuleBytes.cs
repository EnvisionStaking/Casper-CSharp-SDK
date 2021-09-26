using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json.Converters;
using EnvisionStaking.Casper.SDK.Model.Common.Argument;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public partial class ModuleBytes
    {
        public string module_bytes { get; set; }

        public ArgElement[][] args { get; set; }
    }
}
