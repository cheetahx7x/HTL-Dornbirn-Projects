﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _001_Ein_Auslesen_SQL_Database
{
    static class Program
    {
        public static string servername = "";
        public static string login = "";
        public static string password = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
            if (servername != "")
            {
                Application.Run(new MainForm());
            }
        }
    }
}
