using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace dnscrypt_winservicemgr
{
    class UpdateChecker
    {
        public UpdateChecker()
        {

        }

        public static void checkVersion()
        {
            Version newVersion = null;
            string url = "";
            XmlTextReader reader;
            try
            {
                string xmlURL = "http://simonclausen.dk/dnscrypt-winservicemgr/updatecheck.xml";
                reader = new XmlTextReader(xmlURL);
                reader.MoveToContent(); 
                string elementName = ""; 
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "dnscrypt-winservicemgr"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "version":
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        url = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (curVersion.CompareTo(newVersion) < 0)
            { 
                string title = "Update Check";
                string question = "A new version of DNSCrypt Windows Service Manager is available.\nWould you like to download the new version?";
                if (DialogResult.Yes == MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    System.Diagnostics.Process.Start(url);
                }
            } 
        }
    }
}
