using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace ControlsLib
{
    public partial class DeviceSelector : UserControl
    {
       
        public DeviceSelector()
        {
            InitializeComponent();

            
            
        }
        public void Carregar(Guid selected)
        {
            foreach (var dev in DirectSoundOut.Devices)
            {
                comboBox1.Items.Add(dev);
                if (dev.Guid == selected)
                {
                    comboBox1.SelectedItem = dev;
                }
            }
            //var outputDevice = new WaveOut(/*((DirectSoundDeviceInfo)comboBox1.SelectedItem).Guid*/);


            comboBox1.DisplayMember = "Description";
        }

        /// <summary>
        /// stack overflo
        /// https://stackoverflow.com/questions/14679253/how-to-append-two-field-values-in-combobox-display-member-in-c-sharp
        /// 
        /// This example will guide you how to do that without modifying your base class.

        //        First, you can leave your DisplayMember with one property, let's say:

        //cmbEmployees.DisplayMember = "lastname";
        //Now, go to your form in a[Design] mode, right click on the ComboBox -> Properties.

        //In the top of the Properties window, click on Events(lightning icon),

        //look for Format in the events list below(under Property Changed) and type there some event name, let's say: ComboBoxFormat , and press Enter. You will see this:

        //private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        //        {

        //        }
        //        And now write these following lines inside:

        //private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        //        {
        //            // Assuming your class called Employee , and Firstname & Lastname are the fields
        //            string lastname = ((Employee)e.ListItem).Firstname;
        //            string firstname = ((Employee)e.ListItem).Lastname;
        //            e.Value = lastname + " " + firstname;
        //        }
        //        That's it ;)
        /// 
        /// </summary>


        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }
        public Guid SelectedDevice
        {
            get
            {
                if (((DirectSoundDeviceInfo)comboBox1.SelectedItem) != null)
                {
                    return ((DirectSoundDeviceInfo)comboBox1.SelectedItem).Guid;
                }
                else
                {
                    return new DirectSoundDeviceInfo().Guid;
                }
            }
            
        }
    }
}
