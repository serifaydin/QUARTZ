using CL_Module1.QuartzManage;
using CL_Modules;
using System.ComponentModel.Composition;

namespace CL_Module1
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
            SomeScheduler.Start();
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
            ModuleJob1.isActive = false;
            isRepeatable = false;
        }

        public void JobResume()
        {
            ModuleJob1.isActive = true;
            isRepeatable = true;
        }
    }
}