using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Controllers
{
    internal class TimeTableController
    {
        public List<string> CheckEmptyVariables(TimeTables timeTable)
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in timeTable.GetType().GetProperties())
            {
                if (prop.GetValue(timeTable) == null || string.IsNullOrWhiteSpace(prop.GetValue(timeTable).ToString()))
                {
                    Deta.Add(prop.Name);
                }
                else if (prop.PropertyType == typeof(int) && Convert.ToInt32(prop.GetValue(timeTable)) == 0)
                {

                    Deta.Add(prop.Name);
                }
            }
            return Deta;
        }
        public bool AddTimeTable(TimeTables timetable)
        {
            bool result;
            if (!string.IsNullOrWhiteSpace(timetable.Date) && !string.IsNullOrWhiteSpace(timetable.StartTime) && !string.IsNullOrWhiteSpace(timetable.EndTime) &&
                timetable.DepartmentID != 0 && timetable.CourseID != 0 && timetable.SubjectID != 0 && timetable.HallID != 0)
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    SQLiteCommand cmd = connect.CreateCommand();
                    cmd.CommandText = @"INSERT INTO TimeTables(Date,StartTime,EndTime,DepartmentsID,CoursesID,SubjectsID,RoomsID) 
                                        VALUES(@date,@stime,@etime,@did,@cid,@sid,@rid)";
                    cmd.Parameters.AddWithValue("@date", timetable.Date);
                    cmd.Parameters.AddWithValue("@stime", timetable.StartTime);
                    cmd.Parameters.AddWithValue("@etime", timetable.EndTime);
                    cmd.Parameters.AddWithValue("@did", timetable.DepartmentID);
                    cmd.Parameters.AddWithValue("@cid", timetable.CourseID);
                    cmd.Parameters.AddWithValue("@sid", timetable.SubjectID);
                    cmd.Parameters.AddWithValue("@rid", timetable.HallID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully TimeTable Added");
                    result = true;
                }
            }
            else
            {
                MessageBox.Show("Fill All Details!");
                result = false;
            }
            return result;


        }
        public void UpdateTimeTable(TimeTables timetable)
        {
            if (!string.IsNullOrWhiteSpace(timetable.Date) && !string.IsNullOrWhiteSpace(timetable.StartTime) && !string.IsNullOrWhiteSpace(timetable.EndTime) &&
                timetable.DepartmentID != 0 && timetable.CourseID != 0 && timetable.SubjectID != 0 && timetable.HallID != 0)
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    using (SQLiteCommand cmd = connect.CreateCommand()) 
                    {
                        cmd.CommandText = @"UPDATE TimeTables SET Date =@date, StartTime =@stime, EndTime =@etime, DepartmentsID =@did,
                                        CoursesID =@cid, SubjectsID=@sid,RoomsID =@rid WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", timetable.ID);
                        cmd.Parameters.AddWithValue("@date", timetable.Date);
                        cmd.Parameters.AddWithValue("@stime", timetable.StartTime);
                        cmd.Parameters.AddWithValue("@etime", timetable.EndTime);
                        cmd.Parameters.AddWithValue("@did", timetable.DepartmentID);
                        cmd.Parameters.AddWithValue("@cid", timetable.CourseID);
                        cmd.Parameters.AddWithValue("@sid", timetable.SubjectID);
                        cmd.Parameters.AddWithValue("@rid", timetable.HallID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully TimeTable Updated");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Fill All Details!");
            }


        }
        public List<TimeTables> ViewTimeTables(string role, int UserID)
        {
            int CourseID = 0;
            if (role == "Student")
            {
                CourseID = StudentController.GetStudentCourseID(UserID);
            }
            List<TimeTables> list = new List<TimeTables>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = @"SELECT  TimeTables.ID, TimeTables.Date, TimeTables.StartTime,TimeTables.EndTime, TimeTables.DepartmentsID, TimeTables.CoursesID, TimeTables.SubjectsID, TimeTables.RoomsID,
                                    Departments.Name AS DepartmentName, Courses.Name AS CourseName, Subjects.Name AS SubjectName, Rooms.Name AS RoomName
                                    FROM TimeTables LEFT JOIN Departments ON TimeTables.DepartmentsID = Departments.ID
                                    LEFT JOIN Courses ON TimeTables.CoursesID = Courses.ID
                                    LEFT JOIN Subjects ON TimeTables.SubjectsID = Subjects.ID
                                    LEFT JOIN Rooms ON TimeTables.RoomsID = Rooms.ID";
                var reading = cmd.ExecuteReader();
                while (reading.Read())
                {
                    if (role != "Student")
                    {
                        list.Add(new TimeTables
                        {
                            ID = Convert.ToInt32(reading["ID"]),
                            Date = reading["Date"].ToString(),
                            StartTime = reading["StartTime"].ToString(),
                            EndTime = reading["EndTime"].ToString(),
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
                        list.Add(new TimeTables
                        {
                            ID = Convert.ToInt32(reading["ID"]),
                            Date = reading["Date"].ToString(),
                            StartTime = reading["StartTime"].ToString(),
                            EndTime = reading["EndTime"].ToString(),
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
                return list;
            }
        }
        public void DeleteTimeTable(int ID) 
        {
            DialogResult result = MessageBox.Show("Confirm Delete This TimeTable", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
                {
                    using (SQLiteCommand cmd = connect.CreateCommand()) 
                    {
                        cmd.CommandText = "DELETE FROM TimeTables WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("SuccessFully TimeTable Removed");
                    }
                    
                }
            }
        }
    }
}
