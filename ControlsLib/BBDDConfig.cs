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
using Dades;
using System.Data.Entity.Core.EntityClient;

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
            Connection = builder.ConnectionString;
            MessageBox.Show("Modified: {0}", builder.ConnectionString);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                CreateString();
            }
            else
            {
                EntityConnectionStringBuilder entityBuilder =
    new EntityConnectionStringBuilder();

                //Set the provider name.
                entityBuilder.Provider = "System.Data.SqlClient";

                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = Connection;

                // Set the Metadata location.
                
                //Connection = entityBuilder.ConnectionString;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ModelContainer db= new ModelContainer();
            //db.Database.Connection.ConnectionString = Connection;
            db.UsersSet.Add(new Users { Username = "xaviehe" });
            db.SaveChanges();
                
            
        }
    }
}
