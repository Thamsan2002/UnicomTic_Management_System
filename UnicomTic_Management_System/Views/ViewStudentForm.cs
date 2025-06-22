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
    public partial class ViewStudentForm : Form
    {
        public ViewStudentForm()
        {
            InitializeComponent();
        }
        private DashBoard parentform;

        public ViewStudentForm(DashBoard dashBoard)
        {
            InitializeComponent();
            parentform = dashBoard;
        }
        Students student = new Students();
        private void LoadStudentView()
        {
            StudentController studentcontroller = new StudentController();
            dataGridView_Student.DataSource = studentcontroller.LoadStudents(textBox_Search.Text);
            dataGridView_Student.Columns["UserID"].Visible = false;
            dataGridView_Student.Columns["CourseID"].Visible = false;
            dataGridView_Student.Columns["DepartmentID"].Visible = false;

        }

        private void ViewStudentForm_Load(object sender, EventArgs e)
        {
            LoadStudentView();
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            LoadStudentView();
        }

        private void dataGridView_Student_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewRow row = dataGridView_Student.Rows[e.RowIndex];
            student.Id = Convert.ToInt32(row.Cells["Id"].Value);
            student.Date = row.Cells["Date"].Value.ToString();
            student.FirstName = row.Cells["FirstName"].Value.ToString();
            student.LastName = row.Cells["LastName"].Value.ToString();
            student.Phone = row.Cells["Phone"].Value.ToString();
            student.Address = row.Cells["Address"].Value.ToString();
            student.Gender = row.Cells["Gender"].Value.ToString();
            student.NicNo = row.Cells["NicNo"].Value.ToString();
            student.UserID = Convert.ToInt32(row.Cells["UserID"].Value);
            List<string> studentlist = new List<string>
            {
                student.FirstName, student.LastName, student.Gender, student.Phone, student.Address, student.NicNo,student.Id.ToString(),student.UserID.ToString()
            };
            parentform.LoadForm(new StudentUpdateForm(studentlist, parentform));
        }

        private void button_AddStudent_Click(object sender, EventArgs e)
        {
            parentform.LoadForm(new StudentRegisterForm(parentform));
        }
    }
}
