using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        private GraphApiUrlBuilder urlBuilder = new GraphApiUrlBuilder();

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

            this.resourceFirstComboBox.Items.Clear();
            foreach (string resourceFirst in GraphApiEntityType.NavigationProperties.Keys)
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
            this.ExecuteRequest();
        }

        private void ExecuteRequest()
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
                RequestHistoryManager.Instance.AddRequest(this.methodComboBox.Text, this.requestUrlTextBox.Text, this.bodyTextBox.Text);
                httpStatusCode = request.Send(this.methodComboBox.Text, this.requestUrlTextBox.Text, this.bodyTextBox.Text, out response);
                this.mainStatusStripStatusLabel.Text = (int)httpStatusCode + @": " + httpStatusCode;

                if (!String.IsNullOrEmpty(response))
                {
                    if (this.tabControl.SelectedTab != this.responseBodyTabPage && this.tabControl.SelectedTab != this.responseTableTabPage)
                    {
                        this.tabControl.SelectedTab = this.responseBodyTabPage;
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
                this.tabControl.SelectedTab = this.requestBodyTabPage;
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
                this.urlBuilder.Environment = this.EnvironmentComboBox.SelectedItem as AadEnvironment;
                this.urlBuilder.TenantCredential = this.TenantCredentialComboBox.SelectedItem as TenantCredential;
                //this.UpdateRequestUrl();
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
        }

        private void environmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EnvironmentComboBox.SelectedItem == null)
            {
                return;
            }

            AadEnvironment environment = this.EnvironmentComboBox.SelectedItem as AadEnvironment;
            this.PopulateTenantCredentials(environment);
            this.urlBuilder.Environment = environment;

            this.apiVersionComboBox.Items.Clear();
            if (environment != null)
            {
                foreach (string apiVersion in environment.ApiVersions)
                {
                    this.apiVersionComboBox.Items.Add(apiVersion);
                }
            }
        }

        private void PopulateTenantCredentials(AadEnvironment environment, string lastSelectedTenantCredential = null)
        {
            if (environment == null)
            {
                return;
            }

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
        }

        private void PopulateResourcesSecond()
        {
            string selectedResourceFirst = this.resourceFirstComboBox.Text;
            this.resourceSecondComboBox.Items.Clear();
            this.resourceSecondComboBox.Text = null;

            if (String.IsNullOrWhiteSpace(selectedResourceFirst) || String.IsNullOrWhiteSpace(this.idTextBox.Text))
            {
                return;
            }

            ISet<string> resourcesSecondSet;
            if (GraphApiEntityType.NavigationProperties.TryGetValue(selectedResourceFirst, out resourcesSecondSet) && resourcesSecondSet.Count > 0)
            {
                this.resourceSecondComboBox.Items.Add(String.Empty);
                foreach (string resourceSecond in resourcesSecondSet)
                {
                    this.resourceSecondComboBox.Items.Add(resourceSecond);
                }
            }
        }

        private void apiVersionComboBox_TextChanged(object sender, EventArgs e)
        {
            this.urlBuilder.ApiVersion = this.apiVersionComboBox.Text;
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
            this.urlBuilder.TenantCredential = tenantCredential;
         
            this.UpdateRequestUrl();
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            this.urlBuilder.ResourceId = this.idTextBox.Text;
            this.PopulateResourcesSecond();
            this.UpdateRequestUrl();
        }

        private void resourceFirstComboBox_TextChanged(object sender, EventArgs e)
        {
            this.urlBuilder.ResourceFirst = this.resourceFirstComboBox.Text;
            this.idTextBox.Text = null;
            this.urlBuilder.FilterComponents.Clear();
            this.PopulateResourcesSecond();
            this.UpdateRequestUrl();
        }

        private void resourceSecondComboBox_TextChanged(object sender, EventArgs e)
        {
            this.urlBuilder.ResourceSecond = this.resourceSecondComboBox.Text;
            this.UpdateRequestUrl();
        }

        private void UpdateRequestUrl()
        {
            this.requestUrlTextBox.Text = this.urlBuilder.CreateUrl();
        }

        private void openTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string method = null;
            string resourceFirst = null;
            string id = null;
            string resourceSecond = null;
            string apiVersion = null;
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
                                case @"ApiVersion":
                                    apiVersion = parts[1].Trim();
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    // The user pressed cancel or closed the dialog box, do not do anything, and return.
                    return;
                }
            }

            this.methodComboBox.SelectedItem = method;
            this.resourceFirstComboBox.Text = resourceFirst;
            this.idTextBox.Text = id ?? String.Empty;
            this.resourceSecondComboBox.Text = resourceSecond;

            if (!String.IsNullOrEmpty(apiVersion))
            {
                this.apiVersionComboBox.Text = apiVersion;
            }

            this.UpdateRequestUrl();

            this.bodyTextBox.Text = body;
            this.tabControl.SelectedTab = this.requestBodyTabPage;
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
                        writer.WriteLine(@"ResourceFirst==={0}", this.resourceFirstComboBox.Text ?? String.Empty);
                        writer.WriteLine(@"ID==={0}", this.idTextBox.Text ?? String.Empty);
                        writer.WriteLine(@"ResourceSecond==={0}", this.resourceSecondComboBox.Text ?? String.Empty);
                        writer.WriteLine(@"ApiVersion==={0}", this.apiVersionComboBox.Text ?? String.Empty);
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
            HideAllContextMenuItems(this.responseGridContextMenuStrip);
            this.copyCellValueToClipboardToolStripMenuItem.Visible = true;
            this.MakeContextMenuCopyPropertyItemVisible(Names.ObjectId, this.copyObjectIdToRequestToolStripMenuItem);
            this.MakeContextMenuCopyPropertyItemVisible(Names.Id, this.copyIdToRequestToolStripMenuItem);
            this.MakeContextMenuCopyPropertyItemVisible(Names.UserPrincipalName, this.copyUserPrincipalNameToRequestToolStripMenuItem);
        }

        private static void HideAllContextMenuItems(ContextMenuStrip menuStrip)
        {
            foreach (ToolStripItem item in menuStrip.Items)
            {
                item.Visible = false;
            }
        }

        private void MakeContextMenuCopyPropertyItemVisible(string propertyName, ToolStripItem toolStripItem)
        {
            if (!String.IsNullOrEmpty(this.responseTable.GetCellValueFromSelectedRow(propertyName)))
            {
                toolStripItem.Visible = true;
            }
        }

        private void CopyCellValueToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = this.responseTable.GetCellValueOfSelectedCell();
            if (!String.IsNullOrEmpty(value))
            {
                Clipboard.SetText(value);
            }
        }

        private void copyObjectIdToRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyCellValueToClipboard(Names.ObjectId);
        }

        private void copyIdToRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyCellValueToClipboard(Names.Id);
        }

        private void copyUserPrincipalNameToRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyCellValueToClipboard(Names.UserPrincipalName);
        }

        private void CopyCellValueToClipboard(string columnName)
        {
            string value = this.responseTable.GetCellValueFromSelectedRow(columnName);
            if (!String.IsNullOrEmpty(value))
            {
                this.idTextBox.Text = value;
            }
        }

        private void createSearchfilterQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryBuilderForm queryBuilder = new QueryBuilderForm();
            queryBuilder.UrlBuilder = this.urlBuilder;
            DialogResult result = queryBuilder.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }

            this.UpdateRequestUrl();

            if (result == DialogResult.Yes)
            {
                this.ExecuteRequest();
            }
        }

        private void clearExistingfilterQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.urlBuilder.FilterComponents.Clear();
            this.UpdateRequestUrl();
        }

        private void requestUrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ExecuteRequest();
            }
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            ShowHistory();
        }

        private void ShowHistory()
        {
            RequestHistoryWindow window = new RequestHistoryWindow();
            DialogResult dr = window.ShowDialog();

            if (dr == DialogResult.OK && window.RowSelected >= 0)
            {
                var item = window.ViewRequestHistoryObjects[window.RowSelected];
                this.methodComboBox.Text = item.Method;
                this.requestUrlTextBox.Text = item.Url;
                this.bodyTextBox.Text = item.Body;

                RequestHistoryManager.Instance.SaveHistoryToDisk();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Path.GetTempPath()+ Guid.NewGuid().ToString() + ".txt"; ;

            string text = String.IsNullOrEmpty(responseTextBox.SelectedText) ? responseTextBox.Text : responseTextBox.SelectedText;
            File.WriteAllText(filename, text);
            Process.Start(filename);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenantCredential tenantCredential = this.TenantCredentialComboBox.SelectedItem as TenantCredential;

            if (tenantCredential == null)
            {
                return;
            }

            string messageFormat = "Deleting Following Tenant: \n Env: {0}\n Tenant: {1}\n Client ID: {2}: \n Application type:{3}";
            string message = String.Format(messageFormat, tenantCredential.Environment, tenantCredential.Tenant, tenantCredential.ClientId, tenantCredential.ApplicationType);

            DialogResult dr = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                bool res= Store.Delete(tenantCredential);

                MessageBox.Show("Delete was " + ((res) ? "successful" : "Unsuccessful"));

                if (res)
                {
                    TenantCredentialComboBox.Items.Remove(tenantCredential);
                }
            }

        }

        private void tokenTextBox_DoubleClick(object sender, EventArgs e)
        {
            string token = tokenTextBox.Text;
            token = token.Remove(0, token.IndexOf(" ") + 1);
            ShowJwtInBrowser(token);
        }

        private void ShowJwtInBrowser(string token)
        {
            var url = "https://jwt.io/?value=" + token;
            //var info = new ProcessStartInfo(url);
            //Process.Start(info);

            // using default browser method of Process.Start(url) considers the url as exe and trims it to certain
            // max limit. 
            Process.Start("chrome.exe", url);
        }

        private void jwtioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string token = responseTextBox.SelectedText;
            ShowJwtInBrowser(token);
        }

        private void historyMenuItem_Click(object sender, EventArgs e)
        {
            ShowHistory();
        }

        private void historyButton_Click_1(object sender, EventArgs e)
        {
            ShowHistory();
        }

        private void pFATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msauth = "MSAuth";
            string pfat = "PFAT";
            int msAuthStart = responseTextBox.Text.IndexOf(msauth, StringComparison.OrdinalIgnoreCase);
            int pfatEnd = responseTextBox.Text.IndexOf(pfat, StringComparison.OrdinalIgnoreCase) + pfat.Length + 2;

            string token = responseTextBox.Text.Substring(msAuthStart, pfatEnd - msAuthStart);
            token = token.Replace("\\\"","\"");
            Clipboard.SetText(token);
            SetStatusMessage("PFAT Token copied to clipboard!");
        }

        private void SetStatusMessage(string msg)
        {
            mainStatusStripStatusLabel.Text = msg;
        }
    }
}
