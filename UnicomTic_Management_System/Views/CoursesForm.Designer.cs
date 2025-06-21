namespace UnicomTic_Management_System.Views
{
    partial class CoursesForm
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
            this.label_Course = new System.Windows.Forms.Label();
            this.label_Department = new System.Windows.Forms.Label();
            this.textBox_Course = new System.Windows.Forms.TextBox();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.CoursesView = new System.Windows.Forms.DataGridView();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Department = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COURSE MANAGEMENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department";
            // 
            // label_Course
            // 
            this.label_Course.AutoSize = true;
            this.label_Course.ForeColor = System.Drawing.Color.Red;
            this.label_Course.Location = new System.Drawing.Point(326, 69);
            this.label_Course.Name = "label_Course";
            this.label_Course.Size = new System.Drawing.Size(0, 13);
            this.label_Course.TabIndex = 3;
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.ForeColor = System.Drawing.Color.Red;
            this.label_Department.Location = new System.Drawing.Point(326, 121);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(0, 13);
            this.label_Department.TabIndex = 4;
            // 
            // textBox_Course
            // 
            this.textBox_Course.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_Course.Location = new System.Drawing.Point(318, 85);
            this.textBox_Course.Name = "textBox_Course";
            this.textBox_Course.Size = new System.Drawing.Size(270, 20);
            this.textBox_Course.TabIndex = 5;
            this.textBox_Course.Text = "Enter Course";
            this.textBox_Course.Click += new System.EventHandler(this.textBox_Course_Click);
            this.textBox_Course.TextChanged += new System.EventHandler(this.textBox_Course_TextChanged);
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Location = new System.Drawing.Point(319, 137);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(270, 21);
            this.comboBox_Department.TabIndex = 6;
            this.comboBox_Department.Text = "Choose Department";
            this.comboBox_Department.DropDown += new System.EventHandler(this.comboBox_Department_DropDown);
            this.comboBox_Department.SelectedIndexChanged += new System.EventHandler(this.comboBox_Department_SelectedValueChanged);
            this.comboBox_Department.TextChanged += new System.EventHandler(this.comboBox_Department_TextChanged);
            this.comboBox_Department.Click += new System.EventHandler(this.comboBox_Department_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(531, 187);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 32);
            this.button_Add.TabIndex = 7;
            this.button_Add.Text = "ADD";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(429, 187);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 32);
            this.button_Delete.TabIndex = 8;
            this.button_Delete.Text = "DELETE";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(219, 191);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(75, 28);
            this.button_Back.TabIndex = 9;
            this.button_Back.Text = "BACK";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // CoursesView
            // 
            this.CoursesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoursesView.Location = new System.Drawing.Point(247, 250);
            this.CoursesView.Name = "CoursesView";
            this.CoursesView.Size = new System.Drawing.Size(341, 174);
            this.CoursesView.TabIndex = 10;
            this.CoursesView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CoursesView_CellMouseClick);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(319, 191);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 28);
            this.button_Clear.TabIndex = 11;
            this.button_Clear.Text = "CLEAR";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Department
            // 
            this.button_Department.Location = new System.Drawing.Point(637, 20);
            this.button_Department.Name = "button_Department";
            this.button_Department.Size = new System.Drawing.Size(141, 23);
            this.button_Department.TabIndex = 12;
            this.button_Department.Text = "Department Manageent";
            this.button_Department.UseVisualStyleBackColor = true;
            this.button_Department.Click += new System.EventHandler(this.button_Department_Click);
            // 
            // CoursesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Department);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.CoursesView);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.textBox_Course);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.label_Course);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CoursesForm";
            this.Text = "Courses";
            this.Load += new System.EventHandler(this.CoursesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoursesView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Course;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.TextBox textBox_Course;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.DataGridView CoursesView;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Department;
    }
}