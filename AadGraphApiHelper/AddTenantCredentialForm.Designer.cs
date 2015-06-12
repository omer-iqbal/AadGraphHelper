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
            this.clientKeyLabel = new System.Windows.Forms.Label();
            this.clientKeyTextBox = new System.Windows.Forms.TextBox();
            this.tenantLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tenantTextBox = new System.Windows.Forms.TextBox();
            this.saveCredentialCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Location = new System.Drawing.Point(12, 44);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(50, 13);
            this.clientIdLabel.TabIndex = 10;
            this.clientIdLabel.Text = "Client &ID:";
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.Location = new System.Drawing.Point(68, 41);
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.Size = new System.Drawing.Size(451, 20);
            this.clientIdTextBox.TabIndex = 11;
            this.clientIdTextBox.TextChanged += new System.EventHandler(this.clientIdTextBox_TextChanged);
            // 
            // clientKeyLabel
            // 
            this.clientKeyLabel.AutoSize = true;
            this.clientKeyLabel.Location = new System.Drawing.Point(10, 71);
            this.clientKeyLabel.Name = "clientKeyLabel";
            this.clientKeyLabel.Size = new System.Drawing.Size(28, 13);
            this.clientKeyLabel.TabIndex = 20;
            this.clientKeyLabel.Text = "&Key:";
            // 
            // clientKeyTextBox
            // 
            this.clientKeyTextBox.Location = new System.Drawing.Point(68, 68);
            this.clientKeyTextBox.Name = "clientKeyTextBox";
            this.clientKeyTextBox.Size = new System.Drawing.Size(451, 20);
            this.clientKeyTextBox.TabIndex = 21;
            this.clientKeyTextBox.TextChanged += new System.EventHandler(this.clientKeyTextBox_TextChanged);
            // 
            // tenantLabel
            // 
            this.tenantLabel.AutoSize = true;
            this.tenantLabel.Location = new System.Drawing.Point(12, 16);
            this.tenantLabel.Name = "tenantLabel";
            this.tenantLabel.Size = new System.Drawing.Size(44, 13);
            this.tenantLabel.TabIndex = 0;
            this.tenantLabel.Text = "&Tenant:";
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(363, 100);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 30;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(444, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tenantTextBox
            // 
            this.tenantTextBox.Location = new System.Drawing.Point(68, 13);
            this.tenantTextBox.Name = "tenantTextBox";
            this.tenantTextBox.Size = new System.Drawing.Size(451, 20);
            this.tenantTextBox.TabIndex = 1;
            this.tenantTextBox.TextChanged += new System.EventHandler(this.tenantTextBox_TextChanged);
            // 
            // saveCredentialCheckBox
            // 
            this.saveCredentialCheckBox.AutoSize = true;
            this.saveCredentialCheckBox.Checked = true;
            this.saveCredentialCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveCredentialCheckBox.Location = new System.Drawing.Point(68, 104);
            this.saveCredentialCheckBox.Name = "saveCredentialCheckBox";
            this.saveCredentialCheckBox.Size = new System.Drawing.Size(267, 17);
            this.saveCredentialCheckBox.TabIndex = 28;
            this.saveCredentialCheckBox.Text = "&Save Credential (Key is stored encrypted in registry)";
            this.saveCredentialCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddTenantCredentialForm
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(531, 135);
            this.ControlBox = false;
            this.Controls.Add(this.saveCredentialCheckBox);
            this.Controls.Add(this.tenantTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.clientKeyTextBox);
            this.Controls.Add(this.clientKeyLabel);
            this.Controls.Add(this.clientIdTextBox);
            this.Controls.Add(this.clientIdLabel);
            this.Controls.Add(this.tenantLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddTenantCredentialForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Tenant Credential";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientIdLabel;
        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Label clientKeyLabel;
        private System.Windows.Forms.TextBox clientKeyTextBox;
        private System.Windows.Forms.Label tenantLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox tenantTextBox;
        private System.Windows.Forms.CheckBox saveCredentialCheckBox;
    }
}