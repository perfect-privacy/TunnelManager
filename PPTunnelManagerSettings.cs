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
using System.IO;
using Microsoft.Win32;

namespace PerfectPrivacy.PPTunnelManager
{
    class PPTunnelManagerSettings
    {
        private static PPTunnelManagerSettings instance = null;

        public static PPTunnelManagerSettings Instance()
        {
            if (PPTunnelManagerSettings.instance == null)
                PPTunnelManagerSettings.instance = new PPTunnelManagerSettings();
             
            return PPTunnelManagerSettings.instance;
        }

        public static string PTM_REGISTRY_KEYPATH_ROOT = PPSettings.PP_REGISTRY_KEYPATH_ROOT;
       
        public static string PTM_REGISTRY_KEY_PLINK_LOCATION = @"pplink";

        private PPTunnelManagerSettings()
        {
        
                string obviousPlinkPath = Path.Combine(Directory.GetCurrentDirectory(), "pplink.exe");
                if (File.Exists(obviousPlinkPath))
                    this.PlinkLocation = obviousPlinkPath;
        }

        public string PlinkLocation
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "pplink.exe"); 
              
            }
            set
            {
                //RegistryKey ptmRootKey = Registry.CurrentUser.OpenSubKey(PTM_REGISTRY_KEYPATH_ROOT, true);
                //ptmRootKey.SetValue(PTM_REGISTRY_KEY_PLINK_LOCATION, value, RegistryValueKind.String);
            }
        }

        public bool HasPlink
        {
            get { return File.Exists(this.PlinkLocation); }
        }
    }
}
