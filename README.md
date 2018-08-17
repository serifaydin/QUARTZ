Core Mef Code

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
.Net Framework Mef Code

public class MultiEngineLibrary
    {
        [ImportMany(typeof(IJobModule))]
        public IEnumerable<IJobModule> Modules { get; set; }

        public MultiEngineLibrary(string File)
        {
            Console.WriteLine("------Çoklu Modül-------");

            try
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(MultiEngineLibrary).Assembly));
                catalog.Catalogs.Add(new DirectoryCatalog(File, "CL_*.dll"));

                CompositionContainer container = new CompositionContainer(catalog);

                var batch = new CompositionBatch();
                batch.AddPart(this);

                container.Compose(batch);
            }
            catch (FileNotFoundException)
            {

            }
            catch (CompositionException) // Belirtilen yol içerisi boþ ise
            {

            }
            catch (DirectoryNotFoundException) // Belirtilen yol doðru deðil ise
            {

            }
        }
    }