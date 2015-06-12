namespace AadGraphApiHelper
{
    partial class AddEnvironmentForm
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
            this.loginEndpointLabel = new System.Windows.Forms.Label();
            this.loginEndpointTextBox = new System.Windows.Forms.TextBox();
            this.graphEndpointLabel = new System.Windows.Forms.Label();
            this.graphEndpointTextBox = new System.Windows.Forms.TextBox();
            this.displayNameLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.displayNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginEndpointLabel
            // 
            this.loginEndpointLabel.AutoSize = true;
            this.loginEndpointLabel.Location = new System.Drawing.Point(12, 44);
            this.loginEndpointLabel.Name = "loginEndpointLabel";
            this.loginEndpointLabel.Size = new System.Drawing.Size(81, 13);
            this.loginEndpointLabel.TabIndex = 10;
            this.loginEndpointLabel.Text = "&Login Endpoint:";
            // 
            // loginEndpointTextBox
            // 
            this.loginEndpointTextBox.Location = new System.Drawing.Point(100, 41);
            this.loginEndpointTextBox.Name = "loginEndpointTextBox";
            this.loginEndpointTextBox.Size = new System.Drawing.Size(419, 20);
            this.loginEndpointTextBox.TabIndex = 11;
            this.loginEndpointTextBox.TextChanged += new System.EventHandler(this.clientIdTextBox_TextChanged);
            // 
            // graphEndpointLabel
            // 
            this.graphEndpointLabel.AutoSize = true;
            this.graphEndpointLabel.Location = new System.Drawing.Point(10, 71);
            this.graphEndpointLabel.Name = "graphEndpointLabel";
            this.graphEndpointLabel.Size = new System.Drawing.Size(84, 13);
            this.graphEndpointLabel.TabIndex = 20;
            this.graphEndpointLabel.Text = "&Graph Endpoint:";
            // 
            // graphEndpointTextBox
            // 
            this.graphEndpointTextBox.Location = new System.Drawing.Point(100, 67);
            this.graphEndpointTextBox.Name = "graphEndpointTextBox";
            this.graphEndpointTextBox.Size = new System.Drawing.Size(419, 20);
            this.graphEndpointTextBox.TabIndex = 21;
            this.graphEndpointTextBox.TextChanged += new System.EventHandler(this.clientKeyTextBox_TextChanged);
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Location = new System.Drawing.Point(12, 16);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new System.Drawing.Size(75, 13);
            this.displayNameLabel.TabIndex = 0;
            this.displayNameLabel.Text = "Display &Name:";
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
            // displayNameTextBox
            // 
            this.displayNameTextBox.Location = new System.Drawing.Point(100, 13);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new System.Drawing.Size(419, 20);
            this.displayNameTextBox.TabIndex = 1;
            this.displayNameTextBox.TextChanged += new System.EventHandler(this.tenantTextBox_TextChanged);
            // 
            // AddEnvironmentForm
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(531, 135);
            this.ControlBox = false;
            this.Controls.Add(this.displayNameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.graphEndpointTextBox);
            this.Controls.Add(this.graphEndpointLabel);
            this.Controls.Add(this.loginEndpointTextBox);
            this.Controls.Add(this.loginEndpointLabel);
            this.Controls.Add(this.displayNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddEnvironmentForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Environment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginEndpointLabel;
        private System.Windows.Forms.TextBox loginEndpointTextBox;
        private System.Windows.Forms.Label graphEndpointLabel;
        private System.Windows.Forms.TextBox graphEndpointTextBox;
        private System.Windows.Forms.Label displayNameLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox displayNameTextBox;
    }
}