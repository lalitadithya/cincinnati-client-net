# Cincinnati Client Library for .NET

This is .NET client library for Openshift's Cincinnati Update protocol. 

## Installation

This package is available via Nuget
```shell
```

## Usage

Get the next versions available for update
```csharp
CincinnatiClient cincinnatiClient = CincinnatiClientBuilder.GetBuilder()
    .WithServerUrl("http://localhost:8081")
    .WithReleaseChannel("stable")
    .Build(new HttpClient());
List<Node> nextVersions = cincinnatiClient.GetNextApplicationVersions("1.0.0").GetAwaiter().GetResult();
```

