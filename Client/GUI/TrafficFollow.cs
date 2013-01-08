using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHandler;

namespace GUI
{
    public partial class TrafficFollow : Form
    {
        public TrafficFollow()
        {
            InitializeComponent();
            output.Text = "Catch all URLs: " + Environment.NewLine;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true) {
                int i = 0;
                string  res = Messages.read();
                if (res != null)
                    backgroundWorker1.ReportProgress(i, res);
                    
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string res = e.UserState as string;
            output.Text += res + Environment.NewLine + Environment.NewLine;
        }
    }
}
