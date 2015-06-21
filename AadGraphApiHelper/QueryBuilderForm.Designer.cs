namespace AadGraphApiHelper
{
    partial class QueryBuilderForm
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
            this.queryGridView = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createRequestButton = new System.Windows.Forms.Button();
            this.resourceLabel = new System.Windows.Forms.Label();
            this.resourceComboBox = new System.Windows.Forms.ComboBox();
            this.createAndExecuteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.queryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // queryGridView
            // 
            this.queryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queryGridView.Location = new System.Drawing.Point(0, 45);
            this.queryGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.queryGridView.Name = "queryGridView";
            this.queryGridView.Size = new System.Drawing.Size(984, 331);
            this.queryGridView.TabIndex = 10;
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(847, 383);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(125, 27);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createRequestButton
            // 
            this.createRequestButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.createRequestButton.Location = new System.Drawing.Point(485, 383);
            this.createRequestButton.Name = "createRequestButton";
            this.createRequestButton.Size = new System.Drawing.Size(175, 27);
            this.createRequestButton.TabIndex = 21;
            this.createRequestButton.Text = "Create request";
            this.createRequestButton.UseVisualStyleBackColor = true;
            this.createRequestButton.Click += new System.EventHandler(this.createRequestButton_Click);
            // 
            // resourceLabel
            // 
            this.resourceLabel.AutoSize = true;
            this.resourceLabel.Location = new System.Drawing.Point(13, 13);
            this.resourceLabel.Name = "resourceLabel";
            this.resourceLabel.Size = new System.Drawing.Size(67, 19);
            this.resourceLabel.TabIndex = 1;
            this.resourceLabel.Text = "Resource:";
            // 
            // resourceComboBox
            // 
            this.resourceComboBox.Enabled = false;
            this.resourceComboBox.FormattingEnabled = true;
            this.resourceComboBox.Items.AddRange(new object[] {
            "users"});
            this.resourceComboBox.Location = new System.Drawing.Point(101, 10);
            this.resourceComboBox.Name = "resourceComboBox";
            this.resourceComboBox.Size = new System.Drawing.Size(229, 25);
            this.resourceComboBox.TabIndex = 2;
            this.resourceComboBox.Text = "users";
            // 
            // createAndExecuteButton
            // 
            this.createAndExecuteButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.createAndExecuteButton.Location = new System.Drawing.Point(666, 383);
            this.createAndExecuteButton.Name = "createAndExecuteButton";
            this.createAndExecuteButton.Size = new System.Drawing.Size(175, 27);
            this.createAndExecuteButton.TabIndex = 23;
            this.createAndExecuteButton.Text = "Create and execute";
            this.createAndExecuteButton.UseVisualStyleBackColor = true;
            this.createAndExecuteButton.Click += new System.EventHandler(this.createAndExecuteButton_Click);
            // 
            // QueryBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(984, 418);
            this.Controls.Add(this.createAndExecuteButton);
            this.Controls.Add(this.resourceComboBox);
            this.Controls.Add(this.resourceLabel);
            this.Controls.Add(this.createRequestButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.queryGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryBuilderForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query Builder";
            this.Load += new System.EventHandler(this.QueryBuilderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.queryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView queryGridView;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createRequestButton;
        private System.Windows.Forms.Label resourceLabel;
        private System.Windows.Forms.ComboBox resourceComboBox;
        private System.Windows.Forms.Button createAndExecuteButton;

    }
}