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
    internal class StudentSubjectController
    {
        public void AddStudentSubject(int CourseID,int StudentID) 
        {
            List<int> list = new List<int>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = "SELECT SubjectsID FROM CourseSubject WHERE CoursesID =@cid";
                    cmd.Parameters.AddWithValue("@cid", CourseID);
                    using (var Readings = cmd.ExecuteReader())
                        while (Readings.Read())
                        {
                            list.Add(Convert.ToInt32(Readings[0]));
                        }
                    foreach (int id in list)
                    {
                        cmd.CommandText = "INSERT INTO StudentSubject(StudentsID,SubjectsID) VALUES(@stid,@suid)";
                        cmd.Parameters.AddWithValue("@stid", StudentID);
                        cmd.Parameters.AddWithValue("@suid", id);
                        cmd.ExecuteNonQuery();
                    }
                }  
            }
        }
        public static void DeleteStudentSubject(SQLiteConnection conn, int StudentID)
        {
            using (SQLiteCommand newcomand = conn.CreateCommand()) 
            {
                newcomand.CommandText = "DELETE FROM StudentSubject WHERE StudentsID =@sid";
                newcomand.Parameters.AddWithValue("@sid", StudentID);
                newcomand.ExecuteNonQuery();
            }
        }
    }
}
