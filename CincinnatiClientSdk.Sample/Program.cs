using CincinnatiClientSdk.Builders;
using CincinnatiClientSdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CincinnatiClientSdk.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            CincinnatiClient cincinnatiClient = CincinnatiClientBuilder.GetBuilder()
                .WithServerUrl("http://localhost:8081")
                .WithReleaseChannel("stable")
                .Build(new HttpClient());
            List<Node> nextVersions = cincinnatiClient.GetNextApplicationVersions("1.0.0").GetAwaiter().GetResult();
            foreach(var nextVersion in nextVersions)
            {
                Console.WriteLine("Next version is " + nextVersion.Version);
            }
        }
    }
}
