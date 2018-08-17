using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WFA_Jobs.Engine
{
    public class JobManager
    {
        Dictionary<Data, Thread> _threads = new Dictionary<Data, Thread>();
        public void ExecuteAllJobs()
        {
            //log.Debug("Begin Method");
            int _threadSize = 1;
            try
            {
                //Job class' ını implement eden jobları listeliyoruz.
                IEnumerable<Type> jobs = GetAllTypesImplementingInterface(typeof(Job));
                //Job ları çalıştır
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
        /// Job Abstract Class'ını implement eden tüm Jobları listeler. 
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
        ///Nesnenin gerçek olup olmadığını belirleyin - soyut olmayan, jenerik olmayan, arayüz olmayan sınıf.
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

}
