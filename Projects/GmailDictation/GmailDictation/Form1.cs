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
using System.Threading;
using System.Globalization;

namespace GmailDictation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //LoadDictationGrammars();
        }

        SpeechRecognitionEngine recoEngine = new SpeechRecognitionEngine();

        /*private void LoadDictationGrammars()
        {

            // Create a default dictation grammar.
            DictationGrammar defaultDictationGrammar = new DictationGrammar();
            defaultDictationGrammar.Name = "default dictation";
            defaultDictationGrammar.Enabled = true;

            
            // Create the spelling dictation grammar.
            DictationGrammar spellingDictationGrammar =
              new DictationGrammar();
            //spellingDictationGrammar.Name = "spelling dictation";
            spellingDictationGrammar.Enabled = true;
            /*
            // Create the question dictation grammar.
            DictationGrammar customDictationGrammar =
              new DictationGrammar("grammar:dictation");
            customDictationGrammar.Name = "question dictation";
            customDictationGrammar.Enabled = true;

            // Create a SpeechRecognitionEngine object and add the grammars to it.
            recoEngine = new SpeechRecognitionEngine();
            recoEngine.LoadGrammar(defaultDictationGrammar);
            recoEngine.LoadGrammar(spellingDictationGrammar);
            //recoEngine.LoadGrammar(customDictationGrammar);
            
            // Add a context to customDictationGrammar.
            //customDictationGrammar.SetDictationContext("How do you", null);

            
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {            
            recoEngine.SetInputToDefaultAudioDevice();
            DictationGrammar dg = new DictationGrammar();
            recoEngine.LoadGrammar(dg);
            recoEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recoEngine_SpeechRecognized);                
            recoEngine.RecognizeAsync(RecognizeMode.Multiple);
            
        }

        private void recoEngine_SpeechRecognized(Object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show(e.Result.Text);
            textBox1.AppendText(e.Result.Text);
        }
    }
}
