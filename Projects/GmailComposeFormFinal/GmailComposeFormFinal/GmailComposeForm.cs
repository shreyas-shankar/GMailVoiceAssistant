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

namespace GmailComposeFormFinal
{
    public partial class GmailComposeForm : Form
    {
        public GmailComposeForm()
        {
            InitializeComponent();
            Load_Grammar();
        }

        SpeechRecognitionEngine sRecognize;
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        Choices commandList = new Choices();

        public void Load_Grammar()
        {
            commandList.Add(new String[]{"Add recipient","Add subject","Add body"});
            Grammar gr = new Grammar(new GrammarBuilder(commandList));
            sRecognize = new SpeechRecognitionEngine();
            sRecognize.RequestRecognizerUpdate();
            sRecognize.SetInputToDefaultAudioDevice();
            sRecognize.LoadGrammar(gr);
            sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognize_SpeechRecognized);
            sRecognize.RecognizeAsync(RecognizeMode.Multiple);
        }

        private TextBox findFocused(Control parent)
        {
            foreach (Control ctl in parent.Controls)
            {
                if (ctl.HasChildren == true)
                    return findFocused(ctl);
                else if (ctl is TextBox && ctl.Focused)
                    return ctl as TextBox;
            }

            return null;
        }

        public void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "Add recipient")
            {
                toBox.Focus();                
                Choices recipientList = new Choices();
                recipientList.Add(new String[] { "akash.manjunath@gmail.com", "zarakifire@gmail.com", "dragonballzwarriors@gmail.com" });
                Grammar recipientGrammar = new Grammar(new GrammarBuilder(recipientList));
                sRecognize.LoadGrammar(recipientGrammar);
                //sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognize_SpeechRecognized);             
                
            }
            else if (e.Result.Text == "Add subject")
            {
                subjectBox.Focus();
            }
            else if (e.Result.Text == "Add body")
            {
                bodyBox.Focus();
            }
            else
            {
                //if(toBox
                TextBox focusedTxt = findFocused(this);
               if (focusedTxt.Text == "toBox")
                {
                    focusedTxt.Text= e.Result.Text;
                    return;
                }
                focusedTxt.AppendText(e.Result.Text);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
