using DTR.Core.Configuration;

namespace DTR.Core.Endpoints.Discovery
{
    /// <summary>
    /// Logic to generate the data object for the endpoint response.
    /// </summary>
    public class DiscoveryEndpoint : IDiscoveryEndpoint
    {
        private readonly DiscoveryConfiguration _discoveryConfiguration;

        public DiscoveryEndpoint(DiscoveryConfiguration discoveryConfiguration)
        {
            _discoveryConfiguration = discoveryConfiguration;
        }

        /// <summary>
        /// Handles the wellknown endpoint request.
        /// </summary>
        /// <param name="httpRequestBaseUri">Current http request URI.</param>
        /// <returns>DiscoveryEndpointResponse</returns>
        public ValueTask<DiscoveryEndpointResponse> HandleAsync(Uri httpRequestUri)
        {
            var response = new DiscoveryEndpointResponse(CalculateVersionUri(this._discoveryConfiguration.BaseUri,
                httpRequestUri,
                "v1",
                _discoveryConfiguration.ReturnAbsolutePath).ToString());

            return new ValueTask<DiscoveryEndpointResponse>(response);
        }

        /// <summary>
        /// Calculates the correct version URI including hostname from config if defined.
        /// </summary>
        /// <param name="configurationBaseUri">Base URI from config.</param>
        /// <param name="httpRequestUri">Current request URI.</param>
        /// <param name="version">Version value to use.</param>
        /// <param name="returnAbsolutePath">Return an absolute path (defaults to false).</param>
        /// <returns>URI value.</returns>
        internal static Uri CalculateVersionUri(Uri? configurationBaseUri, Uri httpRequestUri, string version, bool returnAbsolutePath = false)
        {
            Uri baseUri = new Uri(httpRequestUri.GetLeftPart(UriPartial.Authority));

            if (configurationBaseUri != null)
            {
                baseUri = new Uri(configurationBaseUri, $"/{version}/");
            }

            if (returnAbsolutePath)
            {
                return new Uri(baseUri, $"/{version}/");
            }

            return new Uri($"/{version}/", UriKind.Relative);
        }
    }
}
