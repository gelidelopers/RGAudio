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
            
        }
        

        public void AddItem(ListViewItem item)
        {
            listView1.Items.Add(item);
        }

        public ListViewItem GetItemAt(int index)
        {
            return listView1.Items[index];
        }

        public void DeleteItemAt(int index)
        {
            listView1.Items.RemoveAt(index);
        }


        private void ListView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
            {
                e.Effect = DragDropEffects.Move; 
            }
        }

        private void ListView1_DragDrop(object sender, DragEventArgs e)
        {
            var item = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

            foreach(ListViewItem lol in item)
            {
                lol.ListView.Items.Remove(lol);
                listView1.Items.Add(lol);
            }

            
        }

        private void ListView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            base.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
        }
    }
}
