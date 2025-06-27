using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Controllers
{
    internal class RoomController
    {
        
        public List<Rooms> ViewRooms()
        {
            List<Rooms> list = new List<Rooms>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM Rooms";
                var Readings = cmd.ExecuteReader();
                while (Readings.Read())
                {
                    list.Add(new Rooms
                    {
                        ID = Convert.ToInt32(Readings["ID"]),
                        Name = Readings["Name"].ToString(),
                    });
                }
            }
            return list;
        }
    }
}
