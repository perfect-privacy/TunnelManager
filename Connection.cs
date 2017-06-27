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
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using Microsoft.Win32;
public enum ConnectionType
{
    SOCKS,
    HTTP,
    FORWARDING
}
namespace PerfectPrivacy.SSHManager
{
    class Connection
    {
        public static string PP_REGISTRY_KEY_CONNECTION_HOSTNAME            = "HostName";
        public static string PP_REGISTRY_KEY_CONNECTION_PORTFORWARDINGS     = "PortForwardings";
       
        public static string PP_REGISTRY_KEY_CONNECTION_PORTNUMBER          = "PortNumber";
        public static string PP_REGISTRY_KEY_CONNECTION_COMPRESSION         = "Compression";
        public static string PP_REGISTRY_KEY_CONNECTION_AUTOCONNECT = "Autoconnect";
        public static string PP_REGISTRY_KEY_CONNECTION_AUTORECONNECT = "Autoreconnect";
        public static string PP_REGISTRY_KEY_CONNECTION_LOCALPORTACCEPTALL  = "LocalPortAcceptAll";
        public static string PP_REGISTRY_KEY_CONNECTION_LOCALPORT = "LocalPort";
        public static string PP_REGISTRY_KEY_CONNECTION_REMOTEPORT = "RemotePort";
        public static string PP_REGISTRY_KEY_CONNECTION_REMOTEHOST = "RemoteHost";
        public static string PP_REGISTRY_KEY_CONNECTION_TYPE = "ConnectionType";
  
        private string name;
        private string hostname;
        private string servername;
        private int localport;
        private int remoteport;
        private string remotehost;



        private ConnectionType connectionType;

        private int port;
        private bool compression;
        private bool localPortsAcceptAll;
        private bool autoconnect;
        private bool autoreconnect;
        private PuttyLink puttyLink;

        private bool resume;

        public static List<Connection> OpenConnections = new List<Connection>();

        public Connection(string name, string hostname, int port,int localport,ConnectionType ct,string remotehost,int remoteport)
        {
            this.name = name;
            this.hostname = hostname.Trim(); 

            this.port = 22;
            this.compression = false;
            this.autoconnect = false;
            this.autoreconnect = false;
            this.localPortsAcceptAll = false;
        
            this.puttyLink = null;

            this.resume = false;
            this.connectionType = ct;
            this.localport = localport;
            this.remotehost = remotehost;
            this.remoteport = remoteport;
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
         
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend && this.IsOpen)
            {
                this.resume = true;
                this.Close();
            }
            else if (e.Mode == PowerModes.Resume && this.resume)
            {
                this.resume = false;
                for (int i = 0; i < 5; i++) { 
                    Thread.Sleep(2000);
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
                        Thread.Sleep(2000);
                        break;
                    }
                }
                    
