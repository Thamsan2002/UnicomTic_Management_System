using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Database_Uses
{
    internal class DatabaseManager
    {
        internal static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection("DATA SOURCE=unicomtic.db; VERSION=3;");
            connection.Open();
            return connection;
        }
    }
}
