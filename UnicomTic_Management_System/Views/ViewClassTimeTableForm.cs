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
    public partial class ViewClassTimeTableForm : Form
    {
        public ViewClassTimeTableForm()
        {
            InitializeComponent();
        }
        private DashBoard parentform;
        private string role;
        private int UserId;
        TimeTableController timeTableController = new TimeTableController();
        TimeTables TimeTable = new TimeTables();

        public ViewClassTimeTableForm(DashBoard dashBoard,string role,int UserID)
        {
            InitializeComponent();
            parentform = dashBoard;
            this.role = role;
            this.UserId = UserID;
        }
        private void LoadTimeTable() 
        {
            dataGridView.DataSource=timeTableController.ViewTimeTables(role,UserId);
            dataGridView.Columns["ID"].Visible = false;
            dataGridView.Columns["DepartmentID"].Visible = false;
            dataGridView.Columns["CourseID"].Visible = false;
            dataGridView.Columns["SubjectID"].Visible = false;
            dataGridView.Columns["HallID"].Visible = false;
        }

        private void ViewClassTimeTableForm_Load(object sender, EventArgs e)
        {
            if (role == "Staff" || role == "Student" || role =="Lecturer")
            {
                button_AddTimeTable.Visible = false;
            }
            LoadTimeTable();
            dataGridView.ReadOnly = true;
        }

        private void button_AddTimeTable_Click(object sender, EventArgs e)
        {
            parentform.LoadForm(new AddTimeTableForm(parentform,role,UserId));
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
            else if (e.ColumnIndex > 0)
            {
                if (role == "Admin" || role == "SuperAdmin")
                {
                    DialogResult result = MessageBox.Show("Are You Update This TimeTable", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                        TimeTable.ID = Convert.ToInt32(row.Cells["ID"].Value);
                        TimeTable.Date = row.Cells["Date"].Value.ToString();
                        TimeTable.StartTime = row.Cells["StartTime"].Value.ToString();
                        TimeTable.EndTime = row.Cells["EndTime"].Value.ToString();
                        TimeTable.DepartmentName = row.Cells["DepartmentName"].Value.ToString();
                        TimeTable.DepartmentID = Convert.ToInt32(row.Cells["DepartmentID"].Value);
                        TimeTable.CourseName = row.Cells["CourseName"].Value.ToString();
                        TimeTable.CourseID = Convert.ToInt32(row.Cells["CourseID"].Value);
                        TimeTable.SubjectName = row.Cells["SubjectName"].Value.ToString();
                        TimeTable.SubjectID = Convert.ToInt32(row.Cells["SubjectID"].Value);
                        TimeTable.HallName = row.Cells["HallName"].Value.ToString();
                        TimeTable.HallID = Convert.ToInt32(row.Cells["HallID"].Value);
                        List<string> list = new List<string>
                    {
                        TimeTable.ID.ToString(),TimeTable.Date,TimeTable.StartTime,TimeTable.EndTime,TimeTable.DepartmentName,TimeTable.DepartmentID.ToString(),
                        TimeTable.CourseName,TimeTable.CourseID.ToString(), TimeTable.SubjectName, TimeTable.SubjectID.ToString(),
                        TimeTable.HallName,TimeTable.HallID.ToString()
                    };
                        parentform.LoadForm(new UpdateClassTimeTableForm(parentform, list, role, UserId));
                    }
                }
            }
        }

        private void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (role == "Admin" || role == "SuperAdmin")
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                TimeTable.ID = Convert.ToInt32(row.Cells["ID"].Value);
                timeTableController.DeleteTimeTable(TimeTable.ID);
                parentform.LoadForm(new ViewClassTimeTableForm(parentform, role, UserId));
            }
        }
    }
}
