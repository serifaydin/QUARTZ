using CoreJob.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace CoreJob.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFileWatcher();
            RunDLL("");
            Console.ReadKey();
        }

        static List<string> _moduleNameList = new List<string>();
        static Dictionary<Data, Thread> _threads = new Dictionary<Data, Thread>();

        private static void RunDLL(string dll)
        {
            EngineLibrary _lib = new EngineLibrary();
            int _threadSize = 1;
            foreach (IModule itemLibrary in _lib.Modules)
            {
                string moduleName = itemLibrary.ToString().Split('.')[1];
                if (isModule(moduleName))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(moduleName + " daha önceden çalıştırıldığı için, tekrar denenmedi.");
                    continue;
                }

                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Modül Adı : " + moduleName + " Çalıştırıldı.");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;

                itemLibrary.DoJob();
                _threadSize++;

                Console.WriteLine("--------");

                _moduleNameList.Add(moduleName);
            }
        }

        private static void RunMethodInSeparateThread(Action action, string moduleName, int _threadSize)
        {
            var thread = new Thread(new ThreadStart(action));
            thread.Start();

            Data _data = new Data
            {
                Id = _threadSize,
                GetName = moduleName
            };

            _threads.Add(_data, thread);
        }

        public static void CreateFileWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "Plugins";

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string metin = "File: " + e.FullPath + " " + e.ChangeType;
            Console.WriteLine(metin);
            RunDLL(e.Name.Split('.')[0]);
        }

        public static bool isModule(string moduleName)
        {
            if (_moduleNameList.Contains(moduleName))
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