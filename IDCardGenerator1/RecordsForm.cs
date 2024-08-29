// RecordsForm.cs

using System.Data.SQLite;


namespace IDCardGenerator
{
    public partial class RecordsForm : Form
    {
        private string databasePath;
        private bool isAdminDb = false;

        public RecordsForm(string dbPath)
        {
            InitializeComponent();
            databasePath = dbPath;
            InitializeDataGridView();
            LoadAllRecords();
            dataGridView.DataError += DataGridView_DataError;
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle the error. You can show a message or log the error.  
            MessageBox.Show($"DataGridView error: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false; // Prevent the exception from being thrown again  
        }


        private void InitializeDataGridView()
        {
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", Width = 50, ReadOnly = true });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", Width = 300 });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Title", Width = 300 });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmployeeNumber", HeaderText = "Employee Number", Width = 185 });

            // Define the DataGridViewComboBoxColumn for "Category"  
            var categoryColumn = new DataGridViewComboBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                Width = 100,
                DataSource = new List<string> { "R&D", "Admin", "Production", "Office", "Temp" }
            };
            dataGridView.Columns.Add(categoryColumn);

            // Define the DataGridViewComboBoxColumn for "Department"  
            var departmentColumn = new DataGridViewComboBoxColumn
            {
                Name = "Department",
                HeaderText = "Department",
                Width = 100,
                DataSource = new List<string> { "UV", "ENG", "DTG", "JEW", "SUB", "MTL", "WOOD", "INV", "MEM", "OFF", "R&D" }
            };
            dataGridView.Columns.Add(departmentColumn);

            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 75
            };
            dataGridView.Columns.Add(deleteButtonColumn);

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = false;
            dataGridView.CellValidating += DataGridView_CellValidating;
            dataGridView.CellEndEdit += DataGridView_CellEndEdit;

            dataGridView.CellContentClick += DataGridView_CellContentClick;
            dataGridView.CellPainting += DataGridView_CellPainting;
        }

        private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var buttonRectangle = new Rectangle(e.CellBounds.Left + 2, e.CellBounds.Top + 2, e.CellBounds.Width - 4, e.CellBounds.Height - 4);

                using (Brush brush = new SolidBrush(ColorTranslator.FromHtml("#EB5C68")))
                {
                    e.Graphics.FillRectangle(brush, buttonRectangle);
                }

                ControlPaint.DrawBorder(e.Graphics, buttonRectangle, Color.Black, ButtonBorderStyle.Solid);
                TextRenderer.DrawText(e.Graphics, "X", dataGridView.Font, buttonRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Id"].Value);
                    DeleteRecord(id);
                    LoadAllRecords();
                }
            }
        }

        private void DeleteRecord(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};"))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM IDCards WHERE Id = @Id";
                    using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllRecords()
        {
            try
            {
                Console.WriteLine("Loading all records...");
                var records = GetAllRecords();
                dataGridView.Rows.Clear();
                foreach (var record in records)
                {
                    var rowIndex = dataGridView.Rows.Add(record.Id, record.Name, record.Title, record.EmployeeNumber);

                    // Category  
                    var categoryCell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["Category"];
                    if (categoryCell.Items.Contains(record.Category))
                    {
                        categoryCell.Value = record.Category;
                    }
                    else
                    {
                        categoryCell.Value = categoryCell.Items[0]; // Assign a default value or handle it as needed  
                    }

                    // Department  
                    var departmentCell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["Department"];
                    if (departmentCell.Items.Contains(record.Department))
                    {
                        departmentCell.Value = record.Department;
                    }
                    else
                    {
                        departmentCell.Value = departmentCell.Items[0]; // Assign a default value or handle it as needed  
                    }
                }
                Console.WriteLine("Records loaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading records: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error loading records: {ex.Message}\n{ex.StackTrace}");
            }
        }


        private List<(int Id, string Name, string Title, string EmployeeNumber, string Category, string Department)> GetAllRecords()
        {
            var records = new List<(int, string, string, string, string, string)>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};"))
                {
                    Console.WriteLine($"Connecting to database: {databasePath}");
                    connection.Open();
                    Console.WriteLine("Connection opened.");

                    string selectQuery = "SELECT * FROM IDCards";
                    using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                    {
                        Console.WriteLine("Executing query...");
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Reading records...");
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string title = reader.GetString(2);
                                string employeeNumber = reader.GetString(3);
                                string category = reader.GetString(4);
                                string department = reader.GetString(5);
                                records.Add((id, name, title, employeeNumber, category, department));
                            }
                            Console.WriteLine("Records read successfully.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error retrieving records: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // Console.WriteLine($"Error retrieving records: {ex.Message}\n{ex.StackTrace}");
            }
            return records;
        }


        private List<(int Id, string Name, string Title, string EmployeeNumber, string Category, string Department)> SearchRecords(string keyword)
        {
            var records = new List<(int, string, string, string, string, string)>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};"))
                {
                    connection.Open();
                    string searchQuery = @"SELECT * FROM IDCards  
                                         WHERE Id LIKE @Keyword  
                                            OR Name LIKE @Keyword  
                                            OR Title LIKE @Keyword  
                                            OR EmployeeNumber LIKE @Keyword  
                                            OR Category LIKE @Keyword  
                                            OR Department LIKE @Keyword";
                    using (SQLiteCommand command = new SQLiteCommand(searchQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string title = reader.GetString(2);
                                string employeeNumber = reader.GetString(3);
                                string category = reader.GetString(4);
                                string department = reader.GetString(5);
                                records.Add((id, name, title, employeeNumber, category, department));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return records;
        }

        private void UpdateRecord(int id, string name, string title, string employeeNumber, string category, string department)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};"))
                {
                    connection.Open();
                    string updateQuery = @"UPDATE IDCards SET  
                                             Name = @Name,  
                                             Title = @Title,  
                                             EmployeeNumber = @EmployeeNumber,  
                                             Category = @Category,  
                                             Department = @Department  
                                             WHERE Id = @Id";
                    using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Department", department);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var columnName = dataGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "Name" || columnName == "Title" || columnName == "EmployeeNumber")
            {
                if (e.FormattedValue != null)
                {
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.FormattedValue.ToString().ToUpper();
                }
            }
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Id"].Value);
            string name = dataGridView.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            string title = dataGridView.Rows[e.RowIndex].Cells["Title"].Value.ToString();
            string employeeNumber = dataGridView.Rows[e.RowIndex].Cells["EmployeeNumber"].Value.ToString();
            string category = dataGridView.Rows[e.RowIndex].Cells["Category"].Value.ToString();
            string department = dataGridView.Rows[e.RowIndex].Cells["Department"].Value.ToString();

            UpdateRecord(id, name, title, employeeNumber, category, department);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Please enter a search value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var records = SearchRecords(searchValue);
            dataGridView.Rows.Clear();
            foreach (var record in records)
            {
                dataGridView.Rows.Add(record.Id, record.Name, record.Title, record.EmployeeNumber, record.Category, record.Department);
            }
        }

        private void btnSwitchDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                isAdminDb = !isAdminDb; // Toggle the database flag  

                // local path
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Employee.db");
                if (isAdminDb)
                {
                    databasePath = Path.Combine(folderPath, "admin.db");
                }
                else
                {
                    databasePath = Path.Combine(folderPath, "production.db");
                }

                // Log the new database path  
                Console.WriteLine($"Switching to database: {databasePath}");

                // Ensure the new database path is valid  
                if (!File.Exists(databasePath))
                {
                    MessageBox.Show($"Database file not found: {databasePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Reload the records with the new database path  
                LoadAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error switching database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}