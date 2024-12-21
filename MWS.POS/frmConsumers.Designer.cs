namespace MWS.POS
{
    partial class frmConsumers
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
            label1 = new Label();
            lblTotalRows = new Label();
            label3 = new Label();
            lblCurrentPage = new Label();
            lblTotalPages = new Label();
            label6 = new Label();
            grdCustomers = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)grdCustomers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 27);
            label1.Name = "label1";
            label1.Size = new Size(77, 19);
            label1.TabIndex = 1;
            label1.Text = "Total Rows:";
            // 
            // lblTotalRows
            // 
            lblTotalRows.AutoSize = true;
            lblTotalRows.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalRows.Location = new Point(109, 27);
            lblTotalRows.Name = "lblTotalRows";
            lblTotalRows.Size = new Size(18, 20);
            lblTotalRows.TabIndex = 2;
            lblTotalRows.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(629, 27);
            label3.Name = "label3";
            label3.Size = new Size(39, 19);
            label3.TabIndex = 3;
            label3.Text = "Page";
            // 
            // lblCurrentPage
            // 
            lblCurrentPage.AutoSize = true;
            lblCurrentPage.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentPage.Location = new Point(674, 27);
            lblCurrentPage.Name = "lblCurrentPage";
            lblCurrentPage.Size = new Size(18, 20);
            lblCurrentPage.TabIndex = 4;
            lblCurrentPage.Text = "0";
            // 
            // lblTotalPages
            // 
            lblTotalPages.AutoSize = true;
            lblTotalPages.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalPages.Location = new Point(728, 27);
            lblTotalPages.Name = "lblTotalPages";
            lblTotalPages.Size = new Size(18, 20);
            lblTotalPages.TabIndex = 5;
            lblTotalPages.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(698, 27);
            label6.Name = "label6";
            label6.Size = new Size(24, 19);
            label6.TabIndex = 6;
            label6.Text = "Of";
            // 
            // grdCustomers
            // 
            grdCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdCustomers.Location = new Point(26, 101);
            grdCustomers.Name = "grdCustomers";
            grdCustomers.RowTemplate.Height = 28;
            grdCustomers.Size = new Size(720, 275);
            grdCustomers.TabIndex = 11;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(211, 69);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(135, 26);
            txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(362, 69);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 25);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(75, 69);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 27);
            comboBox1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 72);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 15;
            label2.Text = "BRGY";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(465, 72);
            label4.Name = "label4";
            label4.Size = new Size(276, 19);
            label4.TabIndex = 16;
            label4.Text = "(Acct No, Meter No, First Name, Last Name)";
            // 
            // frmConsumers
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 444);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(grdCustomers);
            Controls.Add(label6);
            Controls.Add(lblTotalPages);
            Controls.Add(lblCurrentPage);
            Controls.Add(label3);
            Controls.Add(lblTotalRows);
            Controls.Add(label1);
            Name = "frmConsumers";
            Text = "frmConsumers";
            ((System.ComponentModel.ISupportInitialize)grdCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label lblTotalRows;
        private Label label3;
        private Label lblCurrentPage;
        private Label lblTotalPages;
        private Label label6;
        private DataGridView grdCustomers;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox comboBox1;
        private Label label2;
        private Label label4;
    }
}