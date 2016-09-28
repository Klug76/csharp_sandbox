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

        private void Log(string s)
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + s);
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)
                    delegate { label1.Text = s; }
                    );
            }
            else
            {
                label1.Text = s;
            }
        }
    }
}
