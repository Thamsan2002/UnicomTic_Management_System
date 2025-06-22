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
    public partial class LecturerUpdateForm : Form
    {
        public LecturerUpdateForm()
        {
            InitializeComponent();
        }
        Lecturers lecturer = new Lecturers();
        LecturerController lecturerController = new LecturerController();
        private DashBoard parentform;
        public LecturerUpdateForm(List<string> Lecturerlist, DashBoard dashBoard)
        {
            InitializeComponent();
            textBox_FirstName.Text = Lecturerlist[0];
            textBox_LastName.Text = Lecturerlist[1];
            if (Lecturerlist[2] == "Male") { radioButton_Male.Checked = true; }
            else if (Lecturerlist[2] == "Female") { radioButton_Female.Checked = true; }
            textBox_Phone.Text = Lecturerlist[3];
            textBox_Address.Text = Lecturerlist[4];
            textBox_NicNo.Text = Lecturerlist[5];
            lecturer.ID = Convert.ToInt32(Lecturerlist[6]);
            lecturer.UserID = Convert.ToInt32(Lecturerlist[7]);
            comboBox_Department.Text = Lecturerlist[9];
            //comboBox_Department.ValueMember = Lecturerlist[10];
            textBox_Salary.Text = Lecturerlist[8];
            lecturer.DepartmentID = Convert.ToInt32(Lecturerlist[10]);
            parentform = dashBoard;

        }
        private void GetDataAndCheckEmptyFields()
        {
            lecturer.FirstName = textBox_FirstName.Text;
            lecturer.LastName = textBox_LastName.Text;
            lecturer.Phone = textBox_Phone.Text;
            lecturer.Address = textBox_Address.Text;
            lecturer.NicNo = textBox_NicNo.Text;
            lecturer.DepartmentName = comboBox_Department.Text;
            lecturer.Salary = textBox_Salary.Text;
            if (comboBox_Department.Text != null && Convert.ToInt32(comboBox_Department.SelectedValue) != 0) { lecturer.DepartmentID = Convert.ToInt32(comboBox_Department.SelectedValue); }
            

            if (radioButton_Male.Checked) { lecturer.Gender = radioButton_Male.Text; }
            else if (radioButton_Female.Checked) { lecturer.Gender = radioButton_Female.Text; }
            List<string> Deta = new List<string>();
            Deta = lecturerController.CheckEmptyVariables(lecturer,"");
            if (Deta.Contains("FirstName")) { label_FirstName.Text = "*FirstName is Required"; }
            if (Deta.Contains("LastName")) { label_LastName.Text = "*LastName is Required"; }
            if (Deta.Contains("Phone")) { label_Phone.Text = "*Mobile Number is Required"; }
            if (Deta.Contains("Address")) { label_Address.Text = "Address is Required"; }
            if (Deta.Contains("NicNo")) { label_NicNo.Text = "*NIC Number is Required"; }
            if (Deta.Contains("Gender")) { label_Gender.Text = "*Gender is Required"; }
            if (Deta.Contains("Department")) { label_Designation.Text = "*Department is Required"; }
            if (Deta.Contains("Salary")) { label_Salary.Text = "*Salary is Required"; }
        }

        private void LecturerUpdateForm_Load(object sender, EventArgs e)
        {
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            parentform.LoadForm(new ViewLecturerForm(parentform));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            lecturerController.DeleteLecturer(lecturer);
            Close();
            parentform.LoadForm(new ViewLecturerForm(parentform));
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            lecturerController.UpdateLecturer(lecturer);
            Close();
            parentform.LoadForm(new ViewLecturerForm(parentform));


        }

        private void comboBox_Department_DropDown(object sender, EventArgs e)
        {
            DepartmentController departmentController = new DepartmentController();
            comboBox_Department.DataSource = departmentController.ViewDepartments();
            comboBox_Department.DisplayMember = "Name";
            comboBox_Department.ValueMember = "ID";
        }
    }
}
