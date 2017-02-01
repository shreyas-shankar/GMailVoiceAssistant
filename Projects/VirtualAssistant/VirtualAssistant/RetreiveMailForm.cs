using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EAGetMail;
using System.IO;
using System.Data.SQLite;

namespace VirtualAssistant
{
    public partial class RetreiveMailForm : Form
    {
        String username, password;
        MailClient oClient;
        
        public RetreiveMailForm(String uname,String pass,MailClient ocl)
        {
            InitializeComponent();
            username = uname;
            password = pass;
            oClient = ocl;            
        }
       

        private void DatabaseConnect()
        {
            
        }

        private void DatabaseAccess(String command)
        {
            var trigger = "";
            using (SQLiteConnection con = new SQLiteConnection("data source=virtualassistant.db3"))
            {
                using (SQLiteCommand com = new SQLiteCommand(con))
                {
                    con.Open();                             // Open the connection to the database
                    com.CommandText = "Select * FROM commands";      // Select all rows from our database table

                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (command == (reader["command_spoken"].ToString()))
                            {
                               
                                trigger = reader["command_trigger"].ToString();
                                if (trigger == null)
                                {
                                    con.Close();
                                    return;
                                }
                                else
                                {
                                    con.Close();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (trigger != "")
            {
                var type = Type.GetType("VirtualAssistant." + trigger);
                var form = Activator.CreateInstance(type) as Form;
                form.Show();
            }
        }

        private void RetreiveMail_Load(object sender, EventArgs e)
        {
           
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];

                    // Receive email from IMAP4 server
                    Mail oMail = oClient.GetMail(info);

                    MessageBox.Show("From: " + oMail.From.ToString());
                    MessageBox.Show("Subject: \r\n" + oMail.Subject);
                    MessageBox.Show(oMail.TextBody);
                    MessageBox.Show(oMail.ReceivedDate.ToString());
                }
        }
    }
}
