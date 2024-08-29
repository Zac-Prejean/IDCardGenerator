// main.cs


using System.Data.SQLite;
using System.Drawing.Imaging;
using QRCoder;

public class ShadowButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        Graphics g = pevent.Graphics;
        Rectangle rect = this.ClientRectangle;
        // Draw the shadow effect  
        using (Pen pen1 = new Pen(Color.FromArgb(10, 10, 10), 1.5f))  // Dark shadow  
        using (Pen pen2 = new Pen(Color.FromArgb(128, 128, 128), 1))   // Medium shadow  
        using (Pen pen3 = new Pen(Color.FromArgb(192, 192, 192), 0.5f)) // Light shadow  
        using (Pen pen4 = new Pen(Color.FromArgb(255, 255, 255), 2))   // Highlight  
        {
            // Draw the highlight on the top and left  
            g.DrawLine(pen4, rect.Left, rect.Top, rect.Right, rect.Top);
            g.DrawLine(pen4, rect.Left, rect.Top, rect.Left, rect.Bottom);
            // Draw the shadows on the bottom and right  
            g.DrawLine(pen3, rect.Left, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
            g.DrawLine(pen3, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom);
            g.DrawLine(pen2, rect.Left + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
            g.DrawLine(pen2, rect.Right - 2, rect.Top + 1, rect.Right - 2, rect.Bottom - 1);
            g.DrawLine(pen1, rect.Left + 2, rect.Bottom - 3, rect.Right - 3, rect.Bottom - 3);
            g.DrawLine(pen1, rect.Right - 3, rect.Top + 2, rect.Right - 3, rect.Bottom - 2);
        }
    }
}

namespace IDCardGenerator
{
    public partial class main : Form
    {
        private string selectedImageName;
        private bool _textChanging = false;
        private string selectedCategory = "Admin"; // Default category  
        private string selectedDepartment;
        private Dictionary<int, (float FontSize, float YPosition)> namePositionMapping;
        private Dictionary<int, (float FontSize, float YPosition)> titlePositionMapping;
        private string databasePath;

        public main()
        {
            InitializeComponent();
            InitializeMappings();
            PopulateDepartmentComboBox();
            SetDatabasePath();  
            InitializeDatabase();
        }

        private void InitializeMappings()
        {
            namePositionMapping = new Dictionary<int, (float FontSize, float YPosition)>
            {
                { 1, (20F, 820F) }, { 2, (20F, 820F) }, { 3, (20F, 820F) }, { 4, (20F, 820F) },
                { 5, (20F, 820F) }, { 6, (20F, 820F) }, { 7, (20F, 820F) }, { 8, (20F, 820F) },
                { 9, (20F, 820F) }, { 10, (18F, 822F) }, { 11, (18F, 822F) }, { 12, (16F, 824F) },
                { 13, (16F, 824F) }, { 14, (14F, 826F) }, { 15, (14F, 826F) }, { 16, (13F, 828F) },
                { 17, (12F, 830F) }, { 18, (11F, 832F) }, { 19, (11F, 832F) }, { 20, (10F, 834F) },
                { 21, (10F, 834F) }, { 22, (9F, 836F) }, { 23, (9F, 836F) }, { 24, (8.5F, 837F) },
                { 25, (8.5F, 837F) }, { 26, (8F, 838F) }, { 27, (8F, 838F) }, { 28, (7.5F, 839F) },
                { 29, (7.5F, 839F) }, { 30, (7F, 840F) },
            };

            titlePositionMapping = new Dictionary<int, (float FontSize, float YPosition)>
            {
                { 1, (19F, 890F) }, { 2, (19F, 890F) }, { 3, (19F, 890F) }, { 4, (19F, 890F) },
                { 5, (19F, 890F) }, { 6, (19F, 890F) }, { 7, (19F, 890F) }, { 8, (19F, 890F) },
                { 9, (19F, 890F) }, { 10, (17F, 892F) }, { 11, (17F, 892F) }, { 12, (15F, 894F) },
                { 13, (15F, 894F) }, { 14, (13F, 896F) }, { 15, (13F, 896F) }, { 16, (12F, 898F) },
                { 17, (11F, 900F) }, { 18, (10F, 902F) }, { 19, (10F, 902F) }, { 20, (9F, 904F) },
                { 21, (9F, 904F) }, { 22, (8F, 906F) }, { 23, (8F, 906F) }, { 24, (8F, 906F) },
                { 25, (8F, 906F) }, { 26, (7F, 908F) }, { 27, (7F, 908F) }, { 28, (7F, 908F) },
                { 29, (7F, 908F) }, { 30, (6F, 910F) },
            };
        }

