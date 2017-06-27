namespace PerfectPrivacy.SSHManager.Forms
{
    partial class AddTunnelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTunnelForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDestinationPort = new System.Windows.Forms.Label();
            this.destinationPortTextBox = new System.Windows.Forms.TextBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.sourcePortTextBox = new System.Windows.Forms.TextBox();
            this.labelSourcePort = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.labelDestinationPort);
            this.groupBox1.Controls.Add(this.destinationPortTextBox);
            this.groupBox1.Controls.Add(this.labelDestination);
            this.groupBox1.Controls.Add(this.destinationTextBox);
            this.groupBox1.Controls.Add(this.sourcePortTextBox);
            this.groupBox1.Controls.Add(this.labelSourcePort);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // labelDestinationPort
            // 
            resources.ApplyResources(this.labelDestinationPort, "labelDestinationPort");
            this.labelDestinationPort.Name = "labelDestinationPort";
            // 
            // destinationPortTextBox
            // 
            resources.ApplyResources(this.destinationPortTextBox, "destinationPortTextBox");
            this.destinationPortTextBox.Name = "destinationPortTextBox";
            this.destinationPortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.destinationPortTextBox_Validating);
            // 
            // labelDestination
            // 
            resources.ApplyResources(this.labelDestination, "labelDestination");
            this.labelDestination.Name = "labelDestination";
            // 
            // destinationTextBox
            // 
            resources.ApplyResources(this.destinationTextBox, "destinationTextBox");
            this.destinationTextBox.Name = "destinationTextBox";
            // 
            // sourcePortTextBox
            // 
            resources.ApplyResources(this.sourcePortTextBox, "sourcePortTextBox");
            this.sourcePortTextBox.Name = "sourcePortTextBox";
            this.sourcePortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.sourcePortTextBox_Validating);
            // 
            // labelSourcePort
            // 
            resources.ApplyResources(this.labelSourcePort, "labelSourcePort");
            this.labelSourcePort.Name = "labelSourcePort";
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
            // AddTunnelForm
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTunnelForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox sourcePortTextBox;
        private System.Windows.Forms.Label labelSourcePort;
        private System.Windows.Forms.Label labelDestinationPort;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.TextBox destinationPortTextBox;
    }
}