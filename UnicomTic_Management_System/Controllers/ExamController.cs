using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Controllers
{
    internal class ExamController
    {
        public List<string> CheckEmptyVariables(Exams exam)
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in exam.GetType().GetProperties())
            {
                if (prop.GetValue(exam) == null || string.IsNullOrWhiteSpace(prop.GetValue(exam).ToString()))
                {
                    Deta.Add(prop.Name);
                }
                else if (prop.PropertyType == typeof(int) && Convert.ToInt32(prop.GetValue(exam)) == 0)
                {

                    Deta.Add(prop.Name);
                }
            }
            return Deta;
        }
        public int AddExam(Exams exam)
        {
            int Id = 0;
            if (!string.IsNullOrWhiteSpace(exam.Date) && !string.IsNullOrWhiteSpace(exam.StartTime) && !string.IsNullOrWhiteSpace(exam.EndTime) &&
                exam.DepartmentID != 0 && exam.CourseID != 0 && exam.SubjectID != 0 && exam.HallID != 0)
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    SQLiteCommand cmd = connect.CreateCommand();
                    cmd.CommandText = @"INSERT INTO Exams(Date,StartTime,EndTime,Heading,DepartmentsID,CoursesID,SubjectsID,RoomsID) 
                                        VALUES(@date,@stime,@etime,@heding,@did,@cid,@sid,@rid);
                                        SELECT last_insert_rowid();";
                    cmd.Parameters.AddWithValue("@date", exam.Date);
                    cmd.Parameters.AddWithValue("@stime", exam.StartTime);
                    cmd.Parameters.AddWithValue("@etime", exam.EndTime);
                    cmd.Parameters.AddWithValue("@heding", exam.Heading);
                    cmd.Parameters.AddWithValue("@did", exam.DepartmentID);
                    cmd.Parameters.AddWithValue("@cid", exam.CourseID);
                    cmd.Parameters.AddWithValue("@sid", exam.SubjectID);
                    cmd.Parameters.AddWithValue("@rid", exam.HallID);
                    Id =Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show("Successfully Exam Added");
                }
            }
            else
            {
                MessageBox.Show("Fill All Details!");
            }
            return Id;


        }
        public List<Exams> ViewExam(string role, int UserID)
        {
            int CourseID = 0;
            if (role == "Student")
            {
                CourseID = StudentController.GetStudentCourseID(UserID);
            }
            List<Exams> list = new List<Exams>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = @"SELECT  Exams.ID, Exams.Date, Exams.StartTime,Exams.EndTime,Exams.Heading, Exams.DepartmentsID, Exams.CoursesID, Exams.SubjectsID, Exams.RoomsID,
                                    Departments.Name AS DepartmentName, Courses.Name AS CourseName, Subjects.Name AS SubjectName, Rooms.Name AS RoomName
                                    FROM Exams LEFT JOIN Departments ON Exams.DepartmentsID = Departments.ID
                                    LEFT JOIN Courses ON Exams.CoursesID = Courses.ID
                                    LEFT JOIN Subjects ON Exams.SubjectsID = Subjects.ID
                                    LEFT JOIN Rooms ON Exams.RoomsID = Rooms.ID";
                var reading = cmd.ExecuteReader();
                while (reading.Read())
                {
                    if (role != "Student")
                    {
                        list.Add(new Exams
                        {
                            ID = Convert.ToInt32(reading["ID"]),
                            Date = reading["Date"].ToString(),
                            StartTime = reading["StartTime"].ToString(),
                            EndTime = reading["EndTime"].ToString(),
                            Heading = reading["Heading"].ToString(),
                            DepartmentName = reading["DepartmentName"].ToString(),
                            DepartmentID = Convert.ToInt32(reading["DepartmentsID"]),
                            SubjectName = reading["SubjectName"].ToString(),
                            SubjectID = Convert.ToInt32(reading["SubjectsID"]),
                            CourseName = reading["CourseName"].ToString(),
                            CourseID = Convert.ToInt32(reading["CoursesID"]),
                            HallName = reading["RoomName"].ToString(),
                            HallID = Convert.ToInt32(reading["RoomsID"])
                        });
                    }
                    else if (reading["CoursesID"].ToString() == CourseID.ToString())
                    {
                        list.Add(new Exams
                        {
                            ID = Convert.ToInt32(reading["ID"]),
                            Date = reading["Date"].ToString(),
                            StartTime = reading["StartTime"].ToString(),
                            EndTime = reading["EndTime"].ToString(),
                            Heading = reading["Heading"].ToString(),
                            DepartmentName = reading["DepartmentName"].ToString(),
                            DepartmentID = Convert.ToInt32(reading["DepartmentsID"]),
                            SubjectName = reading["SubjectName"].ToString(),
                            SubjectID = Convert.ToInt32(reading["SubjectsID"]),
                            CourseName = reading["CourseName"].ToString(),
                            CourseID = Convert.ToInt32(reading["CoursesID"]),
                            HallName = reading["RoomName"].ToString(),
                            HallID = Convert.ToInt32(reading["RoomsID"])
                        });
                    }

                }
            }
            return list;
        }
        public void UpdateExam(Exams exam)
        {
            if (!string.IsNullOrWhiteSpace(exam.Date) && !string.IsNullOrWhiteSpace(exam.StartTime) && !string.IsNullOrWhiteSpace(exam.EndTime)
                && !string.IsNullOrWhiteSpace(exam.Heading) && exam.DepartmentID != 0 && exam.CourseID != 0 && exam.SubjectID != 0 && exam.HallID != 0)
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    using (SQLiteCommand cmd = connect.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Exams SET Date =@date, StartTime =@stime, EndTime =@etime, Heading =@heading,
                                            DepartmentsID =@did, CoursesID =@cid, SubjectsID=@sid,RoomsID =@rid WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", exam.ID);
                        cmd.Parameters.AddWithValue("@date", exam.Date);
                        cmd.Parameters.AddWithValue("@stime", exam.StartTime);
                        cmd.Parameters.AddWithValue("@etime", exam.EndTime);
                        cmd.Parameters.AddWithValue("@heading", exam.Heading);
                        cmd.Parameters.AddWithValue("@did", exam.DepartmentID);
                        cmd.Parameters.AddWithValue("@cid", exam.CourseID);
                        cmd.Parameters.AddWithValue("@sid", exam.SubjectID);
                        cmd.Parameters.AddWithValue("@rid", exam.HallID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Exam Updated");
                    }

                }
            }
            else
            {
                MessageBox.Show("Fill All Details!");
            }


        }
        public void DeleteExam(int ID)
        {
            DialogResult result = MessageBox.Show("Confirm Delete This Exam", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    SQLiteCommand cmd = connect.CreateCommand();
                    cmd.CommandText = "DELETE FROM Exams WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("SuccessFully Exam Removed");
                }
            }
        }
    }
}
