using HauntedHouseSoftware.SecureNotePad.DomainObjects;
using System;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    public partial class PasswordEntry : Form
    {
        private Password _password;

        public PasswordEntry()
        {
            InitializeComponent();
        }

        public Password Password
        {
            get
            {
                return _password;
            }
        }

        public string LabelText
        {
            get
            {
                return _passwordEntryLabel.Text;
            }
            set
            {
                _passwordEntryLabel.Text = value;
                Text = value;
            }
        }

        private void SetPassword(string password1, string password2)
        {
            if (string.IsNullOrEmpty(password1))
            {
                throw new ArgumentNullException("password1");
            }

            if (string.IsNullOrEmpty(password2))
            {
                throw new ArgumentNullException("password2");
            }

            _password = new Password(password1, password2);
        }

        private void OkButtonClick(object sender, EventArgs e)
        {          
            SetPassword(_passwordOne.Text, _passwordTwo.Text);           
        }
    }
}
