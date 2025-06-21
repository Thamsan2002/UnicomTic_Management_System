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
    public partial class AdminRegisterForm : Form 
    {
        public AdminRegisterForm()
        {
            InitializeComponent();
        }
        Admins admin = new Admins();
        AdminController adminControler = new AdminController();
        Users users = new Users();
        UserController userController = new UserController();
        List<string> Deta = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        { 

        }
        private void ClearForm() 
        {
            FirstName.Clear();
            LastName.Clear();
            Address.Clear();
            Gmail.Clear();
            Phone.Clear();
            NicNo.Clear();
            radiofemale.Checked = false;
            radiomale.Checked = false;
        }
        private void CheckEmptyFields(string CurrentPlace) 
        {
            Deta = adminControler.CheckEmptyVariables(admin);
            if (Deta.Contains("FirstName")) { la_FirstName.Text = "*Enter Your FirstName"; }
            if (CurrentPlace == "LastName") {return; }
            if (Deta.Contains("LastName")) { la_LastName.Text = "*Enter Your LastName"; }
            if (CurrentPlace == "Gmail") { return; }
            if (Deta.Contains("Gmail")) { la_GMail.Text = "*Enter Your Gmail Address"; }
            if (CurrentPlace == "Phone") { return; }
            if (Deta.Contains("Phone")) { la_Phone.Text = "*Enter Your Mobile Number "; }
            if (CurrentPlace == "Address") { return; }
            if (Deta.Contains("Address")) { la_Address.Text = "Enter Your Address"; }
            if (CurrentPlace == "NicNo") { return; }
            if (Deta.Contains("NicNo")) { la_Nic.Text = "*Enter Your NIC Number"; }
            if(CurrentPlace == "radiomale" || CurrentPlace == "radiomale"){ return; }
            if (Deta.Contains("Gender")) { la_Gender.Text = "*Choose Your Gender"; }
        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            FirstName.ForeColor = Color.Black;
            admin.FirstName = FirstName.Text.Trim();
            la_FirstName.Text = null;
        }
        private void LastName_TextChanged(object sender, EventArgs e)
        {
            LastName.ForeColor = Color.Black;
            admin.LastName = LastName.Text.Trim();
            la_LastName.Text = null;
            
        }
        private void Gmail_TextChanged(object sender, EventArgs e)
        {
            Gmail.ForeColor = Color.Black;
            admin.Gmail = Gmail.Text.Trim();
            la_GMail.Text = null;
        }
        private void Phone_TextChanged(object sender, EventArgs e)
        {
            Phone.ForeColor = Color.Black;
            admin.Phone = Phone.Text.Trim();
            la_Phone.Text = null;
        }
        private void Address_TextChanged(object sender, EventArgs e)
        {
            Address.ForeColor = Color.Black;
            admin.Address = Address.Text.Trim();
            la_Address.Text = null;
        }
        private void NicNo_TextChanged(object sender, EventArgs e)
        {
            NicNo.ForeColor = Color.Black;
            admin.NicNo = NicNo.Text.Trim();
            la_Nic.Text = null;
        }
        private void radiomale_CheckedChanged(object sender, EventArgs e)
        {
            if (radiomale.Checked) { la_Gender.Text = null; }
        }

        private void radiofemale_CheckedChanged(object sender, EventArgs e)
        {
            if (radiofemale.Checked) {la_Gender.Text=null; }
        }
        private void checkBox_Manual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Manual.Checked == true) { checkBox_Auto.Checked = false; }
        }

        private void checkBox_Auto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Auto.Checked == true) { checkBox_Manual.Checked = false; }
        }
        private void FirstName_Click(object sender, EventArgs e)
        {
            if(FirstName.ForeColor!=Color.Black) { FirstName.Text = null; }
        }
        private void LastName_MouseClick(object sender, MouseEventArgs e)
        {
            if (LastName.ForeColor != Color.Black) { LastName.Text = null; }
            CheckEmptyFields("LastName");
        }
        private void Gmail_Click(object sender, EventArgs e)
        {
            if(Gmail.ForeColor != Color.Black) { Gmail.Text = null; }
            CheckEmptyFields("Gmail");
        }
        private void Phone_Click(object sender, EventArgs e)
        {
            if(Phone.ForeColor!=Color.Black) { Phone.Text = null; }
            CheckEmptyFields("Phone");
        }
        private void Address_Click(object sender, EventArgs e)
        {
            if (Address.ForeColor != Color.Black) { Address.Text = null; }
            CheckEmptyFields("Address");
        }
        private void NicNo_Click(object sender, EventArgs e)
        {
            if (NicNo.ForeColor != Color.Black) {NicNo.Text= null; }
            CheckEmptyFields("NicNo");

        }
        private void radiomale_Click(object sender, EventArgs e)
        {
            CheckEmptyFields("radiomale");
        }

        private void radiofemale_Click(object sender, EventArgs e)
        {
            CheckEmptyFields("radiofemale");
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            CheckEmptyFields("btn_add");
            if (radiomale.Checked) { admin.Gender = radiomale.Text; }
            else if (radiofemale.Checked) { admin.Gender = radiofemale.Text; }
            if (checkBox_Auto.Checked) { users.UserNameCreateType = "Auto"; }
            else if (checkBox_Manual.Checked) { users.UserNameCreateType = "Manual"; }
            admin.AccessLevel = "Admin";
            admin.Date = DateTime.Now.ToString("yyyy-MM-dd");
            users.UserName = admin.LastName;
            users.Gmail = admin.Gmail;
            users.Role = admin.AccessLevel;
            users.CreatedDate = admin.Date;
            users.UpdatedDate = admin.Date;
            string UserRegisterStatus = userController.SaveUser(users);
            if (UserRegisterStatus != "Failed") 
            {
                string AdminRegisterStatus = adminControler.AdminRegister(admin);
                if (AdminRegisterStatus == "Success") 
                {
                    MessageBox.Show($"{UserRegisterStatus}");
                    ClearForm();
                }
                
            }   
        }

    }
}
