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
using Microsoft.Win32;

namespace PerfectPrivacy.PPTunnelManager
{
    class PPSettings
    {
        public static string PP_REGISTRY_KEYPATH_ROOT = @"Software\Perfect-Privacy\TunnelManager";
        
        public static string PP_REGISTRY_KEY_USERNAME = "username";
        public static string PP_REGISTRY_KEY_PASSWORD = "password";
        public static string PP_REGISTRY_KEY_STOREPASSWORD = "storepassword";
        public static string PP_REGISTRY_KEYPATH_CREDENTIALS = PP_REGISTRY_KEYPATH_ROOT + @"\Credentials";
        public static string PP_REGISTRY_KEYPATH_CONNECTIONS = PP_REGISTRY_KEYPATH_ROOT + @"\Connections";
        public static string PP_REGISTRY_KEYPATH_SSH_HOST_KEYS = PP_REGISTRY_KEYPATH_ROOT + @"\sshHostKeys";
        public static string PP_REGISTRY_KEY_SERVERNAME = "servername";
        public static string PP_REGISTRY_KEY_URL = "url";
        public static string PP_REGISTRY_KEY_FINGERPRINT = "fingerprint";
        public static string PP_REGISTRY_KEY_SERVERVERSION = "version";
        
        public static string PP_REGISTRY_KEY_VERSION = "version";
        
        private static PPSettings instance = null;


        public static PPSettings Instance()
        {
            if (PPSettings.instance == null)
                PPSettings.instance = new PPSettings();

            return PPSettings.instance;
        }

        private PPSettings()
        {
        }

        public string[] Connections
        {
            get {
                try
                {
                    RegistryKey connectionsKey = Registry.CurrentUser.OpenSubKey(PP_REGISTRY_KEYPATH_CONNECTIONS);
                    return connectionsKey.GetSubKeyNames();
                }
                catch (Exception)
                {
                    return new string[0];
                }
            } 
        }

       
    }
}
