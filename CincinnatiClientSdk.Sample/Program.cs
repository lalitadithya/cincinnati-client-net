using CincinnatiClientSdk.Builders;
using System;

namespace CincinnatiClientSdk.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            CincinnatiClient cincinnatiClient = CincinnatiClientBuilder.GetBuilder()
                .WithServerUrl("http://localhost:8081")
                .WithReleaseChannel("stable")
                .Build();
            cincinnatiClient.Start();
        }
    }
}
