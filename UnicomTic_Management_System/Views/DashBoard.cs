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
        public DashBoard(string Gmail,string Username,string role) 
        {
            InitializeComponent();
            label_Gmail.Text =Gmail;
            label_UserName.Text = Username;
            groupBox_User.Text = role;

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
