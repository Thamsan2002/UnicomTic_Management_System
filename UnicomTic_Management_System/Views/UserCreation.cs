using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Views
{
    public partial class UserCreation : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public UserCreation()
        {
            InitializeComponent();
        }
        public UserCreation( string Password) 
        {
            InitializeComponent();
            textBox_Password.Text = Password;
            textBox_ConfirmPassword.Text = Password;
        }

        private void textBox_UserName_TextChanged(object sender, EventArgs e)
        {
          textBox_UserName.ForeColor =Color.Black;
            Username = textBox_UserName.Text.Trim();
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            textBox_Password.ForeColor =Color.Black;
            Password = textBox_Password.Text.Trim();
        }

        private void textBox_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            textBox_ConfirmPassword.ForeColor = Color.Black;
            ConfirmPassword = textBox_ConfirmPassword.Text.Trim();
        }

        private void textBox_UserName_Click(object sender, EventArgs e)
        {
            if (textBox_UserName.ForeColor != Color.Black) { textBox_UserName.Text = null; }
        }

        private void textBox_Password_Click(object sender, EventArgs e)
        {
            if (textBox_Password.ForeColor!=Color.Black) { textBox_Password.Text = null; }
            if (string.IsNullOrWhiteSpace(Username)) { la_UserName.Text = "Enter Your UserName"; }
        }

        private void textBox_ConfirmPassword_Click(object sender, EventArgs e)
        {
            if (textBox_ConfirmPassword.ForeColor != Color.Black) {textBox_ConfirmPassword.Text = null; }
            if (string.IsNullOrWhiteSpace(Username)) { la_UserName.Text = "Enter Your UserName"; }
            if (string.IsNullOrWhiteSpace(Password)) { la_Password.Text = "Enter Your Password"; }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username)) { la_UserName.Text = "Enter Your UserName"; }
            if (string.IsNullOrWhiteSpace(Password)) { la_Password.Text = "Enter Your Password"; }
            else if (string.IsNullOrWhiteSpace(ConfirmPassword)) { BeginInvoke((Action)(() => textBox_ConfirmPassword.Focus())); }
            if (string.IsNullOrWhiteSpace(ConfirmPassword)) { la_ConfirmPassword.Text = "Re Enter Your Password"; }
            if(Username != null && Password != null && ConfirmPassword != null) 
            {
                this.DialogResult = DialogResult.OK;
            }
            else { MessageBox.Show("Please Fill All Details!"); }
        }

        private void UserCreation_Load(object sender, EventArgs e)
        {

        }
    }
}
