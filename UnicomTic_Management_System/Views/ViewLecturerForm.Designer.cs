namespace UnicomTic_Management_System.Views
{
    partial class ViewLecturerForm
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
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_AddLecturer = new System.Windows.Forms.Button();
            this.dataGridView_Lecturer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lecturer)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(95, 42);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(540, 20);
            this.textBox_Search.TabIndex = 11;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_AddLecturer
            // 
            this.button_AddLecturer.Location = new System.Drawing.Point(641, 28);
            this.button_AddLecturer.Name = "button_AddLecturer";
            this.button_AddLecturer.Size = new System.Drawing.Size(117, 34);
            this.button_AddLecturer.TabIndex = 9;
            this.button_AddLecturer.Text = "Add New Lecturer";
            this.button_AddLecturer.UseVisualStyleBackColor = true;
            this.button_AddLecturer.Click += new System.EventHandler(this.button_AddStaff_Click);
            // 
            // dataGridView_Lecturer
            // 
            this.dataGridView_Lecturer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Lecturer.Location = new System.Drawing.Point(42, 68);
            this.dataGridView_Lecturer.Name = "dataGridView_Lecturer";
            this.dataGridView_Lecturer.Size = new System.Drawing.Size(716, 331);
            this.dataGridView_Lecturer.TabIndex = 8;
            this.dataGridView_Lecturer.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Lecturer_CellMouseDoubleClick);
            // 
            // ViewLecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_AddLecturer);
            this.Controls.Add(this.dataGridView_Lecturer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewLecturerForm";
            this.Text = "ViewLecturerForm";
            this.Load += new System.EventHandler(this.ViewLecturerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lecturer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_AddLecturer;
        private System.Windows.Forms.DataGridView dataGridView_Lecturer;
    }
}