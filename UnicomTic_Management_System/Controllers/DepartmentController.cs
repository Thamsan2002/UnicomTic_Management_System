using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Controllers
{
    internal class DepartmentController
    {
        public List<Departments> ViewDepartments()
        {
            List<Departments> list = new List<Departments>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using(SQLiteCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Departments";
                    using (var Readings = cmd.ExecuteReader())
                        while (Readings.Read())
                        {
                            list.Add(new Departments
                            {
                                ID = Readings.GetInt32(0),
                                Name = Readings.GetString(1)
                            });
                        }
                }
            }
            return list;
        }
        public void AddDepartment(Departments department)
        {
            if (!string.IsNullOrWhiteSpace(department.Name))
            {
                try
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        using (SQLiteCommand cmd = connect.CreateCommand()) 
                        {
                            cmd.CommandText = "INSERT INTO Departments(Name) VALUES(@name)";
                            cmd.Parameters.AddWithValue("@name", department.Name);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Department Added Successfully");
                    }
                }
                catch { MessageBox.Show("This Department Already Registered!"); }

            }
            else { MessageBox.Show("Enter a Department Name"); }
        }
        public void DeleteDepartment(Departments department)
        {
            if (!string.IsNullOrWhiteSpace(department.Name))
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    using (SQLiteCommand cmd = connect.CreateCommand()) 
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Courses WHERE DepartmentsID=@id";
                        cmd.Parameters.AddWithValue("@id", department.ID);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0) { MessageBox.Show($"This Department Have {count} Active Subject!"); }
                        else
                        {
                            cmd.CommandText = "DELETE FROM Departments WHERE ID=@id";
                            cmd.Parameters.AddWithValue("@id", department.ID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Department Deleted Successfully!");
                        }
                    }    
                }
            }
            else { MessageBox.Show("Choose a Department"); }
        }
    }
}
