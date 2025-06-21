namespace UnicomTic_Management_System.Views
{
    partial class AdminRegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Gmail = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.radiomale = new System.Windows.Forms.RadioButton();
            this.radiofemale = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.la_FirstName = new System.Windows.Forms.Label();
            this.la_Gender = new System.Windows.Forms.Label();
            this.la_LastName = new System.Windows.Forms.Label();
            this.la_Phone = new System.Windows.Forms.Label();
            this.la_Address = new System.Windows.Forms.Label();
            this.la_GMail = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.la_Nic = new System.Windows.Forms.Label();
            this.NicNo = new System.Windows.Forms.TextBox();
            this.checkBox_Auto = new System.Windows.Forms.CheckBox();
            this.checkBox_Manual = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN REGISTER ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mobile No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "G-Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // FirstName
            // 
            this.FirstName.BackColor = System.Drawing.SystemColors.Window;
            this.FirstName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.FirstName.Location = new System.Drawing.Point(115, 83);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(199, 20);
            this.FirstName.TabIndex = 7;
            this.FirstName.Text = "Enter Your First Name";
            this.FirstName.Click += new System.EventHandler(this.FirstName_Click);
            this.FirstName.TextChanged += new System.EventHandler(this.FirstName_TextChanged);
            // 
            // LastName
            // 
            this.LastName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.LastName.Location = new System.Drawing.Point(488, 83);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(199, 20);
            this.LastName.TabIndex = 8;
            this.LastName.Text = "Enter Your Last Name";
            this.LastName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LastName_MouseClick);
            this.LastName.TextChanged += new System.EventHandler(this.LastName_TextChanged);
            // 
            // Address
            // 
            this.Address.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Address.Location = new System.Drawing.Point(115, 187);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(199, 20);
            this.Address.TabIndex = 9;
            this.Address.Text = "Enter Your Address";
            this.Address.Click += new System.EventHandler(this.Address_Click);
            this.Address.TextChanged += new System.EventHandler(this.Address_TextChanged);
            // 
            // Gmail
            // 
            this.Gmail.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Gmail.Location = new System.Drawing.Point(115, 138);
            this.Gmail.Name = "Gmail";
            this.Gmail.Size = new System.Drawing.Size(199, 20);
            this.Gmail.TabIndex = 10;
            this.Gmail.Text = "Enter Your Gmail Address";
            this.Gmail.Click += new System.EventHandler(this.Gmail_Click);
            this.Gmail.TextChanged += new System.EventHandler(this.Gmail_TextChanged);
            // 
            // Phone
            // 
            this.Phone.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Phone.Location = new System.Drawing.Point(488, 135);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(199, 20);
            this.Phone.TabIndex = 12;
            this.Phone.Text = "Enter Your Mobile Number";
            this.Phone.Click += new System.EventHandler(this.Phone_Click);
            this.Phone.TextChanged += new System.EventHandler(this.Phone_TextChanged);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(472, 352);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(87, 33);
            this.btn_add.TabIndex = 13;
            this.btn_add.Text = "REGISTER";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(337, 352);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 33);
            this.btn_Clear.TabIndex = 15;
            this.btn_Clear.Text = "CLEAR";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // radiomale
            // 
            this.radiomale.AutoSize = true;
            this.radiomale.Location = new System.Drawing.Point(115, 242);
            this.radiomale.Name = "radiomale";
            this.radiomale.Size = new System.Drawing.Size(48, 17);
            this.radiomale.TabIndex = 16;
            this.radiomale.TabStop = true;
            this.radiomale.Text = "Male";
            this.radiomale.UseVisualStyleBackColor = true;
            this.radiomale.CheckedChanged += new System.EventHandler(this.radiomale_CheckedChanged);
            this.radiomale.Click += new System.EventHandler(this.radiomale_Click);
            // 
            // radiofemale
            // 
            this.radiofemale.AutoSize = true;
            this.radiofemale.Location = new System.Drawing.Point(189, 242);
            this.radiofemale.Name = "radiofemale";
            this.radiofemale.Size = new System.Drawing.Size(59, 17);
            this.radiofemale.TabIndex = 17;
            this.radiofemale.TabStop = true;
            this.radiofemale.Text = "Female";
            this.radiofemale.UseVisualStyleBackColor = true;
            this.radiofemale.CheckedChanged += new System.EventHandler(this.radiofemale_CheckedChanged);
            this.radiofemale.Click += new System.EventHandler(this.radiofemale_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Gender";
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(189, 352);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 33);
            this.btn_back.TabIndex = 19;
            this.btn_back.Text = "BACK";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // la_FirstName
            // 
            this.la_FirstName.AutoSize = true;
            this.la_FirstName.ForeColor = System.Drawing.Color.Red;
            this.la_FirstName.Location = new System.Drawing.Point(112, 67);
            this.la_FirstName.Name = "la_FirstName";
            this.la_FirstName.Size = new System.Drawing.Size(0, 13);
            this.la_FirstName.TabIndex = 20;
            // 
            // la_Gender
            // 
            this.la_Gender.AutoSize = true;
            this.la_Gender.ForeColor = System.Drawing.Color.Red;
            this.la_Gender.Location = new System.Drawing.Point(112, 224);
            this.la_Gender.Name = "la_Gender";
            this.la_Gender.Size = new System.Drawing.Size(0, 13);
            this.la_Gender.TabIndex = 21;
            // 
            // la_LastName
            // 
            this.la_LastName.AutoSize = true;
            this.la_LastName.ForeColor = System.Drawing.Color.Red;
            this.la_LastName.Location = new System.Drawing.Point(485, 67);
            this.la_LastName.Name = "la_LastName";
            this.la_LastName.Size = new System.Drawing.Size(0, 13);
            this.la_LastName.TabIndex = 22;
            // 
            // la_Phone
            // 
            this.la_Phone.AutoSize = true;
            this.la_Phone.ForeColor = System.Drawing.Color.Red;
            this.la_Phone.Location = new System.Drawing.Point(485, 119);
            this.la_Phone.Name = "la_Phone";
            this.la_Phone.Size = new System.Drawing.Size(0, 13);
            this.la_Phone.TabIndex = 23;
            // 
            // la_Address
            // 
            this.la_Address.AutoSize = true;
            this.la_Address.ForeColor = System.Drawing.Color.Red;
            this.la_Address.Location = new System.Drawing.Point(112, 171);
            this.la_Address.Name = "la_Address";
            this.la_Address.Size = new System.Drawing.Size(0, 13);
            this.la_Address.TabIndex = 24;
            // 
            // la_GMail
            // 
            this.la_GMail.AutoSize = true;
            this.la_GMail.ForeColor = System.Drawing.Color.Red;
            this.la_GMail.Location = new System.Drawing.Point(112, 119);
            this.la_GMail.Name = "la_GMail";
            this.la_GMail.Size = new System.Drawing.Size(0, 13);
            this.la_GMail.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(391, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "NIC No";
            // 
            // la_Nic
            // 
            this.la_Nic.AutoSize = true;
            this.la_Nic.ForeColor = System.Drawing.Color.Red;
            this.la_Nic.Location = new System.Drawing.Point(485, 171);
            this.la_Nic.Name = "la_Nic";
            this.la_Nic.Size = new System.Drawing.Size(0, 13);
            this.la_Nic.TabIndex = 27;
            // 
            // NicNo
            // 
            this.NicNo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.NicNo.Location = new System.Drawing.Point(488, 187);
            this.NicNo.Name = "NicNo";
            this.NicNo.Size = new System.Drawing.Size(199, 20);
            this.NicNo.TabIndex = 28;
            this.NicNo.Text = "Enter Your NIC Number";
            this.NicNo.Click += new System.EventHandler(this.NicNo_Click);
            this.NicNo.TextChanged += new System.EventHandler(this.NicNo_TextChanged);
            // 
            // checkBox_Auto
            // 
            this.checkBox_Auto.AutoSize = true;
            this.checkBox_Auto.Checked = true;
            this.checkBox_Auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Auto.Location = new System.Drawing.Point(26, 284);
            this.checkBox_Auto.Name = "checkBox_Auto";
            this.checkBox_Auto.Size = new System.Drawing.Size(332, 17);
            this.checkBox_Auto.TabIndex = 29;
            this.checkBox_Auto.Text = "Choose LastName as a UserName and Autogenarated Password";
            this.checkBox_Auto.UseVisualStyleBackColor = true;
            this.checkBox_Auto.CheckedChanged += new System.EventHandler(this.checkBox_Auto_CheckedChanged);
            // 
            // checkBox_Manual
            // 
            this.checkBox_Manual.AutoSize = true;
            this.checkBox_Manual.Location = new System.Drawing.Point(26, 307);
            this.checkBox_Manual.Name = "checkBox_Manual";
            this.checkBox_Manual.Size = new System.Drawing.Size(230, 17);
            this.checkBox_Manual.TabIndex = 30;
            this.checkBox_Manual.Text = "Choose UserName and Password Manually";
            this.checkBox_Manual.UseVisualStyleBackColor = true;
            this.checkBox_Manual.CheckedChanged += new System.EventHandler(this.checkBox_Manual_CheckedChanged);
            // 
            // AdminRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.checkBox_Manual);
            this.Controls.Add(this.checkBox_Auto);
            this.Controls.Add(this.NicNo);
            this.Controls.Add(this.la_Nic);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.la_GMail);
            this.Controls.Add(this.la_Address);
            this.Controls.Add(this.la_Phone);
            this.Controls.Add(this.la_LastName);
            this.Controls.Add(this.la_Gender);
            this.Controls.Add(this.la_FirstName);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radiofemale);
            this.Controls.Add(this.radiomale);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Gmail);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "AdminRegisterForm";
            this.Text = "Admin Register";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Gmail;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.RadioButton radiomale;
        private System.Windows.Forms.RadioButton radiofemale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label la_FirstName;
        private System.Windows.Forms.Label la_Gender;
        private System.Windows.Forms.Label la_LastName;
        private System.Windows.Forms.Label la_Phone;
        private System.Windows.Forms.Label la_Address;
        private System.Windows.Forms.Label la_GMail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label la_Nic;
        private System.Windows.Forms.TextBox NicNo;
        private System.Windows.Forms.CheckBox checkBox_Auto;
        private System.Windows.Forms.CheckBox checkBox_Manual;
    }
}