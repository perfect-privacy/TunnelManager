﻿/**
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
using System.Text;

namespace PerfectPrivacy.SSHManager
{
    public enum TunnelType
    {
        LOCAL,
        DYNAMIC
    }

    class Tunnel
    {
        private Connection session;

        private int sourcePort;
        private string destination;
        private int destinationPort;
        private TunnelType type;

        public Tunnel(Connection session, int sourcePort, string destination, int destinationPort, TunnelType type)
        {
            this.session = session;

            this.sourcePort = sourcePort;
            this.destination = destination;
            this.destinationPort = destinationPort;
            this.type = type;
        }

        public int SourcePort
        {
            get { return this.sourcePort; }
        }

        public string Destination
        {
            get { return this.destination; }
        }

        public int DestinationPort
        {
            get { return this.destinationPort; }
        }

        public TunnelType Type
        {
            get { return this.type; }
        }

        public Connection Session
        {
            get { return this.session; }
        }

        public string Serialize()
        {
            string source = this.type.ToString().Substring(0, 1) + this.sourcePort;
            if (this.type == TunnelType.DYNAMIC)
                return source + ",";
            else
                return source + "=" + this.destination + ":" + this.destinationPort + ",";
        }

        public static Tunnel Load(Connection session, string data)
        {
            string[] parts = data.Substring(1).Split('=', ':');

            int sourcePort = Int32.Parse(parts[0]);
            string destination = "";
            int destinationPort = 0;

            if (parts.Length > 1)
            {
                destination = parts[1];
                destinationPort = Int32.Parse(parts[2]);
            }

            TunnelType type;
            switch (data.Substring(0, 1))
            {
                default:
                case "L": type = TunnelType.LOCAL; break;
                case "D": type = TunnelType.DYNAMIC; break;
            }

            return new Tunnel(session, sourcePort, destination, destinationPort, type);
        }

        public override bool Equals(object obj)
        {
            Tunnel tunnel = obj as Tunnel;
            if (tunnel == null)
            {
                return base.Equals(obj);
            }
            else
            {
                return (this.session == tunnel.Session &&
                    this.destination == tunnel.Destination &&
                    this.destinationPort == tunnel.DestinationPort &&
                    this.sourcePort == tunnel.SourcePort &&
                    this.type == tunnel.Type
                );
            }
        }

        public override int GetHashCode()
        {
            // TODO: This should be calculated based on the equals stuff that is now done in the equals method.
            return base.GetHashCode();
        }
    }
}
