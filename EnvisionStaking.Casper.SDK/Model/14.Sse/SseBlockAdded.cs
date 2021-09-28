using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Sse
{
    public class SseBlockAdded
    {
        public BlockAdded BlockAdded { get; set; }
    }
    public class BlockAdded
    {
        public string block_hash { get; set; }
        public Block block { get; set; }
    }
    
    public class Header
    {
        public string parent_hash { get; set; }
        public string state_root_hash { get; set; }
        public string body_hash { get; set; }
        public bool random_bit { get; set; }
        public string accumulated_seed { get; set; }
        public object era_end { get; set; }
        public DateTime timestamp { get; set; }
        public int era_id { get; set; }
        public int height { get; set; }
        public string protocol_version { get; set; }
    }

    public class Body
    {
        public string proposer { get; set; }
        public List<object> deploy_hashes { get; set; }
        public List<object> transfer_hashes { get; set; }
    }

    public class Block
    {
        public string hash { get; set; }
        public Header header { get; set; }
        public Body body { get; set; }
        public List<object> proofs { get; set; }
    }




}
