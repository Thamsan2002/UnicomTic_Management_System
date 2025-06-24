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
    public partial class ViewExamMarkForm : Form
    {
        private DashBoard parentform;
        private string role;
        private int UserId;
        Marks mark = new Marks();
        MarkController markController = new MarkController();
        public ViewExamMarkForm()
        {
            InitializeComponent();
        }
        public ViewExamMarkForm(DashBoard dashBoard,string role,int UserId)
        {
            InitializeComponent();
            this.parentform = dashBoard;
            this.role = role;
            this.UserId = UserId;
        }
        private void LoadExamMArks() 
        {
            dataGridView.DataSource = markController.ViewExamMArks(role, UserId, textBox_Search.Text);
            dataGridView.Columns["ExamID"].Visible = false;
            dataGridView.Columns["StudentID"].Visible = false;
        }
        private void ViewExamMarkForm_Load(object sender, EventArgs e)
        {
            LoadExamMArks();
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            LoadExamMArks();
        }

        private void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (role == "Admin" || role == "SuperAdmin")
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                mark.ID = Convert.ToInt32(row.Cells["ID"].Value);
                markController.DeleteMark(mark.ID);
                parentform.LoadForm(new ViewExamMarkForm(parentform, role, UserId));
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
            else if (e.ColumnIndex > 0)
            {
                if (role != "Student")
                {
                    DialogResult result = MessageBox.Show("Are You Update This ExamMArks", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                        mark.ID = Convert.ToInt32(row.Cells["ID"].Value);
                        mark.ExamName = row.Cells["ExamName"].Value.ToString();
                        mark.StudentName = row.Cells["StudentName"].Value.ToString();
                        mark.Score= row.Cells["Score"].Value.ToString();
                        List<string> list = new List<string>
                    {
                        mark.ID.ToString(),mark.ExamName,mark.StudentName,mark.Score
                    };
                        parentform.LoadForm(new UpdateMarkForm(parentform, list, role, UserId));
                    }
                }
            }
        }
    }
}
