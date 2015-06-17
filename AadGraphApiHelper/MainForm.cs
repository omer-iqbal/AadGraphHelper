using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AadGraphApiHelper
{   
    public partial class MainForm : Form
    {
        private const string LastSelectedEnvironmentNameKey = @"LastSelectedEnvironmentName";

        private const string LastSelectedTenantCredentialKey = @"LastSelectedTenantCredentialKey";

        private const string LastSelectedMethodKey = @"LastSelectedMethod";

        private const string LastSelectedRequestUrlKey = @"LastSelectedRequestUrl";

        private const string LastSelectedResourceFirstKey = @"LastSelectedResourceFirst";

        private const string LastSelectedResourceSecondKey = @"LastSelectedResourceSecond";

        private const string LastSelectedIdKey = @"LastSelectedID";
        
        private const string LastSelectedApiVersionKey = @"LastSelectedApiVersion";

        private ResponseTable responseTable;

        private AadEnvironmentSet aadEnvironments;

        private readonly IDictionary<string, ISet<string>> resourcesDictionary = new Dictionary<string, ISet<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { Names.Users, new HashSet<string> { Names.MemberOf, Names.MemberOfLinks, Names.Manager, Names.ManagerLinks, Names.DirectReports, Names.DirectReportsLinks, Names.CheckMemberGroups, Names.GetMemberGroups } },
            { Names.Groups, new HashSet<string> {  Names.Members, Names.MembersLinks } },
            { Names.Applications, new HashSet<string> { Names.ExtensionProperties } },
            { Names.ServicePrincipals, new HashSet<string>() },
            { Names.TenantDetails, new HashSet<string>() },
        };

        public MainForm()
        {
            this.InitializeComponent();
            this.Store = new RegistryStore();
        }

        internal IStore Store { get; private set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string lastSelectedEnvironmentName = this.Store.GetPreference<string>(LastSelectedEnvironmentNameKey);
            string lastSelectedTenantCredential = this.Store.GetPreference<string>(LastSelectedTenantCredentialKey);
            this.PopulateEnvironments(this.Store.GetAadEnvironments(), lastSelectedEnvironmentName, lastSelectedTenantCredential);
            this.apiVersionComboBox.Items.Clear();
            foreach (string apiVersion in this.Store.GetApiVersions())
            {
                this.apiVersionComboBox.Items.Add(apiVersion);
            }

            this.resourceFirstComboBox.Items.Clear();
            foreach (string resourceFirst in this.resourcesDictionary.Keys)
            {
                this.resourceFirstComboBox.Items.Add(resourceFirst);
            }

            this.methodComboBox.SelectedItem = this.Store.GetPreference<string>(LastSelectedMethodKey);
            this.resourceFirstComboBox.SelectedItem = this.Store.GetPreference<string>(LastSelectedResourceFirstKey);
            this.apiVersionComboBox.SelectedItem = this.Store.GetPreference<string>(LastSelectedApiVersionKey);
            this.idTextBox.Text = this.Store.GetPreference<string>(LastSelectedIdKey);

            // This depends on method, resourceFirst, and id.
            this.PopulateResourcesSecond();

            this.resourceSecondComboBox.SelectedItem = this.Store.GetPreference<string>(LastSelectedResourceSecondKey);
            this.requestUrlTextBox.Text = this.Store.GetPreference<string>(LastSelectedRequestUrlKey);

            this.responseTable = new ResponseTable(this.responseDataGridView);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.SaveComboBoxPreference(this.EnvironmentComboBox, LastSelectedEnvironmentNameKey);
            this.SaveComboBoxPreference(this.TenantCredentialComboBox, LastSelectedTenantCredentialKey);
            this.SaveComboBoxPreference(this.methodComboBox, LastSelectedMethodKey);
            this.SaveComboBoxPreference(this.resourceFirstComboBox, LastSelectedResourceFirstKey);
            this.SaveComboBoxPreference(this.resourceSecondComboBox, LastSelectedResourceSecondKey);
            this.SaveComboBoxPreference(this.apiVersionComboBox, LastSelectedApiVersionKey);
            this.SaveTextBoxPreference(this.requestUrlTextBox, LastSelectedRequestUrlKey);
            this.SaveTextBoxPreference(this.idTextBox, LastSelectedIdKey);
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.responseTextBox.Text = String.Empty;
                this.responseTable.Clear();
                this.mainStatusStripStatusLabel.Text = null;

                string accessToken = this.tokenTextBox.Text;
                Request request = new Request(accessToken);
                HttpStatusCode httpStatusCode;
                string response;
                httpStatusCode = request.Send(this.methodComboBox.Text, this.requestUrlTextBox.Text, this.bodyTextBox.Text, out response);
                this.mainStatusStripStatusLabel.Text = (int)httpStatusCode + @": " + httpStatusCode;

                if (!String.IsNullOrEmpty(response))
                {
                    if (this.tabControl.SelectedTab == this.bodyTabPage)
                    {
                        this.tabControl.SelectedTab = this.responseTabPage;
                    }

                    this.responseTextBox.Text = JsonText.Format(response);
                    this.responseTextBox.SelectionLength = 0;

                    this.responseTable.SetJsonText(response);
                    this.responseTable.CreateResponseTable();
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.tabControl.SelectedTab = this.bodyTabPage;
                this.bodyTextBox.SelectionLength = 0;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getAppTokenButton_Click(object sender, EventArgs e)
        {
            TenantCredential tenantCredential = this.TenantCredentialComboBox.SelectedItem as TenantCredential;
            if (tenantCredential == null)
            {
                return;
            }

            Func<TenantCredential, string> getTokenFunc = Token.GetApplicationToken;
            if (tenantCredential.ApplicationType == ApplicationType.Native)
            {
                getTokenFunc = Token.GetUserToken;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.tokenTextBox.Text = getTokenFunc(tenantCredential);
                this.Cursor = Cursors.Default;
                this.UpdateRequestUrl();
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(exception.Message, StringResources.TokenErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateEnvironments(AadEnvironmentSet environments, string lastSelectedEnvironmentName = null, string lastSelectedTenantCredentialName = null)
        {
            this.EnvironmentComboBox.Items.Clear();
            this.aadEnvironments = environments;

            foreach (AadEnvironment environment in this.aadEnvironments)
            {
                this.EnvironmentComboBox.Items.Add(environment);
                if (environment.DisplayName.Equals(lastSelectedEnvironmentName, StringComparison.OrdinalIgnoreCase))
                {
                    this.EnvironmentComboBox.SelectedItem = environment;
                    this.PopulateTenantCredentials(environment, lastSelectedTenantCredentialName);
                }
            }

            this.EnvironmentComboBox.Items.Add(StringResources.ManageItem);
        }

        private void environmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EnvironmentComboBox.SelectedItem == null)
            {
                return;
            }

            if (this.EnvironmentComboBox.SelectedItem.Equals(StringResources.ManageItem))
            {
                new AddEnvironmentForm(this).ShowDialog();
            }
            else
            {
                this.PopulateTenantCredentials((AadEnvironment)this.EnvironmentComboBox.SelectedItem);
            }
        }

        private void PopulateTenantCredentials(AadEnvironment environment, string lastSelectedTenantCredential = null)
        {
            this.TenantCredentialComboBox.Items.Clear();
            foreach (TenantCredential tenantCredential in this.Store.GetTenantCredentials(environment))
            {
                this.TenantCredentialComboBox.Items.Add(tenantCredential);
                if (tenantCredential.ToString().Equals(lastSelectedTenantCredential, StringComparison.OrdinalIgnoreCase))
                {
                    this.TenantCredentialComboBox.SelectedItem = tenantCredential;
                }
            }

            this.TenantCredentialComboBox.Items.Add(StringResources.ManageItem);
            this.getAppTokenButton.Enabled = this.TenantCredentialComboBox.SelectedItem != null;
        }

        private void SaveComboBoxPreference(ComboBox comboBox, string key)
        {
            if (comboBox.SelectedItem != null)
            {
                this.Store.SavePreference(key, comboBox.SelectedItem.ToString());
            }
        }

        private void SaveTextBoxPreference(TextBox textBox, string key)
        {
            this.Store.SavePreference(key, textBox.Text);
        }

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateRequestUrl();
        }

        private void resourceFirstComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateResourcesSecond();
            this.UpdateRequestUrl();
        }

        private void PopulateResourcesSecond()
        {
            string selectedResourceFirst = this.resourceFirstComboBox.SelectedItem as string;
            this.resourceSecondComboBox.Items.Clear();

            if (selectedResourceFirst == null || String.IsNullOrWhiteSpace(this.idTextBox.Text))
            {
                this.resourceSecondComboBox.Enabled = false;
                return;
            }

            ISet<string> resourcesSecondSet;
            if (this.resourcesDictionary.TryGetValue(selectedResourceFirst, out resourcesSecondSet) && resourcesSecondSet.Count > 0)
            {
                this.resourceSecondComboBox.Items.Add(String.Empty);
                foreach (string resourceSecond in resourcesSecondSet)
                {
                    this.resourceSecondComboBox.Items.Add(resourceSecond);
                }
                
                this.resourceSecondComboBox.Enabled = this.resourceSecondComboBox.Items.Count > 0;
            }
            else
            {
                this.resourceSecondComboBox.Enabled = false;
            }
        }

        private void apiVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateRequestUrl();
        }

        private void TenantCredentialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TenantCredentialComboBox.SelectedItem == null)
            {
                this.getAppTokenButton.Enabled = false;
                return;
            }

            if (this.TenantCredentialComboBox.SelectedItem.Equals(StringResources.ManageItem))
            {
                this.getAppTokenButton.Enabled = false;
                new AddTenantCredentialForm(this).ShowDialog();
            }

            TenantCredential tenantCredential = this.TenantCredentialComboBox.SelectedItem as TenantCredential;
            if (tenantCredential == null)
            {
                this.getAppTokenButton.Enabled = false;
                return;
            }

            this.getAppTokenButton.Text = tenantCredential.ApplicationType == ApplicationType.Web
                                              ? StringResources.GetAppTokenText
                                              : StringResources.GetUserTokenText;
            this.getAppTokenButton.Enabled = true;
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            this.PopulateResourcesSecond();
            this.UpdateRequestUrl();
        }

        private void resourceSecondComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateRequestUrl();
        }

        private void UpdateRequestUrl()
        {
            GraphApiUrlBuilder urlBuilder = new GraphApiUrlBuilder();
            urlBuilder.Environment = this.EnvironmentComboBox.SelectedItem as AadEnvironment;
            urlBuilder.TenantCredential = this.TenantCredentialComboBox.SelectedItem as TenantCredential;
            urlBuilder.ResourceFirst = this.resourceFirstComboBox.SelectedItem as string;
            urlBuilder.ResourceId = this.idTextBox.Text;
            urlBuilder.ResourceSecond = this.resourceSecondComboBox.SelectedItem as string;
            urlBuilder.ApiVersion = this.apiVersionComboBox.SelectedItem as string;
            this.requestUrlTextBox.Text = urlBuilder.Url;
        }

        private void openTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string method = null;
            string resourceFirst = null;
            string id = null;
            string resourceSecond = null;
            string requestUrl = null;
            string body = null;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = @"request templates (*.rqt)|*.rqt|All files (*.*)|*.*";
                dialog.FilterIndex = 0;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(dialog.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            line = line.Trim();
                            if (line.Equals(@"===BODY===", StringComparison.OrdinalIgnoreCase))
                            {
                                body = reader.ReadToEnd();
                                break;
                            }

                            string[] parts = line.Split(new[] { @"===" }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length != 2)
                            {
                                continue;
                            }

                            switch (parts[0])
                            {
                                case @"Method":
                                    method = parts[1].Trim();
                                    break;
                                case @"ResourceFirst":
                                    resourceFirst = parts[1].Trim();
                                    break;
                                case @"ID":
                                    id = parts[1].Trim();
                                    break;
                                case @"ResourceSecond":
                                    resourceSecond = parts[1].Trim();
                                    break;
                                case @"RequestUrl":
                                    requestUrl = parts[1].Trim();
                                    break;
                            }
                        }
                    }
                }
            }

            this.methodComboBox.SelectedItem = method;
            this.resourceFirstComboBox.SelectedItem = resourceFirst;
            this.resourceSecondComboBox.SelectedItem = resourceSecond;
            this.idTextBox.Text = id ?? String.Empty;
            if (requestUrl != null) this.requestUrlTextBox.Text = requestUrl;

            this.bodyTextBox.Text = body;
            this.tabControl.SelectedTab = this.bodyTabPage;
            this.responseTextBox.Text = null;
            this.responseTable.Clear();
        }

        private void saveTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = @"request templates (*.rqt)|*.rqt|All files (*.*)|*.*";
                dialog.FilterIndex = 0;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        writer.WriteLine(@"Method==={0}", this.methodComboBox.Text ?? String.Empty);
                        writer.WriteLine(@"ResourceFirst==={0}", this.resourceFirstComboBox.SelectedItem ?? String.Empty);
                        writer.WriteLine(@"ID==={0}", this.idTextBox.Text ?? String.Empty);
                        writer.WriteLine(@"ResourceSecond==={0}", this.resourceSecondComboBox.SelectedItem ?? String.Empty);
                        writer.WriteLine(@"RequestUrl==={0}", this.requestUrlTextBox.Text ?? String.Empty);
                        writer.WriteLine(@"===BODY===");
                        writer.WriteLine(this.bodyTextBox.Text);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void responseGridContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasObjectId = !String.IsNullOrEmpty(this.responseTable.GetCellValueOfSelectedRow(Names.ObjectId));
            this.copyobjectIdToClipboardToolStripMenuItem.Enabled = hasObjectId;
            this.copyobjectIdToIRequestToolStripMenuItem.Enabled = hasObjectId;
        }

        private void copyobjectIdToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string objectId = this.responseTable.GetCellValueOfSelectedRow(Names.ObjectId);
            if (!String.IsNullOrEmpty(objectId))
            {
                Clipboard.SetText(objectId);
            }
        }

        private void copyObjectIdToRequestFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string objectId = this.responseTable.GetCellValueOfSelectedRow(Names.ObjectId);
            if (!String.IsNullOrEmpty(objectId))
            {
                this.idTextBox.Text = objectId;
            }
        }
    }
}
