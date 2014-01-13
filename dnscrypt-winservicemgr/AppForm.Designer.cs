using System.Windows.Forms;
namespace dnscrypt_winservicemgr
{
    partial class ApplicationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.providerSelect = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hideAdaptersCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DNSlistbox = new System.Windows.Forms.CheckedListBox();
            this.protoUDP = new System.Windows.Forms.RadioButton();
            this.ipv6Radio = new System.Windows.Forms.RadioButton();
            this.protoTCP = new System.Windows.Forms.RadioButton();
            this.ipv4Radio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(83, 51);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.Text = "Enable";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // providerSelect
            // 
            this.providerSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.providerSelect.FormattingEnabled = true;
            this.providerSelect.Items.AddRange(new object[] {
            "CloudNS (no logs, DNSSEC, AUS)",
            "DNSCrypt.eu (no logs, DNSSEC, EU)",
            "OpenDNS (Anycast)",
            "OpenNIC (no logs, JPN)",
            "OpenNIC (no logs, EU)",
            "Soltysiak.com (no logs, DNSSEC, EU)"});
            this.providerSelect.Location = new System.Drawing.Point(14, 19);
            this.providerSelect.Name = "providerSelect";
            this.providerSelect.Size = new System.Drawing.Size(206, 21);
            this.providerSelect.TabIndex = 2;
            this.providerSelect.SelectedIndexChanged += new System.EventHandler(this.providerSelect_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.providerSelect);
            this.groupBox2.Controls.Add(this.button);
            this.groupBox2.Location = new System.Drawing.Point(13, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 86);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Provider";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "DNSCrypt Windows Service Manager v0.1\nby Simon Clausen (https://dnscrypt.eu)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // hideAdaptersCheckbox
            // 
            this.hideAdaptersCheckbox.AutoSize = true;
            this.hideAdaptersCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hideAdaptersCheckbox.Location = new System.Drawing.Point(247, 90);
            this.hideAdaptersCheckbox.Name = "hideAdaptersCheckbox";
            this.hideAdaptersCheckbox.Size = new System.Drawing.Size(132, 17);
            this.hideAdaptersCheckbox.TabIndex = 14;
            this.hideAdaptersCheckbox.Text = "Show hidden adapters";
            this.hideAdaptersCheckbox.UseVisualStyleBackColor = true;
            this.hideAdaptersCheckbox.CheckedChanged += new System.EventHandler(this.hideAdaptersCheckbox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Select network devices for use with DNSCrypt";
            // 
            // DNSlistbox
            // 
            this.DNSlistbox.CheckOnClick = true;
            this.DNSlistbox.FormattingEnabled = true;
            this.DNSlistbox.HorizontalScrollbar = true;
            this.DNSlistbox.Location = new System.Drawing.Point(12, 22);
            this.DNSlistbox.Name = "DNSlistbox";
            this.DNSlistbox.Size = new System.Drawing.Size(366, 64);
            this.DNSlistbox.TabIndex = 12;
            this.DNSlistbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.DNSlisbox_itemcheck_statechanged);
            // 
            // protoUDP
            // 
            this.protoUDP.AutoSize = true;
            this.protoUDP.Checked = true;
            this.protoUDP.Location = new System.Drawing.Point(14, 14);
            this.protoUDP.Name = "protoUDP";
            this.protoUDP.Size = new System.Drawing.Size(48, 17);
            this.protoUDP.TabIndex = 12;
            this.protoUDP.TabStop = true;
            this.protoUDP.Text = "UDP";
            this.protoUDP.UseVisualStyleBackColor = true;
            // 
            // ipv6Radio
            // 
            this.ipv6Radio.AutoSize = true;
            this.ipv6Radio.Location = new System.Drawing.Point(70, 14);
            this.ipv6Radio.Name = "ipv6Radio";
            this.ipv6Radio.Size = new System.Drawing.Size(47, 17);
            this.ipv6Radio.TabIndex = 11;
            this.ipv6Radio.Text = "IPv6";
            this.ipv6Radio.UseVisualStyleBackColor = true;
            // 
            // protoTCP
            // 
            this.protoTCP.AutoSize = true;
            this.protoTCP.Location = new System.Drawing.Point(70, 14);
            this.protoTCP.Name = "protoTCP";
            this.protoTCP.Size = new System.Drawing.Size(46, 17);
            this.protoTCP.TabIndex = 13;
            this.protoTCP.Text = "TCP";
            this.protoTCP.UseVisualStyleBackColor = true;
            // 
            // ipv4Radio
            // 
            this.ipv4Radio.AutoSize = true;
            this.ipv4Radio.Checked = true;
            this.ipv4Radio.Location = new System.Drawing.Point(13, 14);
            this.ipv4Radio.Name = "ipv4Radio";
            this.ipv4Radio.Size = new System.Drawing.Size(47, 17);
            this.ipv4Radio.TabIndex = 10;
            this.ipv4Radio.TabStop = true;
            this.ipv4Radio.Text = "IPv4";
            this.ipv4Radio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.protoTCP);
            this.groupBox1.Controls.Add(this.protoUDP);
            this.groupBox1.Location = new System.Drawing.Point(257, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 40);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Protocol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "DNSCrypt Service is";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Green;
            this.statusLabel.Location = new System.Drawing.Point(235, 33);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(91, 25);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "Enabled";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.statusLabel);
            this.groupBox3.Location = new System.Drawing.Point(13, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 84);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ipv4Radio);
            this.groupBox4.Controls.Add(this.ipv6Radio);
            this.groupBox4.Location = new System.Drawing.Point(257, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(122, 39);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "IP";
            // 
            // ApplicationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 326);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hideAdaptersCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DNSlistbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "ApplicationWindow";
            this.Text = "DNSCrypt Windows Service Manager";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ComboBox providerSelect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox hideAdaptersCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox DNSlistbox;
        private System.Windows.Forms.RadioButton protoUDP;
        private System.Windows.Forms.RadioButton ipv6Radio;
        private System.Windows.Forms.RadioButton protoTCP;
        private System.Windows.Forms.RadioButton ipv4Radio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private GroupBox groupBox4;
    }
}

