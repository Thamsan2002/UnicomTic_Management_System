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
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();
        }
        private DashBoard dashbord;
        public DepartmentForm(DashBoard dashBoard)
        {
            InitializeComponent();
            dashbord = dashBoard;
        }
        Departments department = new Departments();
        DepartmentController departmentController = new DepartmentController();
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
           dataGridView_Department.DataSource = departmentController.ViewDepartments();
        }
        private void textBox_Department_TextChanged(object sender, EventArgs e)
        {
            textBox_Department.ForeColor = Color.Black;
            department.Name = textBox_Department.Text;
        }
        private void textBox_Department_Click(object sender, EventArgs e)
        {
            if (textBox_Department.ForeColor != Color.Black) { textBox_Department.Text = null; }
        }
        private void dataGridView_Department_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView_Department.Rows[e.RowIndex];
            department.ID =Convert.ToInt32(row.Cells[0].Value);
            department.Name =Convert.ToString(row.Cells[1].Value);
            textBox_Department.Text=department.Name;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            dashbord.LoadForm(new CoursesForm(dashbord));
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            departmentController.AddDepartment(department);
            dataGridView_Department.DataSource = departmentController.ViewDepartments();
            textBox_Department.Clear();
        }


        private void button_Delete_Click(object sender, EventArgs e)
        {
            departmentController.DeleteDepartment(department);
            dataGridView_Department.DataSource= departmentController.ViewDepartments();
        }
    }
}
