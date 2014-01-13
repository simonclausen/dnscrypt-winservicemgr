using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace dnscrypt_winservicemgr
{
    class ProviderMgr
    {
        private List<ProviderItem> providerList = new List<ProviderItem>();

        public ProviderMgr()
        {
            //
            String dnscrypteu1 = "176.56.237.171:443*[2a00:d880:3:1::a6c1:2e89]:443*67C0:0F2C:21C5:5481:45DD:7CB4:6A27:1AF2:EB96:9931:40A3:09B6:2B8D:1653:1185:9C66*2.dnscrypt-cert.resolver1.dnscrypt.eu*DNSCrypt.eu (no logs, DNSSEC, EU)";
            String dnscrypteu2 = "77.66.84.233:443*[2a00:d880:3:1::a6c1:2e89]:443*3748:5585:E3B9:D088:FD25:AD36:B037:01F5:520C:D648:9E9A:DD52:1457:4955:9F0A:9955*2.dnscrypt-cert.resolver2.dnscrypt.eu*DNSCrypt.eu (no logs, DNSSEC, EU)";
            String opendns1 = "208.67.220.220:443*[2620:0:ccc::2]:443*B735:1140:206F:225D:3E2B:D822:D7FD:691E:A1C3:3CC8:D666:8D0C:BE04:BFAB:CA43:FB79*2.dnscrypt-cert.opendns.com*OpenDNS (Anycast)";
            String cloudns1 = "113.20.6.2:443*[2405:5000:2:1e5:250:56ff:fe9a:35b]:443*1971:7C1A:C550:6C09:F09B:ACB1:1AF7:C349:6425:2676:247F:B738:1C5A:243A:C1CC:89F4*2.dnscrypt-cert.cloudns.com.au*CloudNS (no logs, DNSSEC, AUS)";
            String opennic1 = "106.186.17.181:2053*[2400:8900::f03c:91ff:fe70:c452]:2053*8768:C3DB:F70A:FBC6:3B64:8630:8167:2FD4:EE6F:E175:ECFD:46C9:22FC:7674:A1AC:2E2A*2.dnscrypt-cert.ns2.jp.dns.opennic.glue*OpenNIC (no logs, JPN)";
            String opennic2 = "185.19.105.14:443*[2a04:1400:1337:2000::14]:443*B1AB:7025:1119:9AEE:E42E:1B12:F2EF:12D4:53D9:CD92:E07B:9AF4:4794:F6EB:E5A4:F725*2.dnscrypt-cert.ns10.uk.dns.opennic.glue*OpenNIC (no logs, EU)";
            String opennic3 = "185.19.105.6:443*[2a04:1400:1337:2000::6]:443*E864:80D9:DFBD:9DB4:58EA:8063:292F:EC41:9126:8394:BC44:FAB8:4B6E:B104:8C3B:E0B4*2.dnscrypt-cert.ns9.uk.dns.opennic.glue*OpenNIC (no logs, EU)";
            String soltysiak1 = "178.216.201.222:2053*[2001:470:70:4ff::2]:2053*25C4:E188:2915:4697:8F9C:2BBD:B6A7:AFA4:01ED:A051:0508:5D53:03E7:1928:C066:8F21*2.dnscrypt-cert.soltysiak.com*Soltysiak.com (no logs, DNSSEC, EU)";
            
            List<String> providerDetails = new List<String>();
            providerDetails.Add(dnscrypteu2);
            providerDetails.Add(dnscrypteu1);
            providerDetails.Add(opendns1);
            providerDetails.Add(cloudns1);
            providerDetails.Add(opennic1);
            providerDetails.Add(opennic2);
            providerDetails.Add(opennic3);
            providerDetails.Add(soltysiak1);

            for (int i=0; i < providerDetails.Count; i++)
            {
                ProviderItem providerItem = new ProviderItem();

                string s = providerDetails[i];
                string[] detail = s.Split('*');

                providerItem.setHost4(detail[0]);
                providerItem.setHost6(detail[1]);
                providerItem.setKey(detail[2]);
                providerItem.setName(detail[3]);
                providerItem.setIntName(detail[4]);

                providerList.Add(providerItem);
            }
        }

        public List<ProviderItem> getProvider(String searchIntName)
        {
            List<ProviderItem> result = new List<ProviderItem>();

            for(int x=0; x < providerList.Count; x++)
            {
                if (searchIntName == providerList[x].getIntName())
                {
                    result.Add(providerList[x]);
                }
            }
            return result;
        }
    }
}
