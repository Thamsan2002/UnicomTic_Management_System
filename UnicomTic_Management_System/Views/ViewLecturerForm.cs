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
    public partial class ViewLecturerForm : Form
    {
        public ViewLecturerForm()
        {
            InitializeComponent();
        }
        private DashBoard parentform;
        public ViewLecturerForm(DashBoard dashBoard)
        {
            InitializeComponent();
            parentform = dashBoard;
        }
        Lecturers lecturer = new Lecturers();
        private void LoadSLecturerView()
        {
            LecturerController lecturercontroller = new LecturerController();   
            dataGridView_Lecturer.DataSource = lecturercontroller.LoadLecturer(textBox_Search.Text);
            dataGridView_Lecturer.Columns["CourseID"].Visible = false;
            dataGridView_Lecturer.Columns["CourseName"].Visible = false;
            dataGridView_Lecturer.Columns["UserID"].Visible = false;
            dataGridView_Lecturer.Columns["DepartmentID"].Visible = false;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_AddStaff_Click(object sender, EventArgs e)
        {
            parentform.LoadForm(new LecturerRegisterForm(parentform));
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            LoadSLecturerView();
        }

        private void ViewLecturerForm_Load(object sender, EventArgs e)
        {
            LoadSLecturerView();
        }

        private void dataGridView_Lecturer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                DataGridViewRow row = dataGridView_Lecturer.Rows[e.RowIndex];
                lecturer.ID = Convert.ToInt32(row.Cells["ID"].Value);
                lecturer.Date = row.Cells["Date"].Value.ToString();
                lecturer.FirstName = row.Cells["FirstName"].Value.ToString();
                lecturer.LastName = row.Cells["LastName"].Value.ToString();
                lecturer.Gender = row.Cells["Gender"].Value.ToString();
                lecturer.Phone = row.Cells["Phone"].Value.ToString();
                lecturer.Address = row.Cells["Address"].Value.ToString();
                lecturer.NicNo = row.Cells["NicNo"].Value.ToString();
                lecturer.DepartmentName = row.Cells["DepartmentName"].Value.ToString();
                lecturer.Salary = row.Cells["Salary"].Value.ToString();
                lecturer.UserID = Convert.ToInt32(row.Cells["UserID"].Value);
                lecturer.DepartmentID = Convert.ToInt32(row.Cells["DepartmentID"].Value);
                List<string> stafflist = new List<string>
            {
                lecturer.FirstName, lecturer.LastName, lecturer.Gender, lecturer.Phone, lecturer.Address, lecturer.NicNo,lecturer.ID.ToString(),lecturer.UserID.ToString(),lecturer.Salary, lecturer.DepartmentName, lecturer.DepartmentID.ToString()
            };
                parentform.LoadForm(new LecturerUpdateForm(stafflist, parentform));
         
        }
    }
}
