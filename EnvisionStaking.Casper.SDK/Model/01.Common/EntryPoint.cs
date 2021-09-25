using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class EntryPoint
    {
        public string name { get; set; }
        public List<Arg> args { get; set; }
        public object ret { get; set; }
        public string access { get; set; }
        public string entry_point_type { get; set; }
    }
}
