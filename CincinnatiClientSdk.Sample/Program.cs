using CincinnatiClientSdk.Builders;
using System;
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
            cincinnatiClient.GetNextApplicationVersions("1.0.0").GetAwaiter().GetResult();
        }
    }
}
