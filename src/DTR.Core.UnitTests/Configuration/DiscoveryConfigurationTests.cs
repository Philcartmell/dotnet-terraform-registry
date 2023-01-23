using DTR.Core.Configuration;

namespace DTR.Core.Tests.Unit.Configuration
{
    public class DiscoveryConfigurationTests
    {
        [Fact]
        public void Ctor_maps_args_to_pros()
        {
            var uri = new Uri("https://www.base.com");

            var dc = new DiscoveryConfiguration(uri, true);

            Assert.Equal(uri, dc.BaseUri);
            Assert.True(dc.ReturnAbsolutePath);
        }

        [Fact]
        public void Ctor_if_no_base_uri_provided_property_is_null()
        {
            var dc = new DiscoveryConfiguration(null, true);
            Assert.Null(dc.BaseUri);
        }
        
        [Fact]
        public void Default_return_absolute_path_parameter_value_is_false()
        {
            var dc = new DiscoveryConfiguration(null);
            Assert.False(dc.ReturnAbsolutePath);
        }
    }
}
