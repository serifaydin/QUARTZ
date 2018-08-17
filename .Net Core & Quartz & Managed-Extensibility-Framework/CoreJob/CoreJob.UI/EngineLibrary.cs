using CoreJob.Modules;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace CoreJob.UI
{
    public class EngineLibrary
    {
        [ImportMany]
        public IEnumerable<IModule> Modules { get; set; }

        public EngineLibrary()
        {
            var executableLocation = Assembly.GetEntryAssembly().Location;

            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "Plugins");
            var assemblies = Directory
                        .GetFiles(path, "*.dll", SearchOption.AllDirectories)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                        .ToList();
            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies);
            using (var container = configuration.CreateContainer())
            {
                Modules = container.GetExports<IModule>();
            }
        }
    }
}