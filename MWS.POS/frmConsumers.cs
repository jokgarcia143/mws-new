using MetroFramework.Forms;
using MWS.POS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace MWS.POS
{
    public partial class frmConsumers : MetroForm
    {
        private int _currentPage = 1;
        private const int PageSize = 20;
        private int _pageSize = 10; // Rows per page
        private int _totalRecords = 0;
        private string _sortColumn = "AcctNo"; // Default sort column
        private string _sortDirection = "ASC"; // Default sort direction
        private string _searchTerm = "";
        private string selectedValue = "Poblacion 1";
        private string _transactionType = string.Empty;

        private string _connectionString = "Server=DESKTOP-0PV91DC;Database=MWSWeb6;Trusted_Connection=true;Encrypt=Yes;TrustServerCertificate=Yes;MultipleActiveResultSets=true;";

        private int totalPages = 0;
        private int totalRows = 0;
        private int currentIndex = 0;

        private List<CustomerDTO> customers = new List<CustomerDTO>();

        public frmConsumers()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();
            LoadDataAndBindGrid();
            //_transactionType = transactionType.ToString().Trim();
            lblTransaction.Text = _transactionType;
            //lblCurrentPage.Text = currentPageIndex.ToString();
            prtDocCustomers.PrintPage += PrintDocument_PrintPage;
            prtDocNotice.PrintPage += PrintDisconnection_PrintPage;
        }

        private void InitializeComboBox()
        {
            // Initialize the ComboBox
            if (comboBox1 == null)
            {
                comboBox1 = new ComboBox
                {
                    Dock = DockStyle.Top,
                    DropDownStyle = ComboBoxStyle.DropDownList // Disable text input
                };
            }


            // Add hard-coded values to ComboBox
            comboBox1.Items.Add("Poblacion 1");
            comboBox1.Items.Add("Poblacion 2");
            comboBox1.Items.Add("Poblacion 3");
            comboBox1.Items.Add("Poblacion 4");
            comboBox1.Items.Add("Poblacion 5");
            comboBox1.Items.Add("Urdaneta");
            comboBox1.Items.Add("Cabulusan");
            comboBox1.Items.Add("Ramirez");
            comboBox1.Items.Add("Bendita 1");
            comboBox1.Items.Add("Bendita 2");
            comboBox1.Items.Add("Baliwag");
            comboBox1.Items.Add("Caluangan");
            comboBox1.Items.Add("Pacheco");
            comboBox1.Items.Add("Medina");
            comboBox1.Items.Add("San Agustin");
            comboBox1.Items.Add("Tua");
            comboBox1.Items.Add("Urdaneta");


            // Set default selected item
            comboBox1.SelectedIndex = 0;

            // Handle the selection change event
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // Add the ComboBox to the form
            this.Controls.Add(comboBox1);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected value from the ComboBox
            selectedValue = comboBox1.SelectedItem.ToString();
            LoadDataAndBindGrid();

        }


        private void InitializeDataGridView()
        {
            if (grdCustomers == null)
            {
                grdCustomers = new DataGridView
                {
                    Dock = DockStyle.Top,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                    AllowUserToAddRows = false // Prevent adding rows directly by the user
                };

                grdCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                grdCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grdCustomers.EnableHeadersVisualStyles = false;
                this.Controls.Add(grdCustomers);
            }
            // Initialize the DataGridView
            // Handle column header clicks
            grdCustomers.ColumnHeaderMouseClick += grdCustomers_ColumnHeaderMouseClick;

            // Add pagination buttons
            var panel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 40 };
            //TextBox txtSearch = new TextBox { Width = 200, PlaceholderText = "Enter search term..." };
            //Button btnSearch = new Button { Text = "Search" };
            btnSearch.Click += (s, e) =>
            {
                _searchTerm = txtSearch.Text.Trim(); // Set search term
                _currentPage = 1; // Reset to first page
                LoadDataAndBindGrid();
            };

            //panel.Controls.Add(txtSearch);
            //panel.Controls.Add(btnSearch);
            this.Controls.Add(panel);

            Button btnFirst = new Button { Text = "First" };
            Button btnPrevious = new Button { Text = "Previous" };
            Button btnNext = new Button { Text = "Next" };
            Button btnLast = new Button { Text = "Last" };

            btnFirst.Click += (s, e) => { _currentPage = 1; LoadDataAndBindGrid(); };
            btnPrevious.Click += (s, e) => { if (_currentPage > 1) _currentPage--; LoadDataAndBindGrid(); };
            btnNext.Click += (s, e) => { if (_currentPage < GetTotalPages()) _currentPage++; LoadDataAndBindGrid(); };
            btnLast.Click += (s, e) => { _currentPage = GetTotalPages(); LoadDataAndBindGrid(); };

            panel.Controls.Add(btnFirst);
            panel.Controls.Add(btnPrevious);
            panel.Controls.Add(btnNext);
            panel.Controls.Add(btnLast);
            this.Controls.Add(panel);
        }

        private void AddCustomColumns()
        {
            // Clear existing columns to avoid duplication
            grdCustomers.Columns.Clear();

            // Auto-generated columns for SQL data
            grdCustomers.AutoGenerateColumns = false;

            // Add SQL data columns dynamically
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcctNo", HeaderText = "Account No" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MeterNo", HeaderText = "Meter No" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "'LName", DataPropertyName = "LName", HeaderText = "Last Name" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FName", HeaderText = "First Name" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Address" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcctType", HeaderText = "AccountType" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" });

        }
        private void BindDataAndCustomize(DataTable dataTable)
        {
            // Bind the DataTable to the DataGridView
            grdCustomers.DataSource = dataTable;

            // Ensure all columns are sortable
            foreach (DataGridViewColumn column in grdCustomers.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            // Auto resize columns
            grdCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            grdCustomers.Refresh();

            // Populate custom "Age" column
            //foreach (DataGridViewRow row in grdCustomers.Rows)
            //{
            //    if (row.DataBoundItem is DataRowView dataRow)
            //    {
            //        DateTime dob = dataRow.Row.Field<DateTime>("DateOfBirth");
            //        int age = DateTime.Now.Year - dob.Year;
            //        if (dob > DateTime.Now.AddYears(-age)) age--; // Adjust for birthday not yet reached
            //        row.Cells["Age"].Value = age;
            //    }
            //}
        }
        private int GetTotalPages()
        {
            return (int)Math.Ceiling((double)_totalRecords / _pageSize);
        }
        private void LoadDataAndBindGrid()
        {
            customers.Clear();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Get total record count
                using (SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM Customers " +
                    "WHERE LName LIKE @SearchTerm AND Barangay = @SelectedBrgy", conn))
                {
                    countCmd.Parameters.AddWithValue("@SearchTerm", $"%{_searchTerm}%");
                    countCmd.Parameters.AddWithValue("@SelectedBrgy", selectedValue);
                    _totalRecords = (int)countCmd.ExecuteScalar();
                }

                // Fetch paginated data

                if (string.IsNullOrEmpty(_sortDirection))
                {
                    _sortDirection = "DESC";
                }
                if (string.IsNullOrEmpty(_sortColumn))
                {
                    _sortColumn = "AcctNo";
                }

                int startRow = (_currentPage - 1) * _pageSize + 1;
                int endRow = _currentPage * _pageSize;

                string sortCol = _sortColumn.ToString().Trim();
                string sortDirection = _sortDirection.ToString().Trim();

                using (SqlCommand cmd = new SqlCommand($@"SELECT AcctNo, MeterNo, FName, LName,CONCAT(UnitNo, ' ',Barangay, ' ', Street) AS Address, AcctType, Status  FROM " +
                                    "(SELECT ROW_NUMBER() OVER (ORDER BY @SortColumn ASC) AS RowNum, * " +
                                    "FROM Customers " +
                                    "WHERE LName LIKE @SearchTerm " +
                                    "AND Barangay = @SelectedBrgy) AS TempTable " +
                                    "WHERE RowNum BETWEEN @StartRow AND @EndRow", conn))
                {


                    cmd.Parameters.AddWithValue("@SortColumn", _sortColumn);
                    cmd.Parameters.AddWithValue("@SearchTerm", $"%{_searchTerm}%");
                    cmd.Parameters.AddWithValue("@StartRow", startRow);
                    cmd.Parameters.AddWithValue("@EndRow", endRow);
                    cmd.Parameters.AddWithValue("@SelectedBrgy", selectedValue);


                    DataTable dataTable = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                    adapter.Fill(dataTable);

                    // Add custom column dynamically
                    AddCustomColumns();

                    // Bind data and populate custom column
                    BindDataAndCustomize(dataTable);
                }
                using (SqlCommand cmdCustomers = new SqlCommand("SELECT TOP 10 * FROM Customers", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmdCustomers);

                    //SqlDataReader reader = new SqlDataReader(cmdCustomers);
                    SqlDataReader reader = cmdCustomers.ExecuteReader();

                    while (reader.Read())
                    {
                        customers.Add(new CustomerDTO
                        {
                            Name = reader["FName"].ToString(),
                            AcctNo = reader["AcctNo"].ToString(),
                            Address = reader["Street"].ToString()
                        });
                    }
                }
            }

            this.Text = $"Page {_currentPage} of {GetTotalPages()} - Sorted by {_sortColumn} {_sortDirection}";
        }

        private void grdCustomers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the clicked column's name
            string clickedColumn = grdCustomers.Columns[e.ColumnIndex].Name;

            // Toggle sort direction if the same column is clicked, otherwise reset to ascending
            if (_sortColumn == clickedColumn)
                _sortDirection = _sortDirection == "ASC" ? "DESC" : "ASC";
            else
                _sortDirection = "ASC";

            _sortColumn = clickedColumn;

            // Reload data with updated sort settings
            LoadDataAndBindGrid();
        }

        private void grdCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow selectedRow = grdCustomers.Rows[e.RowIndex];
                string value1 = selectedRow.Cells[0].Value.ToString();
                string value2 = selectedRow.Cells[1].Value.ToString();

                //MessageBox.Show($"Value1: {value1}, Value2: {value2}");
            }
        }

        private void grdCustomers_DoubleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow selectedRow = grdCustomers.Rows[e.RowIndex];
                string value1 = selectedRow.Cells[0].Value.ToString();
                string value2 = selectedRow.Cells[1].Value.ToString();

                MessageBox.Show($"Value1: {value1}, Value2: {value2}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customers.Count == 0)
            {
                MessageBox.Show("No business cards to print. Please fetch data first.");
                return;
            }

            currentIndex = 0; // Reset index
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = prtDocCustomers,
                Width = 1063,
                Height = 1375
            };
            previewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Business card dimensions (e.g., 3.5x2 inches, scaled to pixels at 100 DPI)
            float cardWidth = 415.748F; // pixels
            float cardHeight = 360.16F; // pixels
            float margin = 20; // Page margin
            float cardSpacing = 5; // Space between cards
            float startX = margin;
            float startY = margin;

            int cardsPerRow = 2; // Number of cards per row
            int printedCount = 0;

            while (currentIndex < customers.Count)
            {
                CustomerDTO card = customers[currentIndex];

                // Left card position
                float leftCardX = startX;
                float leftCardY = startY + (printedCount / 2) * (cardHeight + cardSpacing);

                // Right card position (duplicate)
                float rightCardX = leftCardX + cardWidth + cardSpacing;
                float rightCardY = leftCardY;

                // Draw both cards in the row
                DrawCard(e.Graphics, card, leftCardX, leftCardY, cardWidth, cardHeight, "");
                DrawCard(e.Graphics, card, rightCardX, rightCardY, cardWidth, cardHeight, "(DUPLICATE COPY)");

                printedCount++;
                currentIndex++;

                // Break to a new page if the row is full
                if (printedCount % (cardsPerRow * 3) == 0) // Assume 3 rows per page
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // End of printing
            e.HasMorePages = false;
        }

        private void DrawCard(Graphics graphics, CustomerDTO card, float x, float y, float width, float height, string? duplicate)
        {
            float textStartX = x + -2; // Position text under the logo (same left margin as logo)
            float textStartY = y + -2; // 
            graphics.FillRectangle(Brushes.White, textStartX, textStartY, width, height);

            // Draw card border
            graphics.DrawRectangle(Pens.Black, textStartX, textStartY, width, height);

            float lineStartX = x + 10;  // Start of the line (same left margin)
            float lineStartY = textStartY + 90; // 10px below the phone number
            float lineEndX = x + width - 10; // End of the line (same width as the card)

            float tableX = x + 5;  // Start X position for the table
            float tableY = y + 200; // Start Y position for the table
            float tableWidth = width - 20; // Table width with padding on both sides
            float tableHeight = 30; // Height of the row (adjus



            // Column width (dividing the total width by 6 columns)
            float columnWidth = tableWidth / 6;

            // Draw the table cells (6 columns and 2 rows)
            for (int row = 0; row < 2; row++)  // Loop through 2 rows
            {
                for (int col = 0; col < 6; col++)  // Loop through 6 columns
                {
                    // Draw the cell border
                    graphics.DrawRectangle(Pens.Black, tableX + (col * columnWidth), tableY + (row * tableHeight), columnWidth, tableHeight);

                    // Add content to each cell (e.g., placeholder text)
                    using (Font font = new Font("Arial", 8, FontStyle.Regular))
                    {
                        string cellText = string.Empty;
                        if (row == 0 && col == 0)
                        {
                            cellText = $"From";
                        }
                        else if (row == 0 && col == 1)
                        {
                            cellText = $"To";
                        }
                        else if (row == 0 && col == 2)
                        {
                            cellText = $"Present";
                        }
                        else if (row == 0 && col == 3)
                        {
                            cellText = $"Previous";
                        }
                        else if (row == 0 && col == 4)
                        {
                            cellText = $"Consumed";
                        }
                        else if (row == 0 && col == 5)
                        {
                            cellText = $"Due Date";
                        }

                        //string cellText = $"Row {row + 1}, Cell {col + 1}"; // Placeholder text for each cell

                        float textX = tableX + (col * columnWidth) + 5; // Add some padding inside the cell
                        float textY = tableY + (row * tableHeight) + (tableHeight / 2) - 10; // Center the text vertically in the cell
                        graphics.DrawString(cellText, font, Brushes.Black, textX, textY);
                    }
                }
            }


            // Top text

            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            {

                graphics.DrawString($"MAGALLANES WATER SYSTEM", font, Brushes.Black, textStartX + 100, textStartY + 5);
            }

            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {

                graphics.DrawString($"Municipality of Magallanes, Cavite", font, Brushes.Black, textStartX + 125, textStartY + 30);
                graphics.DrawString($"Contact Nos: (09000641223) (0468668962)", font, Brushes.Black, textStartX + 105, textStartY + 50);
                graphics.DrawString($"WATER BILL NO:", font, Brushes.Black, textStartX + 105, textStartY + 70);
                graphics.DrawString($"00000000000536744", font, Brushes.Red, textStartX + 205, textStartY + 70);
            }

            // Middle text

            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                graphics.DrawString($" Customer: " + card.Name, font, Brushes.Black, textStartX, textStartY + 100);
                graphics.DrawString($" Date: 12/25/2024", font, Brushes.Black, textStartX + 250, textStartY + 100);

                graphics.DrawString($" Account No: " + card.AcctNo, font, Brushes.Black, textStartX, textStartY + 115);
                graphics.DrawString($" Address: Tua Magallanes Cavite", font, Brushes.Black, textStartX, textStartY + 130);
                graphics.DrawString($" Meter No: 210030980", font, Brushes.Black, textStartX, textStartY + 145);

                graphics.DrawString($"Period Covered", font, Brushes.Black, textStartX + 10, textStartY + 165);
                graphics.DrawString($"Meter Reading", font, Brushes.Black, textStartX + 150, textStartY + 165);

                graphics.DrawString(duplicate, font, Brushes.Gray, textStartX + 255, textStartY + 165);
            }



            string currentDirectory = Directory.GetCurrentDirectory();
            string imgPath = currentDirectory + card.LogoPath;

            // Add logo if available
            if (!string.IsNullOrEmpty(card.LogoPath) && System.IO.File.Exists(imgPath))
            {
                using (Image logo = Image.FromFile(imgPath))
                {
                    //graphics.DrawImage(logo, x + width - 90, y + 10, 80, 80); - FAR RIGHT


                    //CENTER
                    //float logoWidth = 80; // Set logo width
                    //float logoHeight = 80; // Set logo height
                    //float logoX = x + (width - logoWidth) / 2; // Center the logo horizontally
                    //float logoY = y + 10; // Add some top padding

                    //graphics.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);

                    //LEFT
                    float logoWidth = 80;  // Set logo width
                    float logoHeight = 80; // Set logo height
                    float logoX = x + 10;  // Add a small left margin
                    float logoY = y + 10;  // Add a small top margin

                    graphics.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);
                }
            }
        }

        #region "DISCONNECTION NOTICE"
        private void PrintDisconnection_PrintPage(object sender, PrintPageEventArgs e)
        {
            float cardWidth = 415.748F; // pixels
            float cardHeight = 360.16F; // pixels
            float margin = 20; // Page margin
            float cardSpacing = 5; // Space between cards
            float startX = margin;
            float startY = margin;

            int cardsPerRow = 2; // Number of cards per row
            int printedCount = 0;

            while (currentIndex < customers.Count)
            {
                CustomerDTO card = customers[currentIndex];

                // Left card position
                float leftCardX = startX;
                float leftCardY = startY + (printedCount / 2) * (cardHeight + cardSpacing);

                // Right card position (duplicate)
                float rightCardX = leftCardX + cardWidth + cardSpacing;
                float rightCardY = leftCardY;

                // Draw both cards in the row
                DisconnectionPrint(e.Graphics, card, leftCardX, leftCardY, cardWidth, cardHeight, "");
                DisconnectionPrint(e.Graphics, card, rightCardX, rightCardY, cardWidth, cardHeight, "(DUPLICATE COPY)");

                printedCount++;
                currentIndex++;

                // Break to a new page if the row is full
                if (printedCount % (cardsPerRow * 3) == 0) // Assume 3 rows per page
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // End of printing
            e.HasMorePages = false;
        }

        private void DisconnectionPrint(Graphics graphics, CustomerDTO card, float x, float y, float width, float height, string? duplicate)
        {
            float textStartX = x + -2; // Position text under the logo (same left margin as logo)
            float textStartY = y + -2; // 
            graphics.FillRectangle(Brushes.White, textStartX, textStartY, width, height);

            // Draw card border
            graphics.DrawRectangle(Pens.Black, textStartX, textStartY, width, height);

            string currentDirectory = Directory.GetCurrentDirectory();
            string imgPath = currentDirectory + card.LogoPath;
            if (!string.IsNullOrEmpty(card.LogoPath) && System.IO.File.Exists(imgPath))
            {
                using (Image logo = Image.FromFile(imgPath))
                {

                    float logoWidth = 80;  // Set logo width
                    float logoHeight = 80; // Set logo height
                    float logoX = x + 10;  // Add a small left margin
                    float logoY = y + 10;  // Add a small top margin

                    graphics.DrawImage(logo, logoX, logoY, logoWidth, logoHeight);
                }
            }

            // Top text

            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            {

                graphics.DrawString($"MAGALLANES WATER SYSTEM", font, Brushes.Black, textStartX + 100, textStartY + 5);
            }

            using (Font font = new Font("Arial", 8, FontStyle.Bold))
            {

                graphics.DrawString($"Municipality of Magallanes, Cavite", font, Brushes.Black, textStartX + 140, textStartY + 30);
                graphics.DrawString($"NOTICE OF DISCONNECTION", font, Brushes.Red, textStartX + 144, textStartY + 70);

            }

            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {

                graphics.DrawString($"Contact Nos: (09000641223) (0468668962)", font, Brushes.Black, textStartX + 105, textStartY + 50);
                
                graphics.DrawString($"{duplicate}", font, Brushes.Gray, textStartX + 160, textStartY + 90);

            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (customers.Count == 0)
            {
                MessageBox.Show("No business cards to print. Please fetch data first.");
                return;
            }

            currentIndex = 0; // Reset index
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = prtDocNotice,
                Width = 1063,
                Height = 1375
            };
            previewDialog.ShowDialog();
        }
    }
}
