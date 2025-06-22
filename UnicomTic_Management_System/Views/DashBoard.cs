using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Views
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        public DashBoard(string Gmail,string Username,string role) 
        {
            InitializeComponent();
            label_Gmail.Text =Gmail;
            label_UserName.Text = Username;
            groupBox_User.Text = role;


        }
        public void LoadForm(object formobject)
        {
            if (this.panel_Main.Controls.Count > 0)
            {
                this.panel_Main.Controls.RemoveAt(0);
            }

            Form form = formobject as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel_Main.Controls.Add(form);
            form.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button_CourseManage_Click(object sender, EventArgs e)
        {
            LoadForm(new CoursesForm());
        }

        private void button_AdminManage_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewAdminForm(this));
        }

        private void button_StaffManage_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewStaffForm(this));
        }

        private void button_LecturerManage_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewLecturerForm(this));
        }

        private void button_StudentManage_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewStudentForm(this));
        }
    }
}
