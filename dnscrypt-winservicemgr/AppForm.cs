using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Management;

namespace dnscrypt_winservicemgr
{
    public partial class ApplicationWindow : Form
    {
        private Boolean serviceConfigured = false;

        // Handle the dnscrypt-proxy process
        private ProcessStartInfo cryptProc = null;
        private Process cryptHandle = null;

        // Load the provider manager
        ProviderMgr providerMgr = new ProviderMgr();

        // Keep track of current selected provider name
        private String name = "";

        private static readonly Random random = new Random();

        public ApplicationWindow()
        {
            InitializeComponent();
            refreshNICList(false);
            this.providerSelect.SelectedIndex = 0;
            checkStatus();
            UpdateChecker.checkVersion();
        }

        

        private void checkStatus()
        {
            // Check registry for dnscrypt service
            object dnsCryptReg = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\dnscrypt-proxy", "DisplayName", "");
            if (dnsCryptReg != null)
            {
                this.serviceConfigured = true;
                this.button.Text = "Disable";
                this.button.Enabled = true;
                this.providerSelect.Enabled = false;
                this.protoTCP.Enabled = false;
                this.protoUDP.Enabled = false;
                this.statusLabel.ForeColor = Color.Green;
                this.statusLabel.Text = "Enabled";
            }
            else
            {
                this.serviceConfigured = false;
                this.button.Text = "Enable";
                this.button.Enabled = true;
                this.providerSelect.Enabled = true;
                this.protoTCP.Enabled = true;
                this.protoUDP.Enabled = true;
                this.statusLabel.ForeColor = Color.DarkRed;
                this.statusLabel.Text = "Disabled";
            }
        }

        private void refreshNICList(Boolean showHidden)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();

                NetworkListItem item = new NetworkListItem(adapter.Name, adapter.Description, adapter.Id, adapter.Supports(NetworkInterfaceComponent.IPv4), adapter.Supports(NetworkInterfaceComponent.IPv6));
                if (!item.getHidden() || showHidden)
                {
                    List<string> dnsList = new List<string>();

                    object dnsResult = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces\\" + item.getID(), "NameServer", "");
                    if (dnsResult != null && dnsResult.ToString().Length > 0)
                    {
                        dnsList = new List<string>(((string)dnsResult).Split(new string[] { "," }, System.StringSplitOptions.None));
                    }

                    if (dnsList.Count != 0 && dnsList[0] == "127.0.0.1")
                    {
                        DNSlistbox.Items.Add(item, true);
                    }
                    else
                    {
                        DNSlistbox.Items.Add(item);
                    }
                }
            }
        }

        private void DNSlisbox_itemcheck_statechanged(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.CurrentValue == CheckState.Checked)
                {

                    setDNS(((NetworkListItem)DNSlistbox.Items[e.Index]).getDescription(), true);
                }
                else //Set it to loopback for DNSCrypt
                {
                    setDNS(((NetworkListItem)DNSlistbox.Items[e.Index]).getDescription(), false);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("There was an error editing the Network Adapter settings: " + exception.Message);
            }
        }

        public void setDNS(string nicDescription, bool setAuto)
        {
            ManagementClass NetworkConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection NICcollection = NetworkConfig.GetInstances();

            foreach (ManagementObject NICconfig in NICcollection)
            {
                if ((bool)NICconfig["IPEnabled"])
                {
                    ManagementBaseObject DNSconfig = NICconfig.GetMethodParameters("SetDNSServerSearchOrder");

                    if (setAuto)
                    {
                        if (NICconfig["Description"].Equals(nicDescription))
                        {
                            if (DNSconfig != null)
                            {
                                DNSconfig["DNSServerSearchOrder"] = null;
                            }
                        }
                    }
                    else
                    {
                        if (NICconfig["Description"].Equals(nicDescription))
                        {
                            string[] dnsArray = new String[1] {"127.0.0.1"};

                            DNSconfig["DNSServerSearchOrder"] = dnsArray;
                        }
                    }

                    NICconfig.InvokeMethod( "SetDNSServerSearchOrder", DNSconfig, null);
                }
            }
        }

        private void hideAdaptersCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.DNSlistbox.Items.Clear();
            this.refreshNICList(this.hideAdaptersCheckbox.Checked);
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Make sure the file exists before trying to launch it
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\dnscrypt-proxy.exe"))
            {
                MessageBox.Show("dnscrypt-proxy.exe was not found. It should be placed in the same directory as this program. If you do not have this file, you can download it from http://dnscrypt.org", "File not found");
                return;
            }

            this.cryptProc = new ProcessStartInfo();
            this.cryptProc.FileName = "dnscrypt-proxy.exe";
            this.cryptProc.WindowStyle = ProcessWindowStyle.Minimized;

            if (serviceConfigured)
            {
                // Stop running DNSCrypt service
                ServiceMgr serviceMgr = new ServiceMgr();
                ServiceMgr.stopService("dnscrypt-proxy", 1000);

                // Remove service (run dnscrypt-proxy --uninstall)
                this.cryptProc.Arguments = " --uninstall";
                this.statusLabel.Text = "Uninstalling";

                // "dnscrypt-proxy.exe --uninstall" takes care of removing everything from registry. We don't need to do anything there.
            }
            else
            {
                // Install service (run dnscrypt-proxy --install)
                this.cryptProc.Arguments = " -R \"" + this.name + "\" -L \"" + Directory.GetCurrentDirectory() + "\\dnscrypt-resolvers.csv\" --install";
                this.statusLabel.Text = "Installing";

                if (this.protoTCP.Checked)
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\dnscrypt-proxy\\Parameters", "TCPOnly", "1", RegistryValueKind.DWord);
                }
            }

            // Update visuals
            this.button.Enabled = false;
            this.statusLabel.ForeColor = Color.DarkOrange;

            // Run dnscrypt-proxy
            this.cryptHandle = Process.Start(this.cryptProc);

            // Wait for a second
            DateTime Tthen = DateTime.Now;
            do
            {
                Application.DoEvents();
            }

            while (Tthen.AddSeconds(1) > DateTime.Now);

            // Doublecheck that dnscrypt-proxy actually removed the service, if trying to remove the serice
            object dnsCryptReg = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\dnscrypt-proxy", "DisplayName", "");
            if (dnsCryptReg != null && serviceConfigured)
            {
                MessageBox.Show("It was not possible to disable the DNSCrypt system service.", "Error");
            }

            // Doublecheck that dnscrypt-proxy actually installed the service, if trying to install the serice
            if (dnsCryptReg == null && !serviceConfigured)
            {
                MessageBox.Show("It was not possible to enable the DNSCrypt system service. Make sure this program is running with Administrator privileges.", "Error");
            }

            // Update UI and status
            this.checkStatus();
        }

        private void providerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ProviderItem> providerItems = new List<ProviderItem>();
            providerItems = providerMgr.getProvider(providerSelect.SelectedItem.ToString());

            if (!providerItems[0].isEmpty)
            {
                this.name = providerItems[0].getName();
            }
        }
    }
}