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

            for (int n = -1; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                comboBox1.Items.Add($"{caps.ProductName} ({caps.ManufacturerGuid.ToString()} {caps.ProductGuid.ToString()}");
            }
        }
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
        public int SelectedDevice
        {
            get
            {
                return comboBox1.SelectedIndex;
            }
            set
            {
                comboBox1.SelectedIndex = value;
            }
        }
    }
}
