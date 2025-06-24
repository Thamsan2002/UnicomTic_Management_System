using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using UnicomTic_Management_System.Controllers;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Views
{
    public partial class AddExamTimeTableForm : Form
    {
        public AddExamTimeTableForm()
        {
            InitializeComponent();
        }
        private DashBoard parentForm;
        private string role;
        private int UserId;
        public AddExamTimeTableForm(DashBoard parentForm, string role, int UserId)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.role = role;
            this.UserId = UserId;
        }
        Exams exam = new Exams();
        ExamController examController = new ExamController();
        private void GetDataAndCheckEmptyFields()
        {
            exam.DepartmentID = Convert.ToInt32(comboBox_Department.SelectedValue);
            exam.CourseID = Convert.ToInt32(comboBox_Course.SelectedValue);
            exam.SubjectID = Convert.ToInt32(comboBox_Subject.SelectedValue);
            exam.HallID = Convert.ToInt32(comboBox_Hall.SelectedValue);
            exam.Date = dateTimePicker_Date.Text;
            exam.StartTime = dateTimePicker_StartTime.Text;
            exam.EndTime = dateTimePicker_EndTime.Text;
            exam.Heading = textBox_ExamName.Text;
            List<string> Deta = new List<string>();
            Deta = examController.CheckEmptyVariables(exam);
            if (Deta.Contains("DepartmentID")) { label_Department.Text = "*Department is Required"; }
            if (Deta.Contains("CourseID")) { label_Course.Text = "*Course is Required"; }
            if (Deta.Contains("SubjectID")) { label_Subject.Text = "*Subject is Required"; }
            if (Deta.Contains("HallID")) { label_Hall.Text = "Hall is Required"; }
            if (Deta.Contains("Date")) { label_Date.Text = "*Date is Required"; }
            if (Deta.Contains("StartTime")) { label_StartTime.Text = "*StartTime is Required"; }
            if (Deta.Contains("EndTime")) { label_EndTime.Text = "*EndTime is Required"; }
        }
        private void ClearForm()
        {
            comboBox_Course.Text = null;
            comboBox_Subject.Text = null;
            comboBox_Hall.Text = null;
            comboBox_Department.Text = null;
        }
        private void LoadDepartment()
        {
            DepartmentController departmentController = new DepartmentController();
            comboBox_Department.DataSource = departmentController.ViewDepartments();
            comboBox_Department.DisplayMember = "Name";
            comboBox_Department.ValueMember = "ID";
        }
        private void LoadRooms()
        {
            RoomController roomController = new RoomController();
            comboBox_Hall.DataSource = roomController.ViewRooms();
            comboBox_Hall.DisplayMember = "Name";
            comboBox_Hall.ValueMember = "ID";
        }
        private void LoadCourses()
        {
            CourseController courseController = new CourseController();
            comboBox_Course.DataSource = courseController.ViewCourses(comboBox_Department.Text);
            comboBox_Course.DisplayMember = "Name";
            comboBox_Course.ValueMember = "ID";

        }
        private void LoadSubject()
        {
            SubjectController subjectController = new SubjectController();
            comboBox_Subject.DataSource = subjectController.LoadSubjectsName(Convert.ToInt32(comboBox_Course.SelectedValue));
            comboBox_Subject.DisplayMember = "Name";
            comboBox_Subject.ValueMember = "ID";
        }
        private void AddExamTimeTableForm_Load(object sender, EventArgs e)
        {
            dateTimePicker_Date.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Date.CustomFormat = "dd/MM/yyyy";
            dateTimePicker_StartTime.Format = DateTimePickerFormat.Custom;
            dateTimePicker_StartTime.CustomFormat = "HH:mm";
            dateTimePicker_StartTime.ShowUpDown = true;
            dateTimePicker_StartTime.ShowUpDown = true;
            dateTimePicker_EndTime.Format = DateTimePickerFormat.Custom;
            dateTimePicker_EndTime.CustomFormat = "HH:mm";
            dateTimePicker_EndTime.ShowUpDown = true;
            LoadDepartment();
            LoadCourses();
            LoadSubject();
            LoadRooms();
        }

        private void comboBox_Course_DropDown(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void comboBox_Subject_DropDown(object sender, EventArgs e)
        {
            LoadSubject();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            parentForm.LoadForm(new ViewExamTimeTableForm(parentForm, role, UserId));
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            exam.ID = examController.AddExam(exam);
            if (exam.ID > 0)
            {
                MarkController.AddStudentExam(exam);
                ClearForm();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
