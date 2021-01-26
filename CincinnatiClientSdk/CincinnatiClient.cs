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
            await FetchReleaseGraphFromRemote();
            int indexOfVersion = GetIndexOfVersion(currentVersion);
            List<int> nextVersionIndices = FindIndicesOfNextRelease(indexOfVersion);
            List<Node> nextVersions = new List<Node>();
            foreach (var nextVersionIndex in nextVersionIndices)
            {
                nextVersions.Add((Node)releaseGraph.Nodes[nextVersionIndex].Clone());
            }
            return nextVersions;
        }

        private int GetIndexOfVersion(string version)
        {
            return releaseGraph.Nodes.FindIndex(x => x.Version == version);
        }

        private List<int> FindIndicesOfNextRelease(int currentVersionIndex)
        {
            return releaseGraph.Edges.Where(x => x[0] == currentVersionIndex)
                .Select(x => x[1])
                .ToList();
        }

        private async Task FetchReleaseGraphFromRemote()
        {
            string requestUri = $"{serverUrl}/v1/graph?channel={channel}";
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpResult = await httpClient.SendAsync(requestMessage);
            if (httpResult.IsSuccessStatusCode)
            {
                releaseGraph = await JsonSerializer.DeserializeAsync<ReleaseGraph>(await httpResult.Content.ReadAsStreamAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new HttpRequestException($"Http result does not appear to be a success. Reason is {httpResult.ReasonPhrase}");
            }
        }
    }
}
