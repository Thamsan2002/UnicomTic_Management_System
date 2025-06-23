using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    public partial class UpdateClassTimeTableForm : Form
    {
        public UpdateClassTimeTableForm()
        {
            InitializeComponent();
        }
        private DashBoard parentForm;
        private string role;
        private int UserId;
        public UpdateClassTimeTableForm(DashBoard parentForm,List<string> TimeTablelist,string role,int UserId)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.role = role;
            this.UserId = UserId;
            timeTable.ID = Convert.ToInt32(TimeTablelist[0]);
            dateTimePicker_Date.Value = DateTime.ParseExact(TimeTablelist[1], "dd/MM/yyyy", null);
            dateTimePicker_StartTime.Value = DateTime.ParseExact(TimeTablelist[2], "HH:mm", null);
            dateTimePicker_EndTime.Value = DateTime.ParseExact(TimeTablelist[3], "HH:mm", null);
            comboBox_Department.Text = TimeTablelist[4];
            timeTable.DepartmentID = Convert.ToInt32(TimeTablelist[5]);
            comboBox_Course.Text = TimeTablelist[6];
            timeTable.CourseID = Convert.ToInt32(TimeTablelist[7]);
            comboBox_Subject.Text = TimeTablelist[8];
            timeTable.SubjectID = Convert.ToInt32(TimeTablelist[9]);
            comboBox_Hall.Text = TimeTablelist[10];
            timeTable.HallID = Convert.ToInt32(TimeTablelist[11]);

        }
        TimeTableController timetableController = new TimeTableController();
        TimeTables timeTable = new TimeTables();
        private void GetDataAndCheckEmptyFields()
        {
            if(Convert.ToInt32(comboBox_Department.SelectedValue) != 0) { timeTable.DepartmentID = Convert.ToInt32(comboBox_Department.SelectedValue); }
            if (Convert.ToInt32(comboBox_Course.SelectedValue) != 0) { timeTable.CourseID = Convert.ToInt32(comboBox_Course.SelectedValue); }
            if (Convert.ToInt32(comboBox_Subject.SelectedValue) != 0) { timeTable.SubjectID = Convert.ToInt32(comboBox_Subject.SelectedValue); }
            if (Convert.ToInt32(comboBox_Hall.SelectedValue) != 0) { timeTable.HallID = Convert.ToInt32(comboBox_Hall.SelectedValue); }
            timeTable.Date = dateTimePicker_Date.Text;
            timeTable.StartTime = dateTimePicker_StartTime.Text;
            timeTable.EndTime = dateTimePicker_EndTime.Text;
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

        private void UpdateClassTimeTableForm_Load(object sender, EventArgs e)
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
            parentForm.LoadForm(new ViewClassTimeTableForm(parentForm,role,UserId));
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            timetableController.UpdateTimeTable(timeTable);
            Close();
            parentForm.LoadForm(new ViewClassTimeTableForm(parentForm, role, UserId));


        }
    }
}
