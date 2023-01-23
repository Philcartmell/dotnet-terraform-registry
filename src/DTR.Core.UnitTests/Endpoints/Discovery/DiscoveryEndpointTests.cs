using DTR.Core.Configuration;
using DTR.Core.Endpoints.Discovery;

namespace DTR.Core.Tests.Unit.Endpoints.Discovery
{
    public class DiscoveryEndpointTests
    {
        private readonly DiscoveryEndpoint _discoveryEndpointRelativeUrl;
        private readonly DiscoveryEndpoint _discoveryEndpointAbsoluteUrl;

        public DiscoveryEndpointTests()
        {
            this._discoveryEndpointRelativeUrl = new DiscoveryEndpoint(new DiscoveryConfiguration(new Uri("https://relativeconfig.com/")));
            this._discoveryEndpointAbsoluteUrl = new DiscoveryEndpoint(new DiscoveryConfiguration(new Uri("https://absoluteconfig.com/"), true));
        }

        [Fact]
        public async Task Endpoint_returns_correct_modules_value_for_relative_url()
        {
            var dto = await this._discoveryEndpointRelativeUrl.HandleAsync(new Uri("https://fromhttprequest.com/"));
            Assert.Equal("/v1/", dto.ModulesEndpointUrl);
        }

        [Fact]
        public async Task Endpoint_returns_correct_modules_value_for_absolute_url()
        {
            var dto = await this._discoveryEndpointAbsoluteUrl.HandleAsync(new Uri("https://fromhttprequest.com/"));
            Assert.Equal("https://absoluteconfig.com/v1/", dto.ModulesEndpointUrl);
        }

        [Fact]
        public void Calculate_hostname_uses_configuration_base_uri_if_defined()
        {
            var result = DiscoveryEndpoint.CalculateVersionUri(new Uri("https://fromconfig.com/"), new Uri("https://fromhttprequest.com/"), "v1");
            Assert.Equal("/v1/", result.ToString());

            // absolute path variant
            var result2 = DiscoveryEndpoint.CalculateVersionUri(new Uri("https://fromconfig.com/"), new Uri("https://fromhttprequest.com/"), "v1", true);
            Assert.Equal("https://fromconfig.com/v1/", result2.ToString());
        }

        [Fact]
        public void Calculate_hostname_defaults_to_http_request_hostname_if_configuration_is_null()
        {
            var result = DiscoveryEndpoint.CalculateVersionUri(null, new Uri("https://fromhttprequest.com/"), "v1");
            Assert.Equal("/v1/", result.ToString());

            // absolute path variant
            var result2 = DiscoveryEndpoint.CalculateVersionUri(null, new Uri("https://fromhttprequest.com/"), "v1", true);
            Assert.Equal("https://fromhttprequest.com/v1/", result2.ToString());
        }

        [Fact]
        public void Calculate_hostname_returns_correct_version()
        {
            var result = DiscoveryEndpoint.CalculateVersionUri(null, new Uri("https://fromhttprequest.com/"), "v1");
            Assert.Equal("/v1/", result.ToString());
        }
    }
}
