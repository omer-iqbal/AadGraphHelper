namespace AadGraphApiHelper
{
    partial class AddTenantCredentialForm
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
            this.clientIdLabel = new System.Windows.Forms.Label();
            this.clientIdTextBox = new System.Windows.Forms.TextBox();
            this.keyOrReplyUrlLabel = new System.Windows.Forms.Label();
            this.keyOrReplyUrlTextBox = new System.Windows.Forms.TextBox();
            this.tenantLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tenantTextBox = new System.Windows.Forms.TextBox();
            this.saveCredentialCheckBox = new System.Windows.Forms.CheckBox();
            this.webAppRadioButton = new System.Windows.Forms.RadioButton();
            this.nativeAppRadioButton = new System.Windows.Forms.RadioButton();
            this.authenticationTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aliasTextBox = new System.Windows.Forms.TextBox();
            this.authenticationTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Location = new System.Drawing.Point(14, 58);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(65, 19);
            this.clientIdLabel.TabIndex = 10;
            this.clientIdLabel.Text = "Client &ID:";
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.Location = new System.Drawing.Point(119, 54);
            this.clientIdTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.Size = new System.Drawing.Size(517, 25);
            this.clientIdTextBox.TabIndex = 11;
            this.clientIdTextBox.TextChanged += new System.EventHandler(this.clientIdTextBox_TextChanged);
            // 
            // keyOrReplyUrlLabel
            // 
            this.keyOrReplyUrlLabel.AutoSize = true;
            this.keyOrReplyUrlLabel.Enabled = false;
            this.keyOrReplyUrlLabel.Location = new System.Drawing.Point(14, 264);
            this.keyOrReplyUrlLabel.Name = "keyOrReplyUrlLabel";
            this.keyOrReplyUrlLabel.Size = new System.Drawing.Size(34, 19);
            this.keyOrReplyUrlLabel.TabIndex = 20;
            this.keyOrReplyUrlLabel.Text = "&Key:";
            // 
            // keyOrReplyUrlTextBox
            // 
            this.keyOrReplyUrlTextBox.Enabled = false;
            this.keyOrReplyUrlTextBox.Location = new System.Drawing.Point(119, 258);
            this.keyOrReplyUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.keyOrReplyUrlTextBox.Name = "keyOrReplyUrlTextBox";
            this.keyOrReplyUrlTextBox.Size = new System.Drawing.Size(506, 25);
            this.keyOrReplyUrlTextBox.TabIndex = 21;
            this.keyOrReplyUrlTextBox.TextChanged += new System.EventHandler(this.clientKeyTextBox_TextChanged);
            // 
            // tenantLabel
            // 
            this.tenantLabel.AutoSize = true;
            this.tenantLabel.Location = new System.Drawing.Point(14, 21);
            this.tenantLabel.Name = "tenantLabel";
            this.tenantLabel.Size = new System.Drawing.Size(53, 19);
            this.tenantLabel.TabIndex = 0;
            this.tenantLabel.Text = "&Tenant:";
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(445, 292);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(87, 30);
            this.addButton.TabIndex = 30;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(538, 292);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 30);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tenantTextBox
            // 
            this.tenantTextBox.Location = new System.Drawing.Point(119, 17);
            this.tenantTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tenantTextBox.Name = "tenantTextBox";
            this.tenantTextBox.Size = new System.Drawing.Size(517, 25);
            this.tenantTextBox.TabIndex = 1;
            this.tenantTextBox.Text = ".onmicrosoft.com";
            this.tenantTextBox.TextChanged += new System.EventHandler(this.tenantTextBox_TextChanged);
            // 
            // saveCredentialCheckBox
            // 
            this.saveCredentialCheckBox.AutoSize = true;
            this.saveCredentialCheckBox.Checked = true;
            this.saveCredentialCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveCredentialCheckBox.Enabled = false;
            this.saveCredentialCheckBox.Location = new System.Drawing.Point(79, 297);
            this.saveCredentialCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveCredentialCheckBox.Name = "saveCredentialCheckBox";
            this.saveCredentialCheckBox.Size = new System.Drawing.Size(342, 23);
            this.saveCredentialCheckBox.TabIndex = 28;
            this.saveCredentialCheckBox.Text = "&Save Credential (Key is stored encrypted in registry)";
            this.saveCredentialCheckBox.UseVisualStyleBackColor = true;
            // 
            // webAppRadioButton
            // 
            this.webAppRadioButton.AutoSize = true;
            this.webAppRadioButton.Location = new System.Drawing.Point(7, 25);
            this.webAppRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.webAppRadioButton.Name = "webAppRadioButton";
            this.webAppRadioButton.Size = new System.Drawing.Size(83, 23);
            this.webAppRadioButton.TabIndex = 32;
            this.webAppRadioButton.TabStop = true;
            this.webAppRadioButton.Text = "Web App";
            this.webAppRadioButton.UseVisualStyleBackColor = true;
            this.webAppRadioButton.CheckedChanged += new System.EventHandler(this.webAppRadioButton_CheckedChanged);
            // 
            // nativeAppRadioButton
            // 
            this.nativeAppRadioButton.AutoSize = true;
            this.nativeAppRadioButton.Location = new System.Drawing.Point(7, 55);
            this.nativeAppRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nativeAppRadioButton.Name = "nativeAppRadioButton";
            this.nativeAppRadioButton.Size = new System.Drawing.Size(95, 23);
            this.nativeAppRadioButton.TabIndex = 33;
            this.nativeAppRadioButton.TabStop = true;
            this.nativeAppRadioButton.Text = "Native App";
            this.nativeAppRadioButton.UseVisualStyleBackColor = true;
            this.nativeAppRadioButton.CheckedChanged += new System.EventHandler(this.nativeAppRadioButton_CheckedChanged);
            // 
            // authenticationTypeGroupBox
            // 
            this.authenticationTypeGroupBox.Controls.Add(this.nativeAppRadioButton);
            this.authenticationTypeGroupBox.Controls.Add(this.webAppRadioButton);
            this.authenticationTypeGroupBox.Location = new System.Drawing.Point(18, 145);
            this.authenticationTypeGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authenticationTypeGroupBox.Name = "authenticationTypeGroupBox";
            this.authenticationTypeGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authenticationTypeGroupBox.Size = new System.Drawing.Size(607, 92);
            this.authenticationTypeGroupBox.TabIndex = 34;
            this.authenticationTypeGroupBox.TabStop = false;
            this.authenticationTypeGroupBox.Text = "Type of App";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "Alias (optional)";
            // 
            // aliasTextBox
            // 
            this.aliasTextBox.Location = new System.Drawing.Point(119, 97);
            this.aliasTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aliasTextBox.Name = "aliasTextBox";
            this.aliasTextBox.Size = new System.Drawing.Size(517, 25);
            this.aliasTextBox.TabIndex = 36;
            // 
            // AddTenantCredentialForm
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(648, 353);
            this.ControlBox = false;
            this.Controls.Add(this.aliasTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authenticationTypeGroupBox);
            this.Controls.Add(this.saveCredentialCheckBox);
            this.Controls.Add(this.tenantTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.keyOrReplyUrlTextBox);
            this.Controls.Add(this.keyOrReplyUrlLabel);
            this.Controls.Add(this.clientIdTextBox);
            this.Controls.Add(this.clientIdLabel);
            this.Controls.Add(this.tenantLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "AddTenantCredentialForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Tenant Credential";
            this.authenticationTypeGroupBox.ResumeLayout(false);
            this.authenticationTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientIdLabel;
        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Label keyOrReplyUrlLabel;
        private System.Windows.Forms.TextBox keyOrReplyUrlTextBox;
        private System.Windows.Forms.Label tenantLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox tenantTextBox;
        private System.Windows.Forms.CheckBox saveCredentialCheckBox;
        private System.Windows.Forms.RadioButton webAppRadioButton;
        private System.Windows.Forms.RadioButton nativeAppRadioButton;
        private System.Windows.Forms.GroupBox authenticationTypeGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox aliasTextBox;
    }
}