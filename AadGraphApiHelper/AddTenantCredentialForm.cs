using System;
using System.Drawing;
using System.Windows.Forms;

namespace AadGraphApiHelper
{
    public partial class AddTenantCredentialForm : Form
    {
        private MainForm mainForm;

        private readonly Color errorColor = Color.LightCoral;

        private readonly Color defaultControlColor = SystemColors.Window;
 
        public AddTenantCredentialForm(MainForm mainForm)
        {
            this.InitializeComponent();
            this.mainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ApplicationType applicationType = ApplicationType.Web;

            if (this.nativeAppRadioButton.Checked)
            {
                applicationType = ApplicationType.Native;
            }
            
            TenantCredential tenantCredential = new TenantCredential(
                (AadEnvironment)this.mainForm.EnvironmentComboBox.SelectedItem,
                this.tenantTextBox.Text.Trim().ToLowerInvariant(),
                this.clientIdTextBox.Text.Trim().ToLowerInvariant(),
                applicationType);

            if (applicationType == ApplicationType.Native)
            {
                tenantCredential.ReplyUrl = new Uri(this.keyOrReplyUrlTextBox.Text);
            }
            else
            {
                tenantCredential.EncryptAndSetKey(this.keyOrReplyUrlTextBox.Text.Trim());
            }

            this.mainForm.TenantCredentialComboBox.Items.Add(tenantCredential);
            this.mainForm.TenantCredentialComboBox.SelectedItem = tenantCredential;

            if (this.nativeAppRadioButton.Checked || (this.webAppRadioButton.Checked && this.saveCredentialCheckBox.Checked))
            {
                this.mainForm.Store.Store(tenantCredential);
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tenantTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SetAddButtonState();
        }

        private void clientIdTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SetAddButtonState();
        }

        private void clientKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SetAddButtonState();
        }

        private void SetAddButtonState()
        {
            this.tenantTextBox.BackColor = String.IsNullOrWhiteSpace(this.tenantTextBox.Text) ? this.errorColor : this.defaultControlColor;

            if (!String.IsNullOrEmpty(this.clientIdTextBox.Text))
            {
                this.clientIdTextBox.BackColor = this.IsClientIdValid() ? this.defaultControlColor : this.errorColor;
            }

            if (this.keyOrReplyUrlTextBox.Enabled && !String.IsNullOrEmpty(this.keyOrReplyUrlTextBox.Text))
            {
                this.keyOrReplyUrlTextBox.BackColor = this.IsKeyOrReplyUrlValid() ? this.defaultControlColor : this.errorColor;
            }

            if (!String.IsNullOrWhiteSpace(this.tenantTextBox.Text) &&
                this.IsClientIdValid() &&
                this.IsKeyOrReplyUrlValid() && 
                (this.nativeAppRadioButton.Checked || this.webAppRadioButton.Checked))
            {
                this.addButton.Enabled = true;
            }
            else
            {
                this.addButton.Enabled = false;
            }
        }

        private void webAppRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.keyOrReplyUrlLabel.Text = StringResources.ClientKeyLabel;
            this.EnableControls();
            this.SetAddButtonState();
        }

        private void nativeAppRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.keyOrReplyUrlLabel.Text = StringResources.ClientReplyUrlLabel;
            this.EnableControls();
            this.SetAddButtonState();
        }

        private void EnableControls()
        {
            this.keyOrReplyUrlLabel.Enabled = true;
            this.keyOrReplyUrlTextBox.Enabled = true;
            this.saveCredentialCheckBox.Enabled = !this.nativeAppRadioButton.Checked;
        }

        private bool IsClientIdValid()
        {
            Guid ignored;
            return Guid.TryParse(this.clientIdTextBox.Text, out ignored);
        }

        private bool IsKeyOrReplyUrlValid()
        {
            if (this.webAppRadioButton.Checked)
            {
                return this.IsClientKeyValid();
            }
            else
            {
                return this.IsReplyUrlValid();
            }
        }

        private bool IsClientKeyValid()
        {
            try
            {
                Convert.FromBase64String(this.keyOrReplyUrlTextBox.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsReplyUrlValid()
        {
            Uri uriResult;
            return Uri.TryCreate(this.keyOrReplyUrlTextBox.Text, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp |
                   Uri.TryCreate(this.keyOrReplyUrlTextBox.Text, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttps; 
        }
    }
}
