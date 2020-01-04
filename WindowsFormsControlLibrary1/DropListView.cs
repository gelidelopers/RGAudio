using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAudioControls
{
    public partial class DropListView : UserControl
    {
        public DropListView()
        {
            InitializeComponent();
        }
        public int Index { get; set; }

        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (checkBoxOrder.Checked)
            {
                base.DoDragDrop(listView1.SelectedItems[0], DragDropEffects.Move);
            }
            else
            {
                base.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (checkBoxOrder.Checked)
            {
                if (e.Data.GetDataPresent(typeof(ListViewItem)))
                {
                    ListViewItem actual = listView1.Items[Index];
                    //if (listView1.SelectedItems.Count == 0)
                    //{
                    //    return;
                    //}
                    //Returns the location of the mouse pointer in the ListView control.
                    Point cp = listView1.PointToClient(new Point(e.X, e.Y));
                    //Obtain the item that is located at the specified location of the mouse pointer.
                    ListViewItem dragToItem = listView1.GetItemAt(cp.X, cp.Y);
                    //if (dragToItem == null)
                    //{
                    //    return;
                    //}
                    //Obtain the index of the item at the mouse pointer.
                    int dragIndex = dragToItem.Index;
                    ListViewItem[] sel = new ListViewItem[listView1.SelectedItems.Count];
                    for (int i = 0; i <= listView1.SelectedItems.Count - 1; i++)
                    {
                        sel[i] = listView1.SelectedItems[i];
                    }
                    for (int i = 0; i < sel.GetLength(0); i++)
                    {
                        //Obtain the ListViewItem to be dragged to the target location.
                        ListViewItem dragItem = sel[i];
                        int itemIndex = dragIndex;
                        //if (itemIndex == dragItem.Index)
                        //{
                        //    return;
                        //}
                        if (dragItem.Index < itemIndex)
                            itemIndex++;
                        else
                            itemIndex = dragIndex + i;
                        //Insert the item at the mouse pointer.
                        ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                        listView1.Items.Insert(itemIndex, insertItem);
                        //Removes the item from the initial location while 
                        //the item is moved to the new location.
                        listView1.Items.Remove(dragItem);
                    }
                    Index = actual.Index;

                }
                else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    
                }

            }
            else
            {
                if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                {
                    var items = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                    foreach (ListViewItem item in items)
                    {
                        item.ListView.Items.Remove(item);
                        listView1.Items.Add(item);
                    }
                }
                else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                }
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (checkBoxOrder.Checked)
            {
                if (e.Data.GetDataPresent(typeof(ListViewItem)))
                {

                    var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                    if (item.Font != fntPlaying)
                    {
                        e.Effect = DragDropEffects.Move;
                    }
                }
                else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else
            {
                if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }
    }
}
