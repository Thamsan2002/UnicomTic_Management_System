namespace UnicomTic_Management_System.Views
{
    partial class UserCreation
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
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.la_UserName = new System.Windows.Forms.Label();
            this.la_Password = new System.Windows.Forms.Label();
            this.la_ConfirmPassword = new System.Windows.Forms.Label();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_UserName.Location = new System.Drawing.Point(153, 88);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(215, 20);
            this.textBox_UserName.TabIndex = 0;
            this.textBox_UserName.Text = "Enter Your UserName";
            this.textBox_UserName.Click += new System.EventHandler(this.textBox_UserName_Click);
            this.textBox_UserName.TextChanged += new System.EventHandler(this.textBox_UserName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName    :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "password     :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "password     :";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(153, 142);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(215, 20);
            this.textBox_Password.TabIndex = 4;
            this.textBox_Password.Click += new System.EventHandler(this.textBox_Password_Click);
            this.textBox_Password.TextChanged += new System.EventHandler(this.textBox_Password_TextChanged);
            // 
            // textBox_ConfirmPassword
            // 
            this.textBox_ConfirmPassword.Location = new System.Drawing.Point(153, 193);
            this.textBox_ConfirmPassword.Name = "textBox_ConfirmPassword";
            this.textBox_ConfirmPassword.Size = new System.Drawing.Size(215, 20);
            this.textBox_ConfirmPassword.TabIndex = 5;
            this.textBox_ConfirmPassword.Click += new System.EventHandler(this.textBox_ConfirmPassword_Click);
            this.textBox_ConfirmPassword.TextChanged += new System.EventHandler(this.textBox_ConfirmPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "USER CREATION";
            // 
            // la_UserName
            // 
            this.la_UserName.AutoSize = true;
            this.la_UserName.BackColor = System.Drawing.SystemColors.Control;
            this.la_UserName.ForeColor = System.Drawing.Color.Red;
            this.la_UserName.Location = new System.Drawing.Point(150, 70);
            this.la_UserName.Name = "la_UserName";
            this.la_UserName.Size = new System.Drawing.Size(0, 13);
            this.la_UserName.TabIndex = 7;
            // 
            // la_Password
            // 
            this.la_Password.AutoSize = true;
            this.la_Password.ForeColor = System.Drawing.Color.Red;
            this.la_Password.Location = new System.Drawing.Point(150, 123);
            this.la_Password.Name = "la_Password";
            this.la_Password.Size = new System.Drawing.Size(0, 13);
            this.la_Password.TabIndex = 8;
            // 
            // la_ConfirmPassword
            // 
            this.la_ConfirmPassword.AutoSize = true;
            this.la_ConfirmPassword.ForeColor = System.Drawing.Color.Red;
            this.la_ConfirmPassword.Location = new System.Drawing.Point(150, 177);
            this.la_ConfirmPassword.Name = "la_ConfirmPassword";
            this.la_ConfirmPassword.Size = new System.Drawing.Size(0, 13);
            this.la_ConfirmPassword.TabIndex = 9;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(293, 262);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 10;
            this.btn_Confirm.Text = "CONFIRM";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(153, 262);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // UserCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 367);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.la_ConfirmPassword);
            this.Controls.Add(this.la_Password);
            this.Controls.Add(this.la_UserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ConfirmPassword);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_UserName);
            this.Name = "UserCreation";
            this.Text = "UserCreation";
            this.Load += new System.EventHandler(this.UserCreation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_ConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label la_UserName;
        private System.Windows.Forms.Label la_Password;
        private System.Windows.Forms.Label la_ConfirmPassword;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
    }
}