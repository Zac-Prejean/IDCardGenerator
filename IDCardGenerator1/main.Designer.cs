// main.Designer.cs

namespace IDCardGenerator
{
    partial class main
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmployeeTitle;
        private System.Windows.Forms.TextBox txtEmployeeNumber;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelPictureBox;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblEmployeeTitle;
        private System.Windows.Forms.Label lblEmployeeNumber;
        private System.Windows.Forms.Label lblEmployeeClass;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private ShadowButton btnSelectImage;
        private ShadowButton btnGenerate;
        private ShadowButton btnOpenRecordsForm;         
        private System.Windows.Forms.ComboBox comboBoxDepartment;

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
            this.btnSelectImage = new ShadowButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmployeeNumber = new System.Windows.Forms.TextBox();
            this.txtEmployeeTitle = new System.Windows.Forms.TextBox();
            this.btnGenerate = new ShadowButton();
            this.btnOpenRecordsForm = new ShadowButton();            
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelPictureBox = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblEmployeeTitle = new System.Windows.Forms.Label();
            this.lblEmployeeNumber = new System.Windows.Forms.Label();
            this.lblEmployeeClass = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelPictureBox.SuspendLayout();
            this.SuspendLayout();

            // lblHeader                
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(15, 59);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(200, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Employee Name:";

            // lblEmployeeTitle                
            this.lblEmployeeTitle.AutoSize = true;
            this.lblEmployeeTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeTitle.Location = new System.Drawing.Point(15, 140);
            this.lblEmployeeTitle.Name = "lblEmployeeTitle";
            this.lblEmployeeTitle.Size = new System.Drawing.Size(200, 24);
            this.lblEmployeeTitle.TabIndex = 1;
            this.lblEmployeeTitle.Text = "Employee Title:";

            // lblEmployeeNumber                
            this.lblEmployeeNumber.AutoSize = true;
            this.lblEmployeeNumber.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeNumber.Location = new System.Drawing.Point(15, 221);
            this.lblEmployeeNumber.Name = "lblEmployeeNumber";
            this.lblEmployeeNumber.Size = new System.Drawing.Size(200, 24);
            this.lblEmployeeNumber.TabIndex = 2;
            this.lblEmployeeNumber.Text = "Employee Number:";

            // lblEmployeeClass                
            this.lblEmployeeClass.AutoSize = true;
            this.lblEmployeeClass.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeClass.Location = new System.Drawing.Point(15, 302);
            this.lblEmployeeClass.Name = "lblEmployeeClass";
            this.lblEmployeeClass.Size = new System.Drawing.Size(200, 24);
            this.lblEmployeeClass.TabIndex = 2;
            this.lblEmployeeClass.Text = "Employee Class:";

            // btnSelectImage  alt (517, 536)            
            this.btnSelectImage.Location = new System.Drawing.Point(627, 536);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(95, 50);
            this.btnSelectImage.TabIndex = 3;
            this.btnSelectImage.Text = "Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.BackColor = System.Drawing.Color.FromArgb(192, 192, 192); // Set background color                
            this.btnSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Set flat style                
            this.btnSelectImage.FlatAppearance.BorderSize = 0; // Remove border                
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);

            // txtName                
            this.txtName.Location = new System.Drawing.Point(15, 100);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(470, 20);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);

            // txtEmployeeTitle                
            this.txtEmployeeTitle.Location = new System.Drawing.Point(15, 180);
            this.txtEmployeeTitle.Name = "txtEmployeeTitle";
            this.txtEmployeeTitle.Size = new System.Drawing.Size(470, 20);
            this.txtEmployeeTitle.TabIndex = 5;
            this.txtEmployeeTitle.TextChanged += new System.EventHandler(this.txtEmployeeTitle_TextChanged);

            // txtEmployeeNumber                
            this.txtEmployeeNumber.Location = new System.Drawing.Point(15, 260);
            this.txtEmployeeNumber.Name = "txtEmployeeNumber";
            this.txtEmployeeNumber.Size = new System.Drawing.Size(470, 20);
            this.txtEmployeeNumber.TabIndex = 6;

            // btnGenerate                
            this.btnGenerate.Location = new System.Drawing.Point(735, 536);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(95, 50);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(192, 192, 192); // Set background color                
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Set flat style                
            this.btnGenerate.FlatAppearance.BorderSize = 0; // Remove border                
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // btnOpenRecordsForm               
            this.btnOpenRecordsForm.Location = new System.Drawing.Point(15, 536);            
            this.btnOpenRecordsForm.Name = "btnOpenRecordsForm";
            this.btnOpenRecordsForm.Size = new System.Drawing.Size(110, 50);
            this.btnOpenRecordsForm.TabIndex = 12;
            this.btnOpenRecordsForm.Text = "Manage Records";
            this.btnOpenRecordsForm.UseVisualStyleBackColor = true;
            this.btnOpenRecordsForm.BackColor = System.Drawing.Color.FromArgb(192, 192, 192); // Set background color                
            this.btnOpenRecordsForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Set flat style                
            this.btnOpenRecordsForm.FlatAppearance.BorderSize = 0; // Remove border              
            this.btnOpenRecordsForm.Click += new System.EventHandler(this.btnOpenRecordsForm_Click);

            // panelPictureBox                
            this.panelPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPictureBox.Location = new System.Drawing.Point(517, 23);
            this.panelPictureBox.Name = "panelPictureBox";
            this.panelPictureBox.Size = new System.Drawing.Size(312, 500);
            this.panelPictureBox.TabIndex = 8;
            this.panelPictureBox.Controls.Add(this.pictureBox);

            // pictureBox                
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(304, 492);
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // comboBoxCategory                
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.Items.AddRange(new object[] {
                "R&D",
                "Admin",
                "Production",
                "Office",
                "Temp"
            });
            this.comboBoxCategory.Location = new System.Drawing.Point(15, 340);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCategory.TabIndex = 10;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            this.comboBoxCategory.SelectedIndex = 2; // Set default to "Production"    

            // comboBoxDepartment                
            this.comboBoxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartment.Items.AddRange(new object[] {
                "UV",
                "ENG",
                "DTG",
                "JEW",
                "SUB",
                "MTL",
                "WOOD",
                "INV",
                "MEM",
                "OFF",
                "R&D"
            });
            this.comboBoxDepartment.Location = new System.Drawing.Point(282, 340);            
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(200, 21);
            this.comboBoxDepartment.TabIndex = 11;
            this.comboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);


            // Form1                
            this.ClientSize = new System.Drawing.Size(850, 610);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.lblEmployeeTitle);
            this.Controls.Add(this.txtEmployeeTitle);
            this.Controls.Add(this.lblEmployeeNumber);
            this.Controls.Add(this.txtEmployeeNumber);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panelPictureBox);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.lblEmployeeClass);
            this.Controls.Add(this.btnOpenRecordsForm);             
            this.Name = "main";
            this.Text = "ID Card Generator";
            this.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Prevent resizing                
            this.MaximizeBox = false; // Disable maximize button                
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelPictureBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
