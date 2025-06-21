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
            using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT SubjectsID FROM CourseSubject WHERE CoursesID =@cid";
                cmd.Parameters.AddWithValue("@cid",CourseID);
                var Readings = cmd.ExecuteReader();
                while (Readings.Read()) 
                {
                    SQLiteCommand command = connect.CreateCommand();
                    command.CommandText = "INSERT INTO StudentSubject(StudentsID,SubjectsID) VALUES(@stid,@suid)";
                    command.Parameters.AddWithValue("@stid", StudentID);
                    command.Parameters.AddWithValue("@suid", Convert.ToInt32(Readings["SubjectsID"]));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
