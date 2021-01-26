using System;

namespace CincinnatiClientSdk.Builders
{
    public class CincinnatiClientBuilder
    {
        private string serverUrl;
        private string releaseChannel;

        public static CincinnatiClientBuilder GetBuilder() => new CincinnatiClientBuilder();

        public CincinnatiClientBuilder WithServerUrl(string serverUrl)
        {
            this.serverUrl = serverUrl;
            return this;
        }

        public CincinnatiClientBuilder WithReleaseChannel(string releaseChannel)
        {
            this.releaseChannel = releaseChannel;
            return this;
        }

        public CincinnatiClient Build()
        {
            if (string.IsNullOrWhiteSpace(serverUrl)) throw new ArgumentNullException(nameof(serverUrl));
            if (string.IsNullOrWhiteSpace(releaseChannel)) throw new ArgumentNullException(nameof(releaseChannel));
            return new CincinnatiClient(serverUrl, releaseChannel);
        }
    }
}
