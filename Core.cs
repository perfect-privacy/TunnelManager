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
using System.Collections.Generic;
using System;
using Microsoft.Win32;
//using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace PerfectPrivacy.PPTunnelManager
{

    public class RequestManager
    {
        public string LastResponse { protected set; get; }

        CookieContainer cookies = new CookieContainer();

        internal string GetCookieValue(Uri SiteUri, string name)
        {
            Cookie cookie = cookies.GetCookies(SiteUri)[name];
            return (cookie == null) ? null : cookie.Value;
        }

        public string GetResponseContent(HttpWebResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }
            Stream dataStream = null;
            StreamReader reader = null;
            string responseFromServer = null;

            try
            {
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
                // Cleanup the streams and the response.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (dataStream != null)
                {
                    dataStream.Close();
                }
                response.Close();
            }
            LastResponse = responseFromServer;
            return responseFromServer;
        }

        public HttpWebResponse SendPOSTRequest(string uri, string content, string login, string password, bool allowAutoRedirect)
        {
            HttpWebRequest request = GeneratePOSTRequest(uri, content, login, password, allowAutoRedirect);
            return GetResponse(request);
        }

        public HttpWebResponse SendGETRequest(string uri, string login, string password, bool allowAutoRedirect)
        {
            HttpWebRequest request = GenerateGETRequest(uri, login, password, allowAutoRedirect);
            return GetResponse(request);
        }

        public HttpWebResponse SendRequest(string uri, string content, string method, string login, string password, bool allowAutoRedirect)
        {
            HttpWebRequest request = GenerateRequest(uri, content, method, login, password, allowAutoRedirect);
            return GetResponse(request);
        }

        public HttpWebRequest GenerateGETRequest(string uri, string login, string password, bool allowAutoRedirect)
        {
            return GenerateRequest(uri, null, "GET", null, null, allowAutoRedirect);
        }

        public HttpWebRequest GeneratePOSTRequest(string uri, string content, string login, string password, bool allowAutoRedirect)
        {
            return GenerateRequest(uri, content, "POST", null, null, allowAutoRedirect);
        }

        internal HttpWebRequest GenerateRequest(string uri, string content, string method, string login, string password, bool allowAutoRedirect)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            // Create a request using a URL that can receive a post. 
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            // Set the Method property of the request to POST.
            request.Method = method;
            // Set cookie container to maintain cookies
            request.CookieContainer = cookies;
            request.AllowAutoRedirect = allowAutoRedirect;
            // If login is empty use defaul credentials
            if (string.IsNullOrEmpty(login))
            {
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
            }
            else
            {
                request.Credentials = new NetworkCredential(login, password);
            }
            if (method == "POST")
            {
                // Convert POST data to a byte array.
                byte[] byteArray = Encoding.UTF8.GetBytes(content);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
            }
            return request;
        }

        internal HttpWebResponse GetResponse(HttpWebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                cookies.Add(response.Cookies);
                // Print the properties of each cookie.
                Console.WriteLine("\nCookies: ");
                foreach (Cookie cook in cookies.GetCookies(request.RequestUri))
                {
                    Console.WriteLine("Domain: {0}, String: {1}", cook.Domain, cook.ToString());
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Web exception occurred. Status code: {0}", ex.Status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

    }



    class Core
    {
      
        private static Core instance = null;
        public static RequestManager RM = null;
        public static Connection EmptyConnection = new EmptyConnection();

        public Dictionary<string, Dictionary<string, string>> servers = new Dictionary<string, Dictionary<string, string>>();
       
        static readonly object _locker = new object();
            
        public string username = "";
        public string password = "";
        public bool storepassword = false;

        public static Core Instance()
        {
            if (Core.instance == null)
                Core.instance = new Core();
       
            return Core.instance;
        }

        private List<Connection> connections;


        public void setCreds(string _username, string _password, bool _storepassword)
        {
         
            this.username = _username;
            this.password = _password;
            this.storepassword = _storepassword;
            this.storeCreds();
        }

        public void storeCreds() {
            RegistryKey ppCredentialsKey = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_CREDENTIALS);
            ppCredentialsKey.SetValue(PPSettings.PP_REGISTRY_KEY_USERNAME, this.username, RegistryValueKind.String);
       
            if (this.storepassword == false)
            {
              
                ppCredentialsKey.SetValue(PPSettings.PP_REGISTRY_KEY_PASSWORD, "", RegistryValueKind.String); 
            }
            else {
                ppCredentialsKey.SetValue(PPSettings.PP_REGISTRY_KEY_PASSWORD, this.password, RegistryValueKind.String); 
            }

            ppCredentialsKey.SetValue(PPSettings.PP_REGISTRY_KEY_STOREPASSWORD, this.storepassword, RegistryValueKind.DWord);
            ppCredentialsKey.Close();
        }


        public void loadCreds()
        {

            RegistryKey ppCredentialsKey = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_CREDENTIALS);
            this.username = ppCredentialsKey.GetValue(PPSettings.PP_REGISTRY_KEY_USERNAME, "").ToString();
            string tmp_password = ppCredentialsKey.GetValue(PPSettings.PP_REGISTRY_KEY_PASSWORD, "").ToString();
            this.storepassword = ppCredentialsKey.GetValue(PPSettings.PP_REGISTRY_KEY_STOREPASSWORD, 0).Equals(1);
            if (this.storepassword == true)
            {
                this.password = tmp_password;
            }
          
        }

        public void loadServers() {
            servers = new Dictionary<string, Dictionary<string, string>>();
            
            RegistryKey servernamesKeyPath = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_SSH_HOST_KEYS);
            long version = Convert.ToInt32(servernamesKeyPath.GetValue(PPSettings.PP_REGISTRY_KEY_SERVERVERSION, 0).ToString());

            string[] servernames = servernamesKeyPath.GetSubKeyNames();
            foreach (string servername in servernames)
            {
                string serverkeypath = PPSettings.PP_REGISTRY_KEYPATH_SSH_HOST_KEYS + @"\" + Uri.EscapeUriString(servername);
                RegistryKey serverkey = Registry.CurrentUser.CreateSubKey(serverkeypath);
                int _serverversion = Convert.ToInt32(serverkey.GetValue(PPSettings.PP_REGISTRY_KEY_SERVERVERSION, 0).ToString());
                if (_serverversion != version){
                    continue;
                 
                }
                String _servername = serverkey.GetValue(PPSettings.PP_REGISTRY_KEY_SERVERNAME, "").ToString();
                String _fingerprint = serverkey.GetValue(PPSettings.PP_REGISTRY_KEY_FINGERPRINT, "").ToString();
                
                var ht = new Dictionary<string, string>();
                ht["servername"] = servername.Trim();
                ht["fingerprint"] = _fingerprint.Trim(); ;
                String id = "" + servername.Trim();
                servers[id] = ht;
              
            }
      
        }




        private Core()
        {
            this.connections = new List<Connection>();
            this.rm = new RequestManager();

            Initialize();
        }

        

        public void Refresh()
        {
            lock (_locker);
            List<string> currentconnections = new List<string>();
            foreach(Connection connection in this.connections){
                currentconnections.Add(connection.Name);
            }

            List<string> newconnections = new List<string>();
            foreach (string connectionName in PPSettings.Instance().Connections)
            {
                string  connectionName1 = Uri.UnescapeDataString(connectionName);
                newconnections.Add(connectionName1);
                if (currentconnections.Contains(connectionName1))
                {
                    // connection loaded
                } else { 
                    // not loaded/ nach add z.b.
                    this.connections.Add(Connection.Load(connectionName1));
                } 
            }
            List<Connection> toremove = new List<Connection>();
            foreach (Connection connection in this.connections)
            {
                if (newconnections.Contains(connection.Name))
                {
                    // keep connection
                }
                else { 
                    //del connection
                    
                    toremove.Add(connection);
                }
            }
            foreach (Connection removeme in toremove) {
                this.connections.Remove(removeme);
            }
            


            //this.connections.Clear();
           
            //Initialize();
        }

        private void Initialize()
        {
            loadCreds();
            loadServers();
            rm = new RequestManager();

            foreach (string connectionName in PPSettings.Instance().Connections)
            {
                Connection thisconnection = Connection.Load(connectionName);
                this.connections.Add(thisconnection);

            }
     
            
         
        }

        public void autoConnect() {

            foreach (Connection connection in this.connections)
            {
                if (connection.Autoconnect == true)
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
            }
        }

        public List<Connection> Connections
        {
            get { return this.connections; }
        }

        public string Username
        {
            get { return username; }
            set { this.Username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Dictionary<string, Dictionary<string, string>> Servers
        {
            get { return servers; }
            set { servers = value; }
        }

        public RequestManager rm
        {
            get { return RM; }
            set { RM = value; }
        }
        public bool Storepassword
        {
            get { return storepassword; }
            set { storepassword = value; }
        }

        /*   public List<Tunnel> Tunnels
           {
               get
               {
                   List<Tunnel> tunnels = new List<Tunnel>();
                   foreach (Connection connection in this.Connections)
                   {
                       foreach (Tunnel tunnel in connection.Tunnels)
                       {
                           tunnels.Add(tunnel);
                       }
                   }
                   return tunnels;
               }
           }*/
    }
}
