# Cincinnati Client Library for .NET

.NET client library for Openshift's Cincinnati

## Installation

This package is available via NuGet.

Install using the package manager
```shell
Install-Package CincinnatiClient
```

Install using the .NET CLI
```shell
dotnet add package CincinnatiClient
```

## Usage

Get the next versions available for update
```csharp
CincinnatiClient cincinnatiClient = CincinnatiClientBuilder.GetBuilder()
    .WithServerUrl("http://localhost:8081")
    .WithReleaseChannel("stable")
    .Build(new HttpClient());
List<Node> nextVersions = await cincinnatiClient.GetNextApplicationVersions("1.0.0");
```
