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
    public partial class CoursesForm : Form
    {
        public CoursesForm()
        {
            InitializeComponent();
        }
        Courses course = new Courses();
        CourseController courseController = new CourseController();
        private void LoadDepartment() 
        {
            DepartmentController departmentController = new DepartmentController();
            comboBox_Department.DataSource = departmentController.ViewDepartments();
            comboBox_Department.DisplayMember = "Name";
            comboBox_Department.ValueMember = "ID";
        }
        private void LoadCourses() 
        {
            CoursesView.DataSource = courseController.ViewCourses(course.DepartmentName);
            CoursesView.Columns["DepartmentID"].Visible = false;
        }
        private void CoursesForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadDepartment();
        }

        private void textBox_Course_TextChanged(object sender, EventArgs e)
        {
            textBox_Course.ForeColor = Color.Black;
            course.Name = textBox_Course.Text;
            label_Course.Text = null;
        }

        private void comboBox_Department_TextChanged(object sender, EventArgs e)
        {
            comboBox_Department.ForeColor = Color.Black;
            course.DepartmentName = comboBox_Department.Text;
            LoadCourses();
            label_Department.Text = null;
        }
        //private void comboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //}

        private void textBox_Course_Click(object sender, EventArgs e)
        {
            if (textBox_Course.ForeColor != Color.Black) { textBox_Course.Text = null; }
        }

        private void comboBox_Department_Click(object sender, EventArgs e)
        {
            LoadDepartment();
            if (comboBox_Department.ForeColor != Color.Black) {  comboBox_Department.Text = null; }
            List<string> Deta = courseController.CheckEmptyVariables(course);
            if (Deta.Contains("Name")) { label_Course.Text = "*Course Name is Required"; }
        }

        private void comboBox_Department_DropDown(object sender, EventArgs e)
        {
            LoadDepartment();
            if (comboBox_Department.ForeColor != Color.Black) { comboBox_Department.Text = null; }
            comboBox_Department.ForeColor = Color.Black;
        }
        private void CoursesView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = CoursesView.Rows[e.RowIndex];
            course.Id = Convert.ToInt32(row.Cells["ID"].Value);
            course.Name = row.Cells["Name"].Value.ToString();
            course.DepartmentName = row.Cells["DepartmentName"].Value.ToString();
            course.DepartmentID = Convert.ToInt32(row.Cells["DepartmentID"].Value.ToString());
            textBox_Course.Text = course.Name;
            comboBox_Department.Text = course.DepartmentName;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (comboBox_Department.Text != null)
            {
                course.DepartmentID = Convert.ToInt32(comboBox_Department.SelectedValue);
            }
            List<string> Deta = courseController.CheckEmptyVariables(course);
            if (Deta.Contains("Name")) { label_Course.Text = "*Course Name is Required"; }
            if (Deta.Contains("DepartmentName")) { label_Department.Text = "*Department is Required"; }
            courseController.AddCourse(course);
            LoadCourses();

        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button_Delete_Click(object sender, EventArgs e)
        {
            courseController.DeleteCourse(course);
            textBox_Course.Text = null;
            comboBox_Department.Text = null;
            CoursesView.DataSource = courseController.ViewCourses(course.DepartmentName);
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Course.Text = null;
            comboBox_Department.Text= null;
            CoursesView.DataSource = courseController.ViewCourses(course.DepartmentName);

        }

        private void button_Department_Click(object sender, EventArgs e)
        {
            new DepartmentForm().ShowDialog();
            LoadDepartment();
        }

        private void comboBox_Department_SelectedValueChanged(object sender, EventArgs e)
        {

        }

    }
}
