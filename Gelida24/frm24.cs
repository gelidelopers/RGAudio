﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gelida24
{
    public partial class frm24 : Form
    {
        public frm24()
        {
            InitializeComponent();
            lblTime.Text = GenerarTimeDate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = GenerarTimeDate();
        }
        private string GenerarTimeDate()
        {
            return DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
    }
}
