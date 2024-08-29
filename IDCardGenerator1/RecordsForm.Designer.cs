// RecordsForm.Designer.cs

namespace IDCardGenerator
{
    partial class RecordsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtSearch;
        private ShadowButton btnSearch;
        private ShadowButton btnSwitchDatabase;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new ShadowButton();
            this.btnSwitchDatabase = new ShadowButton();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();

            // dataGridView  
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 72);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1078, 450);
            this.dataGridView.TabIndex = 0;

            // txtSearch  
            this.txtSearch.Location = new System.Drawing.Point(768, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 8;

            // btnSearch  
            this.btnSearch.Location = new System.Drawing.Point(978, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 50);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnSwitchDatabase  
            this.btnSwitchDatabase.Location = new System.Drawing.Point(12, 12);
            this.btnSwitchDatabase.Name = "btnSwitchDatabase";
            this.btnSwitchDatabase.Size = new System.Drawing.Size(110, 50);
            this.btnSwitchDatabase.TabIndex = 10;
            this.btnSwitchDatabase.Text = "Switch Database";
            this.btnSwitchDatabase.UseVisualStyleBackColor = true;
            this.btnSwitchDatabase.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            this.btnSwitchDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchDatabase.FlatAppearance.BorderSize = 0;
            this.btnSwitchDatabase.Click += new System.EventHandler(this.btnSwitchDatabase_Click);

            // RecordsForm  
            this.ClientSize = new System.Drawing.Size(1100, 550);
            this.Controls.Add(this.btnSwitchDatabase);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dataGridView);
            this.Name = "RecordsForm";
            this.Text = "Records Management";
            this.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
