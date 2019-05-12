using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlsLib;

namespace Gelida_Player
{
    public partial class MDI : Form
    {
        private int childFormNumber = 0;

        public MDI()
        {
            InitializeComponent();
            AudioDev = Utils.GetAudioDevConfig("audioconfig.xml");
        }
        public Models.AudioDevConfig AudioDev;

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }


        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HelpMenu_Click(object sender, EventArgs e)
        {

        }

        private void ConfiguracioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LogIn logIn = new LogIn() /*{ MdiParent = this }*/;
            logIn.ShowDialog();

            if (logIn.DialogResult == DialogResult.OK)
            {

                Configuracio frm = new Configuracio() { MdiParent = this};

                frm.Show();
            }
        }

        private void Canal1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlayer frm = new frmPlayer(AudioDev.Out1Number) { MdiParent = this};
            frm.Show();
        }

        private void Canal2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlayer frm = new frmPlayer(AudioDev.Out2Number) { MdiParent = this};
            frm.Show();
        }
    }
}
