using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace CL_ItemTransferModule.JobProcess
{
    public class ItemTransferJob : IJob
    {
        Manager.ItemTransferManager itemManager = new Manager.ItemTransferManager();

        public static bool isActive = true;

        public Task Execute(IJobExecutionContext context)
        {
            if (isActive)
            {
                Console.WriteLine(DateTime.Now.ToString() + " ItemTransferJob");
                itemManager.ItemListMethod();
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ItemTransferJob yönetici tarafından durduruldu.");
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

            IJobDetail job = JobBuilder.Create<ItemTransferJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                    //s.WithIntervalInHours(24)
                    s.WithIntervalInSeconds(6)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                  )
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}