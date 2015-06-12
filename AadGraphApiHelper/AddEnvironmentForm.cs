using System;
using System.Windows.Forms;

namespace AadGraphApiHelper
{
    public partial class AddEnvironmentForm : Form
    {
        private MainForm mainForm;

        public AddEnvironmentForm(MainForm mainForm)
        {
            this.InitializeComponent();
            this.mainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AadEnvironment environment = new AadEnvironment(
                this.displayNameTextBox.Text,
                this.loginEndpointTextBox.Text,
                this.graphEndpointTextBox.Text);

            this.mainForm.EnvironmentComboBox.Items.Add(environment);
            this.mainForm.EnvironmentComboBox.SelectedItem = environment;
            this.mainForm.Store.Store(environment);

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
            if (String.IsNullOrWhiteSpace(this.displayNameTextBox.Text) ||
                String.IsNullOrWhiteSpace(this.loginEndpointTextBox.Text) ||
                String.IsNullOrWhiteSpace(this.graphEndpointTextBox.Text))
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
