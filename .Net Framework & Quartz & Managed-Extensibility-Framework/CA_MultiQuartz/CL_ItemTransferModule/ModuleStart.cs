using CL_Modules;
using System.ComponentModel.Composition;

namespace CL_ItemTransferModule
{
    [Export(typeof(IJobModule))]
    public class ModuleStart : IJobModule
    {
        private bool isRepeatable = true;
        public bool IsRepeatable
        {
            get
            {
                return isRepeatable;
            }
            set
            {
                value = isRepeatable;
            }
        }

        public void DoJob()
        {
            JobProcess.SomeScheduler.Start();
        }

        public string GetName()
        {
            return this.GetType().Name;
        }

        public int GetRepetitionIntervalTime()
        {
            return 1000;
        }

        public void JobPause()
        {
            JobProcess.ItemTransferJob.isActive = false;
            isRepeatable = false;
        }

        public void JobResume()
        {
            JobProcess.ItemTransferJob.isActive = true;
            isRepeatable = true;
        }
    }
}