namespace PerfectPrivacy.SSHManager.Forms
{
    partial class TrayIcon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrayIcon));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuTunnels = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparatorTwo = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.menuTunnels,
            this.menuSparatorOne,
            this.menuSettings,
            this.menuAbout,
            this.menuSeparatorTwo,
            this.menuExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_Opening);
            // 
            // menuTunnels
            // 
            resources.ApplyResources(this.menuTunnels, "menuTunnels");
            this.menuTunnels.Name = "menuTunnels";
            // 
            // menuSparatorOne
            // 
            resources.ApplyResources(this.menuSparatorOne, "menuSparatorOne");
            this.menuSparatorOne.Name = "menuSparatorOne";
            // 
            // menuSettings
            // 
            resources.ApplyResources(this.menuSettings, "menuSettings");
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Click += new System.EventHandler(this.MenuSettings_Click);
            // 
            // menuAbout
            // 
            resources.ApplyResources(this.menuAbout, "menuAbout");
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // menuSeparatorTwo
            // 
            resources.ApplyResources(this.menuSeparatorTwo, "menuSeparatorTwo");
            this.menuSeparatorTwo.Name = "menuSeparatorTwo";
            // 
            // menuExit
            // 
            resources.ApplyResources(this.menuExit, "menuExit");
            this.menuExit.Name = "menuExit";
            this.menuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // TrayIcon
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Icon = global::PerfectPrivacy.SSHManager.Properties.Resources.pp_icon;
            this.Name = "TrayIcon";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuTunnels;
        private System.Windows.Forms.ToolStripSeparator menuSparatorOne;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripSeparator menuSeparatorTwo;
    }
}