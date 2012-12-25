using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DataHandler
{
    class DBHandler
    {
        private static SQLiteConnection sqliteCon;
        private static String connectionString =  @"Data Source=myScreen.s3db";

        public DBHandler()
        {
        }

        public static void initDB()
        {
            sqliteCon = new SQLiteConnection(connectionString);
            createTables();
        }

        private static void createTables()
        {
            string FriendsTableSQL = "CREATE TABLE [Friends] (" +
               "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
               "[name] TEXT NULL," +
               "[email] TEXT  NULL" +
               ")";

            string ImagesTableSQL = "CREATE TABLE [Images] (" +
                "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                "[idx] TEXT  NULL," +
                "[name] TEXT NULL," +
                "[key] TEXT  NULL," +
                "[type] TEXT  NULL," +
                "[pathEncrypted] TEXT NULL," +
                "[pathThumb] TEXT NULL," +
                "[pathOriginal] TEXT NULL" +
                ")";

            string AuthImagesTable = "CREATE TABLE [AuthImages] (" +
                "[imageId] INTEGER," +
                "[friendId] INTEGER," +
                " FOREIGN KEY(imageId) REFERENCES Images(id)," +
                " FOREIGN KEY(friendId) REFERENCES Friends(id)" +
                ")";

            string userPropertiesTable = "CREATE TABLE [userProperties] (" +
                 "[email] TEXT PRIMARY KEY," +
                 "[name] TEXT NULL," +
                 "[password] TEXT NOT NULL," +
                 "[securityCode] TEXT NULL" +
                 ")";


            sqliteCon.Open();

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

                // Commit the changes into the database
                sqlTransaction.Commit();
            } // end using

            // Close the database connection
            sqliteCon.Close();
        }

        public static DataTable getTable(String query)
        {
                sqliteCon.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, sqliteCon))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    sqliteCon.Close();   
                    return table;
                }
                     
        }

        public static void updateTable(DataTable table , String query)
        {
            sqliteCon.Open();
            using (SQLiteTransaction txn = sqliteCon.BeginTransaction())
            {
                using (SQLiteDataAdapter dbAdapter = new SQLiteDataAdapter(query, sqliteCon))
                {
                    dbAdapter.InsertCommand = new SQLiteCommandBuilder(dbAdapter).GetInsertCommand(true);
                    dbAdapter.Update(table);
                }
                txn.Commit();
            }
            sqliteCon.Close();
        }
    }
}
