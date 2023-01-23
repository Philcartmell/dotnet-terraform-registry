using DTR.Core.Configuration.Models;

namespace DTR.Core.Configuration.Sources
{
    public interface IModulesSource
    {
        public Task<IAsyncEnumerable<Module>> GetVersionsAsync(string @namespace, string name, string system);
    }
}
