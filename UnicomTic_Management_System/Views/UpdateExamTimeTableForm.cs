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
    public partial class UpdateExamTimeTableForm : Form
    {
        public UpdateExamTimeTableForm()
        {
            InitializeComponent();
        }
        private DashBoard parentForm;
        private string role;
        private int UserId;
        ExamController examController =new ExamController();
        Exams exam = new Exams();
        public UpdateExamTimeTableForm(DashBoard parentForm, List<string> TimeTablelist, string role, int UserId)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.role = role;
            this.UserId = UserId;
            exam.ID = Convert.ToInt32(TimeTablelist[0]);
            dateTimePicker_Date.Value = DateTime.ParseExact(TimeTablelist[1], "dd/MM/yyyy", null);
            dateTimePicker_StartTime.Value = DateTime.ParseExact(TimeTablelist[2], "HH:mm", null);
            dateTimePicker_EndTime.Value = DateTime.ParseExact(TimeTablelist[3], "HH:mm", null);
            comboBox_Department.Text = TimeTablelist[4];
            exam.DepartmentID = Convert.ToInt32(TimeTablelist[5]);
            comboBox_Course.Text = TimeTablelist[6];
            exam.CourseID = Convert.ToInt32(TimeTablelist[7]);
            comboBox_Subject.Text = TimeTablelist[8];
            exam.SubjectID = Convert.ToInt32(TimeTablelist[9]);
            comboBox_Hall.Text = TimeTablelist[10];
            exam.HallID = Convert.ToInt32(TimeTablelist[11]);
            textBox_ExamName.Text = TimeTablelist[12];

        }
        private void GetDataAndCheckEmptyFields()
        {
            if (Convert.ToInt32(comboBox_Department.SelectedValue) != 0) { exam.DepartmentID = Convert.ToInt32(comboBox_Department.SelectedValue); }
            if (Convert.ToInt32(comboBox_Course.SelectedValue) != 0) { exam.CourseID = Convert.ToInt32(comboBox_Course.SelectedValue); }
            if (Convert.ToInt32(comboBox_Subject.SelectedValue) != 0) { exam.SubjectID = Convert.ToInt32(comboBox_Subject.SelectedValue); }
            if (Convert.ToInt32(comboBox_Hall.SelectedValue) != 0) { exam.HallID = Convert.ToInt32(comboBox_Hall.SelectedValue); }
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
            if (Deta.Contains("Heading")) { label_EndTime.Text = "*Heading is Required"; }
        }
        private void ClearForm()
        {
            comboBox_Course.Text = null;
            comboBox_Subject.Text = null;
            comboBox_Hall.Text = null;
            comboBox_Department.Text = null;
            textBox_ExamName.Clear();
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
        private void UpdateExamTimeTableForm_Load(object sender, EventArgs e)
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
        }

        private void comboBox_Department_DropDown(object sender, EventArgs e)
        {
            LoadDepartment();
        }

        private void comboBox_Course_DropDown(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void comboBox_Subject_DropDown(object sender, EventArgs e)
        {
            LoadSubject();
        }

        private void comboBox_Hall_DropDown(object sender, EventArgs e)
        {
            LoadRooms();
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

        private void button_Update_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            examController.UpdateExam(exam);
            Close();
            parentForm.LoadForm(new ViewExamTimeTableForm(parentForm, role, UserId));
        }
    }
}
