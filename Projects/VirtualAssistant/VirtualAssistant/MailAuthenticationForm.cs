/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EAGetMail;
using System.IO;

namespace VirtualAssistant
{
    public partial class MailAuthenticationForm : Form
    {
        public MailAuthenticationForm()
        {
            InitializeComponent();
        }

        private void MailAuthenticationForm_Load(object sender, EventArgs e)
        {

        }
        private void loginbutton_Click(object sender, EventArgs e)
        {

            MailServer oServer = new MailServer("imap.gmail.com",emailbox.Text,passbox.Text, ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");

            oServer.SSLConnection = true;
            oServer.Port = 993;

            try
            {
                oClient.Connect(oServer);
                RetreiveMailForm retreiveMailForm = new RetreiveMailForm(emailbox.Text,passbox.Text,oClient);
                retreiveMailForm.Show();
            }
            catch (Exception ep)
            {
                HomeForm homeForm = new HomeForm();
                homeForm.System_Speak("Invalid Login Credentials. Please try again");                
            }        
        }        
    }
}
*/