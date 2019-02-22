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
        public void AddColumn(ColumnHeader column)
        {
            listView1.Columns.Add(column);
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

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx == 0)
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(totl - 1, selected);
                    }
                    else
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(indx - 1, selected);
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un item");
                }
            }
            catch 
            {

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx == totl - 1)
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(0, selected);
                    }
                    else
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(indx + 1, selected);
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un item");
                }
            }
            catch
            {
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estàs segur que vols borrar tota la llista?", "Borrar tot?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listView1.Items.Clear();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selected = listView1.SelectedItems;

            foreach(ListViewItem item in selected)
            {
                listView1.Items.Remove(item);
            }

        }
    }
}
