using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWS.POS
{
    public partial class frmConsumers : Form
    {
        private int _currentPage = 1;
        private const int PageSize = 20;
        private int _pageSize = 10; // Rows per page
        private int _totalRecords = 0;
        private string _sortColumn = "AcctNo"; // Default sort column
        private string _sortDirection = "ASC"; // Default sort direction
        private string _searchTerm = "";
        private string selectedValue = "Poblacion 1";

        private string _connectionString = "Server=DESKTOP-0PV91DC;Database=MWSWeb6;Trusted_Connection=true;Encrypt=Yes;TrustServerCertificate=Yes;MultipleActiveResultSets=true;";

        private int totalPages = 0;
        private int totalRows = 0;

        public frmConsumers()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();
            LoadDataAndBindGrid();
            //lblCurrentPage.Text = currentPageIndex.ToString();

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
            comboBox1.Items.Add("Poblacion 6");
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
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LName", HeaderText = "Last Name" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FName", HeaderText = "First Name" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Address" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcctType", HeaderText = "AccountType" });
            grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" });

            // Add custom computed column (e.g., Age)
            //grdCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Age", HeaderText = "Age" });

            // Add custom checkbox column for selection
            //grdCustomers.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Select", HeaderText = "Select" });
        }
        private void BindDataAndCustomize(DataTable dataTable)
        {
            // Bind the DataTable to the DataGridView
            grdCustomers.DataSource = dataTable;
            //grdCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

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
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Get total record count
                using (SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE LName LIKE @SearchTerm", conn))
                {
                    countCmd.Parameters.AddWithValue("@SearchTerm", $"%{_searchTerm}%");
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

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Add custom column dynamically
                    AddCustomColumns();

                    // Bind data and populate custom column
                    BindDataAndCustomize(dataTable);
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
    }
}
