using System;
using System.Net.Http;

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

        public void Start()
        {
            Console.WriteLine("Hello, World");
        }
    }
}