                this.Open();
            }
        }

        public string PuttyKeyPath
        {
            get { return PPSettings.PP_REGISTRY_KEYPATH_CONNECTIONS + @"\" + Uri.EscapeUriString(this.name); }
        }

        public string PuttyTunnelManagerKeyPath
        {
            get { return PPSettings.PP_REGISTRY_KEYPATH_ROOT + @"\" + Uri.EscapeUriString(name); }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Hostname
        {
            get { return this.hostname; }
            set { this.hostname = value; }
        }
        public string Servername
        {
            get { return this.servername; }
            set { this.servername = value; }
        }

        public int Port
        {
            get { return this.port; }
            set { this.port = value; }
        }

        public bool Compression
        {
            get { return this.compression; }
            set { this.compression = value; }
        }
        public bool Autoconnect
        {
            get { return this.autoconnect; }
            set { this.autoconnect = value; }
        }
        public bool Autoreconnect
        {
            get { return this.autoreconnect; }
            set { this.autoreconnect = value; }
        }
        public int LocalPort
        {
            get { return this.localport; }
            set { this.localport = value; }
        }

        public ConnectionType ConnectionType
        {
            get { return this.connectionType; }
            set { this.connectionType = value; }
        }

        public bool LocalPortsAcceptAll
        {
            get { return this.localPortsAcceptAll; }
            set { this.localPortsAcceptAll = value; }
        }

        public string RemoteHost
        {
            get { return this.remotehost; }
            set { this.remotehost = value; }
        }

        public int RemotePort
        {
            get { return this.remoteport; }
            set { this.remoteport = value; }
        }
 

        public bool IsOpen
        { 
            get { return (this.puttyLink != null && this.puttyLink.IsActive); }
        }

        public virtual void Close()
        {
            if (this.IsOpen)
                this.puttyLink.Stop();

            this.puttyLink = null;
        }

        public virtual void Open()
        {
          
                if (this.IsOpen)
                    throw new ConnectionAlreadyOpenException();

                    IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                    IPEndPoint[] ipEndPoints = ipGlobalProperties.GetActiveTcpListeners();

                    foreach (IPEndPoint ipEndPoint in ipEndPoints)
                    {
                        if (ipEndPoint.Port == this.localport)
                        {
                            throw new PortAlreadyInUseException(this);
                        }
                    }
           
                this.puttyLink = new PuttyLink(this);
                Thread thread = new Thread(new ThreadStart(this.puttyLink.Start));
                thread.IsBackground = true;
                thread.Start();

        }

        public virtual void Serialize()
        { 
            RegistryKey rootkey = Registry.CurrentUser.CreateSubKey(this.PuttyKeyPath);

            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_HOSTNAME, this.hostname, RegistryValueKind.String);
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_PORTNUMBER, this.port, RegistryValueKind.DWord);

            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_COMPRESSION, this.compression, RegistryValueKind.DWord);
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_AUTOCONNECT, this.autoconnect, RegistryValueKind.DWord);
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_AUTORECONNECT, this.autoreconnect, RegistryValueKind.DWord);
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_LOCALPORTACCEPTALL, this.localPortsAcceptAll, RegistryValueKind.DWord);
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_LOCALPORT, this.localport, RegistryValueKind.DWord);
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_REMOTEPORT, this.remoteport, RegistryValueKind.DWord);
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_REMOTEHOST, this.remotehost, RegistryValueKind.String);
    
            rootkey.SetValue(PP_REGISTRY_KEY_CONNECTION_TYPE,this.connectionType.ToString(), RegistryValueKind.String);

            rootkey.Close();
        }

        public static Connection Load(string keyName)
        {
            keyName = Uri.UnescapeDataString(keyName);
            string puttyKeyPath = PPSettings.PP_REGISTRY_KEYPATH_CONNECTIONS + @"\" + Uri.EscapeUriString(keyName); ;
            RegistryKey rootkey = Registry.CurrentUser.OpenSubKey(puttyKeyPath);



            ConnectionType ct = ConnectionType.SOCKS;
            if (rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_TYPE, ConnectionType.SOCKS).ToString() == ConnectionType.SOCKS.ToString())
            {
                 ct = ConnectionType.SOCKS;
            }else{
                if (rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_TYPE, ConnectionType.HTTP).ToString() == ConnectionType.HTTP.ToString())
                {
                     ct = ConnectionType.HTTP;
                } else {
                    if (rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_TYPE, ConnectionType.FORWARDING).ToString() == ConnectionType.FORWARDING.ToString())
                    {
                        ct = ConnectionType.FORWARDING;
                    }
                    else
                    {
                        ct = ConnectionType.SOCKS;
                    }
                }

                
            }
            Connection connection = new Connection(
                Uri.UnescapeDataString(keyName),
                rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_HOSTNAME, "").ToString(),
                Int32.Parse(rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_PORTNUMBER, "22").ToString()),
                Int32.Parse(rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_LOCALPORT, "8050").ToString()),
                ct,
                rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_REMOTEHOST, "").ToString(),
                Int32.Parse(rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_REMOTEPORT, "3128").ToString())
            );

            connection.Compression = rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_COMPRESSION, 0).Equals(1);
            connection.autoconnect = rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_AUTOCONNECT, 0).Equals(1);
            connection.autoreconnect = rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_AUTORECONNECT, 0).Equals(1);
            connection.LocalPortsAcceptAll = rootkey.GetValue(PP_REGISTRY_KEY_CONNECTION_LOCALPORTACCEPTALL, 0).Equals(1);

            return connection;
        }

        public virtual void Delete()
        {
            try
            {
                if (this.IsOpen)
                    this.Close();

                Registry.CurrentUser.DeleteSubKey(this.PuttyKeyPath);
                Registry.CurrentUser.DeleteSubKey(this.PuttyTunnelManagerKeyPath);
            }
            catch (Exception) { }
        }
      
    }
}
