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
        public List<string> CheckEmptyVariables(Admins admin,string GMail) 
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in admin.GetType().GetProperties())
            {
                if (prop.GetValue(admin)==null || string.IsNullOrWhiteSpace(prop.GetValue(admin).ToString()))
                {
                    Deta.Add(prop.Name);
                }
            }
            if (string.IsNullOrWhiteSpace(GMail)) { Deta.Add("Gmail"); }
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
        public List<Admins> LoadAdmins(string Search) 
        {
            List<Admins> list = new List<Admins>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM Admins";
                using (var Readings = cmd.ExecuteReader()) 
                {
                    while (Readings.Read())
                    {
                        if (string.IsNullOrWhiteSpace(Search))
                        {
                            list.Add(new Admins
                            {
                                Id = Convert.ToInt32(Readings[0]),
                                Date = Readings[1].ToString(),
                                FirstName = Readings[2].ToString(),
                                LastName = Readings[3].ToString(),
                                Address = Readings[4].ToString(),
                                Phone = Readings[5].ToString(),
                                Gender = Readings[6].ToString(),
                                NicNo = Readings[7].ToString(),
                                AccessLevel = Readings[8].ToString(),
                                UserID = Convert.ToInt32(Readings[9])
                            });
                        }
                        else
                        {
                            for (int j = 1; j <= 9; j++)
                            {
                                if (Readings[j].ToString().Contains(Search))
                                {
                                    list.Add(new Admins
                                    {
                                        Id = Convert.ToInt32(Readings[0]),
                                        Date = Readings[1].ToString(),
                                        FirstName = Readings[2].ToString(),
                                        LastName = Readings[3].ToString(),
                                        Address = Readings[4].ToString(),
                                        Phone = Readings[5].ToString(),
                                        Gender = Readings[6].ToString(),
                                        NicNo = Readings[7].ToString(),
                                        AccessLevel = Readings[8].ToString(),
                                        UserID = Convert.ToInt32(Readings[9])
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
        public void DeleteAdmin(Admins admin) 
        {
            if(admin.Id == 0) { MessageBox.Show("Select a Admin!"); }
            else
            {
                DialogResult result = MessageBox.Show("Confirm Delete This Admin", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        SQLiteCommand cmd = connect.CreateCommand();
                        cmd.CommandText = "DELETE FROM Admins WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", admin.Id);
                        cmd.ExecuteNonQuery();
                    }
                    UserController.DeleteUser(admin.UserID);
                    MessageBox.Show("Admin Deleted Successfully");
                }
                
            }
        }
        public void UpdateAdmin(Admins admin) 
        {
            if (!string.IsNullOrWhiteSpace(admin.FirstName) && !string.IsNullOrWhiteSpace(admin.LastName) && !string.IsNullOrWhiteSpace(admin.NicNo) &&
               !string.IsNullOrWhiteSpace(admin.Phone) && !string.IsNullOrWhiteSpace(admin.Gender) && !string.IsNullOrWhiteSpace(admin.Address))
            {
                DialogResult result = MessageBox.Show("Make Changes for This Admin", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        using(SQLiteCommand cmd = connect.CreateCommand()) 
                        {
                            cmd.CommandText = @"UPDATE Admins SET FirstName=@fname, LastName=@lname, NicNumber=@nic, Phone=@phone, Gender=@gender,
                            Address=@address WHERE ID=@id";
                            cmd.Parameters.AddWithValue("@id", admin.Id);
                            cmd.Parameters.AddWithValue("@fname", admin.FirstName);
                            cmd.Parameters.AddWithValue("@lname", admin.LastName);
                            cmd.Parameters.AddWithValue("@nic", admin.NicNo);
                            cmd.Parameters.AddWithValue("@phone", admin.Phone);
                            cmd.Parameters.AddWithValue("@gender", admin.Gender);
                            cmd.Parameters.AddWithValue("@address", admin.Address);
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
