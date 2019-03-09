using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLib
{
    public partial class frmError : Form
    {
        public frmError(Exception err, Form frm)
        {
            InitializeComponent();
            errtext = err.ToString();
            label1.Text = errtext;

            MailAddress from = new MailAddress("excepcioproblemes@gmail.com");
            MailAddress to = new MailAddress("xavib99@gmail.com");
            List<MailAddress> cc = new List<MailAddress>();
            string textbr = errtext.Replace("\n", "</br>");
            //cc.Add(new MailAddress("Someone@domain.topleveldomain", "Name and stuff"));
            try
            {

                SendEmail("Problemes", textbr, from, to, cc, null, "smtp.gmail.com", 587, "excepcioproblemes@gmail.com", "pr0bl3m3s");
            }
            catch
            {

            }
            
            

        }
        private string errtext;
        protected void SendEmail(string _subject, string _text, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc, string smtphost, int smtpport,string gmail, string gmailpasswd)
        {

            SmtpClient mailClient = new SmtpClient(smtphost, smtpport) {
                EnableSsl = true,
                UseDefaultCredentials = true,
                

            };

            NetworkCredential NetworkCred = new NetworkCredential(gmail,gmailpasswd);
            
            mailClient.Credentials = NetworkCred;
            MailMessage msgMail;

            msgMail = new MailMessage
            {
                From = _from
            };
            msgMail.To.Add(_to);
            foreach (MailAddress addr in _cc)
            {
                msgMail.CC.Add(addr);
            }
            if (_bcc != null)
            {
                foreach (MailAddress addr in _bcc)
                {
                    msgMail.Bcc.Add(addr);
                }
            }
            msgMail.Subject = _subject;
            msgMail.Body = _text;
            msgMail.IsBodyHtml = true;
            mailClient.Send(msgMail);
            msgMail.Dispose();
        }

        private void frmError_Shown(object sender, EventArgs e)
        {
            Timer tm = new Timer()
            {
                Interval = 5000,
                Enabled = true
            };
            tm.Tick += Tm_Tick;
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
