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
    public partial class DragList : ListView
    {
        public DragList()
        {
            InitializeComponent();
            AllowDrop = true;
            DragEnter += Drag_DragEnter;
            DragDrop += Drag_DragDrop;
            ItemDrag += Drag_ItemDrag;
        }
        private void Drag_ItemDrag(object sender, ItemDragEventArgs e)
        {
            base.DoDragDrop(this.SelectedItems, DragDropEffects.Move);
        }

        private void Drag_DragDrop(object sender, DragEventArgs e)
        {
            var item = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

            foreach (ListViewItem lol in item)
            {
                lol.ListView.Items.Remove(lol);
                this.Items.Add(lol);
            }
        }

        private void Drag_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
    }
}
