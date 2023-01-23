using System.Text.Json.Serialization;

namespace DTR.Core.Endpoints.Discovery
{
    /// <summary>
    /// DTO response for discovery endpoint.
    /// </summary>
    public sealed class DiscoveryEndpointResponse
    {
        [JsonPropertyName("modules")]
        public string ModulesEndpointUrl { get; set; }

        public DiscoveryEndpointResponse(string modulesEndpointUrl)
        {
            ModulesEndpointUrl = modulesEndpointUrl;
        }
    }
}
