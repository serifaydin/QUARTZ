﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA_Jobs.Engine;

namespace WFA_Jobs.ScheduleJobs
{
    class JobScehdule4 : Job
    {
        private int counter = 0;

        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            Console.WriteLine("This is the execution number \"{0}\" of the Job \"{1}\".", counter.ToString(), this.GetName());
            counter++;
        }

        public override bool IsRepeatable()
        {
            return true;
        }

        public override int GetRepetitionIntervalTime()
        {
            return 1000;
        }
    }
}