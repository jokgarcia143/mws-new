namespace MWS.POS
{
    partial class frmLogin
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
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new MetroFramework.Controls.MetroButton();
            btnClose = new MetroFramework.Controls.MetroButton();
            pictureBox1 = new PictureBox();
            metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // metroPanel1
            // 
            metroPanel1.BorderStyle = BorderStyle.FixedSingle;
            metroPanel1.Controls.Add(txtUserName);
            metroPanel1.Controls.Add(txtPassword);
            metroPanel1.CustomBackground = false;
            metroPanel1.HorizontalScrollbar = false;
            metroPanel1.HorizontalScrollbarBarColor = true;
            metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            metroPanel1.HorizontalScrollbarSize = 10;
            metroPanel1.Location = new Point(145, 40);
            metroPanel1.Name = "metroPanel1";
            metroPanel1.Size = new Size(255, 125);
            metroPanel1.Style = MetroFramework.MetroColorStyle.Blue;
            metroPanel1.StyleManager = null;
            metroPanel1.TabIndex = 0;
            metroPanel1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroPanel1.VerticalScrollbar = false;
            metroPanel1.VerticalScrollbarBarColor = true;
            metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            metroPanel1.VerticalScrollbarSize = 10;
            metroPanel1.Paint += metroPanel1_Paint;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(25, 22);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(205, 26);
            txtUserName.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(25, 75);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(205, 26);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Red;
            btnLogin.FlatAppearance.BorderColor = Color.Red;
            btnLogin.FlatAppearance.BorderSize = 2;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.Lime;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Lime;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Highlight = false;
            btnLogin.Image = Properties.Resources.sign_in_alt;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(171, 181);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(96, 42);
            btnLogin.Style = MetroFramework.MetroColorStyle.Blue;
            btnLogin.StyleManager = null;
            btnLogin.TabIndex = 1;
            btnLogin.Text = "LOGIN";
            btnLogin.Theme = MetroFramework.MetroThemeStyle.Light;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(255, 128, 128);
            btnClose.FlatAppearance.BorderColor = Color.Red;
            btnClose.Highlight = false;
            btnClose.Location = new Point(280, 181);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(96, 42);
            btnClose.Style = MetroFramework.MetroColorStyle.Blue;
            btnClose.StyleManager = null;
            btnClose.TabIndex = 2;
            btnClose.Text = "CLOSE";
            btnClose.Theme = MetroFramework.MetroThemeStyle.Light;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.home_logo;
            pictureBox1.Location = new Point(9, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 233);
            Controls.Add(pictureBox1);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Controls.Add(metroPanel1);
            Location = new Point(0, 0);
            Name = "frmLogin";
            metroPanel1.ResumeLayout(false);
            metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroButton btnPayment;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroButton btnClose;
        private PictureBox pictureBox1;
        private TextBox txtUserName;
        private TextBox txtPassword;
    }
}