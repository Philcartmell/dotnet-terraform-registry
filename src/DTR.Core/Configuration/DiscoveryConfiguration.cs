namespace DTR.Core.Configuration
{
    public sealed class DiscoveryConfiguration
    {
        public Uri? BaseUri { get; private set; }
        public bool ReturnAbsolutePath { get; private set; }

        public DiscoveryConfiguration(Uri? baseUri, bool returnAbsolutePath = false)
        {
            BaseUri = baseUri;
            ReturnAbsolutePath = returnAbsolutePath;
        }

        public DiscoveryConfiguration()
        {

        }
    }
}
