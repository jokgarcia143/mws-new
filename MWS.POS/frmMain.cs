﻿using System;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBillPayment_Click(object sender, EventArgs e)
        {
            frmConsumers frmConsumers = new frmConsumers();
            frmConsumers.Show();    
        }
    }
}
