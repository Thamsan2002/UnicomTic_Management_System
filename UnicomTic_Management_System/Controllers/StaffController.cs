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
    internal class StaffController: CommanUses
    {
        public List<string> CheckEmptyVariables(Staffs staff, string GMail)
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in staff.GetType().GetProperties())
            {
                if (prop.GetValue(staff) == null || string.IsNullOrWhiteSpace(prop.GetValue(staff).ToString()))
                {
                    Deta.Add(prop.Name);
                }
            }
            if (string.IsNullOrWhiteSpace(GMail)) { Deta.Add("Gmail"); }
            return Deta;

        }
        public List<Staffs> LoadStaff(string Search)
        {
            List<Staffs> list = new List<Staffs>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM Staffs";
                using (var Readings = cmd.ExecuteReader())
                {
                    while (Readings.Read())
                    {
                        if (string.IsNullOrWhiteSpace(Search))
                        {
                            list.Add(new Staffs
                            {
                                Id = Convert.ToInt32(Readings[0]),
                                Date = Readings[1].ToString(),
                                FirstName = Readings[2].ToString(),
                                LastName = Readings[3].ToString(),
                                Address = Readings[4].ToString(),
                                Phone = Readings[5].ToString(),
                                Gender = Readings[6].ToString(),
                                NicNo = Readings[7].ToString(),
                                Designation = Readings[8].ToString(),
                                Salary = Readings[9].ToString(),
                                UserID = Convert.ToInt32(Readings[10])
                            });
                        }
                        else
                        {
                            for (int j = 1; j <= 9; j++)
                            {
                                if (Readings[j].ToString().Contains(Search))
                                {
                                    list.Add(new Staffs
                                    {
                                        Id = Convert.ToInt32(Readings[0]),
                                        Date = Readings[1].ToString(),
                                        FirstName = Readings[2].ToString(),
                                        LastName = Readings[3].ToString(),
                                        Address = Readings[4].ToString(),
                                        Phone = Readings[5].ToString(),
                                        Gender = Readings[6].ToString(),
                                        NicNo = Readings[7].ToString(),
                                        Designation = Readings[8].ToString(),
                                        Salary = Readings[9].ToString(),
                                        UserID = Convert.ToInt32(Readings[10])
                                    });
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            return list;
        }
        public string StaffRegister(Staffs staff) 
        {
            if(!string.IsNullOrWhiteSpace(staff.FirstName) && !string.IsNullOrWhiteSpace(staff.LastName) && !string.IsNullOrWhiteSpace(staff.NicNo) 
                && !string.IsNullOrWhiteSpace(staff.Address) && !string.IsNullOrWhiteSpace(staff.Phone) && !string.IsNullOrWhiteSpace(staff.Designation) 
                && !string.IsNullOrWhiteSpace(Convert.ToString(staff.Salary)) && !string.IsNullOrWhiteSpace(staff.Gender)) 
            {
                staff.UserID = GetLastInsertedId();
                string PoneResult = PhoneValidation(staff.Phone);
                string NicResult = NicValidation(staff.NicNo);
                string SalaryResult = CurrencyValidation(staff.Salary);
                if (PoneResult == "Invalid")
                {
                    UserController.DeleteUser(staff.UserID);
                    return "Failed";
                }
                else if (NicResult == "Invalid")
                {
                    UserController.DeleteUser(staff.UserID);
                    return "Failed";
                }
                else if (SalaryResult == "Invalid") 
                {
                    UserController.DeleteUser(staff.UserID);
                    return "Failed";
                }
                else
                {
                    try
                    {
                        using (SQLiteConnection connect = DatabaseManager.GetConnection())
                        {
                            SQLiteCommand cmd = connect.CreateCommand();
                            cmd.CommandText = @"INSERT INTO Staffs(Date,FirstName,LastName,Address,Phone,Gender,NicNumber,Designation,Salary,UsersID)
                                        VALUES(@date,@firstname,@lastname,@address,@phone,@gender,@nic,@designation,@salary,@userid)";
                            cmd.Parameters.AddWithValue("@date", staff.Date);
                            cmd.Parameters.AddWithValue("@firstname", staff.FirstName);
                            cmd.Parameters.AddWithValue("@lastname", staff.LastName);
                            cmd.Parameters.AddWithValue("@address", staff.Address);
                            cmd.Parameters.AddWithValue("@phone", staff.Phone);
                            cmd.Parameters.AddWithValue("@gender", staff.Gender);
                            cmd.Parameters.AddWithValue("@nic", staff.NicNo);
                            cmd.Parameters.AddWithValue("@designation", staff.Designation);
                            cmd.Parameters.AddWithValue("@salary", Convert.ToDouble(staff.Salary));
                            cmd.Parameters.AddWithValue("@userid", staff.UserID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Staff Registered Successfully");
                            return "Success";
                        }
                    }
                    catch (SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        if (ex.Message.Contains("Phone")) { MessageBox.Show("This Mobile Number Already Registered!"); }
                        else if (ex.Message.Contains("NicNumber")) { MessageBox.Show("This NIC Number Already Registered!"); }
                        UserController.DeleteUser(staff.UserID);
                        return "Failed";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Details");
                UserController.DeleteUser(staff.UserID);
                return "Failed";
            }
        }
        public void DeleteStaff(Staffs staff)
        {
            if (staff.Id == 0) { MessageBox.Show("Select a Staff!"); }
            else
            {
                DialogResult result = MessageBox.Show("Confirm Delete This Staff", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        SQLiteCommand cmd = connect.CreateCommand();
                        cmd.CommandText = "DELETE FROM Staffs WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", staff.Id);
                        cmd.ExecuteNonQuery();
                    }
                    UserController.DeleteUser(staff.UserID);
                    MessageBox.Show("Staff Deleted Successfully");
                }
                
            }
        }
        public void UpdateStaff(Staffs staff)
        {
            if (!string.IsNullOrWhiteSpace(staff.FirstName) && !string.IsNullOrWhiteSpace(staff.LastName) && !string.IsNullOrWhiteSpace(staff.NicNo) &&
               !string.IsNullOrWhiteSpace(staff.Phone) && !string.IsNullOrWhiteSpace(staff.Gender) && !string.IsNullOrWhiteSpace(staff.Address) &&
               !string.IsNullOrWhiteSpace(staff.Designation) && !string.IsNullOrWhiteSpace(staff.Salary))
            {
                DialogResult result = MessageBox.Show("Make Changes for This Staff", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        using (SQLiteCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = @"UPDATE Staffs SET FirstName=@fname, LastName=@lname, NicNumber=@nic, Phone=@phone, Gender=@gender, Address=@address, Designation=@design, Salary=@salary WHERE ID=@id";
                            cmd.Parameters.AddWithValue("@id", staff.Id);
                            cmd.Parameters.AddWithValue("@fname", staff.FirstName);
                            cmd.Parameters.AddWithValue("@lname", staff.LastName);
                            cmd.Parameters.AddWithValue("@nic", staff.NicNo);
                            cmd.Parameters.AddWithValue("@phone", staff.Phone);
                            cmd.Parameters.AddWithValue("@gender", staff.Gender);
                            cmd.Parameters.AddWithValue("@address", staff.Address);
                            cmd.Parameters.AddWithValue("@design", staff.Designation);
                            cmd.Parameters.AddWithValue("@salary", staff.Salary);
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
