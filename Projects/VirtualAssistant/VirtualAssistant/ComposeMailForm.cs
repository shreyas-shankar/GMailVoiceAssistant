using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Email.Mail;
using Aspose.Email.Pop3;
using Aspose.Email.Imap;
using System.Data.SQLite;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace VirtualAssistant
{
    public partial class ComposeMailForm : Form
    {   
        HomeForm homeForm = new HomeForm();
        //SpeechRecognitionEngine homeForm.sRecognize = new SpeechRecognitionEngine();
        Choices mailId = new Choices();
        Choices mailAccessCommands = new Choices();
        Grammar contactsGrammar, mailAccessCommandsGrammar;
        

        public ComposeMailForm()
        {
            InitializeComponent();
            this.Focus();            
        }
        
        public void load_Compose_Mail_Grammar()
        {
            MessageBox.Show("inside load compose mail grammar");
            SQLiteConnection conn = new SQLiteConnection();
            SQLiteCommand importContactsQuery = new SQLiteCommand(conn);
            conn.Open();
            importContactsQuery.CommandText = "SELECT email_id FROM contacts";

            SQLiteDataReader reader = importContactsQuery.ExecuteReader();

            while (reader.Read())
            {
                mailId.Add(new String[] { reader["email_id"].ToString() });
            }
            
            conn.Close();

            contactsGrammar = new Grammar(new GrammarBuilder(mailId));

            SQLiteCommand mailAccessQuery = new SQLiteCommand(conn);
            conn.Open();
            mailAccessQuery.CommandText = "SELECT * FROM commands WHERE command_type = 'mail_access'";

            reader = mailAccessQuery.ExecuteReader();
            while (reader.Read())
            {
                mailAccessCommands.Add(new String [] {reader["command_spoken"].ToString()});
            }

            conn.Close();
            mailAccessCommandsGrammar = new Grammar(new GrammarBuilder(mailAccessCommands));

        }


        public void compose_Listener()
        {
            MessageBox.Show("inside compose listener");
            
            try
            {                
                //homeForm.sRecognize.RequestRecognizerUpdate();
                load_Compose_Mail_Grammar();
                homeForm.sRecognize.LoadGrammar(contactsGrammar);
                homeForm.sRecognize.LoadGrammar(mailAccessCommandsGrammar);
                homeForm.sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognize_SpeechRecognized);
                //homeForm.sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(homeForm.sRecognize_SpeechRecognized);
                //homeForm.sRecognize.SetInputToDefaultAudioDevice();
                //homeForm.sRecognize.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }

        }

        public void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show("Inside compose mail form Engine ");
            if (e.Result.Text == "Add Recipient")
            {
                toBox.Focus();
                homeForm.sSynth.Speak("Command Received");
            }
        }
        
        public void form_Fill()
        {            
            //ComposeMailForm composeMailForm = new ComposeMailForm();
            //composeMailForm.Focus();
            toBox.Focus();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {                       
            Aspose.Email.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com");
            // Set the Gmail username
            client.Username = "zarakifire@gmail.com";
            // Set the Gmail password
            client.Password = "akash1992";
            // Set the port to 587. This is the SSL port of Gmail SMTP server
            client.Port = 587;
            // Set the security mode to explicit
            client.SecurityMode = SmtpSslSecurityMode.Explicit;
            // Enable SSL
            client.EnableSsl = true;

            Aspose.Email.Mail.MailMessage msg = new MailMessage();

            // From whom	
            msg.From = new Aspose.Email.Mail.MailAddress("zarakifire@gmail.com");

            // To whom
            msg.To.Add(new Aspose.Email.Mail.MailAddress(toBox.Text));

            // Set the subject
            msg.Subject = "subject";

            // Set the priority
            msg.Priority = Aspose.Email.Mail.MailPriority.High;

            // Set the message bodies (plain text and HTML)
            msg.TextBody = "Please open with html browser";
            msg.HtmlBody = "<bold>this is the mail body</bold>";

            // Add the attachment
            //Aspose.Email.Mail.Attachment attachment = new Attachment(@"c:\File.txt");
            //msg.Attachments.Add(attachment);

            try
            {                
                // Send the message
                client.Send(msg);
                HomeForm homeForm = new HomeForm();
                homeForm.System_Speak("Mail sent");
            }
            // Catch exception
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }                      

        }

        private void ComposeMailForm_Load(object sender, EventArgs e)
        {
            compose_Listener();
            load_Compose_Mail_Grammar();
            
            form_Fill();
        }
    }
}


