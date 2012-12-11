using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
             XmlDataDocument xmlData = new XmlDataDocument();
       public Form1()
        {
            InitializeComponent();
            xmlData.DataSet.ReadXml(@"C:\Users\Noam Tzumie\Documents\Visual Studio 2010\Projects\friends.xml");
            dataGridView1.DataSource = xmlData.DataSet;
            dataGridView1.DataMember = "friend";
          // dataGridView1.Columns[1].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
