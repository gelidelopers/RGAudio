using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;
using Gelida_Player;

namespace Gelida_Player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmSplash());
            Application.Run(new frmPlayer());
            
        }
    }
}
