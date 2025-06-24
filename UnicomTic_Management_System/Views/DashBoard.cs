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
        private int UserID;
        public DashBoard(string Gmail,string Username,string role,int UserID) 
        {
            InitializeComponent();
            label_Gmail.Text =Gmail;
            label_UserName.Text = Username;
            groupBox_User.Text = role;
            this.UserID =UserID;


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
            LoadForm(new DashBordHomeForm());
            if(groupBox_User.Text=="Admin" || groupBox_User.Text=="Staff" || groupBox_User.Text=="Lecture" || groupBox_User.Text == "Student") 
            {
                button_AdminManage.Visible = false;
            }
            if(groupBox_User.Text=="Staff" || groupBox_User.Text=="Lecturer" || groupBox_User.Text == "Student") 
            {
                button_StaffManage.Visible = false;
                button_LecturerManage.Visible = false;
                button_StudentManage.Visible = false;
                button_CourseManage.Visible = false;
                button_Subject.Visible=false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button_CourseManage_Click(object sender, EventArgs e)
        {
            LoadForm(new CoursesForm(this));
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

        private void button_TimeTable_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewClassTimeTableForm(this,groupBox_User.Text,UserID));
        }

        private void button_ExamTimeTable_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewExamTimeTableForm(this, groupBox_User.Text, UserID));
        }

        private void button_Marks_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewExamMarkForm(this, groupBox_User.Text, UserID));

        }

        private void button_Subject_Click(object sender, EventArgs e)
        {
            LoadForm(new SubjectForm(this));
        }
    }
}
