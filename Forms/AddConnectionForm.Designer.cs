namespace PerfectPrivacy.SSHManager.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddConnectionForm));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.portlabel = new System.Windows.Forms.Label();
            this.tolabel = new System.Windows.Forms.Label();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.remoteHostTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectionTypeSelect = new System.Windows.Forms.ComboBox();
            this.localPort = new System.Windows.Forms.Label();
            this.localPortTextBox = new System.Windows.Forms.TextBox();
            this.servers = new System.Windows.Forms.ComboBox();
            this.connectionNameTexBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
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
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // portlabel
            // 
            resources.ApplyResources(this.portlabel, "portlabel");
            this.portlabel.Name = "portlabel";
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
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // connectionTypeSelect
            // 
            resources.ApplyResources(this.connectionTypeSelect, "connectionTypeSelect");
            this.connectionTypeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionTypeSelect.FormattingEnabled = true;
            this.connectionTypeSelect.Name = "connectionTypeSelect";
            this.connectionTypeSelect.SelectedIndexChanged += new System.EventHandler(this.connectionTypeSelect_SelectedIndexChanged);
            // 
            // localPort
            // 
            resources.ApplyResources(this.localPort, "localPort");
            this.localPort.Name = "localPort";
            // 
            // localPortTextBox
            // 
            resources.ApplyResources(this.localPortTextBox, "localPortTextBox");
            this.localPortTextBox.Name = "localPortTextBox";
            this.localPortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.localportTextBox_Validating);
            // 
            // servers
            // 
            resources.ApplyResources(this.servers, "servers");
            this.servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servers.FormattingEnabled = true;
            this.servers.Name = "servers";
            // 
            // connectionNameTexBox
            // 
            resources.ApplyResources(this.connectionNameTexBox, "connectionNameTexBox");
            this.connectionNameTexBox.Name = "connectionNameTexBox";
            this.connectionNameTexBox.TextChanged += new System.EventHandler(this.connectionNameTexBox_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // AddConnectionForm
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddConnectionForm";
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