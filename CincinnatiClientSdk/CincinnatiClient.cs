using CincinnatiClientSdk.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CincinnatiClientSdk
{
    public class CincinnatiClient
    {
        private readonly string serverUrl;
        private readonly string channel;
        private readonly HttpClient httpClient;

        public CincinnatiClient(string serverUrl, string channel, HttpClient httpClient)
        {
            this.serverUrl = serverUrl;
            this.channel = channel;
            this.httpClient = httpClient;
        }

        public async Task GetNextApplicationVersions(string currentVersion)
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
                var releaseGraph = await JsonSerializer.DeserializeAsync<ReleaseGraph>(await httpResult.Content.ReadAsStreamAsync(), options);
            }
            else
            {
                throw new HttpRequestException($"Http resut was not success. Reason is {httpResult.ReasonPhrase}");
            }
        }
    }
}
