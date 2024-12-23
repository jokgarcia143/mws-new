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
            grdCustomers = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            lblTransaction = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)grdCustomers).BeginInit();
            SuspendLayout();
            // 
            // grdCustomers
            // 
            grdCustomers.AllowUserToAddRows = false;
            grdCustomers.AllowUserToDeleteRows = false;
            grdCustomers.AllowUserToOrderColumns = true;
            grdCustomers.AllowUserToResizeRows = false;
            grdCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grdCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdCustomers.Location = new Point(23, 160);
            grdCustomers.Name = "grdCustomers";
            grdCustomers.Size = new Size(859, 275);
            grdCustomers.TabIndex = 11;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(208, 128);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(135, 26);
            txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(359, 128);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 25);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(72, 128);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 27);
            comboBox1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 131);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 15;
            label2.Text = "BRGY";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(462, 131);
            label4.Name = "label4";
            label4.Size = new Size(276, 19);
            label4.TabIndex = 16;
            label4.Text = "(Acct No, Meter No, First Name, Last Name)";
            // 
            // lblTransaction
            // 
            lblTransaction.AutoSize = true;
            lblTransaction.CustomBackground = false;
            lblTransaction.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTransaction.FontSize = MetroFramework.MetroLabelSize.Medium;
            lblTransaction.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            lblTransaction.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            lblTransaction.Location = new Point(414, 71);
            lblTransaction.Name = "lblTransaction";
            lblTransaction.Size = new Size(108, 19);
            lblTransaction.Style = MetroFramework.MetroColorStyle.Blue;
            lblTransaction.StyleManager = null;
            lblTransaction.TabIndex = 17;
            lblTransaction.Text = "TRANSACTION";
            lblTransaction.Theme = MetroFramework.MetroThemeStyle.Light;
            lblTransaction.UseStyleColors = false;
            // 
            // frmConsumers
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 509);
            Controls.Add(lblTransaction);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(grdCustomers);
            Location = new Point(0, 0);
            Name = "frmConsumers";
            ((System.ComponentModel.ISupportInitialize)grdCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView grdCustomers;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox comboBox1;
        private Label label2;
        private Label label4;
        private MetroFramework.Controls.MetroLabel lblTransaction;
    }
}