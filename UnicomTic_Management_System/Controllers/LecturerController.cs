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
        public List<string> CheckEmptyVariables(Lecturers lecturer, string GMail)
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
            if (string.IsNullOrWhiteSpace(GMail)) { Data.Add("Gmail"); }
            return Data;

        }
        public List<Lecturers> ViewLecturer(string departmentName)
        {
            List<Lecturers> list = new List<Lecturers>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
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
                }
                
                return list;
            }
        }
        private string EmployeeNum() 
        {
            string Emplyeenum;
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = "SELECT EmployeeNo FROM Lecturers ORDER BY Id DESC LIMIT 1;";
                    object lastId = cmd.ExecuteScalar();
                    if (lastId == null || lastId == DBNull.Value) { Emplyeenum = "LEC1000"; }
                    else
                    {
                        Emplyeenum =($"LEC{(Convert.ToInt32(lastId.ToString().Substring(3)) + 1).ToString()}");
                    }
                }
            }
            return Emplyeenum ;
        }
        public List<Lecturers> LoadLecturer(string Search)
        {
            List<Lecturers> list = new List<Lecturers>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = @"SELECT Lecturers.* , Departments.Name AS DepartmentName, Lecturers.DepartmentsID AS DepartmentID FROM Lecturers
                                    LEFT JOIN Departments ON Departments.ID = Lecturers.DepartmentsID";
                    using (var Readings = cmd.ExecuteReader())
                    {
                        while (Readings.Read())
                        {
                            if (string.IsNullOrWhiteSpace(Search))
                            {
                                list.Add(new Lecturers
                                {
                                    ID = Convert.ToInt32(Readings["ID"]),
                                    Date = Readings["Date"].ToString(),
                                    FirstName = Readings["FirstName"].ToString(),
                                    LastName = Readings["LastName"].ToString(),
                                    Address = Readings["Address"].ToString(),
                                    Phone = Readings["Phone"].ToString(),
                                    Gender = Readings["Gender"].ToString(),
                                    NicNo = Readings["NicNumber"].ToString(),
                                    EmployeeNo = Readings["EmployeeNo"].ToString(),
                                    Salary = Readings["Salary"].ToString(),
                                    UserID = Convert.ToInt32(Readings["UsersID"]),
                                    DepartmentID = Convert.ToInt32(Readings["DepartmentID"]),
                                    DepartmentName = Readings["DepartmentName"].ToString()
                                });
                            }
                            else
                            {
                                for (int j = 1; j <= 9; j++)
                                {
                                    if (Readings[j].ToString().Contains(Search) || Readings["DepartmentName"].ToString().Contains(Search))
                                    {
                                        list.Add(new Lecturers
                                        {
                                            ID = Convert.ToInt32(Readings["ID"]),
                                            Date = Readings["Date"].ToString(),
                                            FirstName = Readings["FirstName"].ToString(),
                                            LastName = Readings["LastName"].ToString(),
                                            Address = Readings["Address"].ToString(),
                                            Phone = Readings["Phone"].ToString(),
                                            Gender = Readings["Gender"].ToString(),
                                            NicNo = Readings["NicNumber"].ToString(),
                                            EmployeeNo = Readings["EmployeeNo"].ToString(),
                                            Salary = Readings["Salary"].ToString(),
                                            DepartmentID = Convert.ToInt32(Readings["DepartmentID"]),
                                            DepartmentName = Readings["DepartmentName"].ToString(),
                                            UserID = Convert.ToInt32(Readings["UsersID"])
                                        });
                                        break;
                                    }
                                }
                            }

                        }
                    }
                }
                
            }
            return list;
        }
        public string LecturerRegister(Lecturers lecturer)
        {
            string status;
            lecturer.UserID = GetLastInsertedId();
            if (!string.IsNullOrWhiteSpace(lecturer.FirstName) && !string.IsNullOrWhiteSpace(lecturer.LastName) && !string.IsNullOrWhiteSpace(lecturer.Address) && !string.IsNullOrWhiteSpace(lecturer.Phone)
                && !string.IsNullOrWhiteSpace(lecturer.Gender) && !string.IsNullOrWhiteSpace(lecturer.NicNo) && !string.IsNullOrWhiteSpace(lecturer.Salary) && lecturer.DepartmentID>0)
            {
                string PoneResult = PhoneValidation(lecturer.Phone);
                string NicResult = NicValidation(lecturer.NicNo);
                string SalaryResult = CurrencyValidation(lecturer.Salary);
                if (PoneResult == "Invalid")
                {
                    UserController.DeleteUser(lecturer.UserID);
                    status = "Failed";
                }
                else if (NicResult == "Invalid")
                {
                    UserController.DeleteUser(lecturer.UserID);
                    status = "Failed";
                }
                else if (SalaryResult == "Invalid") 
                {
                    UserController.DeleteUser(lecturer.UserID);
                    status = "Failed";
                }
                else
                {
                    lecturer.EmployeeNo = EmployeeNum();
                    try
                    {
                        using (SQLiteConnection connect = DatabaseManager.GetConnection())
                        {
                            using (SQLiteCommand cmd = connect.CreateCommand()) 
                            {
                                cmd.CommandText = @"INSERT INTO Lecturers(Date,FirstName,LastName,Phone,Address,NicNumber,Gender,EmployeeNo,Salary,DepartmentsID,UsersID)
                                        VALUES(@date,@firstname,@lastname,@phone,@address,@nic,@gender,@employeeno,@salary,@departmentid,@userid)";
                                cmd.Parameters.AddWithValue("@date", lecturer.Date);
                                cmd.Parameters.AddWithValue("@firstname", lecturer.FirstName);
                                cmd.Parameters.AddWithValue("@lastname", lecturer.LastName);
                                cmd.Parameters.AddWithValue("@phone", lecturer.Phone);
                                cmd.Parameters.AddWithValue("@address", lecturer.Address);
                                cmd.Parameters.AddWithValue("@nic", lecturer.NicNo);
                                cmd.Parameters.AddWithValue("@gender", lecturer.Gender);
                                cmd.Parameters.AddWithValue("@employeeno", lecturer.EmployeeNo);
                                cmd.Parameters.AddWithValue("@salary", lecturer.Salary);
                                cmd.Parameters.AddWithValue("@departmentid", lecturer.DepartmentID);
                                cmd.Parameters.AddWithValue("@userid", lecturer.UserID);
                                cmd.ExecuteNonQuery();
                            }
                            
                            MessageBox.Show("Lecturer Registered Successfully");
                            status = "Success";
                        }
                    }
                    catch (SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        if (ex.Message.Contains("Phone")) { MessageBox.Show("This Mobile Number Already Registered!"); }
                        else if (ex.Message.Contains("NicNumber")) { MessageBox.Show("This NIC Number Already Registered!"); }
                        UserController.DeleteUser(lecturer.UserID);
                        status = "Failed";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Details");
                UserController.DeleteUser(lecturer.UserID);
                status = "Failed";
            }
            return status;


        }
        public void DeleteLecturer(Lecturers lecturer)
        {
            int count = 0;
            if (lecturer.ID == 0) { MessageBox.Show("Select a Staff!"); }
            else
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    using (SQLiteCommand cmd = connect.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Subjects WHERE LecturersID=@lid";
                        cmd.Parameters.AddWithValue("@lid", lecturer.ID);
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                        if (0 < count) { MessageBox.Show($"This Lecturer Teaching {count} Subjects Now\nRemove Subject First! "); }
                        else
                        {
                            DialogResult result = MessageBox.Show("Confirm Delete This Staff", "Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                using (SQLiteCommand cmd = connect.CreateCommand()) 
                                {
                                    cmd.CommandText = "DELETE FROM Lecturers WHERE ID=@id";
                                    cmd.Parameters.AddWithValue("@id", lecturer.ID);
                                    cmd.ExecuteNonQuery();
                                }
                                LecturerStudent.DeleteLecturerStudent(connect, lecturer.ID);
                                UserController.DeleteUser(lecturer.UserID);
                                MessageBox.Show("Lecture Deleted Successfully");
                            }

                        }
                    
                }
                
            }
        }
        public void UpdateLecturer(Lecturers Lecturer)
        {
            if (!string.IsNullOrWhiteSpace(Lecturer.FirstName) && !string.IsNullOrWhiteSpace(Lecturer.LastName) && !string.IsNullOrWhiteSpace(Lecturer.NicNo) &&
               !string.IsNullOrWhiteSpace(Lecturer.Phone) && !string.IsNullOrWhiteSpace(Lecturer.Gender) && !string.IsNullOrWhiteSpace(Lecturer.Address) &&
               !string.IsNullOrWhiteSpace(Lecturer.DepartmentName) && !string.IsNullOrWhiteSpace(Lecturer.Salary))
            {
                DialogResult result = MessageBox.Show("Make Changes for This Lecturer", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        using (SQLiteCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = @"UPDATE Lecturers SET FirstName=@fname, LastName=@lname, NicNumber=@nic, Phone=@phone, Gender=@gender, Address=@address, DepartmentsID=@did, Salary=@salary WHERE ID=@id";
                            cmd.Parameters.AddWithValue("@id", Lecturer.ID);
                            cmd.Parameters.AddWithValue("@fname", Lecturer.FirstName);
                            cmd.Parameters.AddWithValue("@lname", Lecturer.LastName);
                            cmd.Parameters.AddWithValue("@nic", Lecturer.NicNo);
                            cmd.Parameters.AddWithValue("@phone", Lecturer.Phone);
                            cmd.Parameters.AddWithValue("@gender", Lecturer.Gender);
                            cmd.Parameters.AddWithValue("@address", Lecturer.Address);
                            cmd.Parameters.AddWithValue("@did", Lecturer.DepartmentID);
                            cmd.Parameters.AddWithValue("@salary", Lecturer.Salary);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Updated Successfully");
                        }
                    }
                }
            }
            else { MessageBox.Show("Fill All Details!"); }
        }
    }
}
