using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace CL_Module2.QuartzManage
{
    public class ModuleJob2 : IJob
    {
        public static bool isActive = true;
        public Task Execute(IJobExecutionContext context)
        {
            if (isActive)
                Console.WriteLine(DateTime.Now.ToString() + " JOB2");
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Job2 yönetici tarafından durduruldu.");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }

            return Task.FromResult(0);
        }
    }

    public class SomeScheduler
    {
        public static async Task Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<ModuleJob2>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                    //s.WithIntervalInHours(24)
                    s.WithIntervalInSeconds(2)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                  )
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}