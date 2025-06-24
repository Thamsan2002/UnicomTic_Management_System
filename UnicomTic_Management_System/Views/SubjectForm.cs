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
    public partial class SubjectForm : Form
    {
        public SubjectForm()
        {
            InitializeComponent();
        }
        private DashBoard dashBoard;
        public SubjectForm(DashBoard dashBoard)
        {
            InitializeComponent();
            this.dashBoard = dashBoard;
        }
        Subjects subject = new Subjects();
        CourseLecturer courseLecturer = new CourseLecturer();
        CourseSubject CourseSubject = new CourseSubject();
        CourseLecturerController clController = new CourseLecturerController();
        CourseSubject_Controller csController = new CourseSubject_Controller();
        SubjectController subjectController = new SubjectController();
        private void CheckEmptyFields(string CurrentPlace)
        {
            List<string> Data = new List<string>();
            Data = subjectController.CheckEmptyVariables(subject);
            if (Data.Contains("Subject")) { label_Subject.Text = "*Subject is Required"; }
            if (CurrentPlace == "Department") { return; }
            if (Data.Contains("Department")) { label_Department.Text = "*Department is Required"; }
            if (CurrentPlace == "Course") { return; }
            if (Data.Contains("Course")) { label_Course.Text = "*Course is Required"; }
            if (CurrentPlace == "Lecturer") { return; }
            if (Data.Contains("Lecturer")) { label_Lecturer.Text = "*Lecturer is Required"; }
        }
        private void LoadDepartment()
        {
            DepartmentController departmentController = new DepartmentController();
            comboBox_Department.DataSource = departmentController.ViewDepartments();
            comboBox_Department.DisplayMember = "Name";
            comboBox_Department.ValueMember = "ID";
            //comboBox_Department.Text = string.Empty;

        }
        private void LoadCourses()
        {
            CourseController courseController = new CourseController();
            comboBox_Course.DataSource = courseController.ViewCourses(subject.DepartmentName);
            comboBox_Course.DisplayMember = "Name";
            comboBox_Course.ValueMember = "ID";
            //comboBox_Course.Text = string.Empty;

        }
        private void LoadLecturers()
        {
            LecturerController lecturerController = new LecturerController();
            comboBox_Lecturer.DataSource =lecturerController.ViewLecturer(subject.DepartmentName);
            comboBox_Lecturer.DisplayMember = "LastName";
            comboBox_Lecturer.ValueMember = "ID";
            //comboBox_Lecturer.Text = string.Empty;

        }
        private void LoadSubjects(string search) 
        {
            dataGridView_Subject.DataSource = subjectController.ViewSubjects(search);
            dataGridView_Subject.Columns["LecturerID"].Visible = false;
            dataGridView_Subject.Columns["DepartmentID"].Visible = false;
            dataGridView_Subject.Columns["CourseID"].Visible = false;
        }
        private void ClearForm() 
        {
            textBox_Subject.Clear();
            comboBox_Department.Text = string.Empty;
            comboBox_Course.Text = string.Empty;
            comboBox_Lecturer.Text = string.Empty;

        }
        private void SubjectForm_Load(object sender, EventArgs e)
        {
            LoadDepartment();
            LoadCourses();
            LoadLecturers();
            LoadSubjects(null);

        }

        private void textBox_Subject_TextChanged(object sender, EventArgs e)
        {
            textBox_Subject.ForeColor = Color.Black;
            subject.Name = textBox_Subject.Text;
            label_Subject.Text = null;
        }

        private void comboBox_Department_TextChanged(object sender, EventArgs e)
        {
            comboBox_Department.ForeColor = Color.Black;
            subject.DepartmentName = comboBox_Department.Text;
            label_Department.Text = null;
            LoadCourses() ;
            LoadLecturers();
        }

        private void comboBox_Course_TextChanged(object sender, EventArgs e)
        {
            comboBox_Course.ForeColor = Color.Black;
            CourseSubject.CourseName = comboBox_Course.Text;
            label_Course.Text = null;
        }

        private void comboBox_Lecturer_TextChanged(object sender, EventArgs e)
        {
            comboBox_Lecturer.ForeColor = Color.Black;
            subject.LecturerName = comboBox_Lecturer.Text;
            label_Lecturer.Text = null;
        }

        private void textBox_Subject_Click(object sender, EventArgs e)
        {
            if(textBox_Subject.ForeColor != Color.Black) { textBox_Subject.Text = null; }
        }

        private void comboBox_Department_DropDown(object sender, EventArgs e)
        {
            if(comboBox_Department.ForeColor != Color.Black) {  comboBox_Department.Text = null; }
            CheckEmptyFields("Department");
        }

        private void comboBox_Course_DropDown(object sender, EventArgs e)
        {
            if(comboBox_Course.ForeColor != Color.Black) { comboBox_Course.Text = null; }
            CheckEmptyFields("Course");
        }

        private void comboBox_Lecturer_DropDown(object sender, EventArgs e)
        {
            if(comboBox_Lecturer.ForeColor != Color.Black) {comboBox_Lecturer.Text=null; }
            CheckEmptyFields("Lecturer");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadSubjects(textbox_Search.Text.ToLower());

        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CourseSubject.CourseName) && !string.IsNullOrWhiteSpace(subject.LecturerName) && !string.IsNullOrWhiteSpace(subject.DepartmentName)) 
            {
                subject.DepartmentID =Convert.ToInt32(comboBox_Department.SelectedValue);
                CourseSubject.CourseID = Convert.ToInt32(comboBox_Course.SelectedValue);
                subject.LecturerID = Convert.ToInt32(comboBox_Lecturer.SelectedValue);
            }
            CourseSubject.SubjectID = subjectController.AddSubject(subject, CourseSubject.CourseID);
            if (CourseSubject.SubjectID > 0)
            {
                csController.AddCourseSubject(CourseSubject);
                courseLecturer.CourseID = CourseSubject.CourseID;
                courseLecturer.LecturerID = subject.LecturerID;
                clController.AddCourseLecturer(courseLecturer);
                MessageBox.Show("Subject Added Successfully");
                ClearForm();
                LoadSubjects("");
                subject.DepartmentID = 0;
                CourseSubject.CourseID = 0;
                subject.CourseID = 0;

            }
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            bool DeleteStatus = subjectController.DeleteSubject(subject.Id);
            if (DeleteStatus == true) 
            {
                csController.DeleteCourseSubject(CourseSubject);
                courseLecturer.CourseID = CourseSubject.CourseID;
                courseLecturer.LecturerID = subject.LecturerID;
                clController.DeleteCourseLecturer(courseLecturer);
                MessageBox.Show("Subject Deleted Successfully");
                ClearForm();
                LoadSubjects("");
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            dashBoard.LoadForm(new DashBordHomeForm());
        }

        private void dataGridView_Subject_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView_Subject.Rows[e.RowIndex];
            subject.Id = Convert.ToInt32(row.Cells["ID"].Value);
            subject.Name = row.Cells["Name"].Value.ToString();
            subject.DepartmentID = Convert.ToInt32(row.Cells["DepartmentID"].Value.ToString());
            subject.DepartmentName = row.Cells["DepartmentName"].Value.ToString();
            subject.LecturerID = Convert.ToInt32(row.Cells["LecturerID"].Value);
            subject.LecturerName = row.Cells["LecturerName"].Value.ToString() ;
            subject.CourseID = Convert.ToInt32(row.Cells["CourseID"].Value);
            subject.CourseName = row.Cells["CourseName"].Value.ToString();
            textBox_Subject.Text = subject.Name;
            comboBox_Department.Text = subject.DepartmentName;
            comboBox_Lecturer.Text = subject.LecturerName;
            comboBox_Course.Text = subject.CourseName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
