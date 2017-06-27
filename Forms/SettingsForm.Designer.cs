namespace PerfectPrivacy.SSHManager.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.connections = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NoConnectionSelected = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDeleteConnection = new System.Windows.Forms.Button();
            this.buttonAddConnection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutostart = new System.Windows.Forms.CheckBox();
            this.storepassword = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.buttonDownloadPlink = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.connectionDetails = new System.Windows.Forms.GroupBox();
            this.tolabel = new System.Windows.Forms.Label();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.remoteHostTextBox = new System.Windows.Forms.TextBox();
            this.autoreconnect = new System.Windows.Forms.CheckBox();
            this.autoconnect = new System.Windows.Forms.CheckBox();
            this.explainConnection = new System.Windows.Forms.Label();
            this.connectionType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.localPortTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.servers = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.connectionName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.connectionDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // connections
            // 
            resources.ApplyResources(this.connections, "connections");
            this.connections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader11,
            this.localport,
            this.columnHeader2});
            this.connections.FullRowSelect = true;
            this.connections.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.connections.HideSelection = false;
            this.connections.MultiSelect = false;
            this.connections.Name = "connections";
            this.connections.UseCompatibleStateImageBehavior = false;
            this.connections.View = System.Windows.Forms.View.Details;
            this.connections.SelectedIndexChanged += new System.EventHandler(this.SwitchConnection);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader11
            // 
            resources.ApplyResources(this.columnHeader11, "columnHeader11");
            // 
            // localport
            // 
            resources.ApplyResources(this.localport, "localport");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // NoConnectionSelected
            // 
            resources.ApplyResources(this.NoConnectionSelected, "NoConnectionSelected");
            this.NoConnectionSelected.Name = "NoConnectionSelected";
            this.NoConnectionSelected.Click += new System.EventHandler(this.label1_Click);
            // 
            // username
            // 
            resources.ApplyResources(this.username, "username");
            this.username.Name = "username";
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            this.username.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // buttonDeleteConnection
            // 
            resources.ApplyResources(this.buttonDeleteConnection, "buttonDeleteConnection");
            this.buttonDeleteConnection.Name = "buttonDeleteConnection";
            this.buttonDeleteConnection.UseVisualStyleBackColor = true;
            this.buttonDeleteConnection.Click += new System.EventHandler(this.buttonDeleteConnection_Click);
            // 
            // buttonAddConnection
            // 
            resources.ApplyResources(this.buttonAddConnection, "buttonAddConnection");
            this.buttonAddConnection.Name = "buttonAddConnection";
            this.buttonAddConnection.UseVisualStyleBackColor = true;
            this.buttonAddConnection.Click += new System.EventHandler(this.buttonAddConnection_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chkAutostart);
            this.groupBox1.Controls.Add(this.storepassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.buttonDownloadPlink);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkAutostart
            // 
            resources.ApplyResources(this.chkAutostart, "chkAutostart");
            this.chkAutostart.Name = "chkAutostart";
            this.chkAutostart.UseVisualStyleBackColor = true;
            this.chkAutostart.Click += new System.EventHandler(this.chkAutostart_Click);
            // 
            // storepassword
            // 
            resources.ApplyResources(this.storepassword, "storepassword");
            this.storepassword.Name = "storepassword";
            this.storepassword.UseVisualStyleBackColor = true;
            this.storepassword.CheckedChanged += new System.EventHandler(this.storepassword_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // password
            // 
            resources.ApplyResources(this.password, "password");
            this.password.Name = "password";
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // buttonDownloadPlink
            // 
            resources.ApplyResources(this.buttonDownloadPlink, "buttonDownloadPlink");
            this.buttonDownloadPlink.Name = "buttonDownloadPlink";
            this.buttonDownloadPlink.UseVisualStyleBackColor = true;
            this.buttonDownloadPlink.Click += new System.EventHandler(this.buttonDownloadPlink_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.connectionDetails);
            this.groupBox2.Controls.Add(this.connections);
            this.groupBox2.Controls.Add(this.NoConnectionSelected);
            this.groupBox2.Controls.Add(this.buttonAddConnection);
            this.groupBox2.Controls.Add(this.buttonDeleteConnection);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // connectionDetails
            // 
            resources.ApplyResources(this.connectionDetails, "connectionDetails");
            this.connectionDetails.Controls.Add(this.tolabel);
            this.connectionDetails.Controls.Add(this.remotePortTextBox);
            this.connectionDetails.Controls.Add(this.remoteHostTextBox);
            this.connectionDetails.Controls.Add(this.autoreconnect);
            this.connectionDetails.Controls.Add(this.autoconnect);
            this.connectionDetails.Controls.Add(this.explainConnection);
            this.connectionDetails.Controls.Add(this.connectionType);
            this.connectionDetails.Controls.Add(this.label6);
            this.connectionDetails.Controls.Add(this.label4);
            this.connectionDetails.Controls.Add(this.localPortTextBox);
            this.connectionDetails.Controls.Add(this.ConnectButton);
            this.connectionDetails.Controls.Add(this.servers);
            this.connectionDetails.Controls.Add(this.label5);
            this.connectionDetails.Controls.Add(this.label7);
            this.connectionDetails.Controls.Add(this.connectionName);
            this.connectionDetails.Name = "connectionDetails";
            this.connectionDetails.TabStop = false;
            // 
            // tolabel
            // 
            resources.ApplyResources(this.tolabel, "tolabel");
            this.tolabel.Name = "tolabel";
            // 
            // remotePortTextBox
            // 
            resources.ApplyResources(this.remotePortTextBox, "remotePortTextBox");
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.remoteportTextBox_Validating);
            // 
            // remoteHostTextBox
            // 
            resources.ApplyResources(this.remoteHostTextBox, "remoteHostTextBox");
            this.remoteHostTextBox.Name = "remoteHostTextBox";
            this.remoteHostTextBox.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // autoreconnect
            // 
            resources.ApplyResources(this.autoreconnect, "autoreconnect");
            this.autoreconnect.Name = "autoreconnect";
            this.autoreconnect.UseVisualStyleBackColor = true;
            this.autoreconnect.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // autoconnect
            // 
            resources.ApplyResources(this.autoconnect, "autoconnect");
            this.autoconnect.Name = "autoconnect";
            this.autoconnect.UseVisualStyleBackColor = true;
            this.autoconnect.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // explainConnection
            // 
            resources.ApplyResources(this.explainConnection, "explainConnection");
            this.explainConnection.Name = "explainConnection";
            // 
            // connectionType
            // 
            resources.ApplyResources(this.connectionType, "connectionType");
            this.connectionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.connectionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.connectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionType.FormattingEnabled = true;
            this.connectionType.Name = "connectionType";
            this.connectionType.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // localPortTextBox
            // 
            resources.ApplyResources(this.localPortTextBox, "localPortTextBox");
            this.localPortTextBox.Name = "localPortTextBox";
            this.localPortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.localportTextBox_Validating);
            // 
            // ConnectButton
            // 
            resources.ApplyResources(this.ConnectButton, "ConnectButton");
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // servers
            // 
            resources.ApplyResources(this.servers, "servers");
            this.servers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.servers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servers.FormattingEnabled = true;
            this.servers.Name = "servers";
            this.servers.SelectedIndexChanged += new System.EventHandler(this.servers_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // connectionName
            // 
            resources.ApplyResources(this.connectionName, "connectionName");
            this.connectionName.Name = "connectionName";
            this.connectionName.TextChanged += new System.EventHandler(this.connectionName_TextChanged);
            this.connectionName.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.connectionDetails.ResumeLayout(false);
            this.connectionDetails.PerformLayout();
            this.ResumeLayout(false);

        }

       
        #endregion

        private System.Windows.Forms.ListView connections;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label NoConnectionSelected;
        private System.Windows.Forms.Button buttonDeleteConnection;
        private System.Windows.Forms.Button buttonAddConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDownloadPlink;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox connectionName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox storepassword;
        private System.Windows.Forms.ComboBox servers;
        private System.Windows.Forms.GroupBox connectionDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox localPortTextBox;
        private System.Windows.Forms.ComboBox connectionType;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ColumnHeader localport;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label explainConnection;
        private System.Windows.Forms.CheckBox autoconnect;
        private System.Windows.Forms.CheckBox autoreconnect;
        private System.Windows.Forms.Label tolabel;
        private System.Windows.Forms.TextBox remotePortTextBox;
        private System.Windows.Forms.TextBox remoteHostTextBox;
        private System.Windows.Forms.CheckBox chkAutostart;
    }
}

