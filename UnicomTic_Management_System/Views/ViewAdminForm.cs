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
    public partial class ViewAdminForm : Form
    {
        public ViewAdminForm()
        {
            InitializeComponent();
        }
        private DashBoard parentform;

        public ViewAdminForm(DashBoard dashBoard)
        {
            InitializeComponent();
            parentform = dashBoard;
        }
        Admins admin = new Admins();
        private void LoadAdminView() 
        {
            AdminController adminController = new AdminController();
            dataGridView_Admin.DataSource = adminController.LoadAdmins(textBox_Search.Text);
            dataGridView_Admin.Columns["UserID"].Visible = false;
            dataGridView_Admin.Columns["AccessLevel"].Visible = false;
            
        }
        private void ViewAdminForm_Load(object sender, EventArgs e)
        {
            LoadAdminView();
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            LoadAdminView();
        }

        private void dataGridView_Admin_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView_Admin.Rows[e.RowIndex];
            admin.Id = Convert.ToInt32(row.Cells["Id"].Value);
            admin.Date = row.Cells["Date"].Value.ToString();
            admin.FirstName = row.Cells["FirstName"].Value.ToString();
            admin.LastName = row.Cells["LastName"].Value.ToString();
            admin.Gender = row.Cells["Gender"].Value.ToString();
            admin.Phone = row.Cells["Phone"].Value.ToString();
            admin.Address = row.Cells["Address"].Value.ToString();
            admin.NicNo = row.Cells["NicNo"].Value.ToString();
            admin.UserID = Convert.ToInt32(row.Cells["UserID"].Value);
            List<string> adminlist = new List<string>
            {
                admin.FirstName, admin.LastName, admin.Gender, admin.Phone, admin.Address, admin.NicNo,admin.Id.ToString(),admin.UserID.ToString()
            };
            parentform.LoadForm(new AdminUpdateForm(adminlist,parentform));

        }

        private void button_AddAdmin_Click(object sender, EventArgs e)
        {
            parentform.LoadForm(new AdminRegisterForm(parentform));
        }
    }
}
