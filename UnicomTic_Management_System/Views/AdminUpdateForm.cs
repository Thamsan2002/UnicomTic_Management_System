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
    public partial class AdminUpdateForm : Form
    {
        public AdminUpdateForm()
        {
            InitializeComponent();
        }
        Admins admin = new Admins();
        AdminController adminController = new AdminController();
        private DashBoard parentform;
        public AdminUpdateForm(List<string> adminlist,DashBoard dashBoard)
        {
            InitializeComponent();
            FirstName.Text = adminlist[0];
            LastName.Text = adminlist[1];
            if (adminlist[2] == "Male") {radiomale.Checked = true;}
            else if (adminlist[2] == "Female") {  radiofemale.Checked = true;}
            Phone.Text = adminlist[3];
            Address.Text = adminlist[4];
            NicNo.Text = adminlist[5];
            admin.Id = Convert.ToInt32(adminlist[6]);
            admin.UserID= Convert.ToInt32(adminlist[7]);
            parentform = dashBoard;

        }
        private void GetDataAndCheckEmptyFields()
        {
            admin.FirstName = FirstName.Text;
            admin.LastName = LastName.Text;
            admin.Phone = Phone.Text;
            admin.Address = Address.Text;
            admin.NicNo = NicNo.Text;
            if (radiomale.Checked) { admin.Gender = radiomale.Text; }
            else if (radiofemale.Checked) { admin.Gender = radiofemale.Text; }
            List<string> Deta = new List<string>();
            Deta = adminController.CheckEmptyVariables(admin,"");
            if (Deta.Contains("FirstName")) { la_FirstName.Text = "*FirstName is Required"; }
            if (Deta.Contains("LastName")) { la_LastName.Text = "*LastName is Required"; }
            if (Deta.Contains("Phone")) { la_Phone.Text = "*Mobile Number is Required"; }
            if (Deta.Contains("Address")) { la_Address.Text = "Address is Required"; }
            if (Deta.Contains("NicNo")) { la_Nic.Text = "*NIC Number is Required"; }
            if (Deta.Contains("Gender")) { la_Gender.Text = "*Gender is Required"; }
        }
        private void AdminUpdateForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Close();
            parentform.LoadForm(new ViewAdminForm(parentform));
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            adminController.UpdateAdmin(admin);
            Close();
            parentform.LoadForm(new ViewAdminForm(parentform));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            GetDataAndCheckEmptyFields();
            adminController.DeleteAdmin(admin);
            Close();
            parentform.LoadForm(new ViewAdminForm(parentform));

        }
    }
}
