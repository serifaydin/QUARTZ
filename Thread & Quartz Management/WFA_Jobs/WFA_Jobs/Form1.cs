using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WFA_Jobs.Engine;

namespace WFA_Jobs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        JobManager jobManager = new JobManager();

        private void Form1_Load(object sender, EventArgs e)
        {
            jobManager.ExecuteAllJobs();

            foreach (KeyValuePair<Data, Thread> item in jobManager.GetThreadList())
            {
                chcThreandJobs.Items.Add(item.Key.Id + " - " + item.Key.GetName);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var item in chcThreandJobs.CheckedItems)
            {
                int id = Convert.ToInt32(item.ToString().Split('-')[0]);
                jobManager.ThreadEnd(id);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (var item in chcThreandJobs.CheckedItems)
            {
                int id = Convert.ToInt32(item.ToString().Split('-')[0]);
                jobManager.ThreadStart(id);
            }
        }

        private void chcThreandJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = chcThreandJobs.SelectedItem.ToString();
            int id = Convert.ToInt32(curItem.Split('-')[0]);

            Thread _thread = jobManager.ThreadJobState(id);

            lblThreadManageId.Text = _thread.ManagedThreadId.ToString();
            lblThreadPriority.Text = _thread.Priority.ToString();

            btnColorSetThread(_thread);
        }

        public void btnColorSetThread(Thread _thread)
        {
            switch (_thread.ThreadState)
            {
                case ThreadState.Running:
                    lblThreadState.Text = "Running";
                    btnStateColor.BackColor = Color.Green;
                    break;
                case ThreadState.StopRequested:
                    lblThreadState.Text = "StopRequested";
                    btnStateColor.BackColor = Color.Red;
                    break;
                case ThreadState.SuspendRequested:
                    lblThreadState.Text = "SuspendRequested";
                    btnStateColor.BackColor = Color.Red;
                    break;
                case ThreadState.Background:
                    lblThreadState.Text = "Background";
                    btnStateColor.BackColor = Color.Red;
                    break;
                case ThreadState.Unstarted:
                    lblThreadState.Text = "Unstarted";
                    btnStateColor.BackColor = Color.Red;
                    break;
                case ThreadState.Stopped:
                    lblThreadState.Text = "Stopped";
                    btnStateColor.BackColor = Color.Red;
                    break;
                case ThreadState.WaitSleepJoin:
                    lblThreadState.Text = "WaitSleepJoin";
                    btnStateColor.BackColor = Color.Green;
                    break;
                case ThreadState.Suspended:
                    lblThreadState.Text = "Suspended";
                    btnStateColor.BackColor = Color.Red;
                    break;
                case ThreadState.AbortRequested:
                    lblThreadState.Text = "AbortRequested";
                    btnStateColor.BackColor = Color.Red;
                    break;
                case ThreadState.Aborted:
                    lblThreadState.Text = "Aborted";
                    btnStateColor.BackColor = Color.Red;
                    break;
            }
        }
    }
}