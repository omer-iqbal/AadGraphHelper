using System;
using System.Windows.Forms;

namespace AadGraphApiHelper
{
    public partial class AddTenantCredentialForm : Form
    {
        private MainForm mainForm;

        public AddTenantCredentialForm(MainForm mainForm)
        {
            this.InitializeComponent();
            this.mainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            TenantCredential tenantCredential = new TenantCredential(
                (AadEnvironment)this.mainForm.EnvironmentComboBox.SelectedItem,
                this.tenantTextBox.Text.Trim().ToLowerInvariant(),
                false);
            tenantCredential.ClientId = this.clientIdTextBox.Text;
            tenantCredential.EncryptAndSetKey(this.clientKeyTextBox.Text.Trim());

            this.mainForm.TenantCredentialComboBox.Items.Add(tenantCredential);
            this.mainForm.TenantCredentialComboBox.SelectedItem = tenantCredential;

            if (this.saveCredentialCheckBox.Checked == true)
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
            if (String.IsNullOrWhiteSpace(this.tenantTextBox.Text) ||
                String.IsNullOrWhiteSpace(this.clientIdTextBox.Text) ||
                String.IsNullOrWhiteSpace(this.clientKeyTextBox.Text))
            {
                this.addButton.Enabled = false;
            }
            else
            {
                this.addButton.Enabled = true;
            }
        }
    }
}
