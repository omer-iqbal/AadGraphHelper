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
            this.requestHeadersTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.requestBodyTabPage = new System.Windows.Forms.TabPage();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.responseBodyTabPage = new System.Windows.Forms.TabPage();
            this.responseTableTabPage = new System.Windows.Forms.TabPage();
            this.responseDataGridView = new System.Windows.Forms.DataGridView();
            this.responseGridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCellValueToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabControl.SuspendLayout();
            this.requestHeadersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.requestBodyTabPage.SuspendLayout();
            this.responseBodyTabPage.SuspendLayout();
            this.responseTableTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.responseDataGridView)).BeginInit();
            this.responseGridContextMenuStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tenantLabel
            // 
            this.tenantLabel.AutoSize = true;
            this.tenantLabel.Location = new System.Drawing.Point(404, 31);
            this.tenantLabel.Name = "tenantLabel";
            this.tenantLabel.Size = new System.Drawing.Size(121, 19);
            this.tenantLabel.TabIndex = 4;
            this.tenantLabel.Text = "&Tenant/Credential:";
            // 
            // TenantCredentialComboBox
            // 
            this.TenantCredentialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TenantCredentialComboBox.FormattingEnabled = true;
            this.TenantCredentialComboBox.Location = new System.Drawing.Point(531, 28);
            this.TenantCredentialComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TenantCredentialComboBox.MaxDropDownItems = 20;
            this.TenantCredentialComboBox.Name = "TenantCredentialComboBox";
            this.TenantCredentialComboBox.Size = new System.Drawing.Size(435, 25);
            this.TenantCredentialComboBox.TabIndex = 5;
            this.TenantCredentialComboBox.SelectedIndexChanged += new System.EventHandler(this.TenantCredentialComboBox_SelectedIndexChanged);
            // 
            // getAppTokenButton
            // 
            this.getAppTokenButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.getAppTokenButton.Location = new System.Drawing.Point(1031, 27);
            this.getAppTokenButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.getAppTokenButton.Name = "getAppTokenButton";
            this.getAppTokenButton.Size = new System.Drawing.Size(125, 27);
            this.getAppTokenButton.TabIndex = 7;
            this.getAppTokenButton.Text = "Get &app. token";
            this.getAppTokenButton.UseVisualStyleBackColor = true;
            this.getAppTokenButton.Click += new System.EventHandler(this.getAppTokenButton_Click);
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Location = new System.Drawing.Point(13, 67);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(49, 19);
            this.tokenLabel.TabIndex = 8;
            this.tokenLabel.Text = "To&ken:";
            // 
            // tokenTextBox
            // 
            this.tokenTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.tokenTextBox.Location = new System.Drawing.Point(68, 64);
            this.tokenTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tokenTextBox.Name = "tokenTextBox";
            this.tokenTextBox.Size = new System.Drawing.Size(1089, 25);
            this.tokenTextBox.TabIndex = 9;
            // 
            // environmentLabel
            // 
            this.environmentLabel.AutoSize = true;
            this.environmentLabel.Location = new System.Drawing.Point(14, 31);
            this.environmentLabel.Name = "environmentLabel";
            this.environmentLabel.Size = new System.Drawing.Size(90, 19);
            this.environmentLabel.TabIndex = 1;
            this.environmentLabel.Text = "&Environment:";
            // 
            // EnvironmentComboBox
            // 
            this.EnvironmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnvironmentComboBox.FormattingEnabled = true;
            this.EnvironmentComboBox.Location = new System.Drawing.Point(109, 28);
            this.EnvironmentComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EnvironmentComboBox.Name = "EnvironmentComboBox";
            this.EnvironmentComboBox.Size = new System.Drawing.Size(256, 25);
            this.EnvironmentComboBox.TabIndex = 2;
            this.EnvironmentComboBox.SelectedIndexChanged += new System.EventHandler(this.environmentComboBox_SelectedIndexChanged);
            // 
            // responseTextBox
            // 
            this.responseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.responseTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.responseTextBox.Location = new System.Drawing.Point(0, 0);
            this.responseTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseTextBox.Multiline = true;
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseTextBox.Size = new System.Drawing.Size(1162, 624);
            this.responseTextBox.TabIndex = 95;
            // 
            // requestUrlLabel
            // 
            this.requestUrlLabel.AutoSize = true;
            this.requestUrlLabel.Location = new System.Drawing.Point(14, 139);
            this.requestUrlLabel.Name = "requestUrlLabel";
            this.requestUrlLabel.Size = new System.Drawing.Size(90, 19);
            this.requestUrlLabel.TabIndex = 61;
            this.requestUrlLabel.Text = "Request &URL:";
            // 
            // requestUrlTextBox
            // 
            this.requestUrlTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.requestUrlTextBox.Location = new System.Drawing.Point(120, 136);
            this.requestUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.requestUrlTextBox.Name = "requestUrlTextBox";
            this.requestUrlTextBox.Size = new System.Drawing.Size(933, 25);
            this.requestUrlTextBox.TabIndex = 62;
            // 
            // resourceFirstComboBox
            // 
            this.resourceFirstComboBox.FormattingEnabled = true;
            this.resourceFirstComboBox.Location = new System.Drawing.Point(303, 100);
            this.resourceFirstComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resourceFirstComboBox.Name = "resourceFirstComboBox";
            this.resourceFirstComboBox.Size = new System.Drawing.Size(144, 25);
            this.resourceFirstComboBox.TabIndex = 32;
            this.resourceFirstComboBox.TextChanged += new System.EventHandler(this.resourceFirstComboBox_TextChanged);
            // 
            // entitySetLabel
            // 
            this.entitySetLabel.AutoSize = true;
            this.entitySetLabel.Location = new System.Drawing.Point(207, 103);
            this.entitySetLabel.Name = "entitySetLabel";
            this.entitySetLabel.Size = new System.Drawing.Size(81, 19);
            this.entitySetLabel.TabIndex = 31;
            this.entitySetLabel.Text = "&Entity/Func:";
            // 
            // apiVersionLabel
            // 
            this.apiVersionLabel.AutoSize = true;
            this.apiVersionLabel.Location = new System.Drawing.Point(945, 103);
            this.apiVersionLabel.Name = "apiVersionLabel";
            this.apiVersionLabel.Size = new System.Drawing.Size(82, 19);
            this.apiVersionLabel.TabIndex = 51;
            this.apiVersionLabel.Text = "Api Version:";
            // 
            // apiVersionComboBox
            // 
            this.apiVersionComboBox.FormattingEnabled = true;
            this.apiVersionComboBox.Location = new System.Drawing.Point(1042, 100);
            this.apiVersionComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.apiVersionComboBox.Name = "apiVersionComboBox";
            this.apiVersionComboBox.Size = new System.Drawing.Size(114, 25);
            this.apiVersionComboBox.Sorted = true;
            this.apiVersionComboBox.TabIndex = 52;
            this.apiVersionComboBox.TextChanged += new System.EventHandler(this.apiVersionComboBox_TextChanged);
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(1069, 135);
            this.executeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(87, 27);
            this.executeButton.TabIndex = 81;
            this.executeButton.Text = "E&xecute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(464, 103);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(26, 19);
            this.idLabel.TabIndex = 41;
            this.idLabel.Text = "&ID:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(505, 100);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(238, 25);
            this.idTextBox.TabIndex = 42;
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "&Method:";
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "DELETE",
            "GET",
            "PATCH",
            "POST"});
            this.methodComboBox.Location = new System.Drawing.Point(89, 100);
            this.methodComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(99, 25);
            this.methodComboBox.Sorted = true;
            this.methodComboBox.TabIndex = 22;
            this.methodComboBox.SelectedIndexChanged += new System.EventHandler(this.methodComboBox_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.requestHeadersTabPage);
            this.tabControl.Controls.Add(this.requestBodyTabPage);
            this.tabControl.Controls.Add(this.responseBodyTabPage);
            this.tabControl.Controls.Add(this.responseTableTabPage);
            this.tabControl.Location = new System.Drawing.Point(2, 179);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1170, 650);
            this.tabControl.TabIndex = 90;
            // 
            // requestHeadersTabPage
            // 
            this.requestHeadersTabPage.Controls.Add(this.dataGridView1);
            this.requestHeadersTabPage.Location = new System.Drawing.Point(4, 26);
            this.requestHeadersTabPage.Name = "requestHeadersTabPage";
            this.requestHeadersTabPage.Size = new System.Drawing.Size(1162, 620);
            this.requestHeadersTabPage.TabIndex = 3;
            this.requestHeadersTabPage.Text = "Request Headers";
            this.requestHeadersTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1162, 624);
            this.dataGridView1.TabIndex = 0;
            // 
            // requestBodyTabPage
            // 
            this.requestBodyTabPage.Controls.Add(this.bodyTextBox);
            this.requestBodyTabPage.Location = new System.Drawing.Point(4, 26);
            this.requestBodyTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.requestBodyTabPage.Name = "requestBodyTabPage";
            this.requestBodyTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.requestBodyTabPage.Size = new System.Drawing.Size(1162, 620);
            this.requestBodyTabPage.TabIndex = 0;
            this.requestBodyTabPage.Text = "Request Body";
            this.requestBodyTabPage.UseVisualStyleBackColor = true;
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bodyTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.bodyTextBox.Location = new System.Drawing.Point(0, 0);
            this.bodyTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bodyTextBox.Size = new System.Drawing.Size(1162, 624);
            this.bodyTextBox.TabIndex = 91;
            // 
            // responseBodyTabPage
            // 
            this.responseBodyTabPage.Controls.Add(this.responseTextBox);
            this.responseBodyTabPage.Location = new System.Drawing.Point(4, 26);
            this.responseBodyTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseBodyTabPage.Name = "responseBodyTabPage";
            this.responseBodyTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseBodyTabPage.Size = new System.Drawing.Size(1162, 620);
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
            this.responseTableTabPage.Size = new System.Drawing.Size(1162, 620);
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
            this.responseDataGridView.Location = new System.Drawing.Point(0, 0);
            this.responseDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.responseDataGridView.Name = "responseDataGridView";
            this.responseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.responseDataGridView.Size = new System.Drawing.Size(1162, 624);
            this.responseDataGridView.TabIndex = 99;
            // 
            // responseGridContextMenuStrip
            // 
            this.responseGridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCellValueToClipboardToolStripMenuItem,
            this.copyObjectIdToRequestToolStripMenuItem,
            this.copyUserPrincipalNameToRequestToolStripMenuItem});
            this.responseGridContextMenuStrip.Name = "responseGridContextMenuStrip";
            this.responseGridContextMenuStrip.Size = new System.Drawing.Size(262, 70);
            this.responseGridContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.responseGridContextMenuStrip_Opening);
            // 
            // copyCellValueToClipboardToolStripMenuItem
            // 
            this.copyCellValueToClipboardToolStripMenuItem.Name = "copyCellValueToClipboardToolStripMenuItem";
            this.copyCellValueToClipboardToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.copyCellValueToClipboardToolStripMenuItem.Text = "&Copy cell value to clipboard";
            this.copyCellValueToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyCellValueToClipboardToolStripMenuItem_Click);
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
            this.resourceSecondComboBox.FormattingEnabled = true;
            this.resourceSecondComboBox.Location = new System.Drawing.Point(760, 100);
            this.resourceSecondComboBox.Name = "resourceSecondComboBox";
            this.resourceSecondComboBox.Size = new System.Drawing.Size(166, 25);
            this.resourceSecondComboBox.Sorted = true;
            this.resourceSecondComboBox.TabIndex = 45;
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
            this.mainMenuStrip.Size = new System.Drawing.Size(1174, 24);
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
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 831);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1174, 22);
            this.mainStatusStrip.TabIndex = 93;
            // 
            // mainStatusStripStatusLabel
            // 
            this.mainStatusStripStatusLabel.Name = "mainStatusStripStatusLabel";
            this.mainStatusStripStatusLabel.Size = new System.Drawing.Size(60, 17);
            this.mainStatusStripStatusLabel.Text = "Welcome!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 853);
            this.Controls.Add(this.requestUrlTextBox);
            this.Controls.Add(this.apiVersionComboBox);
            this.Controls.Add(this.resourceSecondComboBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.resourceFirstComboBox);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.apiVersionLabel);
            this.Controls.Add(this.entitySetLabel);
            this.Controls.Add(this.requestUrlLabel);
            this.Controls.Add(this.EnvironmentComboBox);
            this.Controls.Add(this.environmentLabel);
            this.Controls.Add(this.tokenTextBox);
            this.Controls.Add(this.tokenLabel);
            this.Controls.Add(this.getAppTokenButton);
            this.Controls.Add(this.TenantCredentialComboBox);
            this.Controls.Add(this.tenantLabel);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Aad Graph API Buddy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.requestHeadersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private TabPage requestHeadersTabPage;
        private DataGridView dataGridView1;
    }
}

