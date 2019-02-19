using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ColumnHeader col = new ColumnHeader
            {
                Text = "caca"
            };
            dropBetweenList1.AddColumn(col);
            dropBetweenList2.AddColumn(new ColumnHeader{Text = "caca"});

            dropBetweenList1.AddItem(new ListViewItem("wiw"));
            dropBetweenList1.AddItem(new ListViewItem("caca"));
            dropBetweenList1.AddItem(new ListViewItem("culdolla"));
            dropBetweenList1.AddItem(new ListViewItem("llavontes"));
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
