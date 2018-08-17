using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace CL_Module1.QuartzManage
{
    public class ModuleJob1 : IJob
    {
        public static bool isActive = true;
        public Task Execute(IJobExecutionContext context)
        {
            if (isActive)
                Console.WriteLine(DateTime.Now.ToString() + " JOB1");
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Job1 yönetici tarafından durduruldu.");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }


            return Task.FromResult(0);
        }
    }

    public class SomeScheduler
    {
        static IScheduler scheduler;
        public static async Task Start()
        {
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<ModuleJob1>().Build();

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