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
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using PerfectPrivacy.SSHManager.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Resources;
namespace PerfectPrivacy.SSHManager
{
    using PerfectPrivacy.SSHManager.Forms;

    static class Program
    {
        public static TrayIcon TrayIcon;

        private static Mutex mutex;
      
        public static bool isXP = false;
        public static ResourceManager res = new ResourceManager("PerfectPrivacy.SSHManager.lang.strings", System.Reflection.Assembly.GetExecutingAssembly());

        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string exeName = fileInfo.Name;
            bool createdNew;

            mutex = new Mutex(true, "Global\\" + exeName, out createdNew);
            if (createdNew)
                mutex.ReleaseMutex();

            return !createdNew;
        }
        private static long UnixTimeNow()
        {
            TimeSpan _TimeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_TimeSpan.TotalSeconds;
        }
        private static void cleanReg(){
            string thisversion = "3";
            RegistryKey rootKey = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_ROOT);

            if (rootKey.GetValue(PPSettings.PP_REGISTRY_KEY_VERSION, "0").ToString() != thisversion)
            {
                foreach (String subkey in rootKey.GetSubKeyNames())
                {
                    foreach(String nextsubkey in Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_ROOT + @"\" + subkey).GetSubKeyNames()){
                        Registry.CurrentUser.DeleteSubKey(PPSettings.PP_REGISTRY_KEYPATH_ROOT + @"\" + subkey+@"\" +nextsubkey);
                    }
                   
                }

                rootKey.SetValue(PPSettings.PP_REGISTRY_KEY_VERSION, thisversion, RegistryValueKind.String);
                Connection tmpconnection= new Connection("HTTP PROXY", "amsterdam1.perfect-privacy.com", 22,5080,ConnectionType.HTTP,"127.0.0.1",3128);
                tmpconnection.Serialize();

                tmpconnection = new Connection("SOCKS PROXY", "rotterdam.perfect-privacy.com", 22, 5081, ConnectionType.SOCKS,"",0);
                tmpconnection.Serialize();

                tmpconnection = new Connection("FORWARDING EXAMPLE", "paris.perfect-privacy.com", 22, 5082, ConnectionType.FORWARDING, "yourMailServer.com", 25);
                tmpconnection.Serialize();

                tmpconnection = new Connection("TOR PROXY", "rotterdam.perfect-privacy.com", 22, 5083, ConnectionType.FORWARDING, "127.0.0.1", 9050);
                tmpconnection.Serialize();




                long now = UnixTimeNow();
                long count = 0;

                String[] servers ={
                "london2.perfect-privacy.com	4c:9d:03:79:9b:f1:15:25:9b:cd:75:50:f3:9c:12:f9",
                "london1.perfect-privacy.com	4c:9d:03:79:9b:f1:15:25:9b:cd:75:50:f3:9c:12:f9",
                "tokyo.perfect-privacy.com	15:9c:d1:32:b8:99:74:a6:67:e4:dd:fd:9c:cb:b4:ca",
                "huenenberg.perfect-privacy.com	5a:c1:d0:8d:08:b8:5f:7d:f6:f7:73:d0:be:be:f5:93",
                "saopaulo.perfect-privacy.com	86:8f:f6:ac:6a:5b:0d:22:a2:b2:3a:1f:c8:ee:c3:4b",
                "montreal1.perfect-privacy.com	ba:d1:dc:13:dc:ad:86:c3:9e:3e:75:c2:98:e8:a8:38",
                "montreal2.perfect-privacy.com	ba:d1:dc:13:dc:ad:86:c3:9e:3e:75:c2:98:e8:a8:38",
                "reykjavik.perfect-privacy.com	07:55:1a:d4:6d:45:b0:4a:10:51:3c:48:33:6b:ef:c5",
                "paris.perfect-privacy.com	e1:ad:92:a8:0b:b9:83:e4:9a:28:1c:e2:4a:45:7d:81",
                "rotterdam1.perfect-privacy.com	3b:54:ec:8b:69:77:b2:5c:3d:2c:64:e8:34:13:9f:63",
                "rotterdam3.perfect-privacy.com	3b:54:ec:8b:69:77:b2:5c:3d:2c:64:e8:34:13:9f:63",
                "rotterdam2.perfect-privacy.com	3b:54:ec:8b:69:77:b2:5c:3d:2c:64:e8:34:13:9f:63",
                "amsterdam1.perfect-privacy.com	06:63:de:29:33:05:84:b1:d9:a5:6c:5f:12:98:80:72",
                "amsterdam2.perfect-privacy.com	06:63:de:29:33:05:84:b1:d9:a5:6c:5f:12:98:80:72",
                "amsterdam3.perfect-privacy.com	06:63:de:29:33:05:84:b1:d9:a5:6c:5f:12:98:80:72",
                "brisbane.perfect-privacy.com	85:8e:a1:8c:66:28:59:59:56:bf:63:37:0e:bc:1a:10",
                "hongkong.perfect-privacy.com	57:d5:c9:38:29:a6:a5:35:47:ae:6b:79:78:81:2a:ef",
                "telaviv.perfect-privacy.com	59:b3:8c:26:b3:86:51:f8:af:a3:03:44:fd:ba:a4:dd",
                "cairo.perfect-privacy.com	9d:83:0b:c0:b7:0f:f1:c5:bb:40:6a:67:ec:b1:9c:f8",
                "moscow2.perfect-privacy.com	ae:4f:e9:33:8c:10:9a:a7:1c:7a:91:be:64:15:f5:97",
                "moscow1.perfect-privacy.com	ae:4f:e9:33:8c:10:9a:a7:1c:7a:91:be:64:15:f5:97",
                "kiev.perfect-privacy.com	27:f8:7a:fd:f0:0e:d4:6c:a9:14:aa:a7:0f:1a:23:cc",
                "bucharest.perfect-privacy.com	19:86:80:b3:6a:99:40:44:4d:a4:63:9e:26:33:40:c0",
                "stockholm2.perfect-privacy.com	2c:4c:14:97:c3:dd:5c:f9:df:99:ce:fd:0a:5e:29:4c",
                "stockholm1.perfect-privacy.com	2c:4c:14:97:c3:dd:5c:f9:df:99:ce:fd:0a:5e:29:4c",
                "erfurt.perfect-privacy.com	59:5e:23:8d:34:06:10:74:67:86:40:94:59:36:39:7d",
                "steinsel2.perfect-privacy.com	9b:b8:9d:a4:22:64:af:a3:40:cb:96:b3:50:3b:97:3d",
                "steinsel1.perfect-privacy.com	9b:b8:9d:a4:22:64:af:a3:40:cb:96:b3:50:3b:97:3d",
                "frankfurt.perfect-privacy.com	94:7a:7f:09:c5:7f:60:66:51:55:9a:59:ed:58:36:31",
                "nuremberg.perfect-privacy.com	02:37:4e:dc:6d:24:ad:29:fa:f1:d4:c3:e2:f8:c6:51",
                "vilnius.perfect-privacy.com	11:33:cb:df:92:87:a6:a6:1d:34:49:e1:7f:4a:20:b8",
                "panama-city.perfect-privacy.com	88:9a:08:a5:41:f9:18:09:a1:98:6b:c3:8d:71:c4:ef",
                "zurich.perfect-privacy.com	be:86:d4:0d:66:7f:b1:3c:5f:44:32:c8:f1:ea:13:50",
                "newyork1.perfect-privacy.com	90:46:18:62:44:fc:b5:f4:b5:0d:45:d2:e5:4c:db:09",
                "newyork2.perfect-privacy.com	90:46:18:62:44:fc:b5:f4:b5:0d:45:d2:e5:4c:db:09",
                "singapore.perfect-privacy.com	56:08:e3:ae:19:aa:f2:f5:6e:8a:d2:b4:e2:f4:00:92",
                "istanbul.perfect-privacy.com	68:3a:03:3e:95:16:c0:cd:4f:a2:67:74:93:0d:0b:ea",
                "nottingham.perfect-privacy.com	c1:3b:ed:71:d7:8b:da:cb:83:09:6a:40:28:75:d5:6c",
                "prague.perfect-privacy.com	0b:c0:08:c3:97:e6:e0:a3:98:4f:ec:f9:35:8e:ca:b0",
                "riga.perfect-privacy.com	92:01:01:bb:ce:bd:9e:4e:d3:d4:89:1a:41:d0:ce:dd",};

                RegistryKey foo = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_ROOT);
                 foo = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_SSH_HOST_KEYS);
                 foo = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_CONNECTIONS);

                foreach (string server in servers)
                {
                    try
                    {
                        if (server == "") { continue; }

                        string[] parts = server.Split(new string[] { "\t", }, StringSplitOptions.None);
                        string servername = parts[0].Trim();
                        string fingerprint = parts[1].Trim();
                        if (servername.IndexOf(".perfect-privacy.") == -1)
                        {
                            continue;
                        }
                        count++;
                        string serverkeypath = PPSettings.PP_REGISTRY_KEYPATH_SSH_HOST_KEYS + @"\" + Uri.EscapeUriString(servername);
                        RegistryKey serverkey = Registry.CurrentUser.CreateSubKey(serverkeypath);

                        serverkey.SetValue(PPSettings.PP_REGISTRY_KEY_SERVERNAME, servername, RegistryValueKind.String);

                        serverkey.SetValue(PPSettings.PP_REGISTRY_KEY_FINGERPRINT, fingerprint, RegistryValueKind.String);
                        serverkey.SetValue(PPSettings.PP_REGISTRY_KEY_SERVERVERSION, now, RegistryValueKind.String);
                    }
                    catch (Exception ex) { 
                     //   MessageBox.Show(ex.ToString()); 
                    }
                }
                RegistryKey serversversion = Registry.CurrentUser.CreateSubKey(PPSettings.PP_REGISTRY_KEYPATH_SSH_HOST_KEYS);
                serversversion.SetValue(PPSettings.PP_REGISTRY_KEY_SERVERVERSION, now, RegistryValueKind.String);
                Core.Instance().loadServers();
               

            }
         

        
        }


        public static void killpplink()
        {
            Process[] processes = Process.GetProcessesByName("pplink");

            foreach (Process process in processes)
            {
                process.Kill();
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (IsAlreadyRunning())
                {
                    MessageBox.Show("An instance of " + Application.ProductName + " is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // kill old pplink instances that my block the tunnel
                killpplink();

                string osVer = System.Environment.OSVersion.Version.ToString();
                if (osVer.StartsWith("5")) // windows 2000, xp win2k3
                {
                    isXP = true;
                }

                cleanReg();
                TrayIcon = new TrayIcon();
                Core.Instance();
                Core.Instance().autoConnect();
                TrayIcon.showSettings();
                Application.Run();
                TrayIcon = null;  
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured!\n If you want to help us, take a screenshot of this message and post it in our forum or send it via mail!\n" + e);
            }
           
        }
    }
}