        private void PopulateDepartmentComboBox()
        {
            comboBoxDepartment.SelectedIndex = 0; // Set a default selection  
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (ImageCatalogForm catalogForm = new ImageCatalogForm())
            {
                if (catalogForm.ShowDialog() == DialogResult.OK)
                {
                    selectedImageName = catalogForm.SelectedImage;
                    // Display the selected image in the PictureBox  
                    DisplaySelectedImage();
                }
            }
        }

        private void DisplaySelectedImage()
        {
            Image image = GetImageByName(selectedImageName);
            if (image != null)
            {
                pictureBox.Image = DrawTextOnImage(image, txtName.Text, txtEmployeeTitle.Text, txtEmployeeNumber.Text);
            }
        }

        private Image GetImageByName(string imageName)
        {
            string suffix;
            // Determine the suffix based on the selected category  
            switch (selectedCategory)
            {
                case "R&D":
                    suffix = "01";
                    break;
                case "Admin":
                    suffix = "02";
                    break;
                case "Office":
                    suffix = "04";
                    break;
                default:
                    suffix = "03";
                    break;
            }
            switch (imageName)
            {
                case "Abstract.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"abstract{suffix}");
                case "Blue.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"blue{suffix}");
                case "Blue Paint.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"blupaint{suffix}");
                case "Galaxy.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"glxy{suffix}");
                case "Green.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"grn{suffix}");
                case "Green_Orange.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"grnorg{suffix}");
                case "Grey.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"grey{suffix}");
                case "lightning.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"light{suffix}");
                case "Orange.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"orange{suffix}");
                case "Pink.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"pink{suffix}");
                case "Pink_Paint.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"pnkpaint{suffix}");
                case "Purple_Orange.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"purporg{suffix}");
                case "Scarlet.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"scarlet{suffix}");
                case "Blue-Gradient.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"blugrad{suffix}");
                case "Green-Gradient.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"grngrad{suffix}");
                case "Pink-Gradient.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"pnkgrad{suffix}");
                case "camo.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"camo{suffix}");
                case "Gold.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"gold{suffix}");
                case "Puple-Wave.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"puplewave{suffix}");
                case "Pink-Yellow.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"pnkyel{suffix}");
                case "Shatter.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"shatter{suffix}");
                case "Silver.png":
                    return (Image)Properties.Resources.ResourceManager.GetObject($"silver{suffix}");
                case "TempImage":
                    return Properties.Resources.temp;
                default:
                    return null;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImageName))
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = txtName.Text;
            string title = txtEmployeeTitle.Text;
            string employeeNumber = txtEmployeeNumber.Text;
            Image image = GetImageByName(selectedImageName);

