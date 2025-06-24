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
    public partial class UpdateMarkForm : Form
    {
        public UpdateMarkForm()
        {
            InitializeComponent();
        }
        private DashBoard parentform;
        private string role;
        private int UserId;
        Marks mark = new Marks();
        MarkController markController = new MarkController();
        public UpdateMarkForm(DashBoard parentform,List<string> list,string role,int UserId)
        {
            InitializeComponent();
            this.parentform = parentform;
            this.role = role;
            this.UserId = UserId;
            mark.ID = Convert.ToInt32(list[0]);
            label_ExamName.Text = list[1];
            label_StudentName.Text = list[2];
            textBox_Score.Text = list[3];

        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            parentform.LoadForm(new ViewExamMarkForm(parentform, role, UserId));
        }

        private void UpdateMarkForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            mark.Score = textBox_Score.Text;
            bool result =markController.UpdateMark(mark);
            if (result == true) 
            {
                Close();
                parentform.LoadForm(new ViewExamMarkForm(parentform, role, UserId));
            }
        }
    }
}
