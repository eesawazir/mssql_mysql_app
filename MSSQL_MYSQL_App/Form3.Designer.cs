namespace MSSQL_MYSQL_App
{
    partial class Form3
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
            this.confirmSyncLabel = new System.Windows.Forms.Label();
            this.confirmSyncButton = new System.Windows.Forms.Button();
            this.cancelSyncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmSyncLabel
            // 
            this.confirmSyncLabel.AutoSize = true;
            this.confirmSyncLabel.Location = new System.Drawing.Point(109, 81);
            this.confirmSyncLabel.Name = "confirmSyncLabel";
            this.confirmSyncLabel.Size = new System.Drawing.Size(185, 13);
            this.confirmSyncLabel.TabIndex = 0;
            this.confirmSyncLabel.Text = "Sync MSSQL DB WITH MYSQL DB?";
            // 
            // confirmSyncButton
            // 
            this.confirmSyncButton.Location = new System.Drawing.Point(112, 121);
            this.confirmSyncButton.Name = "confirmSyncButton";
            this.confirmSyncButton.Size = new System.Drawing.Size(75, 23);
            this.confirmSyncButton.TabIndex = 1;
            this.confirmSyncButton.Text = "Confirm";
            this.confirmSyncButton.UseVisualStyleBackColor = true;
            this.confirmSyncButton.Click += new System.EventHandler(this.confirmSyncButton_Click);
            // 
            // cancelSyncButton
            // 
            this.cancelSyncButton.Location = new System.Drawing.Point(219, 121);
            this.cancelSyncButton.Name = "cancelSyncButton";
            this.cancelSyncButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSyncButton.TabIndex = 2;
            this.cancelSyncButton.Text = "Cancel";
            this.cancelSyncButton.UseVisualStyleBackColor = true;
            this.cancelSyncButton.Click += new System.EventHandler(this.cancelSyncButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 225);
            this.Controls.Add(this.cancelSyncButton);
            this.Controls.Add(this.confirmSyncButton);
            this.Controls.Add(this.confirmSyncLabel);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label confirmSyncLabel;
        private System.Windows.Forms.Button confirmSyncButton;
        private System.Windows.Forms.Button cancelSyncButton;
    }
}