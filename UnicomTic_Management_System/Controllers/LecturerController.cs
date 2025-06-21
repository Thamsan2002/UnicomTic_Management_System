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
    internal class LecturerController :CommanUses
    {
        public List<string> CheckEmptyVariables(Lecturers lecturer)
        {
            List<string> Data = new List<string>();
            foreach (PropertyInfo prop in lecturer.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(int)) 
                {
                    if(Convert.ToInt32(prop.GetValue(lecturer)) == 0) { Data.Add(prop.Name); }
                }
                else if (prop.GetValue(lecturer) == null || string.IsNullOrWhiteSpace(prop.GetValue(lecturer).ToString()) )
                {
                    Data.Add(prop.Name);
                }
            }
            return Data;

        }
        public List<Lecturers> ViewLecturer(string departmentName)
        {
            List<Lecturers> list = new List<Lecturers>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = @"SELECT Lecturers.ID, Lecturers.LastName AS Name, Lecturers.DepartmentsID, Departments.Name AS DepartmentName
                                    FROM Lecturers LEFT JOIN Departments ON Lecturers.DepartmentsID = Departments.ID";
                var reading = cmd.ExecuteReader();
                while (reading.Read())
                {
                    if (string.IsNullOrWhiteSpace(departmentName))
                    {
                        list.Add(new Lecturers
                        {
                            ID = Convert.ToInt32(reading["ID"]),
                            LastName = reading["Name"].ToString()
                        });
                    }
                    else if (departmentName == reading["DepartmentName"].ToString())
                    {
                        list.Add(new Lecturers
                        {
                            ID = Convert.ToInt32(reading["ID"]),
                            LastName = reading["Name"].ToString()
                        });
                    }

                }
                return list;
            }
        }
        private string EmployeeNum() 
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT EmployeeNo FROM Lecturers ORDER BY Id DESC LIMIT 1;";
                object lastId = cmd.ExecuteScalar();
                if (lastId == null || lastId == DBNull.Value) { return "LEC1000"; }
                else
                {
                    return ($"LEC{ (Convert.ToInt32(lastId.ToString().Substring(3)) + 1).ToString()}");
                }
            }
        }
        public string LecturerRegister(Lecturers lecturer)
        {
            lecturer.UserID = GetLastInsertedId();
            if (!string.IsNullOrWhiteSpace(lecturer.FirstName) && !string.IsNullOrWhiteSpace(lecturer.LastName) && !string.IsNullOrWhiteSpace(lecturer.Address) && !string.IsNullOrWhiteSpace(lecturer.Phone)
                && !string.IsNullOrWhiteSpace(lecturer.Gender) && !string.IsNullOrWhiteSpace(lecturer.NicNo) && !string.IsNullOrWhiteSpace(lecturer.Salary) && lecturer.CourseID>0 && lecturer.DepartmentID>0)
            {
                string PoneResult = PhoneValidation(lecturer.Phone);
                string NicResult = NicValidation(lecturer.NicNo);
                string SalaryResult = CurrencyValidation(lecturer.Salary);
                if (PoneResult == "Invalid")
                {
                    UserController.DeleteUser(lecturer.UserID);
                    return "Failed";
                }
                else if (NicResult == "Invalid")
                {
                    UserController.DeleteUser(lecturer.UserID);
                    return "Failed";
                }
                else if (SalaryResult == "Invalid") 
                {
                    UserController.DeleteUser(lecturer.UserID);
                    return "Failed";
                }
                else
                {
                    lecturer.EmployeeNo = EmployeeNum();
                    try
                    {
                        using (SQLiteConnection connect = DatabaseManager.GetConnection())
                        {
                            SQLiteCommand cmd = connect.CreateCommand();
                            cmd.CommandText = @"INSERT INTO Lecturers(Date,FirstName,LastName,Phone,Address,NicNumber,Gender,EmployeeNo,Salary,DepartmentsID,UsersID)
                                        VALUES(@date,@firstname,@lastname,@phone,@address,@nic,@gender,@employeeno,@salary,@departmentid,@userid)";
                            cmd.Parameters.AddWithValue("@date", lecturer.Date);
                            cmd.Parameters.AddWithValue("@firstname", lecturer.FirstName);
                            cmd.Parameters.AddWithValue("@lastname", lecturer.LastName);
                            cmd.Parameters.AddWithValue("@phone", lecturer.Phone);
                            cmd.Parameters.AddWithValue("@address", lecturer.Address);
                            cmd.Parameters.AddWithValue("@nic", lecturer.NicNo);
                            cmd.Parameters.AddWithValue("@gender", lecturer.Gender);
                            cmd.Parameters.AddWithValue("@employeeno",lecturer.EmployeeNo);
                            cmd.Parameters.AddWithValue("@salary",lecturer.Salary);
                            //cmd.Parameters.AddWithValue("@courseid",lecturer.CourseID);
                            cmd.Parameters.AddWithValue("@departmentid",lecturer.DepartmentID);
                            cmd.Parameters.AddWithValue("@userid", lecturer.UserID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Lecturer Registered Successfully");
                            return "Success";
                        }
                    }
                    catch (SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        if (ex.Message.Contains("Phone")) { MessageBox.Show("This Mobile Number Already Registered!"); }
                        else if (ex.Message.Contains("NicNumber")) { MessageBox.Show("This NIC Number Already Registered!"); }
                        UserController.DeleteUser(lecturer.UserID);
                        return "Failed";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Details");
                UserController.DeleteUser(lecturer.UserID);
                return "Failed";
            }


        }
    }
}
