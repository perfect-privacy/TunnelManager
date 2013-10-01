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

using PerfectPrivacy.PPTunnelManager.Forms;
using Microsoft.Win32;
using System.Diagnostics;
namespace PerfectPrivacy.PPTunnelManager
{
    static class Program
    {
        public static TrayIcon TrayIcon;

        private static Mutex mutex;
      
        public static bool isXP = false;
      
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
                Connection tmpconnection= new Connection("HTTP PROXY", "nl1.gigabit.perfect-privacy.com", 22,5080,ConnectionType.HTTP,"127.0.0.1",3128);
                tmpconnection.Serialize();

                tmpconnection = new Connection("SOCKS PROXY", "de1.gigabit.perfect-privacy.com", 22, 5081, ConnectionType.SOCKS,"",0);
                tmpconnection.Serialize();

                tmpconnection = new Connection("FORWARDING EXAMPLE", "lu2.gigabit.perfect-privacy.com", 22, 5082, ConnectionType.FORWARDING, "yourMailServer.com", 25);
                tmpconnection.Serialize();

                tmpconnection = new Connection("TOR PROXY", "de3.gigabit.perfect-privacy.com", 22, 5083, ConnectionType.FORWARDING, "127.0.0.1", 9050);
                tmpconnection.Serialize();




                long now = UnixTimeNow();
                long count = 0;

                String[] servers ={
                "amsterdam1.perfect-privacy.com	06:63:de:29:33:05:84:b1:d9:a5:6c:5f:12:98:80:72",
                "amsterdam2.perfect-privacy.com	06:63:de:29:33:05:84:b1:d9:a5:6c:5f:12:98:80:72",
                "amsterdam3.perfect-privacy.com	06:63:de:29:33:05:84:b1:d9:a5:6c:5f:12:98:80:72",
                "amsterdam4.perfect-privacy.com	06:63:de:29:33:05:84:b1:d9:a5:6c:5f:12:98:80:72",
                "bangkok.perfect-privacy.com	5b:b8:1f:de:40:25:ed:55:32:d6:2c:2d:31:32:98:9b",
                "brisbane.perfect-privacy.com	85:8e:a1:8c:66:28:59:59:56:bf:63:37:0e:bc:1a:10",
                "cairo.perfect-privacy.com	9d:83:0b:c0:b7:0f:f1:c5:bb:40:6a:67:ec:b1:9c:f8",
                "ch.gigabit.perfect-privacy.com	5a:c1:d0:8d:08:b8:5f:7d:f6:f7:73:d0:be:be:f5:93",
                "chicago.perfect-privacy.com	db:8a:09:45:e8:ca:a3:17:b7:4d:5e:27:0f:00:41:57",
                "de1.gigabit.perfect-privacy.com	59:5e:23:8d:34:06:10:74:67:86:40:94:59:36:39:7d",
                "de2.gigabit.perfect-privacy.com	59:5e:23:8d:34:06:10:74:67:86:40:94:59:36:39:7d",
                "de3.gigabit.perfect-privacy.com	59:5e:23:8d:34:06:10:74:67:86:40:94:59:36:39:7d",
                "denver.perfect-privacy.com	7d:7e:04:77:76:e5:43:bf:5c:38:78:06:68:f2:d2:dc",
                "fr.gigabit.perfect-privacy.com	e1:ad:92:a8:0b:b9:83:e4:9a:28:1c:e2:4a:45:7d:81",
                "hongkong.perfect-privacy.com	57:d5:c9:38:29:a6:a5:35:47:ae:6b:79:78:81:2a:ef",
                "kiev.perfect-privacy.com	27:f8:7a:fd:f0:0e:d4:6c:a9:14:aa:a7:0f:1a:23:cc",
                "london1.perfect-privacy.com	4c:9d:03:79:9b:f1:15:25:9b:cd:75:50:f3:9c:12:f9",
                "london2.perfect-privacy.com	4c:9d:03:79:9b:f1:15:25:9b:cd:75:50:f3:9c:12:f9",
                "lu1.gigabit.perfect-privacy.com	9b:b8:9d:a4:22:64:af:a3:40:cb:96:b3:50:3b:97:3d",
                "lu2.gigabit.perfect-privacy.com	9b:b8:9d:a4:22:64:af:a3:40:cb:96:b3:50:3b:97:3d",
                "montreal1.perfect-privacy.com	ba:d1:dc:13:dc:ad:86:c3:9e:3e:75:c2:98:e8:a8:38",
                "montreal2.perfect-privacy.com	ba:d1:dc:13:dc:ad:86:c3:9e:3e:75:c2:98:e8:a8:38",
                "moscow1.perfect-privacy.com	ae:4f:e9:33:8c:10:9a:a7:1c:7a:91:be:64:15:f5:97",
                "moscow2.perfect-privacy.com	ae:4f:e9:33:8c:10:9a:a7:1c:7a:91:be:64:15:f5:97",
                "moscow3.perfect-privacy.com	ae:4f:e9:33:8c:10:9a:a7:1c:7a:91:be:64:15:f5:97",
                "nl1.gigabit.perfect-privacy.com	3b:54:ec:8b:69:77:b2:5c:3d:2c:64:e8:34:13:9f:63",
                "nl2.gigabit.perfect-privacy.com	3b:54:ec:8b:69:77:b2:5c:3d:2c:64:e8:34:13:9f:63",
                "reykjavik.perfect-privacy.com	07:55:1a:d4:6d:45:b0:4a:10:51:3c:48:33:6b:ef:c5",
                "ro.gigabit.perfect-privacy.com	19:86:80:b3:6a:99:40:44:4d:a4:63:9e:26:33:40:c0",
                "saopaulo.perfect-privacy.com	86:8f:f6:ac:6a:5b:0d:22:a2:b2:3a:1f:c8:ee:c3:4b",
                "stockholm1.perfect-privacy.com 2c:4c:14:97:c3:dd:5c:f9:df:99:ce:fd:0a:5e:29:4c",
                "stockholm2.perfect-privacy.com	2c:4c:14:97:c3:dd:5c:f9:df:99:ce:fd:0a:5e:29:4c",
                "telaviv.perfect-privacy.com	59:b3:8c:26:b3:86:51:f8:af:a3:03:44:fd:ba:a4:dd",
                "tokyo.perfect-privacy.com	15:9c:d1:32:b8:99:74:a6:67:e4:dd:fd:9c:cb:b4:ca",
                "us.gigabit.perfect-privacy.com	0b:b1:b9:c4:56:19:b4:a2:aa:79:81:49:1d:08:81:4e",};

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
            Application.Run();
            TrayIcon = null;
        }
    }
}
