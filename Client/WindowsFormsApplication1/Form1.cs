using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using System.Data;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
       public Form1()
        {
           InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string dbConnectionString = @"Data Source=sample.s3db";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            sqliteCon.Open();

            // Define the SQL Create table statement
            string createFriendTableSQL = "CREATE TABLE [Friends] (" +
                "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                "[name] TEXT NULL," +
                "[email] TEXT  NULL" +
                ")";

            // Define the SQL Create table statement
            string createImageTableSQL = "CREATE TABLE [Images] (" +
                "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                "[idx] TEXT  NULL," +
                "[name] TEXT NULL," +
                "[key] TEXT  NULL," +
                "[type] TEXT  NULL," +
                "[pathEncrypted] TEXT NULL," +
                "[pathThumb] TEXT NULL," +
                "[pathOriginal] TEXT NULL" +
                ")";

            string createAuthImagesTable = "CREATE TABLE [AuthImages] (" +
                "[imageId] INTEGER," +
                "[friendId] INTEGER," +
                " FOREIGN KEY(imageId) REFERENCES Images(id)," +
                " FOREIGN KEY(friendId) REFERENCES Friends(id)" +
                ")";

            using (SQLiteTransaction sqlTransaction = sqliteCon.BeginTransaction())
            {
                // Create the table
                SQLiteCommand createFriendCommand = new SQLiteCommand(createFriendTableSQL , sqliteCon);
                createFriendCommand.ExecuteNonQuery();
                createFriendCommand.Dispose();
                

                SQLiteCommand createImageCommand = new SQLiteCommand(createImageTableSQL, sqliteCon);
                createImageCommand.ExecuteNonQuery();
                createImageCommand.Dispose();

                SQLiteCommand createAuthImageCommand = new SQLiteCommand(createAuthImagesTable, sqliteCon);
                createAuthImageCommand.ExecuteNonQuery();
                createAuthImageCommand.Dispose();

                // Commit the changes into the database
                sqlTransaction.Commit();
            } // end using

            // Close the database connection
            sqliteCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Performs an insert, change contents of sqlStatement to perform
            // update or delete.
           string sqlStatement1 = "INSERT INTO Friends(name, email) VALUES('Noam Tzumie', 'noam185@gmail.com')";
            string sqlStatement2 = "INSERT INTO Images(idx , name, key , type , pathEncrypted , pathThumb , pathOriginal) VALUES('izxc' ,'Desert' ,'','','','','')";
            string sqlStatement3 = "INSERT INTO AuthImages(imageId,friendId) VALUES(1,1)";
            string dbConnectionString = @"Data Source=sample.s3db";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            sqliteCon.Open();
            using (SQLiteTransaction sqlTransaction = sqliteCon.BeginTransaction())
            {
                //SQLiteCommand command1 = new SQLiteCommand(sqlStatement1, sqliteCon);
                //command1.ExecuteNonQuery();
                //sqlTransaction.Commit();
                // SQLiteCommand command2 = new SQLiteCommand(sqlStatement2, sqliteCon);
                //command2.ExecuteNonQuery();
                //sqlTransaction.Commit();
                 SQLiteCommand command3 = new SQLiteCommand(sqlStatement3, sqliteCon);
                command3.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Connect to database
            string dbConnectionString = @"Data Source=sample.s3db";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            sqliteCon.Open();

            // Execute query on database
            string selectSQL = "SELECT * FROM Images";
            SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, sqliteCon);
            SQLiteDataReader dataReader = selectCommand.ExecuteReader();
            DataTable dt = dataReader.GetSchemaTable();
            DataSet ds = dt.DataSet;
            // Iterate every record in the AppUser table
            while (dataReader.Read())
            {
                lblData.Text += "id: " + dataReader.GetInt32(0)
                     + " name: "  + dataReader.GetString(2) + "\n";
            }
            dataReader.Close();
            sqliteCon.Close();
        }
        DataTable t;
        private void button4_Click(object sender, EventArgs e)
        {
            DataRow dr = t.NewRow();
            dr["name"] = "tsuf";
            t.Rows.Add(dr);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populateList();
        }

        private void populateList()
        {
            using (SQLiteConnection sqliteCon = new SQLiteConnection(@"Data Source=sample.s3db"))
            {
                sqliteCon.Open();
                using (SQLiteDataAdapter a = new SQLiteDataAdapter("SELECT name FROM Images", sqliteCon))
                {
                    t =  new DataTable();
                    a.Fill(t);
                    dataGridView1.DataSource = t;
                    listBox1.DataSource = t;
                    listBox1.DisplayMember = "name";


                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
            String s = dataGridView1["name", e.RowIndex].ToString();
            if(s.Equals("tsuf"))
                MessageBox.Show("Row added with index: " + e.RowIndex + " and value: "+ s);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            
            using (
               SQLiteConnection con =
                   new SQLiteConnection(@"Data Source=sample.s3db"))
            {
                con.Open();
                int insertedRows;
                using (SQLiteTransaction txn = con.BeginTransaction())
                {
                    using (SQLiteDataAdapter dbAdapter = new SQLiteDataAdapter("SELECT id,name FROM Images", con))
                    {
                        dbAdapter.InsertCommand = new SQLiteCommandBuilder(dbAdapter).GetInsertCommand(true);
                        insertedRows = dbAdapter.Update(t);
                    }
                    txn.Commit();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            ImageList li = authImg();
            
            this.listView1.LargeImageList = li;
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;
            MessageBox.Show((String)li.Images[0].Tag);
            lvi.Text = "Tulip.jpg";
            listView1.Items.Add(lvi);
        }

        public ImageList authImg()
        {
            ImageList il = new ImageList();            
            il.ColorDepth = ColorDepth.Depth32Bit ;
            Image img = Image.FromFile("C:\\Users\\Public\\Pictures\\Sample Pictures\\Hydrangeas.jpg");
            img.Tag = "Hydrangeas.jpg";
            il.ImageSize = new Size(80, 80);
            il.Images.Add(img);
            MessageBox.Show((String) il.Images[0].Tag);
             //for (int i = 0; i < t.Rows.Count; i++)
             //{
             //    DataRow dr = t.Rows[i];
             //    String path = (String)dr["pathThumb"];
             //    Image img = Image.FromFile(path);
             //    il.ImageSize = new Size(80, 80);
             //    il.Images.Add(img);
             //}
             return il;
        }


    }
}
