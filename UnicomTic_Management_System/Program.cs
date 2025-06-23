using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Repositories;
using UnicomTic_Management_System.Views;

namespace UnicomTic_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Migration.CreateTable();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //if exists user table run login form or run admin register form

            var result = Migration.ExistsUsersTable();

            if ((int)result == 0)
            {
                Application.Run(new AdminRegisterForm("SuperAdmin"));
                Application.Run(new LoginForm());
            }
            else { Application.Run(new LoginForm()); }
            //Application.Run(new AddTimeTableForm());
        }
    }
}

