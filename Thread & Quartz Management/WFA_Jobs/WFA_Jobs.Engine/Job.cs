using System;
using System.Threading;

namespace WFA_Jobs.Engine
{
    public abstract class Job
    {
        public void ExecuteJob()
        {
            if (IsRepeatable())
            {
                while (true)
                {
                    DoJob();
                    Thread.Sleep(GetRepetitionIntervalTime());
                }
            }
            else
            {
                DoJob();
            }
        }
        public virtual Object GetParameters()
        {
            return null;
        }

        public abstract String GetName();

        public abstract void DoJob();

        public abstract bool IsRepeatable();

        public abstract int GetRepetitionIntervalTime();
    }
}