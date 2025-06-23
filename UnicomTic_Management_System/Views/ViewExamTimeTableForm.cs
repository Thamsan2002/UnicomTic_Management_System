using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class ViewExamTimeTableForm : Form
    {
        public ViewExamTimeTableForm()
        {
            InitializeComponent();
        }
        private DashBoard parentform;
        private string role;
        private int UserId;
        public ViewExamTimeTableForm(DashBoard dashBoard, string role, int UserID)
        {
            InitializeComponent();
            parentform = dashBoard;
            this.role = role;
            this.UserId = UserID;
        }
        ExamController examController = new ExamController();
        Exams exam = new Exams();
        private void LoadTimeTable()
        {
            dataGridView.DataSource = examController.ViewExam(role, UserId);
            dataGridView.Columns["ID"].Visible = false;
            dataGridView.Columns["DepartmentID"].Visible = false;
            dataGridView.Columns["CourseID"].Visible = false;
            dataGridView.Columns["SubjectID"].Visible = false;
            dataGridView.Columns["HallID"].Visible = false;
        }
        private void ViewExamTimeTableForm_Load(object sender, EventArgs e)
        {
            if (role == "Lecturer" || role == "Student")
            {
                button_AddExam.Visible = false;
            }
            LoadTimeTable();
            dataGridView.ReadOnly = true;
        }

        private void button_AddExam_Click(object sender, EventArgs e)
        {
            parentform.LoadForm(new AddExamTimeTableForm(parentform, role, UserId));

        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
            else if (e.ColumnIndex > 0)
            {
                if (role == "Admin" || role == "SuperAdmin" || role =="Staff")
                {
                    DialogResult result = MessageBox.Show("Are You Update This Exam", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                        exam.ID = Convert.ToInt32(row.Cells["ID"].Value);
                        exam.Date = row.Cells["Date"].Value.ToString();
                        exam.StartTime = row.Cells["StartTime"].Value.ToString();
                        exam.EndTime = row.Cells["EndTime"].Value.ToString();
                        exam.Heading = row.Cells["Heading"].Value.ToString();
                        exam.DepartmentName = row.Cells["DepartmentName"].Value.ToString();
                        exam.DepartmentID = Convert.ToInt32(row.Cells["DepartmentID"].Value);
                        exam.CourseName = row.Cells["CourseName"].Value.ToString();
                        exam.CourseID = Convert.ToInt32(row.Cells["CourseID"].Value);
                        exam.SubjectName = row.Cells["SubjectName"].Value.ToString();
                        exam.SubjectID = Convert.ToInt32(row.Cells["SubjectID"].Value);
                        exam.HallName = row.Cells["HallName"].Value.ToString();
                        exam.HallID = Convert.ToInt32(row.Cells["HallID"].Value);
                        List<string> list = new List<string>
                    {
                        exam.ID.ToString(),exam.Date,exam.StartTime,exam.EndTime,exam.DepartmentName,exam.DepartmentID.ToString(),
                        exam.CourseName,exam.CourseID.ToString(), exam.SubjectName, exam.SubjectID.ToString(),
                        exam.HallName,exam.HallID.ToString(),exam.Heading
                    };
                        parentform.LoadForm(new UpdateExamTimeTableForm(parentform, list, role, UserId));
                    }
                }
            }
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (role == "Admin" || role == "SuperAdmin")
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                exam.ID = Convert.ToInt32(row.Cells["ID"].Value);
                examController.DeleteExam(exam.ID);
                parentform.LoadForm(new ViewExamTimeTableForm(parentform, role, UserId));
            }
        }
    }
}
