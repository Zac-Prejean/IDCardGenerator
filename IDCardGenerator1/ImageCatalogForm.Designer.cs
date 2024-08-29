namespace IDCardGenerator
{
    partial class ImageCatalogForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imageList;

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
            this.components = new System.ComponentModel.Container();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.btnOK = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();

            // listViewImages  
            this.listViewImages.LargeImageList = this.imageList;
            this.listViewImages.Location = new System.Drawing.Point(12, 12);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(390, 300); // Adjust size to fit more images  
            this.listViewImages.TabIndex = 0;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.View = System.Windows.Forms.View.LargeIcon;

            // btnOK  
            this.btnOK.Location = new System.Drawing.Point(313, 319); // Adjust position according to new form size  
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // imageList  
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(100, 100); // Adjust size to fit three images per row  
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;

            // ImageCatalogForm  
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 350); // Adjust form size
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Prevent resizing  
            this.MaximizeBox = false; // Disable maximize button  
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.listViewImages);
            this.Name = "ImageCatalogForm";
            this.Text = "Image Catalog";
            this.Load += new System.EventHandler(this.ImageCatalogForm_Load);
            this.ResumeLayout(false);
        }
    }
}
