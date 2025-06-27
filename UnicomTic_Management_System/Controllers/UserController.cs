using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;
using UnicomTic_Management_System.Repositories;
using UnicomTic_Management_System.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicomTic_Management_System.Controllers
{
    internal class UserController : CommanUses
    {

        public string SaveUser(Users user) 
        {
            string process;
            if (!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Gmail) && 
                !string.IsNullOrWhiteSpace(user.CreatedDate) && !string.IsNullOrWhiteSpace(user.UserNameCreateType)) 
            {
                 string GmailResult = GmailValidation(user.Gmail);
                if (GmailResult == "Invalid") { process = "Failed"; }
                else
                {
                    bool status =true;
                    while (status) 
                    {
                        if (user.UserNameCreateType == "Manual")
                        {
                            using (UserCreation userCreation = new UserCreation())
                            {
                                if (userCreation.ShowDialog() == DialogResult.OK)
                                {
                                    user.UserName = userCreation.Username;
                                    user.Password = userCreation.Password;
                                }
                                else
                                {
                                    MessageBox.Show("User Creation Cancelled!");
                                    process ="Failed";
                                }
                            }
                        }
                        if (user.Password == null) { user.Password = GeneratePassCode().ToString(); }
                        using (SQLiteConnection connection = DatabaseManager.GetConnection())
                        {
                            try
                            {
                                SQLiteCommand CMD = connection.CreateCommand();
                                CMD.CommandText = @"INSERT INTO Users(Name,GMail,Password,Role,CreatedDate,UpdatedDate) 
                                    VALUES(@name,@gmail,@password,@role,@createddate,@updateddate)";
                                CMD.Parameters.AddWithValue("@name", user.UserName);
                                CMD.Parameters.AddWithValue("@gmail", user.Gmail);
                                CMD.Parameters.AddWithValue("@password", user.Password);
                                CMD.Parameters.AddWithValue("@role", user.Role);
                                CMD.Parameters.AddWithValue("@createddate", user.CreatedDate);
                                CMD.Parameters.AddWithValue("@updateddate", user.UpdatedDate);
                                CMD.ExecuteNonQuery();
                                status = false;

                                return ($"User Created Successfully\nYour UserName is :{user.UserName}\nYour Password is :{user.Password}");
                            }
                            catch(SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint)
                            {
                                MessageBox.Show("This UserName Already Taken!");
                                using (UserCreation userCreation = new UserCreation(user.Password))
                                {
                                    if (userCreation.ShowDialog() == DialogResult.OK)
                                    {
                                        user.UserName = userCreation.Username;
                                        user.Password = userCreation.Password;
                                        continue;
                                    }
                                    else
                                    {
                                        MessageBox.Show("User Creation Cancelled!");
                                        process = "Failed";
                                    }
                                }
                            }


                        }
                    }
                    
                }
                process = "Failed";
            }
            else 
            {
                MessageBox.Show("Please Fill All Details!"); return "Failed"; 
            }
            return process;
            
        }
        public static void DeleteUser(int UserId) 
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "DELETE FROM Users WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", UserId);
                cmd.ExecuteNonQuery();
            }
        }
        public Users Login(Users user) 
        {
            Users LoginedUSer = new Users();
            List<Users> list = new List<Users>();
            if (string.IsNullOrWhiteSpace(user.UserName)) 
            {
                MessageBox.Show("Enter a UserName Or Gmail Address!");
            }
            else if (string.IsNullOrWhiteSpace(user.Password)) 
            {
                MessageBox.Show("Enter a Password!");
            }
            else 
            {
                using(SQLiteConnection connect = DatabaseManager.GetConnection()) 
                {
                    using (SQLiteCommand cmd = connect.CreateCommand()) 
                    {
                        cmd.CommandText = "SELECT * FROM Users WHERE (Name = @name OR GMail = @mail) AND Password = @pas";
                        cmd.Parameters.AddWithValue("@name", user.UserName);
                        cmd.Parameters.AddWithValue("@mail", user.UserName);
                        cmd.Parameters.AddWithValue("@pas", user.Password);
                        var Result = cmd.ExecuteReader();
                        if (Result.Read())
                        {
                            LoginedUSer.UserName = Result["Name"].ToString();
                            LoginedUSer.Gmail = Result["GMail"].ToString();
                            LoginedUSer.Role = Result["Role"].ToString();
                            LoginedUSer.Id = Convert.ToInt32((Result["Id"]));
                        }
                    }
                }
            }
            return LoginedUSer;
        }
    }
}
