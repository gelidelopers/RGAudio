using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAudioControls
{
    public partial class RAudioButton : Button
    {
        public RAudioButton()
        {
            InitializeComponent();
            FlatStyle = FlatStyle.Popup;
            
            this.Click += RAudioButton_Click;
                
        }

        private void RAudioButton_Click(object sender, EventArgs e)
        {
            Active = !Active;
        }
        private Color _activeColor = Color.Blue;
        private Color _unactiveColor = Color.Transparent;
        public Color ActiveColor 
        {
            get { return _activeColor ; }
            set
            {
                _activeColor = value;
                if (_active)
                {
                    this.BackColor = value;
                }
                else
                {
                    this.BackColor = _unactiveColor;
                }
            }
        }
        public Color UnactiveColor
        {
            
            get { return _unactiveColor; }
            set
            {
                _unactiveColor = value;
                if (_active)
                {
                    this.BackColor = _activeColor;
                }
                else
                {
                    this.BackColor = value;
                }
            }
        }
        private bool _active;

        public bool Active
        {
            get { return _active; }
            set
            { 
                _active = value;
                if (value)
                {
                    this.BackColor = ActiveColor;
                }
                else
                {
                    if (UnactiveColor != null)
                    {
                        this.BackColor = UnactiveColor;
                    }
                    else
                    {
                        this.BackColor = Color.LightGray;
                    }
                }
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

    }
}
