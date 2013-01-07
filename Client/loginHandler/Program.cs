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
<<<<<<< HEAD
            int i = 0;
=======
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
            DBHandler.initDB();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }
}
