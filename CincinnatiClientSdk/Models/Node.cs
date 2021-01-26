using System.Collections.Generic;

namespace CincinnatiClientSdk.Models
{
    public class Node
    {
        public string Version { get; set; }
        public string Payload { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}
