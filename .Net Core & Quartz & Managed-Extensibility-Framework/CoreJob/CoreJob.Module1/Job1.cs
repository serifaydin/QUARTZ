using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace CoreJob.Module1
{
    public class Job1 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString() + " JOB1");
            return Task.FromResult(0);
        }
    }

    public class JobScheduler1
    {
        public static async Task Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<Job1>().WithIdentity("job1").Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                    //s.WithIntervalInHours(24)
                    s.WithIntervalInSeconds(5)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                  )
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}