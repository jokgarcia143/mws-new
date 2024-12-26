namespace MWS.POS
{
    partial class frmMain
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
            metroPanel1 = new MetroFramework.Controls.MetroPanel();
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            metroButton2 = new MetroFramework.Controls.MetroButton();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            btnReconnection = new MetroFramework.Controls.MetroButton();
            btnNewConnection = new MetroFramework.Controls.MetroButton();
            btnBillPayment = new MetroFramework.Controls.MetroButton();
            metroPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // metroPanel1
            // 
            metroPanel1.Controls.Add(metroLabel1);
            metroPanel1.Controls.Add(metroButton2);
            metroPanel1.Controls.Add(metroButton1);
            metroPanel1.Controls.Add(btnReconnection);
            metroPanel1.Controls.Add(btnNewConnection);
            metroPanel1.Controls.Add(btnBillPayment);
            metroPanel1.CustomBackground = false;
            metroPanel1.HorizontalScrollbar = false;
            metroPanel1.HorizontalScrollbarBarColor = true;
            metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel1.HorizontalScrollbarSize = 11;
            metroPanel1.Location = new Point(16, 21);
            metroPanel1.Name = "metroPanel1";
            metroPanel1.Size = new Size(260, 881);
            metroPanel1.Style = MetroFramework.MetroColorStyle.Blue;
            metroPanel1.StyleManager = null;
            metroPanel1.TabIndex = 0;
            metroPanel1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroPanel1.VerticalScrollbar = false;
            metroPanel1.VerticalScrollbarBarColor = true;
            metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.CustomBackground = false;
            metroLabel1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel1.Location = new Point(25, 68);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(189, 25);
            metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel1.StyleManager = null;
            metroLabel1.TabIndex = 7;
            metroLabel1.Text = "TRANSACTION TYPE";
            metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel1.UseStyleColors = false;
            // 
            // metroButton2
            // 
            metroButton2.Highlight = false;
            metroButton2.Location = new Point(25, 429);
            metroButton2.Name = "metroButton2";
            metroButton2.Size = new Size(192, 64);
            metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton2.StyleManager = null;
            metroButton2.TabIndex = 6;
            metroButton2.Text = "ADJUSTMENTS";
            metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroButton1
            // 
            metroButton1.Highlight = false;
            metroButton1.Location = new Point(25, 337);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(192, 64);
            metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton1.StyleManager = null;
            metroButton1.TabIndex = 5;
            metroButton1.Text = "MATERIALS";
            metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // btnReconnection
            // 
            btnReconnection.Highlight = false;
            btnReconnection.Location = new Point(25, 528);
            btnReconnection.Name = "btnReconnection";
            btnReconnection.Size = new Size(192, 64);
            btnReconnection.Style = MetroFramework.MetroColorStyle.Blue;
            btnReconnection.StyleManager = null;
            btnReconnection.TabIndex = 4;
            btnReconnection.Text = "NEW CONNECTION";
            btnReconnection.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // btnNewConnection
            // 
            btnNewConnection.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnNewConnection.Highlight = false;
            btnNewConnection.Location = new Point(25, 241);
            btnNewConnection.Name = "btnNewConnection";
            btnNewConnection.Size = new Size(192, 64);
            btnNewConnection.Style = MetroFramework.MetroColorStyle.Blue;
            btnNewConnection.StyleManager = null;
            btnNewConnection.TabIndex = 3;
            btnNewConnection.Text = "RECONNECTION";
            btnNewConnection.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // btnBillPayment
            // 
            btnBillPayment.FlatStyle = FlatStyle.Flat;
            btnBillPayment.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnBillPayment.Highlight = false;
            btnBillPayment.Location = new Point(25, 151);
            btnBillPayment.Name = "btnBillPayment";
            btnBillPayment.Size = new Size(192, 64);
            btnBillPayment.Style = MetroFramework.MetroColorStyle.Blue;
            btnBillPayment.StyleManager = null;
            btnBillPayment.TabIndex = 2;
            btnBillPayment.Text = "BILL PAYMENT";
            btnBillPayment.Theme = MetroFramework.MetroThemeStyle.Light;
            btnBillPayment.Click += btnBillPayment_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 914);
            Controls.Add(metroPanel1);
            IsMdiContainer = true;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            metroPanel1.ResumeLayout(false);
            metroPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnReconnection;
        private MetroFramework.Controls.MetroButton btnNewConnection;
        private MetroFramework.Controls.MetroButton btnBillPayment;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}