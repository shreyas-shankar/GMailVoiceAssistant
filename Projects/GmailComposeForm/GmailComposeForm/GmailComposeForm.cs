using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Data.SQLite;


namespace GmailComposeForm
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        Choices commands = new Choices();
        Choices contacts = new Choices();
        Grammar command_Grammar;
        Grammar contact_Grammar;

        public Form1()
        {
            InitializeComponent();
            //Load_Commands();
            //System_Listener();
        }

        public void Load_Commands()
        {
            MessageBox.Show("inside load commands");
            using (SQLiteConnection con = new SQLiteConnection("data source = virtualassistant.db3"))
            {

                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    con.Open();
                    cmd.CommandText = "SELECT command_spoken FROM commands";
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show(reader["command_spoken"].ToString());
                            commands.Add(new String[] { reader["command_spoken"].ToString() });
                        }
                    }
                }
                con.Close();
                /*con.Open();
                using (SQLiteCommand cmd2 = new SQLiteCommand(con))
                {
                    cmd2.CommandText = "SELECT contact_id FROM contacts";
                    using (SQLiteDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contacts.Add(new String[] { reader["contact_id"].ToString() });
                        }
                    }
                }
                con.Close();*/
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MessageBox.Show("inside form load");
            Load_Commands();
            //System_Listener();
        }
    }
}
        
        /*public void System_Listener()
        {
            command_Grammar = new Grammar(new GrammarBuilder(commands));
            //contact_Grammar = new Grammar(new GrammarBuilder(contacts));

            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(command_Grammar);
                //sRecognize.LoadGrammar(contact_Grammar);
                sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognize_SpeechRecognized);
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch
            {
                return;
            }
        }

        /*public void sRecognize_SpeechRecognized(object sender,SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "Add Recipient")
            {
                MessageBox.Show("inside add recipient");
                toBox.Select();
                toBox.Text = e.Result.Text;
            }
            else if (e.Result.Text == "Add Subject")
            {
                MessageBox.Show("inside add subject");
                subjectBox.Select();
            }
            else if (e.Result.Text == "Add Body")
            {
                bodyBox.Select();
            }
        }*/
        
   
