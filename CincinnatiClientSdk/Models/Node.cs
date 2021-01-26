using System;
using System.Collections.Generic;
using System.Linq;

namespace CincinnatiClientSdk.Models
{
    public class Node : ICloneable
    {
        public string Version { get; set; }
        public string Payload { get; set; }
        public Dictionary<string, string> Metadata { get; set; }

        public object Clone()
        {
            return new Node
            {
                Metadata = Metadata.ToDictionary(x => x.Key, y => (string)y.Value.Clone()),
                Payload = (string)Payload.Clone(),
                Version = (string)Version.Clone()
            };
        }
    }
}
