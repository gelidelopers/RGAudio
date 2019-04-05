using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ControlsLib
{
    public partial class BBDDConfig : UserControl
    {
        public BBDDConfig()
        {
            InitializeComponent();
        }
        public string Connection { get; set; }

        private void CreateString() {


            SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder();

        // Supply the additional values.
            builder.DataSource = AdressEntry.Text;
            builder.UserID = UserEntry.Text;
            builder.Password = PasswdEntry.Text;
            MessageBox.Show("Modified: {0}", builder.ConnectionString);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateString();
        }
    }
}
