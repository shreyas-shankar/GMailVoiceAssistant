
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

namespace FileAccess
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        public SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();


        //Add drives to the choices object

        System.IO.DirectoryInfo root = new System.IO.DirectoryInfo("notadrive");

        Choices wordslist = new Choices();

        string parent = null;
        string nullparent = "";
        public void System_Speak(String message)
        {
            sSynth.Speak(message);
        }

        public void driveinfo()
        {
            string[] drives = System.Environment.GetLogicalDrives();
            foreach (string drive in drives)
            {
                DatabaseConnectivity(drive);
            }

            wordslist.Add(drives);
            
            
        }


        /*void addtowords(string[] newword)
        {
            //MessageBox.Show("Adding to choices   " + newword);
            wordslist.Add(newword); 
            
        }*/

        public void Grammar_Load()
        {
            
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
                MessageBox.Show(e.Message);

            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                //Console.WriteLine(e.Message);
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


            com.CommandText = "SELECT f_name FROM filenames";
            com.ExecuteNonQuery();
            SQLiteDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                //MessageBox.Show(reader["command_spoken"].ToString());
                wordslist.Add(new String[] { reader["f_name"].ToString() });
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
            //Grammar_Load();
        }

        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //textBox1.Text += "\r\n" + "Me : " + " " + e.Result.Text;
            //string[] paths = e.Result.Text.ToString().Split(' ');
            run_query(e.Result.Text);
            
            //append text to TextInterfaceBox
            
            
             // Grammar_Load();
            
            
        }

        void run_query(string query)
        {
            string path = "";
            using (SQLiteConnection loadContactCon = new SQLiteConnection("data source=virtualassistant.db3;"))
            {
                loadContactCon.Open();
                if (parent != null)
                {
                    parent = "'" + parent + "'";
                }
                using (SQLiteCommand insertContacts = new SQLiteCommand(loadContactCon))
                {
                    insertContacts.CommandText = "SELECT f_path FROM filenames WHERE f_name ='" + query + "' AND (parent_dir = '" + parent + "' OR parent_dir = '" + nullparent + "')";
                    parent = query;
                    using (SQLiteDataReader reader = insertContacts.ExecuteReader())
                    {
                        //MessageBox.Show("inside");
                        while (reader.Read())
                        {
                            //MessageBox.Show(reader["f_path"].ToString());
                            path = reader["f_path"].ToString();
                        }
                    }

                }
                loadContactCon.Close();

            }
            
            Process.Start(path);
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(path);
            root = d;
            Grammar_Load();
        }
        


        private void Home_Load(object sender, EventArgs e)
        {
            System_Listener();
        }

        
        
        public static bool check_unique(string pa)
        {
            int result= 3;
            SQLiteConnection check_con = new SQLiteConnection("data source=virtualassistant.db3");
            check_con.Open();
            SQLiteCommand comm = new SQLiteCommand(check_con);
            comm.CommandText = "SELECT f_path from filenames where f_path = " + pa + ";";

            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception bleh)
            {
                result = 0;
            }
            try
            {

                using (SQLiteDataReader r = comm.ExecuteReader())
                {
                    result = 3;
                }
            }

            catch (SQLiteException nodata)
            {
                result = 0;
            }
            check_con.Close();
            if (result == 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        
        static void DatabaseConnectivity(System.IO.FileInfo file)
        {

            string fname = file.Name;
            string fullname = file.FullName;
            string hopethisworks = "'" + fullname + "'";
            string parent = file.Directory.ToString();
            string[] toadd = { fullname };
            if (check_unique(hopethisworks))
            {
                SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3");

                 con.Open();
            
             
                 SQLiteCommand com1 = new SQLiteCommand(con);
                com1.CommandText= "INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')";  
                 try
                 {
                     com1.ExecuteNonQuery();
                 }
                catch (SQLiteException asd)
                {
                    con.Close();
                }
               // Console.WriteLine("INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')");
             }
        }
        static void DatabaseConnectivity(System.IO.DirectoryInfo folder)
        {
            string parent = "";
            string fname = folder.Name;
            string fullname = folder.FullName;
            string hopethisworks = "'" + fullname + "'";
            string[] toadd = { fullname };
            try
            {
                parent = folder.Parent.ToString();
            }
            catch (NullReferenceException)
            {
                parent = null;
            }
            if (parent == null)
            {
                parent = folder.Root.ToString();
            }
            if (check_unique(hopethisworks))
            {

                SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3");
                con.Open();

                SQLiteCommand com = new SQLiteCommand(con);
                com.CommandText = "INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')";

                try
                {
                    com.ExecuteNonQuery();
                }
                catch (SQLiteException sdf)
                {
                    con.Close();
                }
                con.Close();
              //   Console.WriteLine("INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')");
                //Form1 f1 = new Form1();
               // f1.addtowords(toadd);

            }
            

        }

        static void DatabaseConnectivity(string drive)
        {
            System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(drive);
            string parent = "";
            string fname = folder.Name;
            string fullname = folder.FullName;
            try
            {
                parent = folder.Parent.ToString();
            }
            catch (NullReferenceException)
            {
                parent = null;
            }
            SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3");
            con.Open();
            SQLiteCommand com = new SQLiteCommand(con);
            com.CommandText = "INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')";


            com.ExecuteNonQuery();

            con.Close();
            //Console.WriteLine("INSERT INTO filenames VALUES('" + fname + "' , '" + fullname + "', '" + parent + "')");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        _check_Database_Existence();
        driveinfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //driveinfo();
            Grammar_Load();
        }
        
        
        
        public void _check_Database_Existence()
        {
            using (SQLiteConnection contactUpdateCon = new SQLiteConnection("data source=virtualassistant.db3;"))
            {
                contactUpdateCon.Open();
                using (SQLiteCommand createTableCommand = new SQLiteCommand(contactUpdateCon))
                {
                    createTableCommand.CommandText = "CREATE TABLE IF NOT EXISTS filenames (f_name text,f_path text not null unique on conflict ignore, parent_dir text );";
                    createTableCommand.ExecuteNonQuery();
                }
            }
        }
    }
}


