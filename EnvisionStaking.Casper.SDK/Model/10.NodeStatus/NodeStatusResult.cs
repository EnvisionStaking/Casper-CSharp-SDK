using EnvisionStaking.Casper.SDK.Model.Common;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.NodeStatus
{
    public class NodeStatusResult : Base.Result
    {
        public ResultBody result { get; set; }
    }

    public class ResultBody
    {
        public string api_version { get; set; }
        public string chainspec_name { get; set; }
        public string starting_state_root_hash { get; set; }
        public List<Peer> peers { get; set; }
        public LastAddedBlockInfo last_added_block_info { get; set; }
        public string our_public_signing_key { get; set; }
        public object round_length { get; set; }
        public object next_upgrade { get; set; }
        public string build_version { get; set; }
    }     

}
