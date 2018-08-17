using System;

namespace CoreJob.Modules
{
    public interface IModule
    {
        String GetName();

        void DoJob();

        bool IsRepeatable();
    }
}