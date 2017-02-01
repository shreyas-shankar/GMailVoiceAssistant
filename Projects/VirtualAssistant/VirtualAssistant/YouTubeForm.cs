using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*Add Reference to where the Google SDK is installed
 * Download URL -> http://code.google.com/p/google-gdata/downloads/list
 */
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;

namespace VirtualAssistant
{
    public partial class YouTubeForm : Form
    {
        public YouTubeForm()
        {
            InitializeComponent();
        }

        private void YouTubeForm_Load(object sender, EventArgs e)
        {
           // YouTubeRequestSettings settings = new YouTubeRequestSettings("Virutal_Assistant", "663871269903.apps.googleusercontent.com", "AI39si69luA-qPas2lvgzsA-20rK_jfmBoLy8fD072mXfAd7XXj-YwY6AKnfMgAT6kesVa5V_wMdURfutDOv25arGAvzvFC27g","akash.manjunath@gmail.com","amogha1992!");
           // YouTubeRequest request = new YouTubeRequest(settings);
            
        }
    }
}
