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
using System.Text;
using System.Windows.Forms;

namespace PerfectPrivacy.PPTunnelManager.Forms
{
    public partial class AddConnectionForm : Form
    {
        private int port;

        private int localport;
        private int remoteport;
  
 
        public AddConnectionForm()
        {
            InitializeComponent();
            this.servers.Items.Clear();
            Dictionary<string, Dictionary<string, string>> servers = Core.Instance().servers;
            foreach (string key in servers.Keys)
            {
                Dictionary<string, string> server = servers[key];
           
                this.servers.Items.Add(" " + server["servername"].ToString());
            }
            this.connectionTypeSelect.Items.Add(ConnectionType.SOCKS.ToString());
            this.connectionTypeSelect.Items.Add(ConnectionType.HTTP.ToString());
            this.connectionTypeSelect.Items.Add(ConnectionType.FORWARDING.ToString());
            this.port = 22;
            this.remoteport = 0;
           
            this.remotePortTextBox.Visible = false;
            this.remoteHostTextBox.Visible = false;
            this.portlabel.Visible = false;
            this.tolabel.Visible = false;
            this.connectionTypeSelect.SelectedIndex = 0;
            this.servers.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            foreach (Connection connection in Core.Instance().Connections)
            {
                if (connection.Name.Equals(this.ConnectionName))
                {
                    MessageBox.Show(this, "A connection with this name already exists. Please choose another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.connectionNameTexBox.Focus();

                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string ConnectionName
        {
            get { return this.connectionNameTexBox.Text; }
        }

        public string Hostname
        {
            get { return this.servers.SelectedItem.ToString(); }
        }

        public int Port
        {
            get { return port; }
        }
        public int Localport
        {
            get { return this.localport; }
        }
        public int Remoteport
        {
            get { return this.remoteport; }
        }
        public string Remotehost
        {
            get { return this.remoteHostTextBox.Text ; }
        }

        public string ct
        {
            get { return this.connectionTypeSelect.SelectedItem.ToString(); }
        }

        private void localportTextBox_Validating(object sender, CancelEventArgs e)
        {
            int localport = FormUtils.ValidatePortTextBox(sender, e);

            if (!e.Cancel)
                this.localport = localport;
        }
        private void remoteportTextBox_Validating(object sender, CancelEventArgs e)
        {
            int remoteport = FormUtils.ValidatePortTextBox(sender, e);

            if (!e.Cancel)
                this.remoteport = remoteport;
        }

        private void connectionNameTexBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectionTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.connectionTypeSelect.SelectedItem.ToString() == ConnectionType.FORWARDING.ToString()){
                this.remotePortTextBox.Visible = true;
                this.remoteHostTextBox.Visible = true;
                this.portlabel.Visible = true;
                this.tolabel.Visible = true;
            }else{
                this.remotePortTextBox.Visible = false;
                this.remoteHostTextBox.Visible = false;
                this.portlabel.Visible = false;
                this.tolabel.Visible = false;
            }
        }

      
    }
}
