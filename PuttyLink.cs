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
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using PerfectPrivacy.PPTunnelManager.Forms;

namespace PerfectPrivacy.PPTunnelManager
{
    class PuttyLink
    {
        private Connection connection;
        private Process process;
        private Thread guardian;
        private bool active;
        private StringBuilder debuglog;
        private bool shouldbeactive;
      
        public PuttyLink(Connection connection)
        {
            this.shouldbeactive = false;
            this.connection = connection;
            this.debuglog = new StringBuilder();
            this.active = false;
           
           
        }

        public void setup()
        {
            this.process = new Process();
            this.process.StartInfo.FileName = PPTunnelManagerSettings.Instance().PlinkLocation;

            this.debuglog.AppendLine(this.process.StartInfo.FileName);
            this.process.StartInfo.CreateNoWindow = true;
            this.process.StartInfo.UseShellExecute = false;

            this.guardian = new Thread(Guardian);
            this.guardian.IsBackground = true;
            this.guardian.Priority = ThreadPriority.Lowest;

           
        }

        public Connection Connection
        {
            get { return this.connection; }
        }

        public bool IsActive
        {
            get { return this.active; }
        }


        public void Start()
        {
            do
            {
            
                this.setup();
              
                if (this.Start(true)  == false){
                    break;
                } 
            
            } while (this.connection.Autoreconnect == true && this.shouldbeactive == true);
        }
        public long UnixTimeNow()
        {
            TimeSpan _TimeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_TimeSpan.TotalSeconds;
        }
        public bool Start(bool interactive)
        {
            if (!PPTunnelManagerSettings.Instance().HasPlink)
            {
                throw new PlinkNotFoundException();
            }

            while (Core.Instance().password.ToString().Length <= 3)
            {
                LoginForm form = new LoginForm();
                form.Username = Core.Instance().username;
                form.Password = Core.Instance().Password;
                form.Storepassword = Core.Instance().storepassword;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.Password.Length <= 3 || form.Username.Length < 1)
                    {
                        MessageBox.Show("This is not a valid Perfect-Privacy username/password combination (to short) ");
                    }
                    else { 
                        Core.Instance().setCreds(form.Username, form.Password, form.Storepassword);
                    }
                }
                else{
                    Stop();
                    return false;
                }
            }


            this.active = true;
            Connection.OpenConnections.Add(this.connection);

            StringBuilder args = new StringBuilder(" -ssh -batch -4 -noagent -N -T -x   ");

            Dictionary<string, Dictionary<string, string>> servers = Core.Instance().servers;
            Dictionary<string, string> server = null;
            try
            {
                server = servers[this.connection.Hostname];
            }catch(Exception){
                MessageBox.Show("Server " + this.connection.Hostname  + " not found or not available");
                Connection.OpenConnections.Remove(this.connection);
                this.active = false;
                return false;
            }
            this.shouldbeactive = true;
            if (connection.LocalPortsAcceptAll == true)
            {
                args.Append(" -all -a ");
            }
            else {
                args.Append(" -a ");
            }
            args.Append(" -l \"" + Core.Instance().username + "\"  ");
            args.Append(" -pw \"" + Core.Instance().password + "\"  ");
            args.Append(" -F \"ssh-rsa 2048 " + server["fingerprint"] + "\"  ");
            if (interactive)
            {
                this.process.StartInfo.RedirectStandardOutput = true;
                this.process.StartInfo.RedirectStandardInput = true;
                this.process.StartInfo.RedirectStandardError = true;
            }

    
            if(connection.ConnectionType == ConnectionType.SOCKS){
                args.Append(" -D " + connection.LocalPort);
            }else{
                if (connection.ConnectionType == ConnectionType.HTTP)
                {
                    args.Append(" -L " + connection.LocalPort + ":" + "127.0.0.1" + ":" + "3128");
                }
                else {
                    if (connection.ConnectionType == ConnectionType.FORWARDING)
                    {
                        string rh = connection.RemoteHost.Trim().ToLower();
                        if(rh == "localhost"){
                            rh = "127.0.0.1";
                        }
                        args.Append(" -L " + connection.LocalPort + ":" + connection.RemoteHost+ ":" + connection.RemotePort);
                    }
                
                }
                

            }

            args.Append(" " + this.connection.Hostname + " ");

            Core.Instance().Refresh();
            Program.TrayIcon.settingsForm.UpdateConnections();


            this.debuglog.AppendLine(args.ToString());
            this.process.StartInfo.Arguments = args.ToString();
            this.process.Start();
            
            this.debuglog.AppendLine("Plink: Started!");
            long starttime = UnixTimeNow();
            this.guardian.Start();

            this.debuglog.AppendLine("Plink: Starting Guardian!");
            this.debuglog.AppendLine("Plink Output:");


            if (interactive)
            {
                this.process.StandardInput.AutoFlush = true;

                StringBuilder buffer = new StringBuilder();
                string username = Core.Instance().Username;

                while (!this.process.HasExited)
                {
                    while (this.process.StandardOutput.Peek() > 0)
                    {
                        char c = (char)this.process.StandardOutput.Read();
                        buffer.Append(c);
                    }
                    while (this.process.StandardError.Peek() > 0)
                    {
                        char c = (char)this.process.StandardError.Read();
                        buffer.Append(c);
                    }
                    string data = buffer.ToString();
                    this.debuglog.Append(data);
                    data = data.ToLower();
                    if (data.Contains("login"))
                    {
                        LoginForm form = new LoginForm();
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            Core.Instance().setCreds(form.Username, form.Password, form.Storepassword);
                            this.process.StandardInput.WriteLine(username);
                        }
                        else
                            Stop();
                    }
                    else if (data.Contains("password"))
                    {
                        this.process.StandardInput.WriteLine(Core.Instance().Password);
                    }
                    while (this.process.StandardOutput.Peek() > 0)
                    {
                        char c = (char)this.process.StandardOutput.Read();
                        buffer.Append(c);
                    }
                    while (this.process.StandardError.Peek() > 0)
                    {
                        char c = (char)this.process.StandardError.Read();
                        buffer.Append(c);
                    }
                    this.process.StandardOutput.DiscardBufferedData();
                    buffer.Remove(0, buffer.Length);
                }

