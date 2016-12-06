using System.Windows.Forms;

namespace AadGraphApiHelper
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tenantLabel = new System.Windows.Forms.Label();
            this.TenantCredentialComboBox = new System.Windows.Forms.ComboBox();
            this.getAppTokenButton = new System.Windows.Forms.Button();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.tokenTextBox = new System.Windows.Forms.TextBox();
            this.environmentLabel = new System.Windows.Forms.Label();
            this.EnvironmentComboBox = new System.Windows.Forms.ComboBox();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.requestUrlLabel = new System.Windows.Forms.Label();
            this.requestUrlTextBox = new System.Windows.Forms.TextBox();
            this.resourceFirstComboBox = new System.Windows.Forms.ComboBox();
            this.entitySetLabel = new System.Windows.Forms.Label();
            this.apiVersionLabel = new System.Windows.Forms.Label();
            this.apiVersionComboBox = new System.Windows.Forms.ComboBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.requestBodyTabPage = new System.Windows.Forms.TabPage();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.responseBodyTabPage = new System.Windows.Forms.TabPage();
            this.responseTableTabPage = new System.Windows.Forms.TabPage();
            this.responseDataGridView = new System.Windows.Forms.DataGridView();
            this.responseGridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCellValueToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIdToRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyObjectIdToRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyUserPrincipalNameToRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceSecondComboBox = new System.Windows.Forms.ComboBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSearchfilterQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearExistingfilterQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainStatusStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.historyButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.requestBodyTabPage.SuspendLayout();
            this.responseBodyTabPage.SuspendLayout();
            this.responseTableTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.responseDataGridView)).BeginInit();
            this.responseGridContextMenuStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tenantLabel
            // 
            this.tenantLabel.AutoSize = true;
            this.tenantLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenantLabel.Location = new System.Drawing.Point(275, 0);
            this.tenantLabel.Name = "tenantLabel";
            this.tenantLabel.Size = new System.Drawing.Size(156, 33);
            this.tenantLabel.TabIndex = 4;
            this.tenantLabel.Text = "&Tenant/Credential:";
            this.tenantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TenantCredentialComboBox
            // 
            this.TenantCredentialComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TenantCredentialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TenantCredentialComboBox.FormattingEnabled = true;
            this.TenantCredentialComboBox.Location = new System.Drawing.Point(437, 4);
            this.TenantCredentialComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TenantCredentialComboBox.MaxDropDownItems = 20;
            this.TenantCredentialComboBox.Name = "TenantCredentialComboBox";
            this.TenantCredentialComboBox.Size = new System.Drawing.Size(391, 25);
            this.TenantCredentialComboBox.TabIndex = 5;
            this.TenantCredentialComboBox.SelectedIndexChanged += new System.EventHandler(this.TenantCredentialComboBox_SelectedIndexChanged);
            // 
            // getAppTokenButton
            // 
            this.getAppTokenButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.getAppTokenButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.getAppTokenButton.Location = new System.Drawing.Point(839, 4);
            this.getAppTokenButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.getAppTokenButton.Name = "getAppTokenButton";
            this.getAppTokenButton.Size = new System.Drawing.Size(142, 25);
            this.getAppTokenButton.TabIndex = 6;
            this.getAppTokenButton.Text = "Get &app. token";
            this.getAppTokenButton.UseVisualStyleBackColor = true;
            this.getAppTokenButton.Click += new System.EventHandler(this.getAppTokenButton_Click);
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokenLabel.Location = new System.Drawing.Point(3, 0);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(114, 33);
            this.tokenLabel.TabIndex = 8;
            this.tokenLabel.Text = "To&ken:";
            this.tokenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tokenTextBox
            // 
            this.tokenTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokenTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.tokenTextBox.Location = new System.Drawing.Point(123, 4);
            this.tokenTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tokenTextBox.Name = "tokenTextBox";
            this.tokenTextBox.Size = new System.Drawing.Size(858, 25);
            this.tokenTextBox.TabIndex = 9;
            // 
            // environmentLabel
            // 
            this.environmentLabel.AutoSize = true;
            this.environmentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentLabel.Location = new System.Drawing.Point(3, 0);
            this.environmentLabel.Name = "environmentLabel";
            this.environmentLabel.Size = new System.Drawing.Size(114, 33);
            this.environmentLabel.TabIndex = 2;
            this.environmentLabel.Text = "&Environment:";
            this.environmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnvironmentComboBox
            // 
            this.EnvironmentComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnvironmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnvironmentComboBox.FormattingEnabled = true;
            this.EnvironmentComboBox.Location = new System.Drawing.Point(123, 4);
            this.EnvironmentComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EnvironmentComboBox.Name = "EnvironmentComboBox";
            this.EnvironmentComboBox.Size = new System.Drawing.Size(146, 25);
            this.EnvironmentComboBox.TabIndex = 3;
            this.EnvironmentComboBox.SelectedIndexChanged += new System.EventHandler(this.environmentComboBox_SelectedIndexChanged);
            // 
            // responseTextBox
            // 
            this.responseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.responseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.responseTextBox.Location = new System.Drawing.Point(3, 4);
            this.responseTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseTextBox.Multiline = true;
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseTextBox.Size = new System.Drawing.Size(970, 395);
            this.responseTextBox.TabIndex = 95;
            // 
            // requestUrlLabel
            // 
            this.requestUrlLabel.AutoSize = true;
            this.requestUrlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestUrlLabel.Location = new System.Drawing.Point(73, 0);
            this.requestUrlLabel.Name = "requestUrlLabel";
            this.requestUrlLabel.Size = new System.Drawing.Size(94, 33);
            this.requestUrlLabel.TabIndex = 21;
            this.requestUrlLabel.Text = "Request &URL:";
            this.requestUrlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // requestUrlTextBox
            // 
            this.requestUrlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestUrlTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.requestUrlTextBox.Location = new System.Drawing.Point(173, 4);
            this.requestUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.requestUrlTextBox.Name = "requestUrlTextBox";
            this.requestUrlTextBox.Size = new System.Drawing.Size(688, 25);
            this.requestUrlTextBox.TabIndex = 22;
            this.requestUrlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.requestUrlTextBox_KeyDown);
            // 
            // resourceFirstComboBox
            // 
            this.resourceFirstComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceFirstComboBox.FormattingEnabled = true;
            this.resourceFirstComboBox.Location = new System.Drawing.Point(324, 4);
            this.resourceFirstComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resourceFirstComboBox.Name = "resourceFirstComboBox";
            this.resourceFirstComboBox.Size = new System.Drawing.Size(130, 25);
            this.resourceFirstComboBox.TabIndex = 14;
            this.resourceFirstComboBox.TextChanged += new System.EventHandler(this.resourceFirstComboBox_TextChanged);
            // 
            // entitySetLabel
            // 
            this.entitySetLabel.AutoSize = true;
            this.entitySetLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entitySetLabel.Location = new System.Drawing.Point(214, 0);
            this.entitySetLabel.Name = "entitySetLabel";
            this.entitySetLabel.Size = new System.Drawing.Size(104, 33);
            this.entitySetLabel.TabIndex = 13;
            this.entitySetLabel.Text = "&Entity/Func:";
            this.entitySetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // apiVersionLabel
            // 
            this.apiVersionLabel.AutoSize = true;
            this.apiVersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apiVersionLabel.Location = new System.Drawing.Point(784, 0);
            this.apiVersionLabel.Name = "apiVersionLabel";
            this.apiVersionLabel.Size = new System.Drawing.Size(104, 33);
            this.apiVersionLabel.TabIndex = 18;
            this.apiVersionLabel.Text = "Api Version:";
            this.apiVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // apiVersionComboBox
            // 
            this.apiVersionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apiVersionComboBox.FormattingEnabled = true;
            this.apiVersionComboBox.Location = new System.Drawing.Point(894, 4);
            this.apiVersionComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.apiVersionComboBox.Name = "apiVersionComboBox";
            this.apiVersionComboBox.Size = new System.Drawing.Size(87, 25);
            this.apiVersionComboBox.Sorted = true;
            this.apiVersionComboBox.TabIndex = 19;
            this.apiVersionComboBox.TextChanged += new System.EventHandler(this.apiVersionComboBox_TextChanged);
            // 
            // executeButton
            // 
            this.executeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executeButton.Location = new System.Drawing.Point(867, 4);
            this.executeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(114, 25);
            this.executeButton.TabIndex = 23;
            this.executeButton.Text = "E&xecute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idLabel.Location = new System.Drawing.Point(460, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(54, 33);
            this.idLabel.TabIndex = 15;
            this.idLabel.Text = "&ID:";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idTextBox
            // 
            this.idTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idTextBox.Location = new System.Drawing.Point(520, 4);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(149, 25);
            this.idTextBox.TabIndex = 16;
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "&Method:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // methodComboBox
            // 
            this.methodComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "DELETE",
            "GET",
            "PATCH",
            "POST"});
            this.methodComboBox.Location = new System.Drawing.Point(123, 4);
            this.methodComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(85, 25);
            this.methodComboBox.Sorted = true;
            this.methodComboBox.TabIndex = 12;
            this.methodComboBox.SelectedIndexChanged += new System.EventHandler(this.methodComboBox_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.requestBodyTabPage);
            this.tabControl.Controls.Add(this.responseBodyTabPage);
            this.tabControl.Controls.Add(this.responseTableTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 156);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 433);
            this.tabControl.TabIndex = 90;
            // 
            // requestBodyTabPage
            // 
            this.requestBodyTabPage.Controls.Add(this.bodyTextBox);
            this.requestBodyTabPage.Location = new System.Drawing.Point(4, 26);
            this.requestBodyTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.requestBodyTabPage.Name = "requestBodyTabPage";
            this.requestBodyTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.requestBodyTabPage.Size = new System.Drawing.Size(976, 403);
            this.requestBodyTabPage.TabIndex = 0;
            this.requestBodyTabPage.Text = "Request Body";
            this.requestBodyTabPage.UseVisualStyleBackColor = true;
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bodyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.bodyTextBox.Location = new System.Drawing.Point(3, 4);
            this.bodyTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bodyTextBox.Size = new System.Drawing.Size(970, 395);
            this.bodyTextBox.TabIndex = 91;
            // 
            // responseBodyTabPage
            // 
            this.responseBodyTabPage.Controls.Add(this.responseTextBox);
            this.responseBodyTabPage.Location = new System.Drawing.Point(4, 26);
            this.responseBodyTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseBodyTabPage.Name = "responseBodyTabPage";
            this.responseBodyTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseBodyTabPage.Size = new System.Drawing.Size(976, 403);
            this.responseBodyTabPage.TabIndex = 1;
            this.responseBodyTabPage.Text = "Response Body";
            this.responseBodyTabPage.UseVisualStyleBackColor = true;
            // 
            // responseTableTabPage
            // 
            this.responseTableTabPage.Controls.Add(this.responseDataGridView);
            this.responseTableTabPage.Location = new System.Drawing.Point(4, 26);
            this.responseTableTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseTableTabPage.Name = "responseTableTabPage";
            this.responseTableTabPage.Size = new System.Drawing.Size(976, 403);
            this.responseTableTabPage.TabIndex = 2;
            this.responseTableTabPage.Text = "Response Table";
            this.responseTableTabPage.UseVisualStyleBackColor = true;
            // 
            // responseDataGridView
            // 
            this.responseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.responseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.responseDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.responseDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.responseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.responseDataGridView.ContextMenuStrip = this.responseGridContextMenuStrip;
            this.responseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseDataGridView.Location = new System.Drawing.Point(0, 0);
            this.responseDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseDataGridView.Name = "responseDataGridView";
            this.responseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.responseDataGridView.Size = new System.Drawing.Size(976, 403);
            this.responseDataGridView.TabIndex = 99;
            // 
            // responseGridContextMenuStrip
            // 
            this.responseGridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCellValueToClipboardToolStripMenuItem,
            this.copyIdToRequestToolStripMenuItem,
            this.copyObjectIdToRequestToolStripMenuItem,
            this.copyUserPrincipalNameToRequestToolStripMenuItem});
            this.responseGridContextMenuStrip.Name = "responseGridContextMenuStrip";
            this.responseGridContextMenuStrip.Size = new System.Drawing.Size(262, 92);
            this.responseGridContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.responseGridContextMenuStrip_Opening);
            // 
            // copyCellValueToClipboardToolStripMenuItem
            // 
            this.copyCellValueToClipboardToolStripMenuItem.Name = "copyCellValueToClipboardToolStripMenuItem";
            this.copyCellValueToClipboardToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.copyCellValueToClipboardToolStripMenuItem.Text = "&Copy cell value to clipboard";
            this.copyCellValueToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyCellValueToClipboardToolStripMenuItem_Click);
            // 
            // copyIdToRequestToolStripMenuItem
            // 
            this.copyIdToRequestToolStripMenuItem.Name = "copyIdToRequestToolStripMenuItem";
            this.copyIdToRequestToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.copyIdToRequestToolStripMenuItem.Text = "Copy &Id to request";
            this.copyIdToRequestToolStripMenuItem.Click += new System.EventHandler(this.copyIdToRequestToolStripMenuItem_Click);
            // 
            // copyObjectIdToRequestToolStripMenuItem
            // 
            this.copyObjectIdToRequestToolStripMenuItem.Name = "copyObjectIdToRequestToolStripMenuItem";
            this.copyObjectIdToRequestToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.copyObjectIdToRequestToolStripMenuItem.Text = "Copy &objectId to request";
            this.copyObjectIdToRequestToolStripMenuItem.Click += new System.EventHandler(this.copyObjectIdToRequestToolStripMenuItem_Click);
            // 
            // copyUserPrincipalNameToRequestToolStripMenuItem
            // 
            this.copyUserPrincipalNameToRequestToolStripMenuItem.Name = "copyUserPrincipalNameToRequestToolStripMenuItem";
            this.copyUserPrincipalNameToRequestToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.copyUserPrincipalNameToRequestToolStripMenuItem.Text = "Copy &userPrincipalName to request";
            this.copyUserPrincipalNameToRequestToolStripMenuItem.Click += new System.EventHandler(this.copyUserPrincipalNameToRequestToolStripMenuItem_Click);
            // 
            // resourceSecondComboBox
            // 
            this.resourceSecondComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceSecondComboBox.FormattingEnabled = true;
            this.resourceSecondComboBox.Location = new System.Drawing.Point(675, 4);
            this.resourceSecondComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resourceSecondComboBox.Name = "resourceSecondComboBox";
            this.resourceSecondComboBox.Size = new System.Drawing.Size(103, 25);
            this.resourceSecondComboBox.Sorted = true;
            this.resourceSecondComboBox.TabIndex = 17;
            this.resourceSecondComboBox.TextChanged += new System.EventHandler(this.resourceSecondComboBox_TextChanged);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.queryToolStripMenuItem});
            this.mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(984, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTemplateToolStripMenuItem,
            this.saveTemplateToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "&FILE";
            // 
            // openTemplateToolStripMenuItem
            // 
            this.openTemplateToolStripMenuItem.Name = "openTemplateToolStripMenuItem";
            this.openTemplateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openTemplateToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openTemplateToolStripMenuItem.Text = "&Open template...";
            this.openTemplateToolStripMenuItem.Click += new System.EventHandler(this.openTemplateToolStripMenuItem_Click);
            // 
            // saveTemplateToolStripMenuItem
            // 
            this.saveTemplateToolStripMenuItem.Name = "saveTemplateToolStripMenuItem";
            this.saveTemplateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveTemplateToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.saveTemplateToolStripMenuItem.Text = "&Save template...";
            this.saveTemplateToolStripMenuItem.Click += new System.EventHandler(this.saveTemplateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSearchfilterQueryToolStripMenuItem,
            this.clearExistingfilterQueryToolStripMenuItem});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.queryToolStripMenuItem.Text = "&QUERY";
            // 
            // createSearchfilterQueryToolStripMenuItem
            // 
            this.createSearchfilterQueryToolStripMenuItem.Name = "createSearchfilterQueryToolStripMenuItem";
            this.createSearchfilterQueryToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.createSearchfilterQueryToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.createSearchfilterQueryToolStripMenuItem.Text = "Create search (filter) query...";
            this.createSearchfilterQueryToolStripMenuItem.Click += new System.EventHandler(this.createSearchfilterQueryToolStripMenuItem_Click);
            // 
            // clearExistingfilterQueryToolStripMenuItem
            // 
            this.clearExistingfilterQueryToolStripMenuItem.Name = "clearExistingfilterQueryToolStripMenuItem";
            this.clearExistingfilterQueryToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.clearExistingfilterQueryToolStripMenuItem.Text = "Clear existing (filter) query";
            this.clearExistingfilterQueryToolStripMenuItem.Click += new System.EventHandler(this.clearExistingfilterQueryToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 589);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(984, 22);
            this.mainStatusStrip.TabIndex = 93;
            // 
            // mainStatusStripStatusLabel
            // 
            this.mainStatusStripStatusLabel.Name = "mainStatusStripStatusLabel";
            this.mainStatusStripStatusLabel.Size = new System.Drawing.Size(60, 17);
            this.mainStatusStripStatusLabel.Text = "Welcome!";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.64228F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.35772F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.environmentLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EnvironmentComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tenantLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.TenantCredentialComboBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.getAppTokenButton, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 33);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tokenLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tokenTextBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 57);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(984, 33);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 9;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.625F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.4375F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.5625F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.625F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.methodComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.entitySetLabel, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.resourceFirstComboBox, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.apiVersionComboBox, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.idLabel, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.resourceSecondComboBox, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.idTextBox, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.apiVersionLabel, 7, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 90);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(984, 33);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.Controls.Add(this.requestUrlLabel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.requestUrlTextBox, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.executeButton, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.historyButton, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 123);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(984, 33);
            this.tableLayoutPanel4.TabIndex = 20;
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(3, 3);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(64, 27);
            this.historyButton.TabIndex = 24;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Aad Graph API Buddy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.requestBodyTabPage.ResumeLayout(false);
            this.requestBodyTabPage.PerformLayout();
            this.responseBodyTabPage.ResumeLayout(false);
            this.responseBodyTabPage.PerformLayout();
            this.responseTableTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.responseDataGridView)).EndInit();
            this.responseGridContextMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tenantLabel;
        private System.Windows.Forms.Button getAppTokenButton;
        private System.Windows.Forms.Label tokenLabel;
        private System.Windows.Forms.TextBox tokenTextBox;
        private System.Windows.Forms.Label environmentLabel;
        private System.Windows.Forms.TextBox responseTextBox;
        private System.Windows.Forms.Label requestUrlLabel;
        private System.Windows.Forms.TextBox requestUrlTextBox;
        private System.Windows.Forms.ComboBox resourceFirstComboBox;
        private System.Windows.Forms.Label entitySetLabel;
        private System.Windows.Forms.Label apiVersionLabel;
        private System.Windows.Forms.ComboBox apiVersionComboBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox methodComboBox;
        internal System.Windows.Forms.ComboBox EnvironmentComboBox;
        internal System.Windows.Forms.ComboBox TenantCredentialComboBox;
        private TabControl tabControl;
        private TabPage requestBodyTabPage;
        private TabPage responseBodyTabPage;
        private TextBox bodyTextBox;
        private TabPage responseTableTabPage;
        private DataGridView responseDataGridView;
        private ComboBox resourceSecondComboBox;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openTemplateToolStripMenuItem;
        private ToolStripMenuItem saveTemplateToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ContextMenuStrip responseGridContextMenuStrip;
        private ToolStripMenuItem copyCellValueToClipboardToolStripMenuItem;
        private StatusStrip mainStatusStrip;
        private ToolStripStatusLabel mainStatusStripStatusLabel;
        private ToolStripMenuItem queryToolStripMenuItem;
        private ToolStripMenuItem createSearchfilterQueryToolStripMenuItem;
        private ToolStripMenuItem clearExistingfilterQueryToolStripMenuItem;
        private ToolStripMenuItem copyObjectIdToRequestToolStripMenuItem;
        private ToolStripMenuItem copyUserPrincipalNameToRequestToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private ToolStripMenuItem copyIdToRequestToolStripMenuItem;
        private Button historyButton;
    }
}

