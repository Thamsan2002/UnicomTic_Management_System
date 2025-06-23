namespace UnicomTic_Management_System.Views
{
    partial class AddTimeTableForm
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
            this.dateTimePicker_Date = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Subject = new System.Windows.Forms.ComboBox();
            this.comboBox_Course = new System.Windows.Forms.ComboBox();
            this.comboBox_Hall = new System.Windows.Forms.ComboBox();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.label_Department = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.label_Subject = new System.Windows.Forms.Label();
            this.label_Course = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_Hall = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button_Back = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.dateTimePicker_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label_EndTime = new System.Windows.Forms.Label();
            this.label_StartTime = new System.Windows.Forms.Label();
            this.button_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADD TIMETABLE";
            // 
            // dateTimePicker_Date
            // 
            this.dateTimePicker_Date.Location = new System.Drawing.Point(522, 132);
            this.dateTimePicker_Date.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_Date.Name = "dateTimePicker_Date";
            this.dateTimePicker_Date.Size = new System.Drawing.Size(214, 22);
            this.dateTimePicker_Date.TabIndex = 1;
            // 
            // comboBox_Subject
            // 
            this.comboBox_Subject.FormattingEnabled = true;
            this.comboBox_Subject.Location = new System.Drawing.Point(140, 132);
            this.comboBox_Subject.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Subject.Name = "comboBox_Subject";
            this.comboBox_Subject.Size = new System.Drawing.Size(214, 21);
            this.comboBox_Subject.TabIndex = 2;
            this.comboBox_Subject.DropDown += new System.EventHandler(this.comboBox_Subject_DropDown);
            // 
            // comboBox_Course
            // 
            this.comboBox_Course.FormattingEnabled = true;
            this.comboBox_Course.Location = new System.Drawing.Point(522, 81);
            this.comboBox_Course.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Course.Name = "comboBox_Course";
            this.comboBox_Course.Size = new System.Drawing.Size(214, 21);
            this.comboBox_Course.TabIndex = 4;
            this.comboBox_Course.DropDown += new System.EventHandler(this.comboBox_Course_DropDown);
            // 
            // comboBox_Hall
            // 
            this.comboBox_Hall.FormattingEnabled = true;
            this.comboBox_Hall.Location = new System.Drawing.Point(523, 187);
            this.comboBox_Hall.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Hall.Name = "comboBox_Hall";
            this.comboBox_Hall.Size = new System.Drawing.Size(214, 21);
            this.comboBox_Hall.TabIndex = 5;
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(140, 81);
            this.comboBox_Department.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(214, 21);
            this.comboBox_Department.TabIndex = 6;
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.ForeColor = System.Drawing.Color.Red;
            this.label_Department.Location = new System.Drawing.Point(137, 66);
            this.label_Department.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(0, 16);
            this.label_Department.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Course";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Subject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Department";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.ForeColor = System.Drawing.Color.Red;
            this.label_Date.Location = new System.Drawing.Point(520, 116);
            this.label_Date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(0, 16);
            this.label_Date.TabIndex = 12;
            // 
            // label_Subject
            // 
            this.label_Subject.AutoSize = true;
            this.label_Subject.ForeColor = System.Drawing.Color.Red;
            this.label_Subject.Location = new System.Drawing.Point(137, 116);
            this.label_Subject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Subject.Name = "label_Subject";
            this.label_Subject.Size = new System.Drawing.Size(0, 16);
            this.label_Subject.TabIndex = 7;
            // 
            // label_Course
            // 
            this.label_Course.AutoSize = true;
            this.label_Course.ForeColor = System.Drawing.Color.Red;
            this.label_Course.Location = new System.Drawing.Point(520, 66);
            this.label_Course.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Course.Name = "label_Course";
            this.label_Course.Size = new System.Drawing.Size(0, 16);
            this.label_Course.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(431, 138);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Date";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label_Hall
            // 
            this.label_Hall.AutoSize = true;
            this.label_Hall.ForeColor = System.Drawing.Color.Red;
            this.label_Hall.Location = new System.Drawing.Point(520, 169);
            this.label_Hall.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Hall.Name = "label_Hall";
            this.label_Hall.Size = new System.Drawing.Size(0, 16);
            this.label_Hall.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(431, 187);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 16);
            this.label13.TabIndex = 16;
            this.label13.Text = "Hall";
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(247, 306);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(64, 36);
            this.button_Back.TabIndex = 17;
            this.button_Back.Text = "BACK";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(473, 306);
            this.button_Add.Margin = new System.Windows.Forms.Padding(2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(74, 36);
            this.button_Add.TabIndex = 18;
            this.button_Add.Text = "ADD";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // dateTimePicker_EndTime
            // 
            this.dateTimePicker_EndTime.Location = new System.Drawing.Point(140, 243);
            this.dateTimePicker_EndTime.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_EndTime.Name = "dateTimePicker_EndTime";
            this.dateTimePicker_EndTime.Size = new System.Drawing.Size(214, 22);
            this.dateTimePicker_EndTime.TabIndex = 19;
            // 
            // dateTimePicker_StartTime
            // 
            this.dateTimePicker_StartTime.Location = new System.Drawing.Point(140, 188);
            this.dateTimePicker_StartTime.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_StartTime.Name = "dateTimePicker_StartTime";
            this.dateTimePicker_StartTime.Size = new System.Drawing.Size(214, 22);
            this.dateTimePicker_StartTime.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(51, 190);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Start Time";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 249);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "End Time";
            // 
            // label_EndTime
            // 
            this.label_EndTime.AutoSize = true;
            this.label_EndTime.ForeColor = System.Drawing.Color.Red;
            this.label_EndTime.Location = new System.Drawing.Point(137, 225);
            this.label_EndTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EndTime.Name = "label_EndTime";
            this.label_EndTime.Size = new System.Drawing.Size(0, 16);
            this.label_EndTime.TabIndex = 23;
            // 
            // label_StartTime
            // 
            this.label_StartTime.AutoSize = true;
            this.label_StartTime.ForeColor = System.Drawing.Color.Red;
            this.label_StartTime.Location = new System.Drawing.Point(137, 169);
            this.label_StartTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_StartTime.Name = "label_StartTime";
            this.label_StartTime.Size = new System.Drawing.Size(0, 16);
            this.label_StartTime.TabIndex = 24;
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(359, 306);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(69, 36);
            this.button_Clear.TabIndex = 25;
            this.button_Clear.Text = "CLEAR";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // AddTimeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.label_StartTime);
            this.Controls.Add(this.label_EndTime);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateTimePicker_StartTime);
            this.Controls.Add(this.dateTimePicker_EndTime);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label_Hall);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_Course);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Subject);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.comboBox_Hall);
            this.Controls.Add(this.comboBox_Course);
            this.Controls.Add(this.comboBox_Subject);
            this.Controls.Add(this.dateTimePicker_Date);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddTimeTableForm";
            this.Text = "AddTimeTableForm";
            this.Load += new System.EventHandler(this.AddTimeTableForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Date;
        private System.Windows.Forms.ComboBox comboBox_Subject;
        private System.Windows.Forms.ComboBox comboBox_Course;
        private System.Windows.Forms.ComboBox comboBox_Hall;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Label label_Subject;
        private System.Windows.Forms.Label label_Course;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_Hall;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_EndTime;
        private System.Windows.Forms.Label label_StartTime;
        private System.Windows.Forms.Button button_Clear;
    }
}