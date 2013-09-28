using Microsoft.Win32;
/**
 * Copyright (c) 2009, https://code.google.com/p/putty-tunnel-manager/
 * Forked 2013 by Perfect-Privacy.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

    

namespace PerfectPrivacy.PPTunnelManager.Forms
{
    

    public partial class SettingsForm : Form
    {
        private Connection selectedConnection;
        static readonly object _locker = new object();
        public SettingsForm()
        {
            InitializeComponent();
         
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
           
            Core.Instance().Refresh();

            UpdateConnections();
          
        }

   
        public void UpdateConnections()
        {
            lock (_locker)
           
            this.storepassword.Checked = Core.Instance().storepassword;
            
            this.username.Text =  Core.Instance().username;
            this.storepassword.Checked = Core.Instance().storepassword;
            
            if (this.password.Text == "") {
                this.password.Text = Core.Instance().password;
            }

         
            this.servers.Items.Clear();
            Dictionary<string, Dictionary<string, string>> servers = Core.Instance().servers;
            foreach(string key in servers.Keys){
                Dictionary<string, string> server = servers[key];
                
                this.servers.Items.Add("" + server["servername"].ToString());
            }
            bool hasSelectedConnection = (this.connections.SelectedItems.Count > 0);
            int Lastselect = -1;
            if (hasSelectedConnection)
            {
                Lastselect = this.connections.SelectedItems[0].Index ;
            }
            this.connections.Items.Clear();
            foreach (Connection connection in Core.Instance().Connections)
            {
                string isconnected = "No";
                if (connection.IsOpen)
                { 
                isconnected = "Yes";
                }
                ListViewItem connectionViewItem = new ListViewItem(new string[] { connection.Name, connection.ConnectionType.ToString(), "" + connection.LocalPort, isconnected });
                connectionViewItem.Tag = connection;
                this.connections.Items.Add(connectionViewItem);
            }
            if (hasSelectedConnection & Lastselect != -1)
            {
                this.connections.Items[Lastselect].Selected = true;
            }


            
            Lastselect = -1;
            
            Lastselect = this.connectionType.SelectedIndex;
            
            this.connectionType.Items.Clear();
            this.connectionType.Items.Add(ConnectionType.SOCKS.ToString());
            this.connectionType.Items.Add(ConnectionType.HTTP.ToString());
            this.connectionType.Items.Add(ConnectionType.FORWARDING.ToString());
            this.connectionType.SelectedIndex = Lastselect;
                
        }
        private Connection getSelectedConnection() {
            bool hasSelectedConnection = (this.connections.SelectedItems.Count > 0);
            Connection connection;

            if (hasSelectedConnection)
            {
                connection = this.connections.SelectedItems[0].Tag as Connection;

                if (connection == null)
                    return null;

                this.selectedConnection = connection;
            }
            else
            {
                connection = Core.EmptyConnection;
            }
            return connection;
        }

        private void SwitchConnection(object sender, EventArgs e)
        {
           
            this.selectedConnection = null;

            bool hasSelectedConnection = (this.connections.SelectedItems.Count > 0);

            this.connectionDetails.Enabled = hasSelectedConnection;
            this.buttonDeleteConnection.Enabled = hasSelectedConnection;

            this.ConnectButton.Enabled = hasSelectedConnection;
            this.connectionName.Enabled = hasSelectedConnection;
            this.localPortTextBox.Enabled = hasSelectedConnection;
            this.servers.Enabled = hasSelectedConnection;
            this.autoconnect.Enabled = hasSelectedConnection;
            this.autoreconnect.Enabled = hasSelectedConnection;
            this.tolabel.Enabled = hasSelectedConnection;
            this.remoteHostTextBox.Enabled = hasSelectedConnection;
            this.remotePortTextBox.Enabled = hasSelectedConnection;

            Connection connection = getSelectedConnection();

            if(hasSelectedConnection == false){
                this.tolabel.Visible = false;
                this.remoteHostTextBox.Visible = false;
                this.remotePortTextBox.Visible = false;
            }else{
                if (connection.ConnectionType == ConnectionType.FORWARDING)
                {
                    this.remoteHostTextBox.Visible = true;
                    this.remotePortTextBox.Visible = true;
                    this.tolabel.Visible = true;
                }
                else {
                    this.remoteHostTextBox.Visible = false;
                    this.remotePortTextBox.Visible = false;
                    this.tolabel.Visible = false;
                }

            }
            

            if (hasSelectedConnection == false)
            {
                this.servers.Items.Clear();
                this.localPortTextBox.Text = "";
                this.remotePortTextBox.Text = "";
                this.remoteHostTextBox.Text = "";
                this.connectionName.Text = "";
                this.connectionType.Items.Clear();
                this.explainConnection.Text = "";
                return;
            }
            else {
                if (this.connectionType.Items.Count == 0)
                {
                    this.servers.Items.Clear();
                    Dictionary<string, Dictionary<string, string>> servers = Core.Instance().servers;
                    foreach (string key in servers.Keys)
                    {
                        Dictionary<string, string> server = servers[key];

                        this.servers.Items.Add("" + server["servername"].ToString());
                    }

                    int Lastselect = -1;

                    Lastselect = this.connectionType.SelectedIndex;

                    this.connectionType.Items.Clear();
                    this.connectionType.Items.Add(ConnectionType.SOCKS.ToString());
                    this.connectionType.Items.Add(ConnectionType.HTTP.ToString());
                    this.connectionType.Items.Add(ConnectionType.FORWARDING.ToString());
                    this.connectionType.SelectedIndex = Lastselect;
                }
              
            }


            if (connection == null) { 
           
              
                return;
            }
            // General

            if (connection.IsOpen == true)
            {
                this.ConnectButton.Text = "Disconnect";
            }
            else {
                this.ConnectButton.Text = "Connect";
            }
            
            this.connectionName.Text = connection.Name;

            this.connectionType.SelectedIndex = this.connectionType.FindString(connection.ConnectionType.ToString());
            this.localPortTextBox.Text = ""+connection.LocalPort.ToString();
            this.remoteHostTextBox.Text = "" + connection.RemoteHost;
            this.remotePortTextBox.Text = "" + connection.RemotePort.ToString();

            this.autoconnect.Checked = connection.Autoconnect;
            this.autoreconnect.Checked = connection.Autoreconnect;
          //  this.localPortsAcceptAll.Checked = connection.LocalPortsAcceptAll;



            //this.storeTunnelsSeparate.Checked = connection.UsePtmForTunnels;

            // SSH
            try
            {
                this.servers.SelectedIndex = this.servers.FindString(connection.Hostname);
            }catch(Exception){
                try
                {
                    MessageBox.Show("Server " + this.selectedConnection.Hostname + " for connection " + connection.Name + " is no longer available, sorry.");
                }catch(Exception){}
                  this.servers.SelectedIndex = 0;
            }
          
            if(connection.ConnectionType == ConnectionType.FORWARDING){
                string rh = connection.RemoteHost.Trim();
              

                if (rh == "127.0.0.1" || rh.ToLower() == "localhost" ){
                    rh = " servers local";
                   
                }
                
                
                if (connection.IsOpen)
                {
                    this.explainConnection.Text = "Forwarding 127.0.0.1 port " + connection.LocalPort + "  to " + rh + " port " + connection.RemotePort;
                }
                else
                {
                    this.explainConnection.Text = "Forward 127.0.0.1 port " + connection.LocalPort + "  to " + rh + " port " + connection.RemotePort;
                }
            }else{
                if(connection.IsOpen){
                    this.explainConnection.Text = connection.ConnectionType + " Proxy usable at IP 127.0.0.1 port " + connection.LocalPort;
                }else{
                    this.explainConnection.Text = "Create a " + connection.ConnectionType + " Proxy usable at IP 127.0.0.1 port " + connection.LocalPort;
                }
            }
           
        }

        public long UnixTimeNow()
        {
            TimeSpan _TimeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_TimeSpan.TotalSeconds;
        }

        private void buttonDownloadPlink_Click(object sender, EventArgs e)
        {
            try{
                this.buttonDownloadPlink.Enabled = false;
                string serverlist = "";
                string [] urls = {
                                     "https://www.perfect-privacy.com/api/ssh-fingerprints-rsa",
                                     "https://new.perfect-privacy.com/api/ssh-fingerprints-rsa",
                                     "https://perfect-privacy.com/api/ssh-fingerprints-rsa",
                                     "http://www.perfect-privacy.com/api/ssh-fingerprints-rsa",
                                     "http://new.perfect-privacy.com/api/ssh-fingerprints-rsa",
                                     "http://perfect-privacy.com/api/ssh-fingerprints-rsa",
                                 };
                StringBuilder debuglog;
                debuglog = new StringBuilder();

                foreach(string url in urls){
                    try
                    {
                        HttpWebResponse response = Core.Instance().rm.SendGETRequest(url, "", "", true);
                        if (response == null)
                        {
                            debuglog.Append("Unreachable: " + url + "  \n");

                        }
                        else
                        {
                            serverlist = Core.Instance().rm.GetResponseContent(response);
                            if (serverlist != "")
                            {
                                break;
                            }
                            else
                            {
                                debuglog.Append("Failed: "  + url + " \n");
                            }
                        }
                    }catch(Exception ex){
                        debuglog.Append("Failed: " + url + " \n Error: " + ex.ToString() + "\n\n");
                    }
                
                }
                
                if(serverlist == ""){

                    if (MessageBox.Show("Updateserver not available, try again later.\n\n Do you want to see a debug log ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(debuglog.ToString());

                    }
                    return;
                }
              
                string[]  servers = serverlist.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                long now = UnixTimeNow();
                long count = 0;
                
                foreach (string server in servers)
                {
                    try
                    {
                        if (server == "") { continue; }
                       
                        string[] parts = server.Split(new string[] { "\t", }, StringSplitOptions.None);
                        string servername = parts[0].Trim(); 
                        string fingerprint = parts[1].Trim(); 
                        if(servername.IndexOf(".perfect-privacy.") == -1){
                            continue;
                        }
                        count++;
                        string serverkeypath = PPSettings.PP_REGISTRY_KEYPATH_SSH_HOST_KEYS + @"\" + Uri.EscapeUriString(servername);
                        RegistryKey serverkey = Registry.CurrentUser.CreateSubKey(serverkeypath);

                        serverkey.SetValue(PPSettings.PP_REGISTRY_KEY_SERVERNAME, servername, RegistryValueKind.String);
 
                        serverkey.SetValue(PPSettings.PP_REGISTRY_KEY_FINGERPRINT, fingerprint, RegistryValueKind.String);
                        serverkey.SetValue(PPSettings.PP_REGISTRY_KEY_SERVERVERSION, now, RegistryValueKind.String);
                    }
                    catch (Exception ex) { }
                }
                RegistryKey serversversion = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_SSH_HOST_KEYS);
                serversversion.SetValue(PPSettings.PP_REGISTRY_KEY_SERVERVERSION, now, RegistryValueKind.String);
                Core.Instance().loadServers();
                if (count < 4)
                {
                    string only = "";
                    if (count > 0) { only = "Only "; }
                    MessageBox.Show(only + count + " Servers available. \n\n This is most likely wrong.\n\n Try to update again or contact support@perfect-privacy.com if this problem persists.");
                }
                else {
                    MessageBox.Show(count + " Servers available.");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Update failed, try again later.");
            }
          
            this.buttonDownloadPlink.Enabled = true;
            this.servers.Items.Clear();
            Dictionary<string, Dictionary<string, string>> servers_ = Core.Instance().servers;
            foreach (string key in servers_.Keys)
            {
                Dictionary<string, string> server = servers_[key];

                this.servers.Items.Add("" + server["servername"].ToString());
            }
            Connection connection = getSelectedConnection();
            try
            {
                this.servers.SelectedIndex = this.servers.FindString(connection.Hostname);
            }
            catch (Exception)
            {
                try
                {
                    MessageBox.Show("Server " + this.selectedConnection.Hostname + " for connection " + connection.Name + " is no longer available, sorry.");
                }
                catch (Exception) { }
                this.servers.SelectedIndex = 0;
            }

        }

   

        private void AddPortButtonHandler(object sender, EventArgs e)
        {
          /*  if (this.selectedConnection.Tunnels.Count >= 10)
            {
                MessageBox.Show("10 Portforwardings per Connection should be enough for everyone ;)");
            }
            else
            {

                ButtonBase button = sender as ButtonBase;
                AddTunnelForm addTunnelForm = new AddTunnelForm((TunnelType)button.Tag);
                if (addTunnelForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (this.selectedConnection != null)
                    {
                        this.selectedConnection.Tunnels.Add(new Tunnel(this.selectedConnection, addTunnelForm.SourcePort, addTunnelForm.Destination, addTunnelForm.DestinationPort, addTunnelForm.TunnelType));
                        this.selectedConnection.Serialize();

                        this.SwitchConnection(this, null);
                    }
                }
            }
            this.UpdateConnections();*/
        }

        private void DeletePortButtonHandler(object sender, EventArgs e)
        {
          
        }

        private void buttonAddConnection_Click(object sender, EventArgs e)
        {

            if (Core.Instance().Connections.Count >= 100)
            {
                MessageBox.Show("100 Connections should be enough for everyone ;)");
            }
            else
            {
                while (true)
                {
                    AddConnectionForm form = new AddConnectionForm();
                    ConnectionType ct = ConnectionType.SOCKS;
                    DialogResult result = form.ShowDialog(this);
                    if (result == DialogResult.Cancel || result == DialogResult.Abort)
                    {
                        break;
                    }
                    if (result == DialogResult.OK)
                    {
                        if (form.ConnectionName.Trim() == "")
                        {
                            MessageBox.Show("Enter a valid Name");
                            continue;
                        }
                        try {
                            int test = Int32.Parse(form.Localport.ToString());
                            if (test < 1 || test > 65535) {
                                MessageBox.Show("Enter a valid local port between 1 and 65535");
                                continue;
                            }
                        }catch(Exception){
                            MessageBox.Show("Enter a valid local port between 1 and 65535");
                            continue;
                        }


                        if (form.ct.ToString() == ConnectionType.HTTP.ToString())
                        {
                            ct = ConnectionType.HTTP;
                        }
                        else
                        {
                            if (form.ct.ToString() == ConnectionType.SOCKS.ToString())
                            {
                                ct = ConnectionType.SOCKS;
                            }
                            else
                            {

                                if (form.ct.ToString() == ConnectionType.FORWARDING.ToString())
                                {
                                    ct = ConnectionType.FORWARDING;
                                    if (form.Remotehost.Trim() == "") {
                                        MessageBox.Show("Enter a valid hostname or IP");
                                        continue;
                                    }
                                    try
                                    {
                                        int test = Int32.Parse(form.Remoteport.ToString());
                                        if (test < 1 || test > 65535)
                                        {
                                            MessageBox.Show("Enter a valid remote port between 1 and 65535");
                                            continue;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Enter a valid remote port between 1 and 65535");
                                        continue;
                                    }



                                }
                                else
                                {

                                    ct = ConnectionType.SOCKS;
                                }
                            }

                        }
                        string rh = form.Remotehost;
                        int rp = form.Remoteport;
                        if (ct.ToString() != ConnectionType.FORWARDING.ToString())
                        {
                            rh = "";
                            rp = 0;
                        }
                        Connection tmpconnection = new Connection(form.ConnectionName, form.Hostname, form.Port, form.Localport, ct, rh, rp);
                        tmpconnection.Serialize();

                        Core.Instance().Refresh();
                        this.UpdateConnections();
                        break;
                    }
                }
            }
            this.UpdateConnections();
        }

        private void buttonDeleteConnection_Click(object sender, EventArgs e)
        {
            if (this.selectedConnection != null)
            {
                if(this.selectedConnection.IsOpen){
                    MessageBox.Show(this, "Connection " + this.selectedConnection.Name + " is active!\nDisconnect first.", "Warning");
                    return;
                }
                if (MessageBox.Show(this, "Are you sure you want to delete " + this.selectedConnection.Name + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.selectedConnection.Delete();
                    this.connections.SelectedItems.Clear();

                    SwitchConnection(this, null);

                    Core.Instance().Refresh();
                    this.UpdateConnections();
                }
            }
         
        }

       /* private void storeTunnelsSeparate_Click(object sender, EventArgs e)
        {
            if (this.selectedConnection != null)
            {
                if (!this.storeTunnelsSeparate.Checked)
                {
                    DialogResult result = MessageBox.Show("All tunnels in " + this.selectedConnection.Name + " will be copied from PuTTY to " + Application.ProductName + ". Do you want to remove these tunnels from PuTTY afterwards?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            this.selectedConnection.UsePtmForTunnels = true;
                            this.selectedConnection.RemovePuttyTunnels();
                            break;
                        case DialogResult.No:
                            this.selectedConnection.UsePtmForTunnels = true;
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("All tunnels in " + this.selectedConnection.Name + " will be removed from " + Application.ProductName + ". Do you want to copy all these tunnels from " + Application.ProductName + " to PuTTY first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            this.selectedConnection.UsePtmForTunnels = false;
                            this.selectedConnection.MergeBackPuttyTunnels();
                            break;
                        case DialogResult.No:
                            this.selectedConnection.UsePtmForTunnels = false;
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }

                this.storeTunnelsSeparate.Checked = this.selectedConnection.UsePtmForTunnels;
                this.selectedConnection.Serialize();

                this.SwitchConnection(this, null);
            }
        }
        */
        private void Field_Leave(object sender, EventArgs e)
        {
            if (this.selectedConnection != null)
            {
                if (sender == this.servers)
                {
                    this.selectedConnection.Hostname = this.servers.SelectedText;
                    this.UpdateConnections();
                    
                }
                
                else if (sender == this.autoconnect)
                {
                    this.selectedConnection.Autoconnect = this.autoconnect.Checked;
                }
                else if (sender == this.autoreconnect)
                {
                    this.selectedConnection.Autoreconnect = this.autoreconnect.Checked;
                }
                // else if (sender == this.port)
                //    this.selectedConnection.Port = Int32.Parse(this.port.Text);
                //  else if (sender == this.username)
                //  {
                else if (sender == this.username)
                {
                    Core.Instance().username = this.username.Text;
                    Core.Instance().storeCreds();
                }
                else if (sender == this.password)
                {
                    Core.Instance().password = this.password.Text;
                    Core.Instance().storeCreds();
                }
                else if (sender == this.storepassword)
                {
                    Core.Instance().storepassword = this.storepassword.Checked;
                    Core.Instance().storeCreds();
                }
                else if (sender == this.connectionType)
                {

                    ConnectionType ct = ConnectionType.SOCKS;
                    if (this.connectionType.SelectedText.ToString() == ConnectionType.HTTP.ToString())
                    {
                        ct = ConnectionType.HTTP;
                    }
                    else
                    {
                        if (this.connectionType.SelectedText.ToString() == ConnectionType.SOCKS.ToString())
                        {
                            ct = ConnectionType.SOCKS;
                        }
                        else
                        {
                            if (this.connectionType.SelectedText.ToString() == ConnectionType.FORWARDING.ToString())
                            {
                                ct = ConnectionType.FORWARDING;
                            }
                            else
                            {
                                ct = ConnectionType.SOCKS;
                            }
                        }
                    }
                    this.selectedConnection.ConnectionType = ct;
                    this.UpdateConnections();

                    //  else if (sender == this.localPortsAcceptAll)
                    // {
                    //    this.selectedConnection.LocalPortsAcceptAll = this.localPortsAcceptAll.Checked;
                    // }
                }
                else if (sender == this.localPortTextBox)
                {
                    this.selectedConnection.LocalPort = Int32.Parse(this.localPortTextBox.Text);
                    this.UpdateConnections();
                }
                else if (sender == this.remotePortTextBox)
                {
                    this.selectedConnection.RemotePort = Int32.Parse(this.remotePortTextBox.Text);
                    this.UpdateConnections();
                }
                else if (sender == this.remoteHostTextBox)
                {
                    this.selectedConnection.RemoteHost = this.remoteHostTextBox.Text;
                    this.UpdateConnections();
                }
                else if (sender == this.connectionName)
                {
                    string newname =  this.connectionName.Text.Trim();
                    string oldname = this.selectedConnection.Name;
                    if(newname == oldname){
                        return;
                    }
                    if (newname == "") {
                        MessageBox.Show("Enter a valid session name");
                    } else {
                        foreach (Connection connection in Core.Instance().Connections)
                        {
                            if (connection.Name == newname)
                            {
                                MessageBox.Show(this, "A connection with this name already exists. Please choose another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.connectionName.Focus();
                            return;
                            }
                        }
                        
                      
                        this.selectedConnection.Name = newname;
                        this.selectedConnection.Serialize();
                        if (oldname.ToLower() != this.selectedConnection.Name.ToLower())
                        {
                            Registry.CurrentUser.DeleteSubKey(PPSettings.PP_REGISTRY_KEYPATH_CONNECTIONS + @"\" + Uri.EscapeUriString(oldname));
                        }

                        Core.Instance().Refresh();
                        this.UpdateConnections();
                    }
                    return;
                }
                

            

                this.selectedConnection.Serialize();
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Field_Leave(this.ActiveControl, null);
        }

        private void storeTunnelsSeparate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void connectionName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void localPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
       
        private void password_TextChanged(object sender, EventArgs e)
        {
            Core.Instance().password = this.password.Text;
            Core.Instance().storeCreds();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            
            Core.Instance().username = this.username.Text;
            Core.Instance().storeCreds();
          
        }

        private void storepassword_CheckedChanged(object sender, EventArgs e)
        {
          
    
            Core.Instance().storepassword = this.storepassword.Checked;
            Core.Instance().storeCreds();
        }
       
        private void server_TextChanged(object sender, EventArgs e)
        {

        }

        private void servers_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.selectedConnection.Hostname = this.servers.SelectedItem.ToString().Trim(); 
          
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void localportTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int port = FormUtils.ValidatePortTextBox(sender, e);
                if (port > 0 && port < 65536)
                {
                    if (!e.Cancel)
                        this.localPortTextBox.Text = "" + port;
                    this.selectedConnection.LocalPort = Int32.Parse(this.localPortTextBox.Text);
                    this.UpdateConnections();
                }
                else {

                    MessageBox.Show("Enter a valid port number. ");
                    try
                    {
                        this.localPortTextBox.Text = this.selectedConnection.LocalPort + "";
                    }
                    catch (Exception)
                    {
                        this.localPortTextBox.Text = "5080";
                    }
                
                }
            }catch(Exception){
                MessageBox.Show("Enter a valid port number.");
                try
                {
                    this.localPortTextBox.Text = this.selectedConnection.LocalPort+"";
                }
                catch (Exception) {                  
                    this.localPortTextBox.Text = "5080";
                }
              
            }
        }

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           string newname = FormUtils.ValidateTextField(sender, e);
        }


        private void remoteportTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int port = FormUtils.ValidatePortTextBox(sender, e);
                if (port > 0 && port < 65536)
                {
                    if (!e.Cancel)
                        this.remotePortTextBox.Text = "" + port;
                    this.selectedConnection.RemotePort = Int32.Parse(this.remotePortTextBox.Text);
                    this.UpdateConnections();
                }
                else
                {

                    MessageBox.Show("Enter a valid port number. ");
                    try
                    {
                        this.remotePortTextBox.Text = this.selectedConnection.RemotePort + "";
                    }
                    catch (Exception)
                    {
                        this.remotePortTextBox.Text = "3128";
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a valid port number.");
                try
                {
                    this.remotePortTextBox.Text = this.selectedConnection.RemotePort + "";
                }
                catch (Exception)
                {
                    this.remotePortTextBox.Text = "3128";
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Connection connection = getSelectedConnection();
            this.ConnectButton.Enabled = false;
            if (connection.IsOpen)
            {
                connection.Close();
                if (this.ConnectButton.Text == "Disconnect") {
                    this.ConnectButton.Enabled = true;
                    return;
                }
            }
            else
            {
                try
                {
                    connection.Open();
               
                }
                catch (ConnectionAlreadyOpenException)
                {
                    MessageBox.Show("Connection already open.");
                }
                catch (PortAlreadyInUseException ex)
                {
                    MessageBox.Show("Cannot start " + ex.Connection.Name + ". Port " + ex.Connection.LocalPort + " is already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (PlinkNotFoundException)
                {
                    MessageBox.Show("Could not find plink.exe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            System.Threading.Thread.Sleep(500);
            UpdateConnections();

            this.ConnectButton.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }








        public HttpWebResponse response { get; set; }
    }
}
