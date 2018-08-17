using System;
using System.Threading.Tasks;

namespace CL_Modules
{
    public interface IJobModule
    {
        String GetName();

        void DoJob();

        bool IsRepeatable { get; set; }

        int GetRepetitionIntervalTime();

        void JobPause();
        void JobResume();
    }
}