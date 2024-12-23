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
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
            txtDT.Text = DateTime.Now.ToShortDateString();

            txtCustomer.Text = "Jok Garcia";
            txtAcctNo.Text = "B-12345678";
            txtAddress.Text = "Baliuag, Magallanes, Cavite";

            txtType.Text = "Water Bill Payment";
            txtAmount.Text = "1,300.00";
            txtMY.Text = "December / 2024";
            txtWaterBillNo.Text = "0000001234567888";

            txtWords.Text = "One Thousand Three Hundred Pesos ONLY";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = printDocument1;
            printPreview.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtDT.Text.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(27, 170));

            e.Graphics.DrawString(txtCustomer.Text.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(55, 203));
            e.Graphics.DrawString(txtAcctNo.Text.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(55, 216));
            e.Graphics.DrawString(txtAddress.Text.ToString(), new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(55, 229));

            e.Graphics.DrawString(txtType.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(27, 340));
            e.Graphics.DrawString(txtAmount.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(250, 340));
            e.Graphics.DrawString(txtMY.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(25, 360));
            e.Graphics.DrawString(txtWaterBillNo.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(25, 380));

            e.Graphics.DrawString(txtWords.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(27, 545));
        }
    }
}
