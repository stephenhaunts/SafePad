using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    public partial class AboutDialogBox : Form
    {
        public AboutDialogBox()
        {
            InitializeComponent();
        }

        private void aboutBoxLicenseName_Click(object sender, EventArgs e)
        {

        }

        private void aboutBoxLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(aboutBoxLinkLabel.Text);
            Process.Start(sInfo);
        }
    }
}
