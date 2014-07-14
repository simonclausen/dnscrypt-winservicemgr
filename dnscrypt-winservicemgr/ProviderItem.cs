using System;
using System.Collections.Generic;
using System.Text;

namespace dnscrypt_winservicemgr
{
    class ProviderItem
    {

        private String name = "";
        private String fullName = "";
        private String description = "";
        private String location = "";
        private String coordinates = "";
        private String url = "";
        private String version = "";
        private String dnssec = "";
        private String nologs = "";
        private String namecoin = "";
        private String address = "";
        private String providerName = "";
        private String providerPublicKey = "";
        private String providerPublicKeyTxt = "";
        public Boolean isEmpty = true;

        public String getName()
        {
            return name;
        }
        public String getFullName()
        {
            return fullName;
        }

        public String getDescription()
        {
            return description;
        }

        public String getLocation()
        {
            return location;
        }

        public String getCoordinates()
        {
            return coordinates;
        }

        public String getURL()
        {
            return url;
        }

        public String getVersion()
        {
            return version;
        }

        public String getDNSSEC()
        {
            return dnssec;
        }

        public String getNoLogs()
        {
            return nologs;
        }

        public String getNamecoin()
        {
            return namecoin;
        }

        public String getAddress()
        {
            return address;
        }

        public String getProviderName()
        {
            return providerName;
        }

        public String getPublicKey()
        {
            return providerPublicKey;
        }

        public String getPublicKeyTXT()
        {
            return providerPublicKeyTxt;
        }

        public Boolean setName(String name)
        {
            this.name = name;
            this.isEmpty = false;
            return true;
        }
        public Boolean setFullName(String fullName)
        {
            this.fullName = fullName;
            this.isEmpty = false;
            return true;
        }

        public Boolean setDescription(String description)
        {
            this.description = description;
            this.isEmpty = false;
            return true;
        }

        public Boolean setLocation(String location)
        {
            this.location = location;
            this.isEmpty = false;
            return true;
        }

        public Boolean setCoordinates(String coordinates)
        {
            this.coordinates = coordinates;
            this.isEmpty = false;
            return true;
        }

        public Boolean setURL(String url)
        {
            this.url = url;
            this.isEmpty = false;
            return true;
        }

        public Boolean setVersion(String version)
        {
            this.version = version;
            this.isEmpty = false;
            return true;
        }

        public Boolean setDNSSEC(String dnssec)
        {
            this.dnssec = dnssec;
            this.isEmpty = false;
            return true;
        }

        public Boolean setNoLogs(String nologs)
        {
            this.nologs = nologs;
            this.isEmpty = false;
            return true;
        }

        public Boolean setNamecoin(String namecoin)
        {
            this.namecoin = namecoin;
            this.isEmpty = false;
            return true;
        }

        public Boolean setAddress(String address)
        {
            this.address = address;
            this.isEmpty = false;
            return true;
        }

        public Boolean setProviderName(String providerName)
        {
            this.providerName = providerName;
            this.isEmpty = false;
            return true;
        }

        public Boolean setPublicKey(String providerPublicKey)
        {
            this.providerPublicKey = providerPublicKey;
            this.isEmpty = false;
            return true;
        }

        public Boolean setPublicKeyTXT(String providerPublicKeyTxt)
        {
            this.providerPublicKeyTxt = providerPublicKeyTxt;
            return true;
        }

        public String toString()
        {
            return "ProviderItem: " + name + " " + address + " " + providerName + " " + providerPublicKey;
        }
    }
}
