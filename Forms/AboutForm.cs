
using System.Windows.Forms;
using System.Diagnostics;

namespace PerfectPrivacy.SSHManager.Forms
{
    using System.Reflection;

    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.label2.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
        }

        private void test_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
