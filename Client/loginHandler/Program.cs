using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataHandler;

namespace loginHandler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBHandler.initDB();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }
}
