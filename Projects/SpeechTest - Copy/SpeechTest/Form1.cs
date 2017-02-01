using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis; // for the system to talk
using System.Speech.Recognition; // for system to recognize voice
using System.Threading;

namespace SpeechTest
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        Choices wordsList = new Choices();

        public Form1()
        {
            InitializeComponent();
            wordsList.Add(new String[] { "hello","akash" });
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            Grammar gr = new Grammar(new GrammarBuilder(wordsList));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                MessageBox.Show("1");
                sRecognize.LoadGrammar(gr);
                MessageBox.Show("2");
                sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognize_SpeechRecognized);
                MessageBox.Show("3");
                sRecognize.SetInputToDefaultAudioDevice();
                MessageBox.Show("4");
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                MessageBox.Show("5");
            }
            catch
            {
                return;
            }
        }
        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Grammar gr = new Grammar(new GrammarBuilder(wordsList));

            //append text to TextInterfaceBox
            TextInterfaceBox.Text += "\r\n" + "Me : " + " " + e.Result.Text;
           
        }
    }
}
