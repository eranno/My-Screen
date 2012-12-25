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
    public partial class ShowDB : Form
    {
        public ShowDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dBdetalils = DBHandler.showTables();
            richTextBox1.Text = dBdetalils;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String msg = DBHandler.fillWithDump();
            if (msg != null)
                MessageBox.Show(msg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBHandler.deleteDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable t = DBHandler.getTable(txtQuery.Text);
            StringBuilder sb = new StringBuilder();
            foreach(DataRow row in t.Rows)
            {
                sb.Append("** ");
                for(int i=0; i<row.ItemArray.Count(); i++)
                    sb.Append(row[i] + "  |  ");
                sb.AppendLine();
            }
            richTextBox1.Text = sb.ToString();
        }
    }
}
