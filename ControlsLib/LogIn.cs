using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLib
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUser.Text)&& !string.IsNullOrWhiteSpace(txtPasswd.Text))
            {
                if (txtPasswd.Text.Equals("12345"))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Contrasenya incorrecta");
                }
            }
            else
            {
                MessageBox.Show("Introdueix un usuari i contrasenya");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
