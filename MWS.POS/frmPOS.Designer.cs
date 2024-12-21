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
            this.txtDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAcctNo = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtWords = new System.Windows.Forms.TextBox();
            this.txtWaterBillNo = new System.Windows.Forms.TextBox();
            this.txtMY = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtAcctNo = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // txtDT
            // 
            this.txtDT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDT.Location = new System.Drawing.Point(178, 29);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(275, 25);
            this.txtDT.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "DATE:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.Location = new System.Drawing.Point(16, 165);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(97, 25);
            this.lblAddress.TabIndex = 39;
            this.lblAddress.Text = "ADDRESS";
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAcctNo.Location = new System.Drawing.Point(17, 126);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(101, 25);
            this.lblAcctNo.TabIndex = 38;
            this.lblAcctNo.Text = "ACCT. NO:";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.Location = new System.Drawing.Point(178, 490);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(163, 64);
            this.btnPrint.TabIndex = 37;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAmount.Location = new System.Drawing.Point(341, 265);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(112, 25);
            this.txtAmount.TabIndex = 36;
            // 
            // txtWords
            // 
            this.txtWords.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWords.Location = new System.Drawing.Point(24, 449);
            this.txtWords.Name = "txtWords";
            this.txtWords.Size = new System.Drawing.Size(429, 25);
            this.txtWords.TabIndex = 35;
            // 
            // txtWaterBillNo
            // 
            this.txtWaterBillNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWaterBillNo.Location = new System.Drawing.Point(178, 348);
            this.txtWaterBillNo.Name = "txtWaterBillNo";
            this.txtWaterBillNo.Size = new System.Drawing.Size(275, 25);
            this.txtWaterBillNo.TabIndex = 34;
            // 
            // txtMY
            // 
            this.txtMY.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMY.Location = new System.Drawing.Point(178, 309);
            this.txtMY.Name = "txtMY";
            this.txtMY.Size = new System.Drawing.Size(275, 25);
            this.txtMY.TabIndex = 33;
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtType.Location = new System.Drawing.Point(178, 265);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(146, 25);
            this.txtType.TabIndex = 32;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddress.Location = new System.Drawing.Point(178, 165);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(275, 25);
            this.txtAddress.TabIndex = 31;
            // 
            // txtAcctNo
            // 
            this.txtAcctNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAcctNo.Location = new System.Drawing.Point(178, 126);
            this.txtAcctNo.Name = "txtAcctNo";
            this.txtAcctNo.Size = new System.Drawing.Size(275, 25);
            this.txtAcctNo.TabIndex = 30;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustomer.Location = new System.Drawing.Point(178, 89);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(275, 25);
            this.txtCustomer.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(16, 410);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(203, 25);
            this.label17.TabIndex = 28;
            this.label17.Text = "AMOUNT IN WORDS:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(16, 348);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 25);
            this.label16.TabIndex = 27;
            this.label16.Text = "WATER BILL NO:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(16, 306);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 25);
            this.label15.TabIndex = 26;
            this.label15.Text = "MONTH/YEAR:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(16, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 25);
            this.label14.TabIndex = 25;
            this.label14.Text = "TRANSACTION:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomer.Location = new System.Drawing.Point(16, 89);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(118, 25);
            this.lblCustomer.TabIndex = 24;
            this.lblCustomer.Text = "CUSTOMER:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 564);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblAcctNo);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.txtWaterBillNo);
            this.Controls.Add(this.txtMY);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtAcctNo);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtDT);
            this.Controls.Add(this.label2);
            this.Name = "frmPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPOS";
            this.ResumeLayout(false);
            this.PerformLayout();

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