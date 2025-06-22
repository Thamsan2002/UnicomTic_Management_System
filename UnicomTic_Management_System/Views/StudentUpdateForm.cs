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
    public partial class StudentUpdateForm : Form
    {
        public StudentUpdateForm()
        {
            InitializeComponent();
        }
        Students student = new Students();
        StudentController studentController = new StudentController();
        private DashBoard parentform;
        public StudentUpdateForm(List<string> studentlist, DashBoard dashBoard)
        {
            InitializeComponent();
            textBox_FirstName.Text = studentlist[0];
            textBox_LastName.Text = studentlist[1];
            if (studentlist[2] == "Male") { radioButton_Male.Checked = true; }
            else if (studentlist[2] == "Female") { radioButton_Female.Checked = true; }
            textBox_Phone.Text = studentlist[3];
            textBox_Address.Text = studentlist[4];
            textBox_NicNo.Text = studentlist[5];
            student.Id = Convert.ToInt32(studentlist[6]);
            student.UserID = Convert.ToInt32(studentlist[7]);
            parentform = dashBoard;

        }
        private void GetDataAndCheckEmptyFields()
        {
            student.FirstName = textBox_FirstName.Text;
            student.LastName = textBox_LastName.Text;
            student.Phone = textBox_Phone.Text;
            student.Address = textBox_Address.Text;
            student.NicNo = textBox_NicNo.Text;
            if (radioButton_Male.Checked) { student.Gender = radioButton_Male.Text; }
            else if (radioButton_Female.Checked) { student.Gender = radioButton_Female.Text; }
            List<string> Deta = new List<string>();
            Deta = studentController.CheckEmptyVariables(student,"");
            if (Deta.Contains("FirstName")) { label_FirstName.Text = "*FirstName is Required"; }
            if (Deta.Contains("LastName")) { label_LastName.Text = "*LastName is Required"; }
            if (Deta.Contains("Phone")) { label_Phone.Text = "*Mobile Number is Required"; }
            if (Deta.Contains("Address")) { label_Address.Text = "Address is Required"; }
            if (Deta.Contains("NicNo")) { label_NicNo.Text = "*NIC Number is Required"; }
            if (Deta.Contains("Gender")) { label_Gender.Text = "*Gender is Required"; }
        }

        private void StudentUpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            parentform.LoadForm(new ViewStudentForm(parentform)); 
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            studentController.DeleteStudent(student);
            Close();
            parentform.LoadForm(new ViewStudentForm(parentform));
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            studentController.UpdateStudent(student);
            Close();
            parentform.LoadForm(new ViewStudentForm(parentform));
        }
    }
}
