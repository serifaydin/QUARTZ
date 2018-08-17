using CL_Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WFA_MultiQuartz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        List<string> _moduleNameList = new List<string>();
        Dictionary<Data, IJobModule> moduleList = new Dictionary<Data, IJobModule>();

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateFileWatcher();
            RunDll("");
        }

        private void RunDll(string file)
        {
            try
            {
                MultiEngineLibrary multiLibrary = new MultiEngineLibrary("Libs");

                int _moduleId = 1;
                foreach (IJobModule item in multiLibrary.Modules)
                {
                    string moduleName = item.ToString().Split('.')[0];
                    if (isModule(moduleName))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(moduleName + " daha önceden çalıştırıldığı için, tekrar denenmedi.");
                        continue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Modül Adı : " + moduleName + " Çalıştırıldı.");
                    }

                    Console.BackgroundColor = ConsoleColor.DarkMagenta;

                    item.DoJob();

                    Data _data = new Data
                    {
                        Id = _moduleId,
                        GetName = moduleName
                    };
                    moduleList.Add(_data, item);

                    listBox1.Items.Add(_moduleId + " - " + moduleName);

                    _moduleId++;
                    _moduleNameList.Add(moduleName);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void CreateFileWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "Libs";

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string metin = "File: " + e.FullPath + " " + e.ChangeType;
            Console.WriteLine(metin);
            RunDll(e.Name.Split('.')[0]);
        }

        public bool isModule(string moduleName)
        {
            if (_moduleNameList.Contains(moduleName))
                return true;

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sItem = listBox1.SelectedItem.ToString();

            IJobModule th = moduleList.SingleOrDefault(s => s.Key.Id == Convert.ToInt32(sItem.Split('-')[0])).Value;
            th.JobPause();

            label1.Text = "False";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sItem = listBox1.SelectedItem.ToString();

            IJobModule th = moduleList.SingleOrDefault(s => s.Key.Id == Convert.ToInt32(sItem.Split('-')[0])).Value;
            th.JobResume();

            label1.Text = "True";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sItem = listBox1.SelectedItem.ToString();
            IJobModule th = moduleList.SingleOrDefault(s => s.Key.Id == Convert.ToInt32(sItem.Split('-')[0])).Value;

            label1.Text = th.IsRepeatable.ToString();
        }
    }
    public class Data
    {
        public int Id { get; set; }
        public string GetName { get; set; }
    }
}