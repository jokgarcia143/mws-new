namespace MWS.POS
{
    partial class frmPOS
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
            txtDT = new TextBox();
            label2 = new Label();
            lblAddress = new Label();
            lblAcctNo = new Label();
            btnPrint = new Button();
            txtAmount = new TextBox();
            txtWords = new TextBox();
            txtWaterBillNo = new TextBox();
            txtMY = new TextBox();
            txtType = new TextBox();
            txtAddress = new TextBox();
            txtAcctNo = new TextBox();
            txtCustomer = new TextBox();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            lblCustomer = new Label();
            printDialog1 = new PrintDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            SuspendLayout();
            // 
            // txtDT
            // 
            txtDT.Font = new Font("Segoe UI", 9.75F);
            txtDT.Location = new Point(203, 37);
            txtDT.Margin = new Padding(3, 4, 3, 4);
            txtDT.Name = "txtDT";
            txtDT.Size = new Size(314, 25);
            txtDT.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label2.Location = new Point(18, 37);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 22;
            label2.Text = "DATE:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblAddress.Location = new Point(18, 209);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(97, 25);
            lblAddress.TabIndex = 39;
            lblAddress.Text = "ADDRESS";
            // 
            // lblAcctNo
            // 
            lblAcctNo.AutoSize = true;
            lblAcctNo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblAcctNo.Location = new Point(19, 160);
            lblAcctNo.Name = "lblAcctNo";
            lblAcctNo.Size = new Size(101, 25);
            lblAcctNo.TabIndex = 38;
            lblAcctNo.Text = "ACCT. NO:";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(0, 192, 0);
            btnPrint.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnPrint.Location = new Point(203, 621);
            btnPrint.Margin = new Padding(3, 4, 3, 4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(186, 81);
            btnPrint.TabIndex = 37;
            btnPrint.Text = "PRINT";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 9.75F);
            txtAmount.Location = new Point(390, 336);
            txtAmount.Margin = new Padding(3, 4, 3, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(127, 25);
            txtAmount.TabIndex = 36;
            // 
            // txtWords
            // 
            txtWords.Font = new Font("Segoe UI", 9.75F);
            txtWords.Location = new Point(27, 569);
            txtWords.Margin = new Padding(3, 4, 3, 4);
            txtWords.Name = "txtWords";
            txtWords.Size = new Size(490, 25);
            txtWords.TabIndex = 35;
            // 
            // txtWaterBillNo
            // 
            txtWaterBillNo.Font = new Font("Segoe UI", 9.75F);
            txtWaterBillNo.Location = new Point(203, 441);
            txtWaterBillNo.Margin = new Padding(3, 4, 3, 4);
            txtWaterBillNo.Name = "txtWaterBillNo";
            txtWaterBillNo.Size = new Size(314, 25);
            txtWaterBillNo.TabIndex = 34;
            // 
            // txtMY
            // 
            txtMY.Font = new Font("Segoe UI", 9.75F);
            txtMY.Location = new Point(203, 391);
            txtMY.Margin = new Padding(3, 4, 3, 4);
            txtMY.Name = "txtMY";
            txtMY.Size = new Size(314, 25);
            txtMY.TabIndex = 33;
            // 
            // txtType
            // 
            txtType.Font = new Font("Segoe UI", 9.75F);
            txtType.Location = new Point(203, 336);
            txtType.Margin = new Padding(3, 4, 3, 4);
            txtType.Name = "txtType";
            txtType.Size = new Size(166, 25);
            txtType.TabIndex = 32;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 9.75F);
            txtAddress.Location = new Point(203, 209);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(314, 25);
            txtAddress.TabIndex = 31;
            // 
            // txtAcctNo
            // 
            txtAcctNo.Font = new Font("Segoe UI", 9.75F);
            txtAcctNo.Location = new Point(203, 160);
            txtAcctNo.Margin = new Padding(3, 4, 3, 4);
            txtAcctNo.Name = "txtAcctNo";
            txtAcctNo.Size = new Size(314, 25);
            txtAcctNo.TabIndex = 30;
            // 
            // txtCustomer
            // 
            txtCustomer.Font = new Font("Segoe UI", 9.75F);
            txtCustomer.Location = new Point(203, 113);
            txtCustomer.Margin = new Padding(3, 4, 3, 4);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(314, 25);
            txtCustomer.TabIndex = 29;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label17.Location = new Point(18, 519);
            label17.Name = "label17";
            label17.Size = new Size(203, 25);
            label17.TabIndex = 28;
            label17.Text = "AMOUNT IN WORDS:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label16.Location = new Point(18, 441);
            label16.Name = "label16";
            label16.Size = new Size(157, 25);
            label16.TabIndex = 27;
            label16.Text = "WATER BILL NO:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label15.Location = new Point(18, 388);
            label15.Name = "label15";
            label15.Size = new Size(145, 25);
            label15.TabIndex = 26;
            label15.Text = "MONTH/YEAR:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label14.Location = new Point(18, 336);
            label14.Name = "label14";
            label14.Size = new Size(150, 25);
            label14.TabIndex = 25;
            label14.Text = "TRANSACTION:";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblCustomer.Location = new Point(18, 113);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(118, 25);
            lblCustomer.TabIndex = 24;
            lblCustomer.Text = "CUSTOMER:";
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // frmPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 714);
            Controls.Add(lblAddress);
            Controls.Add(lblAcctNo);
            Controls.Add(btnPrint);
            Controls.Add(txtAmount);
            Controls.Add(txtWords);
            Controls.Add(txtWaterBillNo);
            Controls.Add(txtMY);
            Controls.Add(txtType);
            Controls.Add(txtAddress);
            Controls.Add(txtAcctNo);
            Controls.Add(txtCustomer);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(lblCustomer);
            Controls.Add(txtDT);
            Controls.Add(label2);
            Location = new Point(0, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPOS";
            Padding = new Padding(23, 76, 23, 25);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDT;
        private Label label2;
        private Label lblAddress;
        private Label lblAcctNo;
        private Button btnPrint;
        private TextBox txtAmount;
        private TextBox txtWords;
        private TextBox txtWaterBillNo;
        private TextBox txtMY;
        private TextBox txtType;
        private TextBox txtAddress;
        private TextBox txtAcctNo;
        private TextBox txtCustomer;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label lblCustomer;
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}