            if (image == null)
            {
                MessageBox.Show("Selected image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            image = DrawTextOnImage(image, name, title, employeeNumber);
            // Display the image in the PictureBox  
            pictureBox.Image = (Image)image.Clone();
            // Get the path to the Downloads folder  
            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string outputImagePath = Path.Combine(downloadsFolder, $"{name}_ID.png");
            // Save the new image  
            image.Save(outputImagePath, ImageFormat.Png);
            // Optionally, show a message to the user  
            MessageBox.Show($"Image saved to: {outputImagePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Save the data to the database  
            SaveDataToDatabase(name, title, employeeNumber, selectedCategory, selectedDepartment);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!_textChanging)
            {
                _textChanging = true;
                txtName.Text = txtName.Text.ToUpper();
                txtName.SelectionStart = txtName.Text.Length;
                txtName.SelectionLength = 0;
                _textChanging = false;
                // Update the image in the PictureBox as the text changes  
                DisplaySelectedImage();
            }
        }

        private void txtEmployeeTitle_TextChanged(object sender, EventArgs e)
        {
            if (!_textChanging)
            {
                _textChanging = true;
                txtEmployeeTitle.Text = txtEmployeeTitle.Text.ToUpper();
                txtEmployeeTitle.SelectionStart = txtEmployeeTitle.Text.Length;
                txtEmployeeTitle.SelectionLength = 0;
                _textChanging = false;
                // Update the image in the PictureBox as the text changes  
                DisplaySelectedImage();
            }
        }

        private float CalculateXPosition(Graphics g, string text, Font font, int imageWidth)
        {
            SizeF textSize = g.MeasureString(text, font);
            return (imageWidth - textSize.Width) / 2;
        }

        private Image DrawTextOnImage(Image image, string name, string title, string employeeNumber)
        {
            Image newImage = (Image)image.Clone();
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // Get the font size and Y position based on the number of characters  
                var nameLength = name.Length;
                var titleLength = title.Length;
                // Default font size and positions  
                float nameFontSize = 20F;
                float nameYPosition = 750F;
                float titleFontSize = 20F;
                float titleYPosition = 800F;
                if (namePositionMapping.ContainsKey(nameLength))
                {
                    var nameMapping = namePositionMapping[nameLength];
                    nameFontSize = nameMapping.FontSize;
                    nameYPosition = nameMapping.YPosition;
                }
                if (titlePositionMapping.ContainsKey(titleLength))
                {
                    var titleMapping = titlePositionMapping[titleLength];
                    titleFontSize = titleMapping.FontSize;
                    titleYPosition = titleMapping.YPosition;
                }
                Font nameFont = new Font("Arial", nameFontSize, FontStyle.Bold, GraphicsUnit.Point);
                Font titleFont = new Font("Arial", titleFontSize, FontStyle.Bold, GraphicsUnit.Point);
                // Choose the brush color based on the selected image name  
                Brush brush;
                if (selectedImageName == "Gold.png" || selectedCategory == "Temp")
                {
                    brush = new SolidBrush(ColorTranslator.FromHtml("#3D3D3D")); // Use dark grey text  
                }
                else
                {
                    brush = new SolidBrush(ColorTranslator.FromHtml("#F2F2F3")); // Use white text for others  
                }
                // Calculate X positions for centering the text  
                float nameXPosition = CalculateXPosition(g, name, nameFont, newImage.Width);
                float titleXPosition = CalculateXPosition(g, title, titleFont, newImage.Width);
                // Draw the name on the image  
                g.DrawString(name, nameFont, brush, new PointF(nameXPosition, nameYPosition));
                // Draw the title on the image  
                g.DrawString(title, titleFont, brush, new PointF(titleXPosition, titleYPosition));
                // Generate QR Code for the employee number  
                if (!string.IsNullOrEmpty(employeeNumber))
                {
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(employeeNumber, QRCodeGenerator.ECCLevel.Q))
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20, ColorTranslator.FromHtml("#3D3D3D"), ColorTranslator.FromHtml("#F0EFEF"), true))
                    {
                        // Position the QR code on the image  
                        int qrCodeSize = 280;
                        int qrCodeXPosition = 255;
                        int qrCodeYPosition = 327;
                        // Draw the QR code on the image  
                        g.DrawImage(qrCodeImage, new Rectangle(qrCodeXPosition, qrCodeYPosition, qrCodeSize, qrCodeSize));
                    }
                }
            }
            return newImage;
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = comboBoxCategory.SelectedItem.ToString();
            SetDatabasePath(); // Update the database path based on the selected category  
            InitializeDatabase(); // Reinitialize the database with the new path  
            if (selectedCategory == "Temp")
            {
                // Automatically set the image to "Temp" from the resources  
                selectedImageName = "TempImage";
                DisplaySelectedImage();
            }
            else
            {
                DisplaySelectedImage();
            }
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDepartment = comboBoxDepartment.SelectedItem.ToString();
        }

        private void SetDatabasePath()
        {
            // string networkPath = @"//comwin2k19dc01/Shares/CAKE/Employee.db/";
            string networkPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Employee.db");

            // Determine the database path based on the category  
            string localPath;
            if (selectedCategory == "Admin" || selectedCategory == "R&D")
            {
                localPath = Path.Combine(networkPath, "admin.db");
            }
            else
            {
                localPath = Path.Combine(networkPath, "production.db");
            }

            try
            {
                // Ensure the directory exists  
                string directoryPath = Path.GetDirectoryName(localPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Set the database path  
                databasePath = $"Data Source={localPath};";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting database path: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS IDCards (  
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT,  
                                          Name TEXT,  
                                          Title TEXT,  
                                          EmployeeNumber TEXT,  
                                          Category TEXT,  
                                          Department TEXT)";
                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveDataToDatabase(string name, string title, string employeeNumber, string category, string department)
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.Open();
                string insertQuery = @"INSERT INTO IDCards (Name, Title, EmployeeNumber, Category, Department)   
                               VALUES (@Name, @Title, @EmployeeNumber, @Category, @Department)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@Department", department);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnOpenRecordsForm_Click(object sender, EventArgs e)
        {
            RecordsForm recordsForm = new RecordsForm(databasePath);
            recordsForm.Show();
        }
    }
}