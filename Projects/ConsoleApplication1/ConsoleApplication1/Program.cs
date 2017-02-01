using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EAGetMail;
using System.IO;
using System.Net.NetworkInformation;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool chk = NetworkInterface.GetIsNetworkAvailable();
            Console.WriteLine(chk);
            if (!chk)
            {
                Console.WriteLine("Available");

            }
            else
                Console.WriteLine("Not available");


            /*
            // Create a folder named "inbox" under current directory
            // to store the email file retrieved.
            string curpath = Directory.GetCurrentDirectory();
            string mailbox = String.Format("{0}\\inbox", curpath);

            // If the folder is not existed, create it.
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }

            MailServer oServer = new MailServer("imap.gmail.com","projectjarvis999@gmail.com", "jarvis99", ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");

            // Set IMAP4 server port
            //oServer.Port = 143;

            // If your IMAP4 server requires SSL connection,
            // Please add the following codes:
             oServer.SSLConnection = true;
             oServer.Port = 993;

            try
            {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    // Receive email from IMAP4 server
                    Mail oMail = oClient.GetMail(info);

                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);
                    Console.WriteLine(oMail.Content);

                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);

                    // Save email to local disk
                    oMail.SaveAs(fileName, true);

                    // Mark email as deleted from IMAP4 server.
                    //oClient.Delete(info);
                }

                // Quit and pure emails marked as deleted from IMAP4 server.
                //oClient.Quit();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
             * */
        }
    }
}
