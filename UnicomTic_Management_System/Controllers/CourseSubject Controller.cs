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
    internal class CourseSubject_Controller
    {
        public void AddCourseSubject(CourseSubject courseSubject)
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "INSERT INTO CourseSubject(CoursesID, SubjectsID) VALUES(@cid,@sid)";
                cmd.Parameters.AddWithValue("@cid", courseSubject.CourseID);
                cmd.Parameters.AddWithValue("@sid", courseSubject.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCourseSubject(CourseSubject courseSubject) 
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "DELETE FROM CourseSubject WHERE CoursesID =@cid AND SubjectsID = @sid";
                cmd.Parameters.AddWithValue("@cid", courseSubject.CourseID);
                cmd.Parameters.AddWithValue("@sid", courseSubject.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
