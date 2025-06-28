using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Database_Uses;

namespace UnicomTic_Management_System.Controllers
{
    internal class LecturerStudentController
    {
        public void AddLecturerStudent(int CourseID, int StudentID)
        {   List<int> list = new List<int>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = "SELECT LecturersID FROM CourseLecturer WHERE CoursesID =@cid";
                    cmd.Parameters.AddWithValue("@cid", CourseID);
                    using (var Readings = cmd.ExecuteReader())
                        while (Readings.Read())
                        {
                            list.Add(Convert.ToInt32(Readings[0]));
                        }
                    foreach(int id in list)
                    {
                        cmd.CommandText = "INSERT INTO LecturerStudent(LecturersID,StudentsID) VALUES(@lid,@sid)";
                        cmd.Parameters.AddWithValue("@sid", StudentID);
                        cmd.Parameters.AddWithValue("@lid", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                
            }
        }
    }
}
