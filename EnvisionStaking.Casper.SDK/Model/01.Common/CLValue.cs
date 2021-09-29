using EnvisionStaking.Casper.SDK.Utils;
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

        public byte[] ToBytes(CLValue source)
        {
            throw new NotImplementedException();
            //return ByteUtil.concat(
            //        getU32Serializer().serialize(source.getBytes().length),
            //        source.getBytes(),
            //        toBytesForCLTypeInfo(source.getCLTypeInfo())
            //);
        }
    }
}
