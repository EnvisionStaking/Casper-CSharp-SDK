using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common.Argument
{
    public partial struct ArgElement
    {
        public ArgClass ArgClass;
        public string String;

        public static implicit operator ArgElement(ArgClass ArgClass) => new ArgElement { ArgClass = ArgClass };
        public static implicit operator ArgElement(string String) => new ArgElement { String = String };
    }

    public partial class ArgClass
    {
        [JsonProperty("cl_type")]
        public string cl_type { get; set; }

        [JsonProperty("bytes")]
        public string bytes { get; set; }

        [JsonProperty("parsed")]
        public string parsed { get; set; }
    } 
}
