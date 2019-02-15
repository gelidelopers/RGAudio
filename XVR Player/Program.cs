using System;
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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmSplash());
            Application.Run(new frmPlayer(args));
            
        }
    }
}
