using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Database_Uses;

namespace UnicomTic_Management_System.Models
{
    internal class LecturerStudent
    {
        public static void DeleteLecturerStudent(SQLiteConnection conn, int LecturerID)
        {
            SQLiteCommand comand = conn.CreateCommand();
            comand.CommandText = "DELETE FROM LecturerStudent WHERE LecturersID =@lid";
            comand.Parameters.AddWithValue("@lid", LecturerID);
            comand.ExecuteNonQuery();
        }
        public static void DeleteStudentLecturer(SQLiteConnection conn, int StudentID)
        {
            SQLiteCommand comand = conn.CreateCommand();
            comand.CommandText = "DELETE FROM LecturerStudent WHERE StudentsID =@sid";
            comand.Parameters.AddWithValue("@sid", StudentID);
            comand.ExecuteNonQuery();
        }
    }
}
