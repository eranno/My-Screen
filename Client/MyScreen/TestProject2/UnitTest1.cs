using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataHandler;
using System.Data;
using System.Xml;

namespace TestProject2
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void myclassinitialize(testcontext testcontext) {

        //}
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{

        //}
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        //This test building the DB and insert single row to Friends table and query the Friends table
        //and get the inserted row.
        //this test compare the result with expected data.
        //this test should pass.
        [TestMethod]
        public void TestMethod1()
        {
            DBHandler.initDB();
            DBHandler.insert("INSERT INTO Friends(email, name) VALUES('unit@test.com' , 'test1')");
            DataTable table = DBHandler.getTable("SELECT * FROM Friends WHERE name='test1'");
            DataRow row = table.Rows[0];

            string email = row["email"].ToString();
            string name = row["name"].ToString();

            Assert.AreEqual(email, "unit@test.com");
            Assert.AreEqual(name, "test1");
            DBHandler.deleteDB();
        }
        //This test query the DataBase with invalid query , this test should fail!.
        [TestMethod]
        public void TestMethod2()
        {
            DBHandler.insert("SELECT * FROM Images WHERE invalid=1");
        }
    }
}
