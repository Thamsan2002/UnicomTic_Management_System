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
        public List<string> CheckEmptyVariables(Staffs staff)
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in staff.GetType().GetProperties())
            {
                if (prop.GetValue(staff) == null || string.IsNullOrWhiteSpace(prop.GetValue(staff).ToString()))
                {
                    Deta.Add(prop.Name);
                }
            }
            return Deta;

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
    }
}
