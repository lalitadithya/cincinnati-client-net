﻿using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CincinnatiClientSdk.Builders
{
    public class CincinnatiClientBuilder
    {
        private string serverUrl;
        private string releaseChannel;
        private Dictionary<string, string> filterParameters = new Dictionary<string, string>();

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

        public CincinnatiClientBuilder AddAdditionalFilterParameters(Dictionary<string, string> filterParameters)
        {
            this.filterParameters = filterParameters;
            return this;
        }

        public CincinnatiClient Build(HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(serverUrl)) throw new NullReferenceException(nameof(serverUrl));
            if (string.IsNullOrWhiteSpace(releaseChannel)) throw new NullReferenceException(nameof(releaseChannel));
            return new CincinnatiClient(serverUrl, releaseChannel, httpClient, filterParameters);
        }
    }
}
