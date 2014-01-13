using System;
using System.Collections.Generic;
using System.Text;

namespace dnscrypt_winservicemgr
{
    class ProviderItem
    {
        private String host4 = "";
        private String host6 = "";
        private String key = "";
        private String name = "";
        private String intName = "";
        public Boolean isEmpty = true;

        public String getHost4()
        {
            return host4;
        }

        public String getHost6()
        {
            return host6;
        }

        public String getKey()
        {
            return key;
        }

        public String getName()
        {
            return name;
        }

        public String getIntName()
        {
            return intName;
        }

        public Boolean setHost4(String host4)
        {
            this.host4 = host4;
            this.isEmpty = false;
            return true;
        }

        public Boolean setHost6(String host6)
        {
            this.host6 = host6;
            this.isEmpty = false;
            return true;
        }

        public Boolean setKey(String key)
        {
            this.key = key;
            this.isEmpty = false;
            return true;
        }

        public Boolean setName(String name)
        {
            this.name = name;
            this.isEmpty = false;
            return true;
        }

        public Boolean setIntName(String intName)
        {
            this.intName = intName;
            this.isEmpty = false;
            return true;
        }

        public String toString()
        {
            return "ProviderItem: " + host4 + " " + host6 + " " + key + " " + name + " " + intName;
        }

    }


}
