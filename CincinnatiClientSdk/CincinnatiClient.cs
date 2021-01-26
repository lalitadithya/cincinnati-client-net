using System;

namespace CincinnatiClientSdk
{
    public class CincinnatiClient
    {
        private readonly string serverUrl;
        private readonly string channel;

        public CincinnatiClient(string serverUrl, string channel)
        {
            this.serverUrl = serverUrl;
            this.channel = channel;
        }

        public void Start()
        {
            Console.WriteLine("Hello, World");
        }
    }
}
