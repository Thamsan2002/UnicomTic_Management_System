using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Controllers;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Views
{
    public partial class LecturerRegisterForm : Form
    {
        public LecturerRegisterForm()
        {
            InitializeComponent();
        }
        Lecturers lecturer = new Lecturers();
        LecturerController lecturerController = new LecturerController();
        Users user = new Users();
        UserController userController = new UserController();


        private void ClearForm()
        {
            textBox_FirstName.Clear();
            textBox_LastName.Clear();
            textBox_Address.Clear();
            textBox_Gmail.Clear();
            textBox_Phone.Clear();
            textBox_NicNo.Clear();
            textBox_Salary.Clear();
            comboBox_Course.SelectedIndex = 0;
            comboBox_Department.SelectedIndex = 0;
            radioButton_Male.Checked = false;
            radioButton_Female.Checked = false;
        }
        private void CheckEmptyFields(string CurrentPlace)
        {
            List<string> Data = new List<string>();
            Data = lecturerController.CheckEmptyVariables(lecturer);
            if (Data.Contains("FirstName")) { label_FirstName.Text = "*Enter Your FirstName"; }
            if (CurrentPlace == "LastName") { return; }
            if (Data.Contains("LastName")) { label_LastName.Text = "*Enter Your LastName"; }
            if (CurrentPlace == "Address") { return; }
            if (Data.Contains("Address")) { label_Address.Text = "Enter Your Address"; }
            if (CurrentPlace == "Phone") { return; }
            if (Data.Contains("Phone")) { label_Phone.Text = "*Enter Your Mobile Number "; }
            if (CurrentPlace == "Gmail") { return; }
            if (Data.Contains("Gmail")) { label_Gmail.Text = "*Enter Your Gmail Address"; }
            if (CurrentPlace == "NicNo") { return; }
            if (Data.Contains("NicNo")) { label_NicNo.Text = "*Enter Your NIC Number"; }
            if (CurrentPlace == "radioButton_Male" || CurrentPlace == "radioButton_Female") { return; }
            if (Data.Contains("Gender")) { label_Gender.Text = "*Choose Your Gender"; }
            if(CurrentPlace == "Department") {return; }
            if (Data.Contains("Department")) { label_Department.Text = "*Department is Required"; }
            if (CurrentPlace == "Salary") { return; }
            if (Data.Contains("Salary")) { label_Salary.Text = "*Salary is Required"; }
            if (CurrentPlace == "Course") { return; }
            if (Data.Contains("Course")) { label_Course.Text = "*Course is Required"; }
        }
        private void LoadDepartments() 
        {
            DepartmentController departmentController = new DepartmentController();
            comboBox_Department.DataSource = departmentController.ViewDepartments();
            comboBox_Department.DisplayMember = "Name";
            comboBox_Department.ValueMember = "ID";
        }
        private void LoadCourses() 
        {
            CourseController courseController = new CourseController();
            comboBox_Course.DataSource = courseController.ViewCourses(lecturer.DepartmentName);
            comboBox_Course.DisplayMember = "Name";
            comboBox_Course.ValueMember = "ID";
        }
        private void LecturerRegisterForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadCourses();
        }

        private void textBox_FirstName_TextChanged(object sender, EventArgs e)
        {
            textBox_FirstName.ForeColor = Color.Black;
            lecturer.FirstName = textBox_FirstName.Text.Trim();
            label_FirstName.Text = null;
        }

        private void textBox_LastName_TextChanged(object sender, EventArgs e)
        {
            textBox_LastName.ForeColor = Color.Black;
            lecturer.LastName = textBox_LastName.Text.Trim();
            label_LastName.Text = null;
        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            textBox_Address.ForeColor = Color.Black;
            lecturer.Address = textBox_Address.Text.Trim(); 
            label_Address.Text = null;
        }

        private void textBox_Phone_TextChanged(object sender, EventArgs e)
        {
            textBox_Phone.ForeColor = Color.Black;
            lecturer.Phone = textBox_Phone.Text.Trim(); 
            label_Phone.Text = null;
        }

        private void textBox_Gmail_TextChanged(object sender, EventArgs e)
        {
            textBox_Gmail.ForeColor = Color.Black;
            lecturer.Gmail = textBox_Gmail.Text.Trim();
            label_Gmail.Text = null;
        }

        private void textBox_NicNo_TextChanged(object sender, EventArgs e)
        {
            textBox_NicNo.ForeColor = Color.Black;
            lecturer.NicNo = textBox_NicNo.Text.Trim();
            label_NicNo.Text = null;
        }
        private void comboBox_Department_TextChanged(object sender, EventArgs e)
        {
            comboBox_Department.ForeColor = Color.Black;
            lecturer.DepartmentName = comboBox_Department.Text.Trim();
            LoadCourses();
            label_Department.Text = null;
        }
        private void textBox_Salary_TextChanged(object sender, EventArgs e)
        {
            textBox_Salary.ForeColor = Color.Black;
            lecturer.Salary = textBox_Salary.Text.Trim();
            label_Salary.Text = null;
        }
        private void comboBox_Course_TextChanged(object sender, EventArgs e)
        {
            comboBox_Course.ForeColor = Color.Black;
            lecturer.CourseName = comboBox_Course.Text.Trim();
            label_Course.Text = null;
        }

        private void radioButton_Male_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Male.Checked) { label_Gender.Text = null; }
        }

        private void radioButton_Female_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Female.Checked) { label_Gender.Text = null; }
        }

        private void textBox_FirstName_Click(object sender, EventArgs e)
        {
            if(textBox_FirstName.ForeColor != Color.Black) {textBox_FirstName.Text = null;}
        }

        private void textBox_LastName_Click(object sender, EventArgs e)
        {
            if (textBox_LastName.ForeColor != Color.Black) { textBox_LastName.Text = null; }
            CheckEmptyFields("LastName");
        }

        private void textBox_Address_Click(object sender, EventArgs e)
        {
            if(textBox_Address.ForeColor != Color.Black) { textBox_Address.Text = null;}
            CheckEmptyFields("Address");
        }

        private void textBox_Phone_Click(object sender, EventArgs e)
        {
            if(textBox_Phone.ForeColor != Color.Black) {textBox_Phone.Text = null;}
            CheckEmptyFields("Phone");
        }

        private void textBox_Gmail_Click(object sender, EventArgs e)
        {
            if(textBox_Gmail.ForeColor != Color.Black) { textBox_Gmail.Text = null;}
            CheckEmptyFields("Gmail");
        }

        private void textBox_NicNo_Click(object sender, EventArgs e)
        {
            if (textBox_NicNo.ForeColor != Color.Black) { textBox_NicNo.Text = null; }
            CheckEmptyFields("NicNo");
        }

        private void radioButton_Male_Click(object sender, EventArgs e)
        {
            CheckEmptyFields("radioButton_Male");
        }

        private void radioButton_Female_Click(object sender, EventArgs e)
        {
            CheckEmptyFields("radioButton_Female");
        }

        private void comboBox_Department_Click(object sender, EventArgs e)
        {
           if(comboBox_Department.ForeColor != Color.Black) {comboBox_Department.Text = null;}
            CheckEmptyFields("Department");
        }

        private void comboBox_Department_DropDown(object sender, EventArgs e)
        {
            if (comboBox_Department.ForeColor != Color.Black) { comboBox_Department.Text = null; }
            CheckEmptyFields("Department");
        }

        private void textBox_Salary_Click(object sender, EventArgs e)
        {
            if(textBox_Salary.ForeColor != Color.Black) { textBox_Salary.Text = null;}
            CheckEmptyFields("Salary");
            
        }

        private void comboBox_Course_Click(object sender, EventArgs e)
        {
            if(comboBox_Course.ForeColor != Color.Black) {comboBox_Course.Text = null;}
            CheckEmptyFields("Course");
        }

        private void comboBox_Course_DropDown(object sender, EventArgs e)
        {
            if (comboBox_Course.ForeColor != Color.Black) { comboBox_Course.Text = null; }
            CheckEmptyFields("Course");
        }

        private void checkBox_Auto_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Auto.Checked == true) { checkBox_Manual.Checked = false;}
        }

        private void checkBox_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Manual.Checked == true) {checkBox_Auto.Checked = false;}
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button_Register_Click(object sender, EventArgs e)
        {
            lecturer.CourseID = Convert.ToInt32((comboBox_Course.SelectedValue));
            lecturer.DepartmentID = Convert.ToInt32((comboBox_Department.SelectedValue));
            CheckEmptyFields("btn_add");
            if (radioButton_Male.Checked) { lecturer.Gender = radioButton_Male.Text; }
            else if (radioButton_Female.Checked) { lecturer.Gender = radioButton_Male.Text; }
            if (checkBox_Auto.Checked) { user.UserNameCreateType = "Auto"; }
            else if (checkBox_Manual.Checked) { user.UserNameCreateType = "Manual"; }
            lecturer.Date = DateTime.Now.ToString("yyyy-MM-dd");
            user.UserName = lecturer.LastName;
            user.Gmail = lecturer.Gmail;
            user.Role = "Lecturer";
            user.CreatedDate = lecturer.Date;
            user.UpdatedDate = lecturer.Date;
            string UserRegisterStatus = userController.SaveUser(user);
            if (UserRegisterStatus != "Failed")
            {
                string AdminRegisterStatus =lecturerController.LecturerRegister(lecturer);
                if (AdminRegisterStatus == "Success")

                {
                    MessageBox.Show($"{UserRegisterStatus}");
                    ClearForm();
                }

            }
        }
    }
}
