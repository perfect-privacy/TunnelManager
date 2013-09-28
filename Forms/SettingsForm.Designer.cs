namespace PerfectPrivacy.PPTunnelManager.Forms
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
            this.connections = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDeleteConnection = new System.Windows.Forms.Button();
            this.buttonAddConnection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.connections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader11,
            this.localport,
            this.columnHeader2});
            this.connections.FullRowSelect = true;
            this.connections.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.connections.HideSelection = false;
            this.connections.LabelWrap = false;
            this.connections.Location = new System.Drawing.Point(6, 19);
            this.connections.MaximumSize = new System.Drawing.Size(388, 118);
            this.connections.MinimumSize = new System.Drawing.Size(388, 118);
            this.connections.MultiSelect = false;
            this.connections.Name = "connections";
            this.connections.Size = new System.Drawing.Size(388, 118);
            this.connections.TabIndex = 0;
            this.connections.UseCompatibleStateImageBehavior = false;
            this.connections.View = System.Windows.Forms.View.Details;
            this.connections.SelectedIndexChanged += new System.EventHandler(this.SwitchConnection);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Type";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 90;
            // 
            // localport
            // 
            this.localport.Text = "Local Port";
            this.localport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.localport.Width = 64;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Active";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Click on a connection to display the details";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(89, 20);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(136, 20);
            this.username.TabIndex = 2;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            this.username.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // buttonDeleteConnection
            // 
            this.buttonDeleteConnection.Enabled = false;
            this.buttonDeleteConnection.Location = new System.Drawing.Point(318, 143);
            this.buttonDeleteConnection.Name = "buttonDeleteConnection";
            this.buttonDeleteConnection.Size = new System.Drawing.Size(75, 26);
            this.buttonDeleteConnection.TabIndex = 2;
            this.buttonDeleteConnection.Text = "Delete";
            this.buttonDeleteConnection.UseVisualStyleBackColor = true;
            this.buttonDeleteConnection.Click += new System.EventHandler(this.buttonDeleteConnection_Click);
            // 
            // buttonAddConnection
            // 
            this.buttonAddConnection.Location = new System.Drawing.Point(237, 143);
            this.buttonAddConnection.Name = "buttonAddConnection";
            this.buttonAddConnection.Size = new System.Drawing.Size(75, 26);
            this.buttonAddConnection.TabIndex = 1;
            this.buttonAddConnection.Text = "Add";
            this.buttonAddConnection.UseVisualStyleBackColor = true;
            this.buttonAddConnection.Click += new System.EventHandler(this.buttonAddConnection_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.storepassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.buttonDownloadPlink);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Settings";
            // 
            // storepassword
            // 
            this.storepassword.AutoSize = true;
            this.storepassword.Location = new System.Drawing.Point(271, 53);
            this.storepassword.Name = "storepassword";
            this.storepassword.Size = new System.Drawing.Size(100, 17);
            this.storepassword.TabIndex = 10;
            this.storepassword.Text = "Store Password";
            this.storepassword.UseVisualStyleBackColor = true;
            this.storepassword.CheckedChanged += new System.EventHandler(this.storepassword_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(89, 50);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(136, 20);
            this.password.TabIndex = 8;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // buttonDownloadPlink
            // 
            this.buttonDownloadPlink.Location = new System.Drawing.Point(271, 16);
            this.buttonDownloadPlink.Name = "buttonDownloadPlink";
            this.buttonDownloadPlink.Size = new System.Drawing.Size(107, 26);
            this.buttonDownloadPlink.TabIndex = 1;
            this.buttonDownloadPlink.Text = "Update Serverlist";
            this.buttonDownloadPlink.UseVisualStyleBackColor = true;
            this.buttonDownloadPlink.Click += new System.EventHandler(this.buttonDownloadPlink_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.connectionDetails);
            this.groupBox2.Controls.Add(this.connections);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonAddConnection);
            this.groupBox2.Controls.Add(this.buttonDeleteConnection);
            this.groupBox2.Location = new System.Drawing.Point(12, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 401);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connections";
            // 
            // connectionDetails
            // 
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
            this.connectionDetails.Location = new System.Drawing.Point(6, 175);
            this.connectionDetails.Name = "connectionDetails";
            this.connectionDetails.Size = new System.Drawing.Size(387, 220);
            this.connectionDetails.TabIndex = 5;
            this.connectionDetails.TabStop = false;
            this.connectionDetails.Text = "Connection Details";
            // 
            // tolabel
            // 
            this.tolabel.AutoSize = true;
            this.tolabel.Location = new System.Drawing.Point(165, 113);
            this.tolabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tolabel.Name = "tolabel";
            this.tolabel.Size = new System.Drawing.Size(16, 13);
            this.tolabel.TabIndex = 19;
            this.tolabel.Text = "to";
            // 
            // remotePortTextBox
            // 
            this.remotePortTextBox.Enabled = false;
            this.remotePortTextBox.Location = new System.Drawing.Point(321, 110);
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Size = new System.Drawing.Size(44, 20);
            this.remotePortTextBox.TabIndex = 18;
            this.remotePortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.remoteportTextBox_Validating);
            // 
            // remoteHostTextBox
            // 
            this.remoteHostTextBox.Enabled = false;
            this.remoteHostTextBox.Location = new System.Drawing.Point(186, 110);
            this.remoteHostTextBox.Name = "remoteHostTextBox";
            this.remoteHostTextBox.Size = new System.Drawing.Size(129, 20);
            this.remoteHostTextBox.TabIndex = 17;
            this.remoteHostTextBox.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // autoreconnect
            // 
            this.autoreconnect.AutoSize = true;
            this.autoreconnect.Location = new System.Drawing.Point(23, 162);
            this.autoreconnect.Name = "autoreconnect";
            this.autoreconnect.Size = new System.Drawing.Size(169, 17);
            this.autoreconnect.TabIndex = 16;
            this.autoreconnect.Text = "Auto reconnect on disconnect";
            this.autoreconnect.UseVisualStyleBackColor = true;
            this.autoreconnect.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // autoconnect
            // 
            this.autoconnect.AutoSize = true;
            this.autoconnect.Location = new System.Drawing.Point(23, 139);
            this.autoconnect.Name = "autoconnect";
            this.autoconnect.Size = new System.Drawing.Size(170, 17);
            this.autoconnect.TabIndex = 15;
            this.autoconnect.Text = "Connect on application startup";
            this.autoconnect.UseVisualStyleBackColor = true;
            this.autoconnect.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // explainConnection
            // 
            this.explainConnection.AutoSize = true;
            this.explainConnection.Location = new System.Drawing.Point(10, 195);
            this.explainConnection.Name = "explainConnection";
            this.explainConnection.Size = new System.Drawing.Size(120, 13);
            this.explainConnection.TabIndex = 14;
            this.explainConnection.Text = "No connection selected";
            // 
            // connectionType
            // 
            this.connectionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.connectionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.connectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionType.Enabled = false;
            this.connectionType.FormattingEnabled = true;
            this.connectionType.Location = new System.Drawing.Point(116, 54);
            this.connectionType.Name = "connectionType";
            this.connectionType.Size = new System.Drawing.Size(120, 21);
            this.connectionType.TabIndex = 13;
            this.connectionType.Leave += new System.EventHandler(this.Field_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Connection Type";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Local Port";
            // 
            // localPortTextBox
            // 
            this.localPortTextBox.Enabled = false;
            this.localPortTextBox.Location = new System.Drawing.Point(116, 110);
            this.localPortTextBox.Name = "localPortTextBox";
            this.localPortTextBox.Size = new System.Drawing.Size(44, 20);
            this.localPortTextBox.TabIndex = 10;
            this.localPortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.localportTextBox_Validating);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Enabled = false;
            this.ConnectButton.Location = new System.Drawing.Point(306, 188);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 26);
            this.ConnectButton.TabIndex = 9;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // servers
            // 
            this.servers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.servers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servers.Enabled = false;
            this.servers.FormattingEnabled = true;
            this.servers.Location = new System.Drawing.Point(116, 83);
            this.servers.Name = "servers";
            this.servers.Size = new System.Drawing.Size(249, 21);
            this.servers.TabIndex = 8;
            this.servers.SelectedIndexChanged += new System.EventHandler(this.servers_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "To Server";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Connection name";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // connectionName
            // 
            this.connectionName.Enabled = false;
            this.connectionName.Location = new System.Drawing.Point(116, 26);
            this.connectionName.Name = "connectionName";
            this.connectionName.Size = new System.Drawing.Size(249, 20);
            this.connectionName.TabIndex = 0;
            this.connectionName.TextChanged += new System.EventHandler(this.connectionName_TextChanged);
            this.connectionName.Leave += new System.EventHandler(this.Field_Leave);
            this.remotePortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 506);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PP TunnelManager Settings";
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
        private System.Windows.Forms.Label label1;
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
    }
}

