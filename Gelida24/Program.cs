using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gelida24
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm = new frm24();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            
            try
            {
                Application.Run(frm);
            }
            catch (Exception ex)
            {
                RestartApplication(ex);
            }
        }
        static frm24 frm;
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            RestartApplication(e.Exception);
        }
        private static void RestartApplication(Exception ex)
        {
            var frmError = new ControlsLib.frmError(ex,frm);
            // log exception somewhere, EventLog is one option    
            Application.Run(frmError);
            Process.Start(Application.ExecutablePath);
            
            Application.Exit();
        }
    }
}
