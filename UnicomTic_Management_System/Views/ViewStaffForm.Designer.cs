namespace UnicomTic_Management_System.Views
{
    partial class ViewStaffForm
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
            this.button_AddStaff = new System.Windows.Forms.Button();
            this.dataGridView_Staff = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Staff)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(95, 35);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(540, 20);
            this.textBox_Search.TabIndex = 7;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search";
            // 
            // button_AddStaff
            // 
            this.button_AddStaff.Location = new System.Drawing.Point(641, 21);
            this.button_AddStaff.Name = "button_AddStaff";
            this.button_AddStaff.Size = new System.Drawing.Size(117, 34);
            this.button_AddStaff.TabIndex = 5;
            this.button_AddStaff.Text = "Add New Staff";
            this.button_AddStaff.UseVisualStyleBackColor = true;
            this.button_AddStaff.Click += new System.EventHandler(this.button_AddStaff_Click);
            // 
            // dataGridView_Staff
            // 
            this.dataGridView_Staff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Staff.Location = new System.Drawing.Point(42, 61);
            this.dataGridView_Staff.Name = "dataGridView_Staff";
            this.dataGridView_Staff.Size = new System.Drawing.Size(716, 331);
            this.dataGridView_Staff.TabIndex = 4;
            this.dataGridView_Staff.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Staff_CellMouseDoubleClick);
            // 
            // ViewStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_AddStaff);
            this.Controls.Add(this.dataGridView_Staff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewStaffForm";
            this.Text = "ViewStaffForm";
            this.Load += new System.EventHandler(this.ViewStaffForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Staff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_AddStaff;
        private System.Windows.Forms.DataGridView dataGridView_Staff;
    }
}