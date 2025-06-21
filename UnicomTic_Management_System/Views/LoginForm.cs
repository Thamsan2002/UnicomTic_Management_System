using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Controllers;
using UnicomTic_Management_System.Models;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        Users user = new Users();
        UserController userController = new UserController();

        private void label1_Click(object sender, EventArgs e)
        {
            //object result = Migration.ExistsUsersTable();
            //label1.Text=result.ToString();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox_UserName_TextChanged(object sender, EventArgs e)
        {
            textBox_UserName.ForeColor = Color.Black;
            user.UserName = textBox_UserName.Text;
            label_UserName.Text =null;

        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            textBox_Password.ForeColor = Color.Black;
            user.Password = textBox_Password.Text;
            label_Password.Text = null;
        }

        private void textBox_UserName_Click(object sender, EventArgs e)
        {
            if (textBox_UserName.ForeColor != Color.Black) { textBox_UserName.Text = null; }
        }

        private void textBox_Password_Click(object sender, EventArgs e)
        {
            if(textBox_Password.ForeColor != Color.Black) { textBox_Password.Text = null; }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
           Users LoginedUSer = userController.Login(user);
            if (LoginedUSer.Role==null) { MessageBox.Show($"Login Failed!\nInvalid UserName Or Password"); }
            else 
            {
                new DashBoard(LoginedUSer.Gmail,LoginedUSer.UserName,LoginedUSer.Role).ShowDialog();
            }
        }
    }
}