                while (this.process.StandardOutput.Peek() > 0)
                {
                    char c = (char)this.process.StandardOutput.Read();
                    buffer.Append(c);
                }
                while (this.process.StandardError.Peek() > 0)
                {
                    char c = (char)this.process.StandardError.Read();
                    buffer.Append(c);
                }

                string data1 = buffer.ToString();

                this.debuglog.Append(data1);
            }
            else
            {

                this.process.WaitForExit();
            }
            Connection.OpenConnections.Remove(this.connection);
            this.active = false;
            this.debuglog.Append("Plink: Stopped!");
            long stoptime = UnixTimeNow();
            if (this.debuglog.ToString().IndexOf("Key verification failed") != -1)
            {
                if (Program.isXP == true)
                {
                    Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red_xp));
                }
                else
                {
                    Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red));
                }
                if (MessageBox.Show("Host key verification for Server " + this.connection.Hostname + " Failed!\n\nPlease update your Server list!\n Contact support@perfect-privacy.com if this problem persists.\n\n Do you want to see a debug log ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(this.debuglog.ToString());
                }
                resetTrayIcon();
                return false;
            }
            else
            {
                if (this.debuglog.ToString().IndexOf("Access denied") != -1)
                {
                    if (Program.isXP == true)
                    {
                        Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red_xp));
                    }
                    else
                    {
                        Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red));
                    }
                    MessageBox.Show("Login failed!\n\n Please make sure you have entered the correct username/password combination. \n\n Go to https://www.perfect-privacy.com and login to make sure your account did not expire");
                    resetTrayIcon();
                    return false;
                }
                else
                {
                    if (this.debuglog.ToString().IndexOf("Host does not exist") != -1 || this.debuglog.ToString().IndexOf("FATAL ERROR: Network error") != -1)
                    {
                        if (Program.isXP == true)
                        {
                            Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red_xp));
                        }
                        else
                        {
                            Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red));
                        }
                        if (this.connection.Autoconnect == false)
                        {
                            if (MessageBox.Show("Network error.\n Please check you internet connection and DNS settings.\n\n Do you want to see a debug log ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                MessageBox.Show(this.debuglog.ToString());
                            }
                            resetTrayIcon();
                            return false;
                        }
                        else
                        {

                            Thread.Sleep(1000);
                            resetTrayIcon();
                            return true;
                        }

                    }
                    else
                    {
                        if (stoptime - starttime < 20)
                        {
                            if (Program.isXP == true)
                            {
                                Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red_xp));
                            }
                            else
                            {
                                Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_red));
                            }
                            if (MessageBox.Show("Tunnel exited within 20 seconds!\n This may be wrong.\n\n Do you want to see a debug log ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                MessageBox.Show(this.debuglog.ToString());
                            }
                            resetTrayIcon();
                            return false;
                        }
                    }

                }
            }
            return true;
         
        }

        public void Stop()
        {
            this.shouldbeactive = false;
            Debug.WriteLine("Plink: Terminating!");
            try
            {
                this.process.Kill();
                Debug.WriteLine("Plink: Killed!");
            }
            catch (Exception) { }
        }


        private void resetTrayIcon() {
            
            bool activetunnel = false;
            foreach (Connection connection in Core.Instance().Connections)
            {
                
                
                    if (connection.IsOpen)
                        activetunnel = true;
              
            }
            if (activetunnel == true)
            {
                if (Program.isXP == true)
                {
                      Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_green_xp));
                }
                else
                {
                    Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_green));
                }
            }
            else {
                if (Program.isXP == true)
                {
                      Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_xp));
                }
                else
                {
                    Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon));
                }
            }
            Core.Instance().Refresh();
            Program.TrayIcon.settingsForm.UpdateConnections();
        }

        private void Guardian()
        {

            if (Program.isXP == true)
            {
                 Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_yellow_xp));
            }
            else
            {
                Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_yellow));
            }
            try
            {
                do
                {
                    Thread.Sleep(2000);
                    if (this.process.HasExited)
                    {
                        Debug.WriteLine("Guardian: Stopped due to Plink termination!");
                        resetTrayIcon();
                        return;
                    }
                    if (Program.isXP == true)
                    {
                         Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_green_xp));
                    }
                    else
                    {
                        Program.TrayIcon.notifyIcon.Icon = ((System.Drawing.Icon)(Properties.Resources.pp_icon_green));
                    }
                    Thread.Sleep(2000);
                    Debug.WriteLine("Guardian: Plink is alive!");

                } while (this.process.Responding);
                Debug.WriteLine("Guardian: Plink stopped responding!");
            }
            catch (Exception) { }
            finally
            {
                if (!this.process.HasExited)
                    Stop();
            }
            if(this.connection.Autoconnect == true){
                this.shouldbeactive = true;
            }
            Debug.WriteLine("Guardian: Stopped!");
            resetTrayIcon();
          
        }
    }
}
