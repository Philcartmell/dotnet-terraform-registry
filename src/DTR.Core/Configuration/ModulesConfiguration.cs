using DTR.Core.Configuration.Sources;

namespace DTR.Core.Configuration
{
    public class ModulesConfiguration
    {
        internal readonly IModulesSource ModulesSource;

        internal bool Enabled { get; set; }

        internal ModulesConfiguration(bool enabed, IModulesSource modulesSource)
        {
            this.Enabled = enabed;
            this.ModulesSource = modulesSource;
        }
    }
}
