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
Thread Jon Manager

public class JobManager
    {
        Dictionary<Data, Thread> _threads = new Dictionary<Data, Thread>();
        public void ExecuteAllJobs()
        {
            //log.Debug("Begin Method");
            int _threadSize = 1;
            try
            {
                //Job class' ýný implement eden joblarý listeliyoruz.
                IEnumerable<Type> jobs = GetAllTypesImplementingInterface(typeof(Job));
                //Job larý çalýþtýr
                if (jobs != null && jobs.Count() > 0)
                {
                    Job instanceJob = null;
                    Thread thread = null;
                    foreach (Type job in jobs)
                    {

                        //Job istenilen özelliklerdemi ?
                        if (IsRealClass(job))
                        {
                            try
                            {
                                // Reflection ile Job instance ediliyor.
                                instanceJob = (Job)Activator.CreateInstance(job);
                                Console.WriteLine(String.Format("The Job \"{0}\" has been instantiated successfully.", instanceJob.GetName()));

                                //if (instanceJob.status == false)
                                //    continue;

                                thread = new Thread(new ThreadStart(instanceJob.ExecuteJob));
                                thread.Start();

                                Data data = new Data
                                {
                                    Id = _threadSize,
                                    GetName = instanceJob.GetName()
                                };

                                _threads.Add(data, thread); //Her bir thread' i bir Dictionary dizisinde tutuyorum,
                                _threadSize++;

                                Console.WriteLine(String.Format("The Job \"{0}\" has its thread started successfully.", instanceJob.GetName()));
                            }
                            catch (Exception ex)
                            {
                                // log.Error(String.Format("The Job \"{0}\" could not be instantiated or executed.", job.Name), ex);
                            }
                        }
                        else
                        {
                            //log.Error(String.Format("The Job \"{0}\" cannot be instantiated.", job.FullName));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // log.Error("An error has occured while instantiating or executing Jobs for the Scheduler Framework.", ex);
            }

            //log.Debug("End Method");
        }

        public void ThreadEnd(int id)
        {
            Thread _thr = _threads.SingleOrDefault(s => s.Key.Id == id).Value;
            _thr.Suspend();
        }

        public void ThreadStart(int id)
        {
            Thread _thr = _threads.SingleOrDefault(s => s.Key.Id == id).Value;
            _thr.Resume();
        }

        public Dictionary<Data, Thread> GetThreadList()
        {
            return _threads;
        }

        public Thread ThreadJobState(int id)
        {
            return _threads.SingleOrDefault(t => t.Key.Id == id).Value;
        }

        /// <summary>
        /// Job Abstract Class'ýný implement eden tüm Joblarý listeler. 
        /// </summary>
        private IEnumerable<Type> GetAllTypesImplementingInterface(Type desiredType)
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => desiredType.IsAssignableFrom(type));

        }

        /// <summary>
        ///Nesnenin gerçek olup olmadýðýný belirleyin - soyut olmayan, jenerik olmayan, arayüz olmayan sýnýf.
        /// </summary>
        /// <param name="testType">Type to be verified.</param>
        /// <returns>True in case the class is real, false otherwise.</returns>
        public static bool IsRealClass(Type testType)
        {
            return testType.IsAbstract == false
                && testType.IsGenericTypeDefinition == false
                && testType.IsInterface == false;
        }
    }

    public class Data
    {
        public int Id { get; set; }
        public string GetName { get; set; }
    }

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


.Net Core and Quartz
<p align="center">
  <img src="https://github.com/serifaydin/QUARTZ/blob/master/.Net%20Core%20%26%20Quartz%20%26%20Managed-Extensibility-Framework/CoreJob/screen.PNG">
</p>



QUARTZ/.Net Framework & Quartz & Managed-Extensibility-Framework
<p align="center">
  <img src="https://github.com/serifaydin/QUARTZ/blob/master/.Net%20Framework%20%26%20Quartz%20%26%20Managed-Extensibility-Framework/CA_MultiQuartz/Screen.PNG">
</p>


QUARTZ/Thread & Quartz Management
<p align="center">
  <img src="https://github.com/serifaydin/QUARTZ/blob/master/Thread%20%26%20Quartz%20Management/WFA_Jobs/screen.PNG">
</p>