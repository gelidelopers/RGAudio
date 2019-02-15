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
    public partial class MusicLibrary : UserControl
    {
        public MusicLibrary()
        {
            InitializeComponent();
        }

        private void ListView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                
                    e.Effect = DragDropEffects.Move;
                
            }
        }

        private void ListView1_DragDrop(object sender, DragEventArgs e)
        {
            var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            item.ListView.Items.Remove(item);
            listView1.Items.Add(item);
        }
    }
}
