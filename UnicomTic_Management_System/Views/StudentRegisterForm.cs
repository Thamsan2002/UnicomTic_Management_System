using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomTic_Management_System.Controllers;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Views
{
    public partial class StudentRegisterForm : Form
    {
        public StudentRegisterForm()
        {
            InitializeComponent();
        }
        Students student = new Students();
        Users user = new Users();
        StudentController studentController = new StudentController();
        UserController UserController = new UserController();
        StudentSubject studentSubject = new StudentSubject();
        StudentSubjectController studentSubjectController = new StudentSubjectController();
        LecturerStudentController lecturerStudentController = new LecturerStudentController();
        private void CheckEmptyFields(string CurrentPlace)
        {
            List<string> Deta = new List<string>();
            Deta = studentController.CheckEmptyVariables(student,user.Gmail);
            if (Deta.Contains("FirstName")) { label_FirstName.Text = "*FirstName is Required"; }
            if (CurrentPlace == "LastName") { return; }
            if (Deta.Contains("LastName")) { label_LastName.Text = "*LastName is Required"; }
            if (CurrentPlace == "Gmail") { return; }
            if (Deta.Contains("Gmail")) { label_Gmail.Text = "*GMail Address is Required"; }
            if (CurrentPlace == "Phone") { return; }
            if (Deta.Contains("Phone")) { label_Phone.Text = "*Mobile Number is Required "; }
            if (CurrentPlace == "Address") { return; }
            if (Deta.Contains("Address")) { label_Address.Text = "*Address is Required"; }
            if (CurrentPlace == "NicNo") { return; }
            if (Deta.Contains("NicNo")) { label_NicNo.Text = "*Nic Number is Required"; }
            if (CurrentPlace == "radioButton_Male" || CurrentPlace == "radioButton_Female") { return; }
            if (Deta.Contains("Gender")) { label_Gender.Text = "*Gender is Required"; }
            if (CurrentPlace == "Department") { return; }
            if (Deta.Contains("DepartmentID")) { label_Department.Text = "*Department is Required"; }
            if (CurrentPlace == "Course") { return; }
            if (Deta.Contains("CourseID")) { label_Course.Text = "*Course is Required"; }
        }
        private void ClearForm()
        {
            textBox_FirstName.Clear();
            textBox_LastName.Clear();
            textBox_Address.Clear();
            textBox_Gmail.Clear();
            textBox_Phone.Clear();
            textBox_NicNo.Clear();
            comboBox_Course.Text =null;
            comboBox_Department.Text =null;
            radioButton_Female.Checked = false;
            radioButton_Male.Checked = false;

        }
        private void LoadDepartment()
        {
            DepartmentController departmentController = new DepartmentController();
            comboBox_Department.DataSource = departmentController.ViewDepartments();
            comboBox_Department.DisplayMember = "Name";
            comboBox_Department.ValueMember = "ID";

        }
        private void LoadCourses(string DepartmentName)
        {
            CourseController courseController = new CourseController();
            comboBox_Course.DataSource = courseController.ViewCourses(DepartmentName);
            comboBox_Course.DisplayMember = "Name";
            comboBox_Course.ValueMember = "ID";

        }
        private void StudentRegisterForm_Load(object sender, EventArgs e)
        {
            LoadDepartment();
            LoadCourses(null);
        }

        private void textBox_FirstName_TextChanged(object sender, EventArgs e)
        {
            textBox_FirstName.ForeColor = Color.Black;
            student.FirstName = textBox_FirstName.Text;
            label_FirstName.Text = null;
        }

        private void textBox_LastName_TextChanged(object sender, EventArgs e)
        {
            textBox_LastName.ForeColor = Color.Black;
            student.LastName = textBox_LastName.Text;
            user.UserName = textBox_LastName.Text;
            label_LastName.Text = null;
        }

        private void textBox_Gmail_TextChanged(object sender, EventArgs e)
        {
            textBox_Gmail.ForeColor = Color.Black;
            user.Gmail = textBox_Gmail.Text;
            label_Gmail.Text = null;
        }

        private void textBox_Phone_TextChanged(object sender, EventArgs e)
        {
            textBox_Phone.ForeColor = Color.Black;
            student.Phone = textBox_Phone.Text;
            label_Phone.Text = null;
        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            textBox_Address.ForeColor = Color.Black;
            student.Address = textBox_Address.Text;
            label_Address.Text = null;
        }

        private void textBox_NicNo_TextChanged(object sender, EventArgs e)
        {
            textBox_NicNo.ForeColor = Color.Black;
            student.NicNo = textBox_NicNo.Text;
            label_NicNo.Text = null;
        }

        private void comboBox_Department_TextChanged(object sender, EventArgs e)
        {
            comboBox_Department.ForeColor = Color.Black;
            label_Department.Text = null;
        }

        private void comboBox_Course_TextChanged(object sender, EventArgs e)
        {
            comboBox_Course.ForeColor = Color.Black;
            label_Course.Text = null;
        }

        private void radioButton_Male_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Male.Checked) { student.Gender = radioButton_Male.Text; }
            label_Gender.Text = null;
        }

        private void radioButton_Female_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Female.Checked) { student.Gender = radioButton_Female.Text; }
            label_Gender.Text = null;
        }

        private void textBox_FirstName_Click(object sender, EventArgs e)
        {
            if (textBox_FirstName.ForeColor != Color.Black) { textBox_FirstName.Text = null; }
        }

        private void textBox_LastName_Click(object sender, EventArgs e)
        {
            if (textBox_LastName.ForeColor != Color.Black) { textBox_LastName.Text = null; }
            CheckEmptyFields("LastName");
        }

        private void textBox_Gmail_Click(object sender, EventArgs e)
        {
            if (textBox_Gmail.ForeColor != Color.Black) { textBox_Gmail.Text = null; }
            CheckEmptyFields("Gmail");
        }

        private void textBox_Phone_Click(object sender, EventArgs e)
        {
            if (textBox_Phone.ForeColor != Color.Black) { textBox_Phone.Text = null; }
            CheckEmptyFields("Phone");
        }

        private void textBox_Address_Click(object sender, EventArgs e)
        {
            if (textBox_Address.ForeColor != Color.Black) { textBox_Address.Text = null; }
            CheckEmptyFields("Address");
        }

        private void textBox_NicNo_Click(object sender, EventArgs e)
        {
            if (textBox_NicNo.ForeColor != Color.Black) { textBox_NicNo.Text = null; }
            CheckEmptyFields("NicNo");
        }

        private void comboBox_Department_Click(object sender, EventArgs e)
        {
            if (comboBox_Department.ForeColor != Color.Black) { comboBox_Department.Text = null; }
            CheckEmptyFields("Department");
        }

        private void comboBox_Course_Click(object sender, EventArgs e)
        {
            student.DepartmentID = Convert.ToInt32(comboBox_Department.SelectedValue);
            if (comboBox_Course.ForeColor != Color.Black) {comboBox_Course.Text = null; }
            CheckEmptyFields("Course");
        }

        private void comboBox_Department_DropDown(object sender, EventArgs e)
        {
            if (comboBox_Department.ForeColor != Color.Black) { comboBox_Department.Text = null; }
            CheckEmptyFields("Department");
        }

        private void comboBox_Course_DropDown(object sender, EventArgs e)
        {
            student.DepartmentID=Convert.ToInt32(comboBox_Department.SelectedValue);
            if (comboBox_Course.ForeColor != Color.Black) { comboBox_Course.Text = null; }
            CheckEmptyFields("Course");
            LoadCourses(comboBox_Department.Text);
        }

        private void checkBox_Auto_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Auto.Checked == true) { checkBox_Manual.Checked = false; }
        }

        private void checkBox_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Manual.Checked == true) { checkBox_Auto.Checked = false; }
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
            student.DepartmentID = Convert.ToInt32(comboBox_Department.SelectedValue);
            student.CourseID = Convert.ToInt32(comboBox_Course.SelectedValue);
            if (checkBox_Auto.Checked == true) { user.UserNameCreateType = "Auto"; }
            else if (checkBox_Manual.Checked == true) { user.UserNameCreateType = "Manual"; }
                CheckEmptyFields("btn_add");
            student.Date = DateTime.Now.ToString("yyyy-MM-dd");
            user.UserName = student.LastName;
            user.Role = "Student";
            user.CreatedDate = student.Date;
            user.UpdatedDate = student.Date;
            string UserRegisterStatus = UserController.SaveUser(user);
            if (UserRegisterStatus != "Failed") 
            {
                studentSubject.StudentId = studentController.StudentRegister(student);
                if (studentSubject.StudentId >0)
                {
                    studentSubjectController.AddStudentSubject(student.CourseID,studentSubject.StudentId);
                    lecturerStudentController.AddLecturerStudent(student.CourseID, studentSubject.StudentId);
                    MessageBox.Show("Student Registered Successfully");
                    MessageBox.Show($"{UserRegisterStatus}");
                    ClearForm();
                }
            }
        }
    }
}
