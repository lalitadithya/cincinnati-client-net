using CincinnatiClientSdk.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CincinnatiClientSdk
{
    public class CincinnatiClient
    {
        private readonly string serverUrl;
        private readonly string channel;
        private readonly HttpClient httpClient;
        private ReleaseGraph releaseGraph;

        public CincinnatiClient(string serverUrl, string channel, HttpClient httpClient)
        {
            this.serverUrl = serverUrl;
            this.channel = channel;
            this.httpClient = httpClient;
        }

        public async Task<List<Node>> GetNextApplicationVersions(string currentVersion)
        {
            string requestUri = $"{serverUrl}/v1/graph?channel={channel}";
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpResult = await httpClient.SendAsync(requestMessage);
            if (httpResult.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                releaseGraph = await JsonSerializer.DeserializeAsync<ReleaseGraph>(await httpResult.Content.ReadAsStreamAsync(), options);
                int indexOfVersion = GetIndexOfVersion(currentVersion);
                List<int> nextVersionIndices = FindIndicexOfNextRelease(indexOfVersion);
                List<Node> nextVersions = new List<Node>();
                foreach(var nextVersionIndex in nextVersionIndices)
                {
                    nextVersions.Add((Node)releaseGraph.Nodes[nextVersionIndex].Clone());
                }
                return nextVersions;
            }
            else
            {
                throw new HttpRequestException($"Http resut was not success. Reason is {httpResult.ReasonPhrase}");
            }
        }

        private int GetIndexOfVersion(string version)
        {
            return releaseGraph.Nodes.FindIndex(x => x.Version == version);
        }

        private List<int> FindIndicexOfNextRelease(int currentVersionIndex)
        {
            return releaseGraph.Edges.Where(x => x[0] == currentVersionIndex)
                .Select(x => x[1])
                .ToList();
        }
    }
}
