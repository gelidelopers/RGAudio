using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLib
{
    public partial class CategoriesManager : UserControl
    {
        public CategoriesManager()
        {
            InitializeComponent();
            CarregarCategories();
        }

        private void CarregarCategories()
        {
            //crear diccionari amb nodeitem i id

            //carregar totes les categories sense pare


            // do while llista de categories pendent no buida
            // foreach llista pendent
                // buscar id pare al diccionari i afegirlo     
            //

            
        }

        private int idCat;

        private void btnNou_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                idCat = (int)treeView1.SelectedNode.Tag;

            }
        }
    }
}
