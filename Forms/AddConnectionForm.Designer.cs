namespace PerfectPrivacy.PPTunnelManager.Forms
{
    partial class AddConnectionForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectionTypeSelect = new System.Windows.Forms.ComboBox();
            this.localPort = new System.Windows.Forms.Label();
            this.localPortTextBox = new System.Windows.Forms.TextBox();
            this.servers = new System.Windows.Forms.ComboBox();
            this.connectionNameTexBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.remoteHostTextBox = new System.Windows.Forms.TextBox();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.tolabel = new System.Windows.Forms.Label();
            this.portlabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(388, 172);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 26);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(307, 172);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 26);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.portlabel);
            this.groupBox1.Controls.Add(this.tolabel);
            this.groupBox1.Controls.Add(this.remotePortTextBox);
            this.groupBox1.Controls.Add(this.remoteHostTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.connectionTypeSelect);
            this.groupBox1.Controls.Add(this.localPort);
            this.groupBox1.Controls.Add(this.localPortTextBox);
            this.groupBox1.Controls.Add(this.servers);
            this.groupBox1.Controls.Add(this.connectionNameTexBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Connection Type";
            // 
            // connectionTypeSelect
            // 
            this.connectionTypeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionTypeSelect.FormattingEnabled = true;
            this.connectionTypeSelect.Location = new System.Drawing.Point(105, 66);
            this.connectionTypeSelect.Name = "connectionTypeSelect";
            this.connectionTypeSelect.Size = new System.Drawing.Size(116, 21);
            this.connectionTypeSelect.TabIndex = 3;
            this.connectionTypeSelect.SelectedIndexChanged += new System.EventHandler(this.connectionTypeSelect_SelectedIndexChanged);
            // 
            // localPort
            // 
            this.localPort.AutoSize = true;
            this.localPort.Location = new System.Drawing.Point(44, 95);
            this.localPort.Name = "localPort";
            this.localPort.Size = new System.Drawing.Size(55, 13);
            this.localPort.TabIndex = 5;
            this.localPort.Text = "Local Port";
            // 
            // localPortTextBox
            // 
            this.localPortTextBox.Location = new System.Drawing.Point(105, 92);
            this.localPortTextBox.Name = "localPortTextBox";
            this.localPortTextBox.Size = new System.Drawing.Size(42, 20);
            this.localPortTextBox.TabIndex = 4;
            this.localPortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.localportTextBox_Validating);
            // 
            // servers
            // 
            this.servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servers.FormattingEnabled = true;
            this.servers.Location = new System.Drawing.Point(105, 39);
            this.servers.Name = "servers";
            this.servers.Size = new System.Drawing.Size(294, 21);
            this.servers.TabIndex = 2;
            // 
            // connectionNameTexBox
            // 
            this.connectionNameTexBox.Location = new System.Drawing.Point(105, 13);
            this.connectionNameTexBox.Name = "connectionNameTexBox";
            this.connectionNameTexBox.Size = new System.Drawing.Size(294, 20);
            this.connectionNameTexBox.TabIndex = 0;
            this.connectionNameTexBox.TextChanged += new System.EventHandler(this.connectionNameTexBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection name:";
            // 
            // remoteHostTextBox
            // 
            this.remoteHostTextBox.Location = new System.Drawing.Point(175, 92);
            this.remoteHostTextBox.Name = "remoteHostTextBox";
            this.remoteHostTextBox.Size = new System.Drawing.Size(144, 20);
            this.remoteHostTextBox.TabIndex = 7;
            // 
            // remotePortTextBox
            // 
            this.remotePortTextBox.Location = new System.Drawing.Point(357, 92);
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Size = new System.Drawing.Size(42, 20);
            this.remotePortTextBox.TabIndex = 8;
            this.remotePortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.remoteportTextBox_Validating);
            // 
            // tolabel
            // 
            this.tolabel.AutoSize = true;
            this.tolabel.Location = new System.Drawing.Point(153, 95);
            this.tolabel.Name = "tolabel";
            this.tolabel.Size = new System.Drawing.Size(16, 13);
            this.tolabel.TabIndex = 9;
            this.tolabel.Text = "to";
            // 
            // portlabel
            // 
            this.portlabel.AutoSize = true;
            this.portlabel.Location = new System.Drawing.Point(325, 95);
            this.portlabel.Name = "portlabel";
            this.portlabel.Size = new System.Drawing.Size(26, 13);
            this.portlabel.TabIndex = 10;
            this.portlabel.Text = "Port";
            // 
            // AddConnectionForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(475, 208);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add connection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox connectionNameTexBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox servers;
        private System.Windows.Forms.ComboBox connectionTypeSelect;
        private System.Windows.Forms.Label localPort;
        private System.Windows.Forms.TextBox localPortTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label portlabel;
        private System.Windows.Forms.Label tolabel;
        private System.Windows.Forms.TextBox remotePortTextBox;
        private System.Windows.Forms.TextBox remoteHostTextBox;
    }
}