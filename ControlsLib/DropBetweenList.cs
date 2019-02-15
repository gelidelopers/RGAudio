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
    public partial class DropBetweenList : UserControl
    {
        public DropBetweenList()
        {
            InitializeComponent();
            listView1.Items.Add("lol");
            listView1.Items.Add("caca");
            listView1.Items.Add("culdolla");
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

        private void ListView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            base.DoDragDrop(listView1.SelectedItems[0], DragDropEffects.Move);
        }
    }
}
