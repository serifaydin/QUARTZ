using CoreJob.Modules;
using System.Composition;

namespace CoreJob.Module1
{
    [Export(typeof(IModule))]
    public class ModuleStart : IModule
    {
        public async void DoJob()
        {
            await JobScheduler1.Start();
        }

        public string GetName()
        {
            return this.GetType().Name;
        }

        public bool IsRepeatable()
        {
            return true;
        }
    }
}