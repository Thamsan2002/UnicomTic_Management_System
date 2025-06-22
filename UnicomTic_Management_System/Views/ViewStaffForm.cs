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
    public partial class ViewStaffForm : Form
    {
        public ViewStaffForm()
        {
            InitializeComponent();
        }
        Staffs staff = new Staffs();
        private DashBoard parentform;
        public ViewStaffForm(DashBoard dashBoard)
        {
            InitializeComponent();
            parentform = dashBoard;
        }
        private void LoadStaffView()
        {
            StaffController staffController = new StaffController();
            dataGridView_Staff.DataSource = staffController.LoadStaff(textBox_Search.Text);
            dataGridView_Staff.Columns["Date"].Visible = false;
            dataGridView_Staff.Columns["UserID"].Visible = false;

        }

        private void ViewStaffForm_Load(object sender, EventArgs e)
        {
            LoadStaffView();
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            LoadStaffView();
        }

        private void dataGridView_Staff_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                DataGridViewRow row = dataGridView_Staff.Rows[e.RowIndex];
                staff.Id = Convert.ToInt32(row.Cells["Id"].Value);
                staff.Date = row.Cells["Date"].Value.ToString();
                staff.FirstName = row.Cells["FirstName"].Value.ToString();
                staff.LastName = row.Cells["LastName"].Value.ToString();
                staff.Gender = row.Cells["Gender"].Value.ToString();
                staff.Phone = row.Cells["Phone"].Value.ToString();
                staff.Address = row.Cells["Address"].Value.ToString();
                staff.NicNo = row.Cells["NicNo"].Value.ToString();
                staff.Designation = row.Cells["Designation"].Value.ToString();
                staff.Salary = row.Cells["Salary"].Value.ToString();
            staff.UserID = Convert.ToInt32(row.Cells["UserID"].Value);
                List<string> stafflist = new List<string>
            {
                staff.FirstName, staff.LastName, staff.Gender, staff.Phone, staff.Address, staff.NicNo,staff.Id.ToString(),staff.UserID.ToString(),staff.Designation,staff.Salary
            };
            parentform.LoadForm(new StaffUpdateForm(stafflist, parentform));

        }

        private void button_AddStaff_Click(object sender, EventArgs e)
        {
            parentform.LoadForm(new StaffRegisterForm(parentform));
        }
    }
}
