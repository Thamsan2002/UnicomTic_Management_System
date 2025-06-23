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
    internal class SubjectController
    {
        public List<string> CheckEmptyVariables(Subjects subject)
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in subject.GetType().GetProperties())
            {
                if (prop.GetValue(subject) == null || string.IsNullOrWhiteSpace(prop.GetValue(subject).ToString()))
                {
                    Deta.Add(prop.Name);
                }
            }
            return Deta;

        }
        public int AddSubject(Subjects subject,int CourseID)
        {
            if (!string.IsNullOrWhiteSpace(subject.Name) && CourseID > 0 && subject.DepartmentID > 0 && subject.LecturerID >0) 
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    SQLiteCommand cmd = connect.CreateCommand();
                    cmd.CommandText = @"INSERT INTO Subjects(Name,DepartmentsID,LecturersID) VALUES(@name,@did,@lid);
                                        SELECT last_insert_rowid();";
                    cmd.Parameters.AddWithValue("@name", subject.Name);
                    cmd.Parameters.AddWithValue("@did", subject.DepartmentID);
                    cmd.Parameters.AddWithValue("@lid", subject.LecturerID);
                    int ID =Convert.ToInt32(cmd.ExecuteScalar());
                    return ID;
                }
            }
            else
            {
                MessageBox.Show("Fill Required Details!");
                return -1;
            }


        }
        public List<Subjects> ViewSubjects(string Search)
        {
            List<Subjects> list = new List<Subjects>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = @"SELECT Subjects.ID, Subjects.Name AS SubjectName, Subjects.DepartmentsID, Subjects.LecturersID,
                                    Departments.Name AS DepartmentName, Lecturers.LastName AS LecturerName,CourseSubject.CoursesID, Courses.Name AS CourseName
                                    FROM Subjects LEFT JOIN Departments ON Subjects.DepartmentsID = Departments.ID
                                    LEFT JOIN CourseSubject ON CourseSubject.SubjectsID = Subjects.ID
                                    LEFT JOIN Courses ON CourseSubject.CoursesID = Courses.ID
                                    LEFT JOIN Lecturers ON Subjects.LecturersID = Lecturers.ID";
                var reading = cmd.ExecuteReader();
                while (reading.Read())
                {
                    if (string.IsNullOrWhiteSpace(Search))
                    {
                        list.Add(new Subjects
                        {
                            Id = Convert.ToInt32(reading["ID"]),
                            Name = reading["SubjectName"].ToString(),
                            DepartmentID = reading["DepartmentsID"] != DBNull.Value ? Convert.ToInt32(reading["DepartmentsID"]) : 0,
                            DepartmentName = reading["DepartmentName"] != DBNull.Value ? reading["DepartmentName"].ToString() :"",
                            LecturerID =reading["LecturersID"] != DBNull.Value ? Convert.ToInt32(reading["LecturersID"]) :0,
                            LecturerName =reading["LecturerName"] != DBNull.Value ? reading["LecturerName"].ToString() : "",
                            CourseID = reading["CoursesID"] != DBNull.Value ? Convert.ToInt32(reading["CoursesID"]) : 0,
                            CourseName = reading["CourseName"] != DBNull.Value ? reading["CourseName"].ToString() : ""
                        });
                    }
                    else if (reading["SubjectName"].ToString().ToLower().Contains(Search))
                    {
                        list.Add(new Subjects
                        {
                            Id = Convert.ToInt32(reading["ID"]),
                            Name = reading["SubjectName"].ToString(),
                            DepartmentID = reading["DepartmentsID"] != DBNull.Value ? Convert.ToInt32(reading["DepartmentsID"]) : 0,
                            DepartmentName = reading["DepartmentName"] != DBNull.Value ? reading["DepartmentName"].ToString() : "",
                            LecturerID = reading["LecturersID"] != DBNull.Value ? Convert.ToInt32(reading["LecturersID"]) : 0,
                            LecturerName = reading["LecturerName"] != DBNull.Value ? reading["LecturerName"].ToString() : "",
                            CourseID = reading["CoursesID"] != DBNull.Value ? Convert.ToInt32(reading["CoursesID"]) : 0,
                            CourseName = reading["CourseName"] != DBNull.Value ? reading["CourseName"].ToString() : ""

                            //Id = Convert.ToInt32(reading["ID"]),
                            //Name = reading["SubjectName"].ToString(),
                            //DepartmentID = Convert.ToInt32(reading["DepartmentsID"]),
                            //DepartmentName = reading["DepartmentName"].ToString(),
                            //LecturerID = Convert.ToInt32(reading["LecturersID"]),
                            //LecturerName = reading["LecturerName"].ToString(),
                            //CourseID = Convert.ToInt32(reading["CoursesID"]),
                            //CourseName = reading["CourseName"].ToString()

                        });
                    }

                }
                return list;
            }
        }
        public List<Subjects> LoadSubjectsName(int CourseID) 
        {
            List<Subjects> list = new List<Subjects>();
            using(SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                SQLiteCommand cmd = connect.CreateCommand();
                if (CourseID == 0) 
                {
                    cmd.CommandText = "SELECT ID, Name FROM Subjects";
                    var Readings =cmd.ExecuteReader();
                    while (Readings.Read()) 
                    {
                        list.Add(new Subjects 
                        {
                            Id = Convert.ToInt32(Readings["ID"]),
                            Name = Readings["Name"].ToString()
                        });
                    }
                }
                else 
                {
                    cmd.CommandText = @"SELECT Subjects.ID, Subjects.Name FROM Subjects  
                                        LEFT JOIN CourseSubject ON CourseSubject.CoursesID = @cid
                                        WHERE Subjects.ID=CourseSubject.SubjectsID";
                    cmd.Parameters.AddWithValue("@cid",CourseID);
                    var Readings = cmd.ExecuteReader();
                    while (Readings.Read())
                    {
                        list.Add(new Subjects
                        {
                            Id = Convert.ToInt32(Readings["ID"]),
                            Name = Readings["Name"].ToString()
                        });
                    }

                }
            }
            return list;
        }
        public bool DeleteSubject(int SubjectID)
        {
            if (SubjectID > 0) 
            {
                using(SQLiteConnection connect = DatabaseManager.GetConnection()) 
                {
                    SQLiteCommand cmd = connect.CreateCommand();
                    cmd.CommandText = @"DELETE FROM Subjects WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", SubjectID);
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            else 
            {
                MessageBox.Show("Select a Subject!");
                return false;
            }
        }
    }
}
