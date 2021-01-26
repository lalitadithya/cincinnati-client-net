using System.Collections.Generic;

namespace CincinnatiClientSdk.Models
{
    public class ReleaseGraph
    {
        public List<Node> Nodes { get; set; }
        public List<int[]> Edges { get; set; }
    }
}
