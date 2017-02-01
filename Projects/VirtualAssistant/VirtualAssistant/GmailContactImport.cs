/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Contacts;
using Google.GData.Apps;
using Google.GData.Client;
using Google.GData.Extensions;
using System.Windows.Forms;
using System.Data.SQLite;

namespace VirtualAssistant
{
    class GmailContactImport
    {        
        public String[] FetchContactList()
        {
            // Define string of list
            List<string> lstContacts = new List<string>();
            
            // Below requestsetting class take 3 parameters applicationname, gmail username, gmail password. Provide appropriate Gmail account details
            RequestSettings rsLoginInfo = new RequestSettings("", "osa.lfps@gmail.com", "Excelsiorinterschool");
            rsLoginInfo.AutoPaging = true;
            ContactsRequest cRequest = new ContactsRequest(rsLoginInfo);

            // fetch contacts list
            Feed<Contact> feedContacts = cRequest.GetContacts();

            // looping the feedcontact entries
            try
            {
                foreach (Contact gmailAddresses in feedContacts.Entries)
                {
                    // Looping to read email addresses
                    foreach (EMail emailId in gmailAddresses.Emails)
                    {
                        lstContacts.Add(emailId.Address);                        
                        //MessageBox.Show(emailId.Address.ToString());
                    }
                }
             }
            catch (Exception)
            {
                MessageBox.Show("Error Please enter the correct credentials","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //throw;
            }

            String[] contacts = lstContacts.ToArray();
            return contacts;

            foreach (String contacts in lstContacts)
            {
               // UpdateContactsInDatabase(contacts);   
            }

        }
    }

    public class MyClass
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}

*/