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

namespace UnicomTic_Management_System.Views
{
    public partial class AddTimeTableForm : Form
    {
        public AddTimeTableForm()
        {
            InitializeComponent();
        }
        private DashBoard parentForm;
        private string role;
        private int UserId;
        public AddTimeTableForm(DashBoard parentForm,string role,int UserId)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.role = role;
            this.UserId = UserId;
        }
        TimeTableController timetableController = new TimeTableController();
        TimeTables timeTable = new TimeTables();
        private void GetDataAndCheckEmptyFields()
        {
            timeTable.DepartmentID =Convert.ToInt32(comboBox_Department.SelectedValue);
            timeTable.CourseID =Convert.ToInt32(comboBox_Course.SelectedValue);
            timeTable.SubjectID =Convert.ToInt32(comboBox_Subject.SelectedValue);
            timeTable.HallID = Convert.ToInt32(comboBox_Hall.SelectedValue);
            timeTable.Date =dateTimePicker_Date.Text;
            timeTable.StartTime =dateTimePicker_StartTime.Text;
            timeTable.EndTime =dateTimePicker_EndTime.Text;
            List<string> Deta = new List<string>();
            Deta = timetableController.CheckEmptyVariables(timeTable);
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
            comboBox_Department.Text=null;
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

        private void AddTimeTableForm_Load(object sender, EventArgs e)
        {
            dateTimePicker_Date.Format =DateTimePickerFormat.Custom;
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            bool result=timetableController.AddTimeTable(timeTable);
            if (result == true) 
            {
                ClearForm();
            }

        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            parentForm.LoadForm(new ViewClassTimeTableForm(parentForm,role,UserId));
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
    }
}
