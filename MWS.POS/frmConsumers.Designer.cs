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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumers));
            grdCustomers = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            lblTransaction = new MetroFramework.Controls.MetroLabel();
            button1 = new Button();
            prtDialogCustomers = new PrintPreviewDialog();
            prtDocCustomers = new System.Drawing.Printing.PrintDocument();
            button2 = new Button();
            prtDocNotice = new System.Drawing.Printing.PrintDocument();
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
            grdCustomers.Location = new Point(22, 139);
            grdCustomers.Name = "grdCustomers";
            grdCustomers.Size = new Size(850, 275);
            grdCustomers.TabIndex = 11;
            grdCustomers.CellClick += grdCustomers_CellClick;
            grdCustomers.CellDoubleClick += grdCustomers_DoubleCellClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(207, 107);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(135, 26);
            txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Navy;
            btnSearch.Location = new Point(348, 107);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(97, 27);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(71, 107);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 27);
            comboBox1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(17, 110);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 15;
            label2.Text = "BRGY";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(451, 110);
            label4.Name = "label4";
            label4.Size = new Size(82, 19);
            label4.TabIndex = 16;
            label4.Text = "(Last Name)";
            // 
            // lblTransaction
            // 
            lblTransaction.AutoSize = true;
            lblTransaction.CustomBackground = false;
            lblTransaction.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTransaction.FontSize = MetroFramework.MetroLabelSize.Medium;
            lblTransaction.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            lblTransaction.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            lblTransaction.Location = new Point(348, 60);
            lblTransaction.Name = "lblTransaction";
            lblTransaction.Size = new Size(108, 19);
            lblTransaction.Style = MetroFramework.MetroColorStyle.Blue;
            lblTransaction.StyleManager = null;
            lblTransaction.TabIndex = 17;
            lblTransaction.Text = "TRANSACTION";
            lblTransaction.Theme = MetroFramework.MetroThemeStyle.Light;
            lblTransaction.UseStyleColors = false;
            // 
            // button1
            // 
            button1.Location = new Point(699, 420);
            button1.Name = "button1";
            button1.Size = new Size(121, 37);
            button1.TabIndex = 18;
            button1.Text = "WATER BILL";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // prtDialogCustomers
            // 
            prtDialogCustomers.AutoScrollMargin = new Size(0, 0);
            prtDialogCustomers.AutoScrollMinSize = new Size(0, 0);
            prtDialogCustomers.ClientSize = new Size(400, 300);
            prtDialogCustomers.Enabled = true;
            prtDialogCustomers.Icon = (Icon)resources.GetObject("prtDialogCustomers.Icon");
            prtDialogCustomers.Name = "prtDialogCustomers";
            prtDialogCustomers.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(553, 420);
            button2.Name = "button2";
            button2.Size = new Size(121, 37);
            button2.TabIndex = 19;
            button2.Text = "NOTICE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // frmConsumers
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 480);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private PrintPreviewDialog prtDialogCustomers;
        private System.Drawing.Printing.PrintDocument prtDocCustomers;
        private Button button2;
        private System.Drawing.Printing.PrintDocument prtDocNotice;
    }
}