namespace UnicomTic_Management_System.Views
{
    partial class LoginForm
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
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_UserName = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.label_Password = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Forgot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "UNICOM TIC MANAGEMENT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_UserName.Location = new System.Drawing.Point(181, 111);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(232, 22);
            this.textBox_UserName.TabIndex = 1;
            this.textBox_UserName.Text = "Enter UserName or Gmail Address";
            this.textBox_UserName.Click += new System.EventHandler(this.textBox_UserName_Click);
            this.textBox_UserName.TextChanged += new System.EventHandler(this.textBox_UserName_TextChanged);
            // 
            // textBox_Password
            // 
            this.textBox_Password.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_Password.Location = new System.Drawing.Point(181, 168);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(232, 22);
            this.textBox_Password.TabIndex = 2;
            this.textBox_Password.Text = "Enter Your Password";
            this.textBox_Password.Click += new System.EventHandler(this.textBox_Password_Click);
            this.textBox_Password.TextChanged += new System.EventHandler(this.textBox_Password_TextChanged);
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.ForeColor = System.Drawing.Color.Red;
            this.label_UserName.Location = new System.Drawing.Point(178, 92);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(0, 16);
            this.label_UserName.TabIndex = 3;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(290, 221);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 35);
            this.button_Login.TabIndex = 4;
            this.button_Login.Text = "LOGIN";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.ForeColor = System.Drawing.Color.Red;
            this.label_Password.Location = new System.Drawing.Point(178, 149);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(0, 16);
            this.label_Password.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "UserName or Gmail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // button_Forgot
            // 
            this.button_Forgot.Location = new System.Drawing.Point(118, 221);
            this.button_Forgot.Name = "button_Forgot";
            this.button_Forgot.Size = new System.Drawing.Size(130, 35);
            this.button_Forgot.TabIndex = 8;
            this.button_Forgot.Text = "Forgot Password";
            this.button_Forgot.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 367);
            this.Controls.Add(this.button_Forgot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Forgot;
    }
}