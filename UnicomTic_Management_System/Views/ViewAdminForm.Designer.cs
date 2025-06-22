namespace UnicomTic_Management_System.Views
{
    partial class ViewAdminForm
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
            this.dataGridView_Admin = new System.Windows.Forms.DataGridView();
            this.button_AddAdmin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Admin)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Admin
            // 
            this.dataGridView_Admin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Admin.Location = new System.Drawing.Point(39, 65);
            this.dataGridView_Admin.Name = "dataGridView_Admin";
            this.dataGridView_Admin.Size = new System.Drawing.Size(716, 331);
            this.dataGridView_Admin.TabIndex = 0;
            this.dataGridView_Admin.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Admin_CellMouseDoubleClick);
            // 
            // button_AddAdmin
            // 
            this.button_AddAdmin.Location = new System.Drawing.Point(638, 25);
            this.button_AddAdmin.Name = "button_AddAdmin";
            this.button_AddAdmin.Size = new System.Drawing.Size(117, 34);
            this.button_AddAdmin.TabIndex = 1;
            this.button_AddAdmin.Text = "Add New Admin";
            this.button_AddAdmin.UseVisualStyleBackColor = true;
            this.button_AddAdmin.Click += new System.EventHandler(this.button_AddAdmin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(92, 39);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(540, 20);
            this.textBox_Search.TabIndex = 3;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // ViewAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_AddAdmin);
            this.Controls.Add(this.dataGridView_Admin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewAdminForm";
            this.Text = "ViewAdminForm";
            this.Load += new System.EventHandler(this.ViewAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Admin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Admin;
        private System.Windows.Forms.Button button_AddAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Search;
    }
}