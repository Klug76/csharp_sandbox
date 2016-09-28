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
        SynchronizationContext sc_;
        public Form1()
        {
            InitializeComponent();
            sc_ = SynchronizationContext.Current;
            Debug.WriteLine("UI:" + Thread.CurrentThread.ManagedThreadId);
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
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + this.InvokeRequired + ": " + s);
            sc_.Post(Log_, s);
        }

        private void Log_(object data)
        {
            string s = data as string;
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + ": " + s);
            label1.Text += s;
            label1.Text += Environment.NewLine;
        }
    }
}
