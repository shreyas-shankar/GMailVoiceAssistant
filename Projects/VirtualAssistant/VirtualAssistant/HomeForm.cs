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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net.Mail;
using System.Data.SQLite;

namespace VirtualAssistant
{
    public partial class HomeForm : Form
    {

        public SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        public SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        

        //Add drives to the choices object

        System.IO.DirectoryInfo root = null;

        public void System_Speak(String message)
        {
            sSynth.Speak(message);
        }



        public void Grammar_Load()
        {
             Choices wordslist= new Choices();
             string[] drives = System.Environment.GetLogicalDrives();
             wordslist.Add(drives);

            //fill the database with files and folders present in the current folder

           
                System.IO.FileInfo[] files = null;
                System.IO.DirectoryInfo[] subDirs = null;
        

                 // First, process all the files directly under this folder 
                try
                {
                    files = root.GetFiles();
                          
                }
                // This is thrown if even one of the files requires permissions greater 
                // than the application provides. 
                catch (UnauthorizedAccessException e)
                {
                   
           
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                if (files != null)
                {
                    foreach (System.IO.FileInfo fi in files)
                    {                          
                            DatabaseConnectivity(fi);
                    }
                }
                            // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();


                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    DatabaseConnectivity(dirInfo);
                
                }
                

            SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3");
            con.Open();
            SQLiteCommand com = new SQLiteCommand(con);
              
                    
                    com.CommandText = "SELECT f_names FROM filenames'";
                    com.ExecuteNonQuery();
                    SQLiteDataReader reader = com.ExecuteReader();
                        
                            while(reader.Read())
                            {
                                //MessageBox.Show(reader["command_spoken"].ToString());
                                wordslist.Add(new String[] {reader["f_name"].ToString() });
                            }
                        
                       con.Close();

                       Grammar gr = new Grammar(new GrammarBuilder(wordslist));
                       try
                       {
                           sRecognize.RequestRecognizerUpdate();
                           sRecognize.LoadGrammar(gr);
                           sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sRecognize_SpeechRecognized);
                           sRecognize.SetInputToDefaultAudioDevice();
                           sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                           //MessageBox.Show("inside system_listener");
                       }
                       catch
                       {
                           return;
                       }
                    
            
            
        }        

        public void System_Listener()
        {
           
        }

        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Grammar gr = new Grammar(new GrammarBuilder(wordslist));
            //append text to TextInterfaceBox
            TextInterfaceBox.Text += "\r\n" + "Me : " + " " + e.Result.Text;
            run_query(e.Result.Text.ToString());
            
            Grammar_Load();
        }

        void run_query(string query)
        {
            SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3");

            con.Open();
            string CommandText = "SELECT f_path FROM filenames where f_name =' "+query+" ';";
            SQLiteCommand com = new SQLiteCommand(CommandText, con);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (NullReferenceException)
            {
                con.Close();
            }
            SQLiteDataReader reader = com.ExecuteReader();
            string path = reader.Read().ToString();
            Process.Start(path);
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(path);
            root = d;
            
        }
      /*  private void DatabaseAccess(String command)
        {
            var trigger=""; 
            //SQLiteConnection.CreateFile("virtualassistant.db3");        // Create the file which will be hosting our database
            using (SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3"))
            {
                using (SQLiteCommand com = new SQLiteCommand(con))
                {                    
                    con.Open();                             // Open the connection to the database
                    com.CommandText = "Select * FROM commands where command_type='general'";      // Select all rows from our database table

                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            
                            if (command == (reader["command_spoken"].ToString()))
                            {
                                sSynth.Speak(reader["command_response"].ToString());

                                if (command == "Update Contacts")
                                {
                                    //con.Close();
                                    //reader.Dispose();
                                    //GC.Collect();

                                    SQLiteCommand deleteFromDatabaseCommand = new SQLiteCommand(con);
                                    deleteFromDatabaseCommand.CommandText = "DELETE FROM contacts";
                                    deleteFromDatabaseCommand.ExecuteNonQuery();

                                    GmailContactImport gmailContactImport = new GmailContactImport();
                                    String [] contacts = gmailContactImport.FetchContactList();

                                    foreach (String email_id in contacts)
                                    {
                                        SQLiteCommand contactUpdateCommand = new SQLiteCommand(con);
                                        contactUpdateCommand.CommandText = "INSERT INTO contacts VALUES ('zarakifire@gmail.com','" +email_id +"');";
                                        contactUpdateCommand.ExecuteNonQuery();
                                    }
                                    sSynth.Speak("Update Completed");
                                    return;
                                }
                                trigger = reader["command_trigger"].ToString();
                                if (trigger == null)
                                {
                                    
                                    con.Close();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show(trigger);
                                    //con.Close();
                                    //goto internetAccess;
                                    //if (trigger != "")
                                    //{
                                        //MessageBox.Show(trigger);
                                        var type = Type.GetType("VirtualAssistant." + trigger);
                                        var form = Activator.CreateInstance(type) as Form;
                                        form.Show();
                                    //}
                                    break;
                                }
                                 }
                            } 
                    }                    
                }                
            }
            //internetAccess : 
            
        }*/


        private void Home_Load(object sender, EventArgs e)
        {
               System_Listener();            
        }      
        
            
        public HomeForm()
        {
            InitializeComponent();
            
        }

        static void DatabaseConnectivity(System.IO.FileInfo file)
        {

            string fname = file.Name;
            string fullname = file.FullName;
            string parent = file.Directory.ToString();
            SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3");

            con.Open();
            string CommandText = "INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')";
            SQLiteCommand com = new SQLiteCommand(CommandText, con);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (NullReferenceException)
            {
                con.Close();
            }
            Console.WriteLine("INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')");

        }
        static void DatabaseConnectivity(System.IO.DirectoryInfo folder)
        {
            string parent = "";
            string fname = folder.Name;
            string fullname = folder.FullName;
            try
            {
                parent = folder.Parent.ToString();
            }
            catch (NullReferenceException)
            {
                parent = "";
            }
            SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3");
            con.Open();
            SQLiteCommand com = new SQLiteCommand(con);
            com.CommandText = "INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')";


            com.ExecuteNonQuery();

            con.Close();
            Console.WriteLine("INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')");

        }
   }
}      


