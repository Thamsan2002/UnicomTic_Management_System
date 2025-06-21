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
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT LecturersID FROM CourseLecturer WHERE CoursesID =@cid";
                cmd.Parameters.AddWithValue("@cid", CourseID);
                var Readings = cmd.ExecuteReader();
                while (Readings.Read())
                {
                    SQLiteCommand command = connect.CreateCommand();
                    command.CommandText = "INSERT INTO LecturerStudent(LecturersID,StudentsID) VALUES(@lid,@sid)";
                    command.Parameters.AddWithValue("@sid", StudentID);
                    command.Parameters.AddWithValue("@lid", Convert.ToInt32(Readings["LecturersID"]));
                    command.ExecuteNonQuery();
                    
                }
            }
        }
    }
}
