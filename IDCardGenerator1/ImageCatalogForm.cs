//ImageCatalogForm.cs

namespace IDCardGenerator
{
    public partial class ImageCatalogForm : Form
    {
        public string SelectedImage { get; private set; }

        public ImageCatalogForm()
        {
            InitializeComponent();
        }

        private void ImageCatalogForm_Load(object sender, EventArgs e)
        {
            // Load images into the ImageList  
            imageList.Images.Add("Blue.png", Properties.Resources.Blue);
            imageList.Images.Add("Pink.png", Properties.Resources.Pink);
            imageList.Images.Add("Green.png", Properties.Resources.Green);
            //imageList.Images.Add("Grey.png", Properties.Resources.Grey);
            
            imageList.Images.Add("Blue-Gradient.png", Properties.Resources.Blue_Gradient);            
            imageList.Images.Add("Pink-Gradient.png", Properties.Resources.Pink_Gradient);            
            imageList.Images.Add("Green-Gradient.png", Properties.Resources.Green_Gradient);
            imageList.Images.Add("Orange.png", Properties.Resources.Orange);
            
            imageList.Images.Add("Pink-Yellow.png", Properties.Resources.Pink_Yellow);
            imageList.Images.Add("Green_Orange.png", Properties.Resources.Green_Orange);
            imageList.Images.Add("Purple_Orange.png", Properties.Resources.Purple_Orange);

            imageList.Images.Add("Blue Paint.png", Properties.Resources.Blue_Paint);
            imageList.Images.Add("Pink_Paint.png", Properties.Resources.Pink_Paint);
            imageList.Images.Add("Abstract.png", Properties.Resources.Abstract);
            imageList.Images.Add("lightning.png", Properties.Resources.lightning);
            imageList.Images.Add("Galaxy.png", Properties.Resources.Galaxy);
            imageList.Images.Add("Scarlet.png", Properties.Resources.Scarlet);
            imageList.Images.Add("camo.png", Properties.Resources.camo);
            imageList.Images.Add("Puple-Wave.png", Properties.Resources.Puple_Wave);
            imageList.Images.Add("Shatter.png", Properties.Resources.Shatter);

            imageList.Images.Add("Silver.png", Properties.Resources.Silver);
            imageList.Images.Add("Gold.png", Properties.Resources.Gold);
            // Add more images as needed  

            // Add items to the ListView  
            listViewImages.Items.Add(new ListViewItem("Blue", "Blue.png"));
            listViewImages.Items.Add(new ListViewItem("Pink", "Pink.png"));
            listViewImages.Items.Add(new ListViewItem("Green", "Green.png"));
            //listViewImages.Items.Add(new ListViewItem("Grey", "Grey.png"));
            
            listViewImages.Items.Add(new ListViewItem("Blue-Gradient", "Blue-Gradient.png"));            
            listViewImages.Items.Add(new ListViewItem("Pink-Gradient", "Pink-Gradient.png"));            
            listViewImages.Items.Add(new ListViewItem("Green-Gradient", "Green-Gradient.png"));
            listViewImages.Items.Add(new ListViewItem("Orange-Gradient", "Orange.png"));
            
            listViewImages.Items.Add(new ListViewItem("Pink/Yellow", "Pink-Yellow.png"));
            listViewImages.Items.Add(new ListViewItem("Green/Orange", "Green_Orange.png"));
            listViewImages.Items.Add(new ListViewItem("Purple/Orange", "Purple_Orange.png"));

            listViewImages.Items.Add(new ListViewItem("Blue-Paint", "Blue Paint.png"));
            listViewImages.Items.Add(new ListViewItem("Pink-Paint", "Pink_Paint.png"));
            listViewImages.Items.Add(new ListViewItem("Abstract", "Abstract.png"));
            listViewImages.Items.Add(new ListViewItem("Lightning", "lightning.png"));
            listViewImages.Items.Add(new ListViewItem("Galaxy", "Galaxy.png"));
            listViewImages.Items.Add(new ListViewItem("Scarlet", "Scarlet.png"));
            listViewImages.Items.Add(new ListViewItem("Camo", "camo.png"));
            listViewImages.Items.Add(new ListViewItem("Puple-Wave", "Puple-Wave.png"));
            listViewImages.Items.Add(new ListViewItem("Shatter", "Shatter.png"));

            listViewImages.Items.Add(new ListViewItem("Silver", "Silver.png"));
            listViewImages.Items.Add(new ListViewItem("Gold", "Gold.png"));
            // Add more items as needed  
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Get the selected image  
            if (listViewImages.SelectedItems.Count > 0)
            {
                SelectedImage = listViewImages.SelectedItems[0].ImageKey;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
