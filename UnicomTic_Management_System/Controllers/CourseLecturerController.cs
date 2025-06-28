using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Controllers
{
    internal class CourseLecturerController
    {
        public void AddCourseLecturer(CourseLecturer courseLecturer) 
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = "INSERT OR IGNORE INTO CourseLecturer(CoursesID, LecturersID) VALUES(@cid,@lid)";
                    cmd.Parameters.AddWithValue("@cid", courseLecturer.CourseID);
                    cmd.Parameters.AddWithValue("@lid", courseLecturer.LecturerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteCourseLecturer(CourseLecturer courseLecturer) 
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = @"SELECT COUNT(*) FROM Subjects 
                                    JOIN CourseSubject ON Subjects.ID = CourseSubject.SubjectsID
                                    WHERE Subjects.LecturersID = @lid AND CourseSubject.CoursesID = @cid";
                    cmd.Parameters.AddWithValue("@lid", courseLecturer.LecturerID);
                    cmd.Parameters.AddWithValue("@cid", courseLecturer.CourseID);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        cmd.CommandText = "DELETE FROM CourseLecturer WHERE LecturersID =@Lid";
                        cmd.Parameters.AddWithValue("@Lid", courseLecturer.LecturerID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
