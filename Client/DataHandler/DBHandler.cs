using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace DataHandler
{
    public class DBHandler
    { 
        private static SQLiteConnection sqliteCon;
        private static String dbName = "myScreen.s3db";
        private static String connectionString = @"Data Source=" + dbName;

        public static void initDB()
        {
            if (!Directory.Exists("Thumbnails"))
                 Directory.CreateDirectory("Thumbnails");
            if (!Directory.Exists("EncodedImages"))
                Directory.CreateDirectory("EncodedImages");
            bool isDbExist = File.Exists(dbName);
            sqliteCon = new SQLiteConnection(connectionString);
            sqliteCon.Open();
            if(!isDbExist)
                createTables();
        }

        private static void createTables()
        {
            string FriendsTableSQL = "CREATE TABLE [Friends] (" +
               "[email] TEXT PRIMARY KEY," +
               "[userId] TEXT NULL," +
               "[name] TEXT NULL" +
               ")";

            string ImagesTableSQL = "CREATE TABLE [Images] (" +
                "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                "[name] TEXT NULL," +
                "[idx] TEXT  NULL," +//The id of the encrypted image
                "[key] TEXT  NULL," +
                "[type] TEXT  NULL," +
                "[pathEncrypted] TEXT NULL," +
                "[pathThumb] TEXT NULL," +
                "[pathOriginal] TEXT NULL" +
                ")";

            string DecryptedImagesTableSQL = "CREATE TABLE [DecryptedImages] (" +
                "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                "[name] TEXT NULL," +
                "[type] TEXT  NULL," +
                "[pathThumb] TEXT NULL," +
                "[path] TEXT NULL" +
                ")";

            string AuthImagesTable = "CREATE TABLE [AuthImages] (" +
                "[imageId] INTEGER," +
                "[friendId] TEXT," +
                " FOREIGN KEY(imageId) REFERENCES Images(id)," +
                " FOREIGN KEY(friendId) REFERENCES Friends(email)," +
                " PRIMARY KEY(friendId , imageId)" +
                ")";

            string userPropertiesTable = "CREATE TABLE [UserProperties] (" +
                 "[email] TEXT PRIMARY KEY," +
                 "[userId] TEXT NULL," +
                 "[name] TEXT NULL," +
                 "[password] TEXT NOT NULL," +
                 "[securityCode] TEXT NULL," +
                 "[imageId] TEXT NULL" +
                 ")";


            

            using (SQLiteTransaction sqlTransaction = sqliteCon.BeginTransaction())
            {
                // Create the table
                SQLiteCommand createFriendCommand = new SQLiteCommand(FriendsTableSQL, sqliteCon);
                createFriendCommand.ExecuteNonQuery();
                createFriendCommand.Dispose();

                SQLiteCommand createImageCommand = new SQLiteCommand(ImagesTableSQL, sqliteCon);
                createImageCommand.ExecuteNonQuery();
                createImageCommand.Dispose();

                SQLiteCommand createAuthImagesCommand = new SQLiteCommand(AuthImagesTable, sqliteCon);
                createAuthImagesCommand.ExecuteNonQuery();
                createAuthImagesCommand.Dispose();

                SQLiteCommand createUserPropertiesCommand = new SQLiteCommand(userPropertiesTable, sqliteCon);
                createUserPropertiesCommand.ExecuteNonQuery();
                createUserPropertiesCommand.Dispose();

                SQLiteCommand createDecryptedImagesCommand = new SQLiteCommand(DecryptedImagesTableSQL, sqliteCon);
                createDecryptedImagesCommand.ExecuteNonQuery();
                createDecryptedImagesCommand.Dispose();

                // Commit the changes into the database
                sqlTransaction.Commit();
            } // end using
        }

        public static DataTable getTable(string query)
        {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, sqliteCon))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table); 
                    return table;
                }
                     
        }

        public static void updateTable(DataTable table , string query)
        {
            using (SQLiteTransaction txn = sqliteCon.BeginTransaction())
            {
                using (SQLiteDataAdapter dbAdapter = new SQLiteDataAdapter(query, sqliteCon))
                {
                    dbAdapter.InsertCommand = new SQLiteCommandBuilder(dbAdapter).GetInsertCommand(true);
                    dbAdapter.Update(table);
                }
                txn.Commit();
            }
        }

        public static String executeCmd(string query)
        {
            using (SQLiteTransaction txn = sqliteCon.BeginTransaction())
            {
                SQLiteCommand cmd = new SQLiteCommand(query, sqliteCon);
                try
                {
                    cmd.ExecuteNonQuery();
                    txn.Commit();
                }
                catch (SQLiteException e)
                {
                    cmd.Dispose();
                    return e.ToString();
                }
            }
            return null;
        }

        public static String insert(string query)
        {
            return executeCmd(query);
        }

        public static String showTables()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("******** Show Tables *************");
            sb.AppendLine();
            sb.AppendLine(" Friends Table: ");
            sb.AppendLine();
            DataTable dt = getTable("SELECT * FROM Friends");
            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("**     email: " + row["email"].ToString() + " |  name: " + row["name"].ToString() + " |  userId: " + row["userId"].ToString());
            }
            sb.AppendLine();


            sb.AppendLine("****************************");
            sb.AppendLine();
            sb.AppendLine(" Images Table: ");
            sb.AppendLine();
            DataTable dt2 = getTable("SELECT * FROM Images");
            foreach (DataRow row in dt2.Rows)
            {
                sb.AppendLine("**     id: " + row["id"].ToString() + " |  idx: " + row["idx"].ToString() 
                    + " |  name: " + row["name"].ToString() 
                    + " | key: " + row["key"].ToString() + " | type: " + row["type"].ToString() 
                    + " | pathEncrypted: " + row["pathEncrypted"].ToString()
                    + " | pathThumb: " + row["pathThumb"].ToString() + " | pathOriginal: " + row["pathOriginal"].ToString());
            }
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendLine("****************************");
            sb.AppendLine();
            sb.AppendLine("DecryptedImages Table: ");
            sb.AppendLine();
            DataTable dt5 = getTable("SELECT * FROM DecryptedImages");
            foreach (DataRow row in dt5.Rows)
            {
                sb.AppendLine("**     id: " + row["id"].ToString()
                    + " |  name: " + row["name"].ToString()
                    + " | type: " + row["type"].ToString()
                    + " | pathThumb: " + row["pathThumb"].ToString()
                    + " | path: " + row["path"].ToString());
            }
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendLine("****************************");
            sb.AppendLine();
            sb.AppendLine(" AuthImages Table: ");
            DataTable dt3 = getTable("SELECT * FROM AuthImages");
            foreach (DataRow row in dt3.Rows)
            {
                sb.AppendLine("**     imageId: " + row["imageId"].ToString()
                    + " | friendId: " + row["friendId"].ToString());
            }
            sb.AppendLine();

            sb.AppendLine("****************************");
            sb.AppendLine();
            sb.AppendLine(" UserProperties Table: ");
            sb.AppendLine();
            DataTable dt4 = getTable("SELECT * FROM UserProperties");
            foreach (DataRow row in dt4.Rows)
            {
                sb.AppendLine("**     email: " + row["email"].ToString()
                    + " | name: " + row["name"].ToString()
                    + " | password: " + row["password"].ToString()
                    + " | securityCode: " + row["securityCode"].ToString()
                    + " | userId: " + row["userId"].ToString()
                    + " | imageId: " + row["imageId"].ToString());
            }
            sb.AppendLine();
            sb.AppendLine("******** End ! Show Tables *************");
            return sb.ToString();
        }

        public static String fillWithDump()
        {
            List<string> dump = new List<string>(); 
            dump.Add("INSERT INTO Friends(email , name , userId) VALUES('noam185@gmail.com' ,'Noam Tzumie' , '12345')");
            dump.Add("INSERT INTO Friends(email , name , userId) VALUES('david@gmail.com' ,'David krantz' , '7890')");
            dump.Add("INSERT INTO Friends(email , name , userId) VALUES('ilan@gmail.com' , 'Ilan Ben Tal' , '534535')");
            dump.Add("INSERT INTO Friends(email , name , userId) VALUES('eran@gmail.com' , 'Eran Naor' , '34535')");

            //dump.Add("INSERT INTO Images(idx , name , key , type , pathEncrypted , pathThumb , pathOriginal) VALUES('index 1' , 'Desert' , '#$%2fffwe4533' , 'jpg' ,'c:\\cmyImages\\' , 'C:\\Users\\Public\\Pictures\\Sample Pictures\\thumbs\\Hydrangeas.png' , 'c:\\originalPath\\')");
            //dump.Add("INSERT INTO Images(idx , name , key , type , pathEncrypted , pathThumb , pathOriginal) "
            //    + "VALUES('index 2' , 'Island' , '#$%2fffwe4533' , 'jpg' ,'c:\\myImages\\' , 'C:\\Users\\Public\\Pictures\\Sample Pictures\\thumbs\\Chrysanthemum.png' , 'c:\\originalPath\\')");
            //dump.Add("INSERT INTO Images(idx , name , key , type , pathEncrypted , pathThumb , pathOriginal) "
            //    + "VALUES('index 3' , 'boy' , '#$%2fffwe4533' , 'jpg' ,'c:\\myImages\\' , 'C:\\Users\\Public\\Pictures\\Sample Pictures\\thumbs\\Desert.png' , 'c:\\originalPath\\')");

            //dump.Add("INSERT INTO AuthImages(imageId , friendId) VALUES('1', 'eran@gmail.com')");
            //dump.Add("INSERT INTO AuthImages(imageId , friendId) VALUES('2', 'eran@gmail.com')");
            //dump.Add("INSERT INTO AuthImages(imageId , friendId) VALUES('3', 'eran@gmail.com')");
            //dump.Add("INSERT INTO AuthImages(imageId , friendId) VALUES('1', 'noam185@gmail.com')");
            //dump.Add("INSERT INTO AuthImages(imageId , friendId) VALUES('2', 'noam185@gmail.com')");
            //dump.Add("INSERT INTO AuthImages(imageId , friendId) VALUES('3', 'ilan@gmail.com')");
            //dump.Add("INSERT INTO AuthImages(imageId , friendId) VALUES('1', 'ilan@gmail.com')");


            dump.Add("INSERT INTO UserProperties(email , name , password , securityCode , userId , imageId) VALUES('myComp@gmail.com', 'localhost' , '123456' , '187365543208213678653094' , 'userId' , '12')");

            foreach (string cmd in dump)
            {
                String msg = insert(cmd);
                if (msg != null)
                    return msg;
            }
            return null;
        }

        public static void deleteDB()
        {
            executeCmd("DROP TABLE  Friends");
            executeCmd("DROP TABLE  Images");
            executeCmd("DROP TABLE  AuthImages");
            executeCmd("DROP TABLE  UserProperties");
            executeCmd("DROP TABLE  DecryptedImages");
            createTables();
        }
    }
}
