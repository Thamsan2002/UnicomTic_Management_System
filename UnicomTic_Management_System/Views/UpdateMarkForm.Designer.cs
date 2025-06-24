namespace UnicomTic_Management_System.Views
{
    partial class UpdateMarkForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_StudentName = new System.Windows.Forms.Label();
            this.label_ExamName = new System.Windows.Forms.Label();
            this.textBox_Score = new System.Windows.Forms.TextBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADD / UPDATE MARKS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exam Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mark";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Student Name";
            // 
            // label_StudentName
            // 
            this.label_StudentName.AutoSize = true;
            this.label_StudentName.Location = new System.Drawing.Point(383, 160);
            this.label_StudentName.Name = "label_StudentName";
            this.label_StudentName.Size = new System.Drawing.Size(0, 13);
            this.label_StudentName.TabIndex = 4;
            // 
            // label_ExamName
            // 
            this.label_ExamName.AutoSize = true;
            this.label_ExamName.Location = new System.Drawing.Point(383, 121);
            this.label_ExamName.Name = "label_ExamName";
            this.label_ExamName.Size = new System.Drawing.Size(0, 13);
            this.label_ExamName.TabIndex = 5;
            // 
            // textBox_Score
            // 
            this.textBox_Score.Location = new System.Drawing.Point(386, 190);
            this.textBox_Score.Name = "textBox_Score";
            this.textBox_Score.Size = new System.Drawing.Size(152, 20);
            this.textBox_Score.TabIndex = 6;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(418, 275);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(93, 32);
            this.button_Add.TabIndex = 7;
            this.button_Add.Text = "ADD/UPDATE";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(293, 275);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(75, 32);
            this.button_Back.TabIndex = 8;
            this.button_Back.Text = "BACK";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // UpdateMarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.textBox_Score);
            this.Controls.Add(this.label_ExamName);
            this.Controls.Add(this.label_StudentName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateMarkForm";
            this.Text = "UpdateMarkForm";
            this.Load += new System.EventHandler(this.UpdateMarkForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_StudentName;
        private System.Windows.Forms.Label label_ExamName;
        private System.Windows.Forms.TextBox textBox_Score;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Back;
    }
}