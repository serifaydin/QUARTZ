using CL_Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace CA_MultiQuartz
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFileWatcher();
            RunDll("");
            Console.ReadLine();
        }

        static List<string> deneme = new List<string>();
        static Dictionary<Data, Thread> _threads = new Dictionary<Data, Thread>();
        private static void RunDll(string file)
        {
            MultiEngineLibrary multiLibrary = new MultiEngineLibrary("Libs");

            int _threadSize = 1;
            Thread thread = null;
            foreach (IJobModule item in multiLibrary.Modules)
            {
                string moduleName = item.ToString().Split('.')[0];
                if (isModule(moduleName))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(moduleName + " daha önceden çalıştırıldığı için, tekrar denenmedi.");
                    continue;
                }

                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Modül Adı : " + moduleName + " Çalıştırıldı.");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;

                thread = new Thread(new ThreadStart(item.DoJob));
                thread.Start();

                Data _data = new Data
                {
                    Id = _threadSize,
                    GetName = moduleName
                };

                _threads.Add(_data, thread);
                _threadSize++;

                Console.WriteLine("--------");

                deneme.Add(moduleName);
            }
        }

        public static void CreateFileWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "Libs";

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            //watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string metin = "File: " + e.FullPath + " " + e.ChangeType;
            Console.WriteLine(metin);
            RunDll(e.Name.Split('.')[0]);
        }

        public static bool isModule(string moduleName)
        {
            if (deneme.Contains(moduleName))
                return true;

            return false;
        }
    }

    public class Data
    {
        public int Id { get; set; }
        public string GetName { get; set; }
    }
}