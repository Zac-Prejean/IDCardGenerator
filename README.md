Main Form (Main.cs)

 
The main form handles user interactions for generating ID cards.
Key Methods and Functionality

 

    InitializeMappings: Initializes font size and position mappings for text on the ID card based on text length.
    PopulateDepartmentComboBox: Sets a default selection for the department combo box.
    btnSelectImage_Click: Opens the image catalog form to select an image template.
    DisplaySelectedImage: Displays the selected image with text and QR code.
    DrawTextOnImage: Draws the employee name, title, and QR code on the selected image.
    btnGenerate_Click: Generates the ID card, saves the image, and stores the data in the SQLite database.
    SetDatabasePath: Sets the database path based on the selected category.
    InitializeDatabase: Creates the database and table if they do not exist.
    SaveDataToDatabase: Saves the employee data to the SQLite database.

Records Form (RecordsForm.cs)

 
The records form allows users to view and manage saved employee records.
Key Methods and Functionality

 

    InitializeDataGridView: Initializes the DataGridView with columns for displaying records.
    LoadAllRecords: Loads all records from the SQLite database and populates the DataGridView.
    DeleteRecord: Deletes a record from the database.
    UpdateRecord: Updates a record in the database.
    SearchRecords: Searches for records in the database based on a keyword.
    btnSwitchDatabase_Click: Switches between the admin and production databases.

Image Catalog Form (ImageCatalogForm.cs)

 
The image catalog form allows users to select an image template for the ID card.
Key Methods and Functionality

 

    ImageCatalogForm_Load: Loads images into the ImageList and ListView.
    btnOK_Click: Selects the chosen image and closes the form.

Example Usage

 

    Select an Image Template:
        Click the "Select Image" button to open the image catalog.
        Choose an image from the list and click "OK".
    Input Employee Details:
        Enter the employee's name, title, and employee number in the respective text boxes.
    Generate ID Card:
        Click the "Generate" button to create the ID card.
        The generated ID card will be displayed in the PictureBox and saved to the Downloads folder.
    View and Manage Records:
        Click the "Open Records Form" button to view saved records.
        Use the DataGridView to update or delete records.

Dependencies

 

    QRCoder: A library for generating QR codes.
    System.Data.SQLite: A library for interacting with SQLite databases.
    System.Drawing.Imaging: A library for handling image formats.

Installation

 

    Clone the repository.
    Open the solution in Visual Studio.
    Restore NuGet packages.
    Build and run the application.

Conclusion

 
This ID Card Generator application provides a simple and efficient way to create customized ID cards for employees. It leverages .NET libraries and SQLite for database management, ensuring a robust and scalable solution for managing employee records.
