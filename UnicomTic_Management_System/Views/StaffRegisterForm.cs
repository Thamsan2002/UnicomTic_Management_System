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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UnicomTic_Management_System.Views
{
    public partial class StaffRegisterForm : Form
    {
        public StaffRegisterForm()
        {
            InitializeComponent();
        }
        Staffs staff =new Staffs();
        Users user = new Users();
        StaffController StaffController = new StaffController();
        UserController UserController = new UserController();
        
        private void CheckEmptyFields(string CurrentPlace)
        {
            List<string> Deta = new List<string>();
            Deta = StaffController.CheckEmptyVariables(staff);
            if (Deta.Contains("FirstName")) { label_FirstName.Text = "*FirstName is Required"; }
            if (CurrentPlace == "LastName") { return; }
            if (Deta.Contains("LastName")) { label_LastName.Text = "*LastName is Required"; }
            if (CurrentPlace == "Address") { return; }
            if (Deta.Contains("Address")) { label_Address.Text = "*Address is Required"; }
            if (CurrentPlace == "Phone") { return; }
            if (Deta.Contains("Phone")) { label_Phone.Text = "*Mobile Number is Required "; }
            if (CurrentPlace == "Gmail") { return; }
            if (Deta.Contains("Gmail")) { label_Gmail.Text = "*GMail Address is Required"; }
            if (CurrentPlace == "NicNo") { return; }
            if (Deta.Contains("NicNo")) { label_NicNo.Text = "*Nic Number is Required"; }
            if (CurrentPlace == "radiomale" || CurrentPlace == "radiomale") { return; }
            if (Deta.Contains("Gender")) { label_Gender.Text = "*Gender is Required"; }
            if (CurrentPlace == "Designation") { return; }
            if (Deta.Contains("Designation")) { label_Designation.Text = "*Designation is Required"; }
            if (CurrentPlace == "Salary") { return; }
            if (Deta.Contains("Salary")) { label_Salary.Text = "*Salary is Required"; }
        }
        private void ClearForm() 
        {
            textBox_FirstName.Clear();
            textBox_LastName.Clear();
            textBox_Address.Clear();
            textBox_Gmail.Clear();
            textBox_Phone.Clear();
            textBox_NicNo.Clear();
            textBox_Designation.Clear();
            textBox_Salary.Clear();
            radioButton_Female.Checked = false;
            radioButton_Male.Checked = false;
            
        }
        private void StaffRegisterForm_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox_FirstName_TextChanged(object sender, EventArgs e)
        {
            textBox_FirstName.ForeColor = Color.Black;
            staff.FirstName = textBox_FirstName.Text;
            label_FirstName.Text = null;
        }

        private void textBox_LastName_TextChanged(object sender, EventArgs e)
        {
            textBox_LastName.ForeColor = Color.Black;
            staff.LastName = textBox_LastName.Text;
            user.UserName = textBox_LastName.Text;
            label_LastName.Text = null;
        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            textBox_Address.ForeColor = Color.Black;
            staff.Address = textBox_Address.Text;
            label_Address.Text = null;
        }

        private void textBox_Phone_TextChanged(object sender, EventArgs e)
        {
            textBox_Phone.ForeColor = Color.Black;
            staff.Phone = textBox_Phone.Text;
            label_Phone.Text = null;
        }

        private void textBox_Gmail_TextChanged(object sender, EventArgs e)
        {
            textBox_Gmail.ForeColor = Color.Black;
            user.Gmail = textBox_Gmail.Text;
            label_Gmail.Text = null;
        }

        private void textBox_NicNo_TextChanged(object sender, EventArgs e)
        {
            textBox_NicNo.ForeColor = Color.Black;
            staff.NicNo = textBox_NicNo.Text;
            label_NicNo.Text = null;
        }

        private void textBox_Designation_TextChanged(object sender, EventArgs e)
        {
            textBox_Designation.ForeColor = Color.Black;
            staff.Designation = textBox_Designation.Text;
            label_Designation.Text = null;
        }

        private void textBox_Salary_TextChanged(object sender, EventArgs e)
        {
            textBox_Salary.ForeColor = Color.Black;
            staff.Salary = textBox_Salary.Text;
            label_Salary.Text = null;
        }

        private void radioButton_Male_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Male.Checked) { radioButton_Female.Checked = false; }
        }

        private void radioButton_Female_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Female.Checked) { radioButton_Male.Checked = false; }
        }

        private void textBox_FirstName_Click(object sender, EventArgs e)
        {
            if (textBox_FirstName.ForeColor != Color.Black) { textBox_FirstName.Text = null; }
        }

        private void textBox_LastName_Click(object sender, EventArgs e)
        {
            if(textBox_LastName.ForeColor != Color.Black) {textBox_LastName.Text = null;}
            CheckEmptyFields("LastName");
        }

        private void textBox_Address_Click(object sender, EventArgs e)
        {
            if(textBox_Address.ForeColor != Color.Black) {textBox_Address.Text =null;}
            CheckEmptyFields("Address");
        }

        private void textBox_Phone_Click(object sender, EventArgs e)
        {
            if (textBox_Phone.ForeColor != Color.Black) { textBox_Phone.Text = null; }
            CheckEmptyFields("Phone");
        }

        private void textBox_Gmail_Click(object sender, EventArgs e)
        {
            if(textBox_Gmail.ForeColor != Color.Black) { textBox_Gmail.Text = null; }
            CheckEmptyFields("Gmail");
        }

        private void textBox_NicNo_Click(object sender, EventArgs e)
        {
            if (textBox_NicNo.ForeColor !=Color.Black) { textBox_NicNo.Text = null; }
            CheckEmptyFields("NicNo");

        }

        private void textBox_Designation_Click(object sender, EventArgs e)
        {
            if (textBox_Designation.ForeColor != Color.Black) { textBox_Designation.Text = null; }
            CheckEmptyFields("Designation");
        }

        private void textBox_Salary_Click(object sender, EventArgs e)
        {
            if (textBox_Salary.ForeColor != Color.Black) { textBox_Salary.Text = null; }
            CheckEmptyFields("Salary");
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Register_Click(object sender, EventArgs e)
        {
            CheckEmptyFields("btn_add");
            if (radioButton_Male.Checked) {staff.Gender = radioButton_Male.Text; }
            else if (radioButton_Female.Checked) { staff.Gender = radioButton_Female.Text; }
            if (checkBox_Auto.Checked) { user.UserNameCreateType = "Auto"; }
            else if (checkBox_Manual.Checked) { user.UserNameCreateType = "Manual"; }
            staff.Date = DateTime.Now.ToString("yyyy-MM-dd");
            user.UserName = staff.LastName;
            user.Role = "Staff";
            user.CreatedDate = staff.Date;
            user.UpdatedDate = staff.Date;
            string UserRegisterStatus = UserController.SaveUser(user);
            if (UserRegisterStatus != "Failed")
            {
                string StaffRegisterStatus = StaffController.StaffRegister(staff);
                if (StaffRegisterStatus == "Success")
                {
                    MessageBox.Show($"{UserRegisterStatus}");
                    ClearForm();
                }

            }

        }
    }
}
