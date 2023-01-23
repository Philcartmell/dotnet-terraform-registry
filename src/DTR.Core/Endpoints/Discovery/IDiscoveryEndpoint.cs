namespace DTR.Core.Endpoints.Discovery
{
    public interface IDiscoveryEndpoint
    {
        /// <summary>
        /// Handles the discovery request
        /// </summary>
        /// <param name="httpRequestBaseUri">The base URI used for the http request (e.g https://tf.somewhere.com/ - no path/query etc.)</param>
        /// <returns>DiscoveryEndpointResponse</returns>
        ValueTask<DiscoveryEndpointResponse> HandleAsync(Uri httpRequestBaseUri);
    }
}
