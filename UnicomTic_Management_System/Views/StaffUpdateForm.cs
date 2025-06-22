using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Controllers;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Views
{
    public partial class StaffUpdateForm : Form
    {
        public StaffUpdateForm()
        {
            InitializeComponent();
        }
        Staffs staff = new Staffs();
        StaffController staffcontroller = new StaffController();
        private DashBoard parentform;
        public StaffUpdateForm(List<string> stafflist, DashBoard dashBoard)
        {
            InitializeComponent();
            textBox_FirstName.Text = stafflist[0];
            textBox_LastName.Text = stafflist[1];
            if (stafflist[2] == "Male") { radioButton_Male.Checked = true; }
            else if (stafflist[2] == "Female") { radioButton_Female.Checked = true; }
            textBox_Phone.Text = stafflist[3];
            textBox_Address.Text = stafflist[4];
            textBox_NicNo.Text = stafflist[5];
            staff.Id = Convert.ToInt32(stafflist[6]);
            staff.UserID = Convert.ToInt32(stafflist[7]);
            textBox_Designation.Text = stafflist[8];
            textBox_Salary.Text = stafflist[9];
            parentform = dashBoard;

        }
        private void GetDataAndCheckEmptyFields()
        {
            staff.FirstName = textBox_FirstName.Text;
            staff.LastName = textBox_LastName.Text;
            staff.Phone = textBox_Phone.Text;
            staff.Address = textBox_Address.Text;
            staff.NicNo = textBox_NicNo.Text;
            staff.Designation = textBox_Designation.Text;
            staff.Salary = textBox_Salary.Text;
            if (radioButton_Male.Checked) { staff.Gender = radioButton_Male.Text; }
            else if (radioButton_Female.Checked) { staff.Gender = radioButton_Female.Text; }
            List<string> Deta = new List<string>();
            Deta = staffcontroller.CheckEmptyVariables(staff, "");
            if (Deta.Contains("FirstName")) { label_FirstName.Text = "*FirstName is Required"; }
            if (Deta.Contains("LastName")) { label_LastName.Text = "*LastName is Required"; }
            if (Deta.Contains("Phone")) { label_Phone.Text = "*Mobile Number is Required"; }
            if (Deta.Contains("Address")) { label_Address.Text = "Address is Required"; }
            if (Deta.Contains("NicNo")) { label_NicNo.Text = "*NIC Number is Required"; }
            if (Deta.Contains("Gender")) { label_Gender.Text = "*Gender is Required"; }
            if (Deta.Contains("Designation")) { label_Designation.Text = "*Designation is Required"; }
            if (Deta.Contains("Salary")) { label_Salary.Text = "*Salary is Required"; }
        }

        private void StaffUpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            parentform.LoadForm(new ViewStaffForm(parentform));
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            staffcontroller.UpdateStaff(staff);
            Close();
            parentform.LoadForm(new ViewStaffForm(parentform));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            staffcontroller.DeleteStaff(staff);
            Close();
            parentform.LoadForm(new ViewStaffForm(parentform));
        }
    }
}
