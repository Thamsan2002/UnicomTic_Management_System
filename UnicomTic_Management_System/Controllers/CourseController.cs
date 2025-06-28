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
    internal class CourseController
    {
        public List<string> CheckEmptyVariables(Courses course)
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in course.GetType().GetProperties())
            {
                if (prop.GetValue(course) == null || string.IsNullOrWhiteSpace(prop.GetValue(course).ToString()))
                {
                    Deta.Add(prop.Name);
                }
            }
            return Deta;

        }
        public List<Courses> ViewCourses(string departmentName)
        {
            List<Courses> list = new List<Courses>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = @"SELECT Courses.ID, Courses.Name AS CourseName, Courses.DepartmentsID, Departments.Name AS DepartmentName
                                    FROM Courses LEFT JOIN Departments ON Courses.DepartmentsID = Departments.ID";
                    using (var reading = cmd.ExecuteReader())
                        while (reading.Read())
                        {
                            if (string.IsNullOrWhiteSpace(departmentName))
                            {
                                list.Add(new Courses
                                {
                                    Id = Convert.ToInt32(reading["ID"]),
                                    Name = reading["CourseName"].ToString(),
                                    DepartmentID = Convert.ToInt32(reading["DepartmentsID"]),
                                    DepartmentName = reading["DepartmentName"].ToString(),
                                });
                            }
                            else if (departmentName == reading["DepartmentName"].ToString())
                            {
                                list.Add(new Courses
                                {
                                    Id = Convert.ToInt32(reading["ID"]),
                                    Name = reading["CourseName"].ToString(),
                                    DepartmentID = Convert.ToInt32(reading["DepartmentsID"]),
                                    DepartmentName = reading["DepartmentName"].ToString(),

                                });
                            }

                        }
                }
                
            }
            return list;
        }
        public void AddCourse(Courses course)
        {
            if (string.IsNullOrWhiteSpace(course.Name)) { MessageBox.Show("Enter a Course Name!"); }
            else if (course.DepartmentID==0) { MessageBox.Show("Choose a Department!"); }
            else
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    using (SQLiteCommand cmd = connect.CreateCommand()) 
                    {
                        cmd.CommandText = "INSERT INTO Courses(Name,DepartmentsID) VALUES(@name,@departmentid)";
                        cmd.Parameters.AddWithValue("@name", course.Name);
                        cmd.Parameters.AddWithValue("@departmentid", course.DepartmentID);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully Course Added");
                }
            }


        }
        public void DeleteCourse(Courses course)
        {
            if (!string.IsNullOrWhiteSpace(course.Name) && course.DepartmentID >0 && course.Id >0)
            {
                using(SQLiteConnection connect = DatabaseManager.GetConnection()) 
                {
                    using (SQLiteCommand cmd = connect.CreateCommand()) 
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Subjects WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", course.Id);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0) { MessageBox.Show($"Delete Failed!\nThis Course Have Active Subjects"); }
                        else
                        {
                            cmd.CommandText = "DELETE FROM Courses WHERE ID=@id";
                            cmd.Parameters.AddWithValue("@id", course.Id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully.");
                        }
                    }
                }
            }
            else{ MessageBox.Show("Select a Course to Delete!"); }
        }
    }
}
