namespace UnicomTic_Management_System.Views
{
    partial class StudentRegisterForm
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
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.textBox_NicNo = new System.Windows.Forms.TextBox();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.textBox_Gmail = new System.Windows.Forms.TextBox();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Department = new System.Windows.Forms.Label();
            this.label_Course = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_NicNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_Gender = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label_Phone = new System.Windows.Forms.Label();
            this.label_Address = new System.Windows.Forms.Label();
            this.label_FirstName = new System.Windows.Forms.Label();
            this.label_Gmail = new System.Windows.Forms.Label();
            this.label_LastName = new System.Windows.Forms.Label();
            this.comboBox_Course = new System.Windows.Forms.ComboBox();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.radioButton_Male = new System.Windows.Forms.RadioButton();
            this.radioButton_Female = new System.Windows.Forms.RadioButton();
            this.checkBox_Auto = new System.Windows.Forms.CheckBox();
            this.checkBox_Manual = new System.Windows.Forms.CheckBox();
            this.button_Back = new System.Windows.Forms.Button();
            this.button_Register = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "STUDENT REGISTER";
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_LastName.Location = new System.Drawing.Point(490, 75);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.Size = new System.Drawing.Size(197, 20);
            this.textBox_LastName.TabIndex = 1;
            this.textBox_LastName.Text = "Enter LastName";
            this.textBox_LastName.Click += new System.EventHandler(this.textBox_LastName_Click);
            this.textBox_LastName.TextChanged += new System.EventHandler(this.textBox_LastName_TextChanged);
            // 
            // textBox_NicNo
            // 
            this.textBox_NicNo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_NicNo.Location = new System.Drawing.Point(490, 172);
            this.textBox_NicNo.Name = "textBox_NicNo";
            this.textBox_NicNo.Size = new System.Drawing.Size(197, 20);
            this.textBox_NicNo.TabIndex = 2;
            this.textBox_NicNo.Text = "Enter NIC Number";
            this.textBox_NicNo.Click += new System.EventHandler(this.textBox_NicNo_Click);
            this.textBox_NicNo.TextChanged += new System.EventHandler(this.textBox_NicNo_TextChanged);
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_Phone.Location = new System.Drawing.Point(490, 124);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(197, 20);
            this.textBox_Phone.TabIndex = 3;
            this.textBox_Phone.Text = "Enter Mobile Number";
            this.textBox_Phone.Click += new System.EventHandler(this.textBox_Phone_Click);
            this.textBox_Phone.TextChanged += new System.EventHandler(this.textBox_Phone_TextChanged);
            // 
            // textBox_Address
            // 
            this.textBox_Address.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_Address.Location = new System.Drawing.Point(128, 172);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(197, 20);
            this.textBox_Address.TabIndex = 4;
            this.textBox_Address.Text = "Enter Address";
            this.textBox_Address.Click += new System.EventHandler(this.textBox_Address_Click);
            this.textBox_Address.TextChanged += new System.EventHandler(this.textBox_Address_TextChanged);
            // 
            // textBox_Gmail
            // 
            this.textBox_Gmail.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_Gmail.Location = new System.Drawing.Point(128, 124);
            this.textBox_Gmail.Name = "textBox_Gmail";
            this.textBox_Gmail.Size = new System.Drawing.Size(197, 20);
            this.textBox_Gmail.TabIndex = 5;
            this.textBox_Gmail.Text = "Enter GMail Address";
            this.textBox_Gmail.Click += new System.EventHandler(this.textBox_Gmail_Click);
            this.textBox_Gmail.TextChanged += new System.EventHandler(this.textBox_Gmail_TextChanged);
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_FirstName.Location = new System.Drawing.Point(128, 75);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.Size = new System.Drawing.Size(197, 20);
            this.textBox_FirstName.TabIndex = 6;
            this.textBox_FirstName.Text = "Enter FirstName";
            this.textBox_FirstName.Click += new System.EventHandler(this.textBox_FirstName_Click);
            this.textBox_FirstName.TextChanged += new System.EventHandler(this.textBox_FirstName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "GMail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "MobileNo";
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.ForeColor = System.Drawing.Color.Red;
            this.label_Department.Location = new System.Drawing.Point(487, 205);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(0, 13);
            this.label_Department.TabIndex = 9;
            // 
            // label_Course
            // 
            this.label_Course.AutoSize = true;
            this.label_Course.ForeColor = System.Drawing.Color.Red;
            this.label_Course.Location = new System.Drawing.Point(125, 251);
            this.label_Course.Name = "label_Course";
            this.label_Course.Size = new System.Drawing.Size(0, 13);
            this.label_Course.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Gender";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "NicNo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "LastName";
            // 
            // label_NicNo
            // 
            this.label_NicNo.AutoSize = true;
            this.label_NicNo.ForeColor = System.Drawing.Color.Red;
            this.label_NicNo.Location = new System.Drawing.Point(487, 156);
            this.label_NicNo.Name = "label_NicNo";
            this.label_NicNo.Size = new System.Drawing.Size(0, 13);
            this.label_NicNo.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(399, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Department";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Course";
            // 
            // label_Gender
            // 
            this.label_Gender.AutoSize = true;
            this.label_Gender.ForeColor = System.Drawing.Color.Red;
            this.label_Gender.Location = new System.Drawing.Point(125, 205);
            this.label_Gender.Name = "label_Gender";
            this.label_Gender.Size = new System.Drawing.Size(0, 13);
            this.label_Gender.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "FirstName";
            // 
            // label_Phone
            // 
            this.label_Phone.AutoSize = true;
            this.label_Phone.ForeColor = System.Drawing.Color.Red;
            this.label_Phone.Location = new System.Drawing.Point(487, 108);
            this.label_Phone.Name = "label_Phone";
            this.label_Phone.Size = new System.Drawing.Size(0, 13);
            this.label_Phone.TabIndex = 20;
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.ForeColor = System.Drawing.Color.Red;
            this.label_Address.Location = new System.Drawing.Point(125, 156);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(0, 13);
            this.label_Address.TabIndex = 21;
            // 
            // label_FirstName
            // 
            this.label_FirstName.AutoSize = true;
            this.label_FirstName.ForeColor = System.Drawing.Color.Red;
            this.label_FirstName.Location = new System.Drawing.Point(125, 59);
            this.label_FirstName.Name = "label_FirstName";
            this.label_FirstName.Size = new System.Drawing.Size(0, 13);
            this.label_FirstName.TabIndex = 22;
            // 
            // label_Gmail
            // 
            this.label_Gmail.AutoSize = true;
            this.label_Gmail.ForeColor = System.Drawing.Color.Red;
            this.label_Gmail.Location = new System.Drawing.Point(125, 108);
            this.label_Gmail.Name = "label_Gmail";
            this.label_Gmail.Size = new System.Drawing.Size(0, 13);
            this.label_Gmail.TabIndex = 23;
            // 
            // label_LastName
            // 
            this.label_LastName.AutoSize = true;
            this.label_LastName.ForeColor = System.Drawing.Color.Red;
            this.label_LastName.Location = new System.Drawing.Point(487, 59);
            this.label_LastName.Name = "label_LastName";
            this.label_LastName.Size = new System.Drawing.Size(0, 13);
            this.label_LastName.TabIndex = 24;
            // 
            // comboBox_Course
            // 
            this.comboBox_Course.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox_Course.FormattingEnabled = true;
            this.comboBox_Course.Location = new System.Drawing.Point(128, 267);
            this.comboBox_Course.Name = "comboBox_Course";
            this.comboBox_Course.Size = new System.Drawing.Size(197, 21);
            this.comboBox_Course.TabIndex = 25;
            this.comboBox_Course.Text = "Choose Course";
            this.comboBox_Course.DropDown += new System.EventHandler(this.comboBox_Course_DropDown);
            this.comboBox_Course.TextChanged += new System.EventHandler(this.comboBox_Course_TextChanged);
            this.comboBox_Course.Click += new System.EventHandler(this.comboBox_Course_Click);
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(490, 221);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(197, 21);
            this.comboBox_Department.TabIndex = 26;
            this.comboBox_Department.Text = "Choose Department";
            this.comboBox_Department.DropDown += new System.EventHandler(this.comboBox_Department_DropDown);
            this.comboBox_Department.TextChanged += new System.EventHandler(this.comboBox_Department_TextChanged);
            this.comboBox_Department.Click += new System.EventHandler(this.comboBox_Department_Click);
            // 
            // radioButton_Male
            // 
            this.radioButton_Male.AutoSize = true;
            this.radioButton_Male.Location = new System.Drawing.Point(128, 222);
            this.radioButton_Male.Name = "radioButton_Male";
            this.radioButton_Male.Size = new System.Drawing.Size(48, 17);
            this.radioButton_Male.TabIndex = 27;
            this.radioButton_Male.TabStop = true;
            this.radioButton_Male.Text = "Male";
            this.radioButton_Male.UseVisualStyleBackColor = true;
            this.radioButton_Male.CheckedChanged += new System.EventHandler(this.radioButton_Male_CheckedChanged);
            // 
            // radioButton_Female
            // 
            this.radioButton_Female.AutoSize = true;
            this.radioButton_Female.Location = new System.Drawing.Point(195, 222);
            this.radioButton_Female.Name = "radioButton_Female";
            this.radioButton_Female.Size = new System.Drawing.Size(59, 17);
            this.radioButton_Female.TabIndex = 28;
            this.radioButton_Female.TabStop = true;
            this.radioButton_Female.Text = "Female";
            this.radioButton_Female.UseVisualStyleBackColor = true;
            this.radioButton_Female.CheckedChanged += new System.EventHandler(this.radioButton_Female_CheckedChanged);
            // 
            // checkBox_Auto
            // 
            this.checkBox_Auto.AutoSize = true;
            this.checkBox_Auto.Checked = true;
            this.checkBox_Auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Auto.Location = new System.Drawing.Point(37, 306);
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
            this.checkBox_Manual.Location = new System.Drawing.Point(37, 329);
            this.checkBox_Manual.Name = "checkBox_Manual";
            this.checkBox_Manual.Size = new System.Drawing.Size(230, 17);
            this.checkBox_Manual.TabIndex = 30;
            this.checkBox_Manual.Text = "Choose UserName and Password Manually";
            this.checkBox_Manual.UseVisualStyleBackColor = true;
            this.checkBox_Manual.CheckedChanged += new System.EventHandler(this.checkBox_Manual_CheckedChanged);
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(224, 358);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(75, 34);
            this.button_Back.TabIndex = 31;
            this.button_Back.Text = "BACK";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // button_Register
            // 
            this.button_Register.Location = new System.Drawing.Point(490, 358);
            this.button_Register.Name = "button_Register";
            this.button_Register.Size = new System.Drawing.Size(75, 34);
            this.button_Register.TabIndex = 32;
            this.button_Register.Text = "REGISTER";
            this.button_Register.UseVisualStyleBackColor = true;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(361, 358);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 34);
            this.button_Clear.TabIndex = 33;
            this.button_Clear.Text = "CLEAR";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // StudentRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Register);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.checkBox_Manual);
            this.Controls.Add(this.checkBox_Auto);
            this.Controls.Add(this.radioButton_Female);
            this.Controls.Add(this.radioButton_Male);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.comboBox_Course);
            this.Controls.Add(this.label_LastName);
            this.Controls.Add(this.label_Gmail);
            this.Controls.Add(this.label_FirstName);
            this.Controls.Add(this.label_Address);
            this.Controls.Add(this.label_Phone);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label_Gender);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_NicNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_Course);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_FirstName);
            this.Controls.Add(this.textBox_Gmail);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.textBox_Phone);
            this.Controls.Add(this.textBox_NicNo);
            this.Controls.Add(this.textBox_LastName);
            this.Controls.Add(this.label1);
            this.Name = "StudentRegisterForm";
            this.Text = "StudentRegisterForm";
            this.Load += new System.EventHandler(this.StudentRegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.TextBox textBox_NicNo;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.TextBox textBox_Gmail;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.Label label_Course;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_NicNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_Gender;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_Phone;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Label label_FirstName;
        private System.Windows.Forms.Label label_Gmail;
        private System.Windows.Forms.Label label_LastName;
        private System.Windows.Forms.ComboBox comboBox_Course;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.RadioButton radioButton_Male;
        private System.Windows.Forms.RadioButton radioButton_Female;
        private System.Windows.Forms.CheckBox checkBox_Auto;
        private System.Windows.Forms.CheckBox checkBox_Manual;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Register;
        private System.Windows.Forms.Button button_Clear;
    }
}