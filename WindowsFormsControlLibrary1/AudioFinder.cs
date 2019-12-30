using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RAudioDataAccess.Models;
using RAudioDataAccess;
using MySql.Data.MySqlClient;

namespace RAudioControls
{
    public partial class AudioFinder : UserControl
    {
        private IRAudioDataAccess dataAccess;
        public AudioFinder()
        {
            InitializeComponent();
            MySqlConnectionStringBuilder lol = new MySqlConnectionStringBuilder();
            lol.Database = "raudio";
            lol.Server = "localhost";
            lol.UserID = "root";
            lol.Password = "";
            dataAccess = new MySqlRAudioDataAccess(lol.GetConnectionString(true));

            List<Artist> test = dataAccess.GetArtists();

            BindingList<Artist> objects = new BindingList<Artist>(test);

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = objects;

        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            string allExtensions = "*.wav;*.aiff;*.mp3;*.aac;*.flac";
            openFileDialog.Filter = String.Format("Fiters de musica coneguts|{0}|Tots els fitxers (*.*)|*.*", allExtensions);
            openFileDialog.Multiselect = true;

            //openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AfegirFitxers(openFileDialog.FileNames);
            }
        }

        private void AfegirFitxers(string[] files)
        {
            List<string> errors = new List<string>();
            string extensio;

            foreach (string file in files)
            {
                extensio = Path.GetExtension(file);
                //posar el path.get en una variable i posar tots els fitxers compatibles en un List
                if (Path.GetExtension(file) == ".wav" || Path.GetExtension(file) == ".flac" || Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".aac")
                {

                    Arxiu axr = new Arxiu
                    {
                        fileName = file
                    };

                    try
                    {
                        var tfile = TagLib.File.Create(axr.fileName);
                        axr.name = tfile.Tag.Title ?? Path.GetFileNameWithoutExtension(axr.fileName);
                        axr.artist = tfile.Tag.JoinedPerformers;

                        string[] lol = { axr.name, axr.artist, axr.fileName };

                        var itom = new ListViewItem(lol)
                        {
                            BackColor = Color.Yellow
                        };

                        //item.SubItems.Add(axr.artist);
                        //item.SubItems.Add(axr.duration.ToString());

                        listView1.Items.Add(itom);

                    }
                    catch (TagLib.CorruptFileException)
                    {

                        if (!errors.Contains("Fitxer/s Corrupte/s :("))
                        {
                            errors.Add("Fitxer/s Corrupte/s :(");
                        }

                    }
                    catch (TagLib.UnsupportedFormatException)
                    {
                        if (!errors.Contains("Tipus de fitxer " + Path.GetExtension(file) + " no acceptat :("))
                        {
                            errors.Add("Tipus de fitxer " + Path.GetExtension(file) + " no acceptat :(");
                        }
                    }
                    catch
                    {
                        if (!errors.Contains("Error al carregar el fitxer " + Path.GetFullPath(file) + " :("))
                        {
                            errors.Add("Error al carregar el fitxer " + Path.GetFullPath(file) + " :(");
                        }
                    }
                }
                else
                {
                    if (!errors.Contains("El format " + Path.GetExtension(file) + " no esta soportat :("))
                    {

                        errors.Add("El format " + Path.GetExtension(file) + " no esta soportat :(");
                    }
                }
            }
            foreach (string error in errors)
            {
                MessageBox.Show(error);
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Collections.Specialized.StringCollection filePath = new
    System.Collections.Specialized.StringCollection();
            if (listView1.SelectedItems.Count > 0)
            {
                filePath.Add(listView1.SelectedItems[0].SubItems[2].Text);
                DataObject dataObject = new DataObject();
                dataObject.SetFileDropList(filePath);
                listView1.DoDragDrop(dataObject, DragDropEffects.Copy);
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            base.DoDragDrop(listView1.SelectedItems[0], DragDropEffects.All);
        }
    }
}
