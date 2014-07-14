using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.IO;


namespace dnscrypt_winservicemgr
{
    class ProviderMgr
    {
        private List<ProviderItem> providerList = new List<ProviderItem>();

        public ProviderMgr()
        {
            TextFieldParser parser = new TextFieldParser(@"" + Directory.GetCurrentDirectory() + "\\dnscrypt-resolvers.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData) 
            {
                ProviderItem providerItem = new ProviderItem();

                string[] fields = parser.ReadFields();

                providerItem.setName(fields[0]);
                providerItem.setFullName(fields[1]);
                providerItem.setDescription(fields[2]);
                providerItem.setLocation(fields[3]);
                providerItem.setCoordinates(fields[4]);
                providerItem.setURL(fields[5]);
                providerItem.setVersion(fields[6]);
                providerItem.setDNSSEC(fields[7]);
                providerItem.setNoLogs(fields[8]);
                providerItem.setNamecoin(fields[9]);
                providerItem.setAddress(fields[10]);
                providerItem.setProviderName(fields[11]);
                providerItem.setPublicKey(fields[12]);
                providerItem.setPublicKeyTXT(fields[13]);
                providerList.Add(providerItem);
            }
            parser.Close();

            // Remove first line from CVS (Name, etc, etc)
            providerList.RemoveAt(0);
        }

        public List<ProviderItem> getProvider(String searchFullName)
        {
            List<ProviderItem> result = new List<ProviderItem>();

            for(int x=0; x < providerList.Count; x++)
            {
                if (searchFullName == providerList[x].getFullName())
                {
                    result.Add(providerList[x]);
                }
            }
            return result;
        }

        public string[] getFullNames()
        {
            List<String> names = new List<String>();

            for (int i = 0; i < providerList.Count; i++)
            {
                names.Add(providerList[i].getFullName());
            }
            
            string[] returnObject = names.ToArray();

            return returnObject;
        }
    }
}
