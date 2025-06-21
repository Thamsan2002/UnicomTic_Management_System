using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;
using UnicomTic_Management_System.Views;

namespace UnicomTic_Management_System.Controllers
{
    internal class AdminController : CommanUses
    {
        public List<string> CheckEmptyVariables(Admins admin) 
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in admin.GetType().GetProperties())
            {
                if (prop.GetValue(admin)==null || string.IsNullOrWhiteSpace(prop.GetValue(admin).ToString()))
                {
                    Deta.Add(prop.Name);
                }
            }
            return Deta;
                
        }
        public string AdminRegister(Admins admin) 
        {
            admin.UserID = GetLastInsertedId();
            if (!string.IsNullOrWhiteSpace(admin.FirstName) && !string.IsNullOrWhiteSpace(admin.LastName) && !string.IsNullOrWhiteSpace(admin.Address) && !string.IsNullOrWhiteSpace(admin.Phone)
                && !string.IsNullOrWhiteSpace(admin.Gender) && !string.IsNullOrWhiteSpace(admin.NicNo))
            {
                string PoneResult = PhoneValidation(admin.Phone);
                string NicResult = NicValidation(admin.NicNo);
                if (PoneResult == "Invalid")
                {
                    UserController.DeleteUser(admin.UserID);
                    return "Failed";
                }
                else if (NicResult == "Invalid")
                {
                    UserController.DeleteUser(admin.UserID);
                    return "Failed";
                }
                else
                {
                    try
                    {
                        using (SQLiteConnection connect = DatabaseManager.GetConnection())
                        {
                            SQLiteCommand cmd = connect.CreateCommand();
                            cmd.CommandText = @"INSERT INTO Admins(Date,FirstName,LastName,Phone,Address,NicNumber,Gender,AccessLevel,UsersID)
                                        VALUES(@date,@firstname,@lastname,@phone,@address,@nic,@gender,@accesslevel,@userid)";
                            cmd.Parameters.AddWithValue("@date", admin.Date);
                            cmd.Parameters.AddWithValue("@firstname", admin.FirstName);
                            cmd.Parameters.AddWithValue("@lastname", admin.LastName);
                            cmd.Parameters.AddWithValue("@phone", admin.Phone);
                            cmd.Parameters.AddWithValue("@address", admin.Address);
                            cmd.Parameters.AddWithValue("@nic", admin.NicNo);
                            cmd.Parameters.AddWithValue("@gender", admin.Gender);
                            cmd.Parameters.AddWithValue("accesslevel", admin.AccessLevel);
                            cmd.Parameters.AddWithValue("@userid", admin.UserID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Admin Registered Successfully");
                            return "Success";
                        }
                    }
                    catch (SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        if (ex.Message.Contains("Phone")) { MessageBox.Show("This Mobile Number Already Registered!"); }
                        else if (ex.Message.Contains("NicNumber")) { MessageBox.Show("This NIC Number Already Registered!"); }
                        UserController.DeleteUser(admin.UserID);
                        return "Failed";
                    }
                }
            }
            else 
            {
                MessageBox.Show("Please Fill All Details");
                UserController.DeleteUser(admin.UserID);
                return "Failed";
            }
            
            
        }
    }
}
