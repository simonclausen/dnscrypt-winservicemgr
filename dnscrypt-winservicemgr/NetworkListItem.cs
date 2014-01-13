using System;
using System.Collections.Generic;
using System.Text;

namespace dnscrypt_winservicemgr
{
    public class NetworkListItem
    {
        private String nicName;
        private String nicDescription;
        private String id;
        private Boolean ipv4 = false;
        private Boolean ipv6 = false;
        private Boolean hidden = false;

        public NetworkListItem(String Name, String Description, String ID, Boolean IPv4, Boolean IPv6)
        {
            this.nicName = Name;
            this.nicDescription = Description;
            this.id = ID;
            this.ipv4 = IPv4;
            this.ipv6 = IPv6;

            if (this.shouldHide(Description))
            {
                this.hidden = true;
            }
        }

        public String getNicName()
        {
            return this.nicName;
        }

        public String getDescription()
        {
            return this.nicDescription;
        }

        public String getID()
        {
            return this.id;
        }

        public Boolean getIpv4()
        {
            return this.ipv4;
        }

        public Boolean getIpv6()
        {
            return this.ipv6;
        }

        public Boolean getHidden()
        {
            return this.hidden;
        }

        public override string ToString()
        {
            String message = this.nicDescription;
            return message;
        }

        private Boolean shouldHide(String Description)
        {
            string[] blacklist = { 
				"Microsoft Virtual",
				"Hamachi Network",
				"VMware Virtual",
				"VirtualBox",
				"Software Loopback",
				"Microsoft ISATAP",
				"Teredo Tunneling Pseudo-Interface"
			};

            foreach (string entry in blacklist)
            {
                if (Description.Contains(entry))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
