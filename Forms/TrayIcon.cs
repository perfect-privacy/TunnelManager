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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PerfectPrivacy.SSHManager.Forms
{
    public partial class TrayIcon : Form
    {
        public SettingsForm settingsForm;
        private TipForm tipForm;
        private AboutForm aboutForm;

        public TrayIcon()
        {
            InitializeComponent();
            this.settingsForm = new SettingsForm();
            this.tipForm = new TipForm();
            this.aboutForm = new AboutForm();
            //this.showSettings();
        }

        public void UpdateConnections()
        {
            if (!sshManagerSettings.Instance().HasPlink)
                return;
            
            while (this.contextMenuStrip.Items[0].GetType() != typeof(ToolStripSeparator))
            {
                this.contextMenuStrip.Items.RemoveAt(0);
            }
            foreach (Connection connection in Core.Instance().Connections)
            {
                ToolStripMenuItem connectionItem = new ToolStripMenuItem(connection.Name);
                this.contextMenuStrip.Items.Insert(0, connectionItem);
                  
                connectionItem.Tag = connection;
                connectionItem.Click += new EventHandler(MenuConnection_Click);

                if (connection.IsOpen)
                    connectionItem.Checked = true;
            }
        }

        private void MenuConnection_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem connectionItem = sender as ToolStripMenuItem;
            Connection connection = connectionItem.Tag as Connection;

            if (connection.IsOpen)
            {
                connection.Close();
                connectionItem.Checked = false;
            }
            else
            {
                try
                {
                    connection.Open();
                    connectionItem.Checked = true;
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
                    MessageBox.Show("Could not find pplink.exe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            for (int i = Connection.OpenConnections.Count - 1; i > -1; i--)
            {
                Connection.OpenConnections[i].Close();
            }

            this.Dispose(true);
            Application.Exit();
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            this.showSettings();
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.settingsForm.Visible)
                {
                    this.settingsForm.BringToFront();
                    this.settingsForm.Focus();
                    this.settingsForm.Activate();
                }
                else
                {
                    if (!this.tipForm.Visible && Connection.OpenConnections.Count > 0)
                    {
                        this.tipForm.ShowDialog();
                    }
                }
            }
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {
            this.UpdateConnections();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.showSettings();
        }

        public void showSettings()
        {

            if (this.tipForm.Visible)
            {
                this.tipForm.Close();    
            }

            if (!this.settingsForm.Visible)
            {
                this.settingsForm.ShowDialog();
            }
            else { 
                this.settingsForm.BringToFront();
                this.settingsForm.Focus();
                this.settingsForm.Activate();
            }
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            if (!this.aboutForm.Visible)
                this.aboutForm.ShowDialog();
        }
    }
}
