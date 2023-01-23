namespace DTR.Core.Configuration.Models
{
    public class Module
    {
        public Module(string @namespace, string name, string system, string[] versions)
        {
            Namespace = @namespace;
            Name = name;
            System = system;
            Versions = versions;
        }

        public string Namespace { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public string[] Versions { get; set; }
    }
}
