using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace invoke_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
            Log("foo");
            Log("1");
            Log("2");
            Log("3");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Log("bar");
            Log("a");
            Log("b");
            Log("c");
        }

        delegate void Log_Handler(string s);

        private void Log(string s)
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + this.InvokeRequired + ":" + s);
            if (this.InvokeRequired)
            {
                BeginInvoke(new Log_Handler(Log), s);
                Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " LEAVE");
                return;
            }
            label1.Text += s;
            label1.Text += Environment.NewLine;
        }
    }
}
