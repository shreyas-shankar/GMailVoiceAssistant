/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net; //to use HttpWebRequest
using System.IO; // to use Stream
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace VirtualAssistant
{
    public partial class WikiSearchForm : Form
    {
        String searchKey;
        public WikiSearchForm()
        {
            InitializeComponent();
        }
        public WikiSearchForm(string sKey)
        {
            InitializeComponent();
            searchKey = sKey;
        }
        private void WikiSearchForm_Load(object sender, EventArgs e)
        {

            HomeForm homeForm = new HomeForm();
           // homeForm.Grammar_Load("words_set");
            homeForm.System_Listener();

            //ServicePointManager.Expect100Continue = false;            
            
            /*HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://en.wikipedia.org/wiki/Special:Export/"+searchKey);
            webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            webRequest.Accept = "text/xml";
            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                Stream responseStream = webResponse.GetResponseStream();
                XmlReader xmlreader = new XmlTextReader(responseStream);
                String NS = "http://www.mediawiki.org/xml/export-0.3/";
                XPathDocument xpathdoc = new XPathDocument(xmlreader);
                xmlreader.Close();
                webResponse.Close();
                XPathNavigator myXPathNavigator = xpathdoc.CreateNavigator();
                XPathNodeIterator nodesIt = myXPathNavigator.SelectDescendants("text", NS, false);
                
                //MessageBox.Show("Inside1");
                WikiTextBox.AppendText(nodesIt.Current.InnerXml);
                /*do
                {
                    WikiTextBox.AppendText(nodesIt.Current.InnerXml);
                    //MessageBox.Show("Inside2");
                } while (nodesIt.MoveNext());
            }
        
            /*catch (Exception ex)
            {
                MessageBox.Show("Error while retrieve from Wikipedia. " + ex.ToString());
            }*/

            //String searchUrl = "http://en.wikipedia.org/wiki/Special:Export/"+searchKey; 
            /*WebClient client = new WebClient();
            String htmlCode = client.DownloadString(searchUrl);
            //WikiTextBox.Text = htmlCode;


            //XmlDocument xmlDoc = new XmlDocument(); 
            //xmlDoc.Load(searchUrl);

            XmlTextReader reader = new XmlTextReader(new StringReader(htmlCode));
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        WikiTextBox.AppendText(reader.ToString()+"\r\n");
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        break;
                }
            }

            string xml = new WebClient().DownloadString(searchUrl);
            XDocument doc = XDocument.Parse(xml);
            
            XmlTextReader reader = new XmlTextReader(new StringReader(doc.ToString()));

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        WikiTextBox.AppendText(reader.Value.ToString() + "\r\n");
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        break;
                }
            }
        }
    }
}
*/