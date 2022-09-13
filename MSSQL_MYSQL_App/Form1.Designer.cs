namespace MSSQL_MYSQL_App
{
    partial class Form1
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
            this.mssqlConfigLabel = new System.Windows.Forms.Label();
            this.mssqlUsernameTextBox = new System.Windows.Forms.TextBox();
            this.mysqlConfigLabel = new System.Windows.Forms.Label();
            this.mssqlUsernameLabel = new System.Windows.Forms.Label();
            this.mssqlPasswordLabel = new System.Windows.Forms.Label();
            this.mssqlPasswordTextBox = new System.Windows.Forms.TextBox();
            this.mysqlPasswordLabel = new System.Windows.Forms.Label();
            this.mysqlPasswordTextBox = new System.Windows.Forms.TextBox();
            this.mysqlUsernameLabel = new System.Windows.Forms.Label();
            this.mysqlUsernameTextBox = new System.Windows.Forms.TextBox();
            this.configDbButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mssqlConfigLabel
            // 
            this.mssqlConfigLabel.AutoSize = true;
            this.mssqlConfigLabel.Location = new System.Drawing.Point(50, 25);
            this.mssqlConfigLabel.Name = "mssqlConfigLabel";
            this.mssqlConfigLabel.Size = new System.Drawing.Size(109, 13);
            this.mssqlConfigLabel.TabIndex = 8;
            this.mssqlConfigLabel.Text = "MSSQL Configuration";
            // 
            // mssqlUsernameTextBox
            // 
            this.mssqlUsernameTextBox.Location = new System.Drawing.Point(53, 85);
            this.mssqlUsernameTextBox.Name = "mssqlUsernameTextBox";
            this.mssqlUsernameTextBox.Size = new System.Drawing.Size(113, 20);
            this.mssqlUsernameTextBox.TabIndex = 9;
            // 
            // mysqlConfigLabel
            // 
            this.mysqlConfigLabel.AutoSize = true;
            this.mysqlConfigLabel.Location = new System.Drawing.Point(50, 139);
            this.mysqlConfigLabel.Name = "mysqlConfigLabel";
            this.mysqlConfigLabel.Size = new System.Drawing.Size(107, 13);
            this.mysqlConfigLabel.TabIndex = 10;
            this.mysqlConfigLabel.Text = "MySQL Configuration";
            // 
            // mssqlUsernameLabel
            // 
            this.mssqlUsernameLabel.AutoSize = true;
            this.mssqlUsernameLabel.Location = new System.Drawing.Point(50, 60);
            this.mssqlUsernameLabel.Name = "mssqlUsernameLabel";
            this.mssqlUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.mssqlUsernameLabel.TabIndex = 13;
            this.mssqlUsernameLabel.Text = "Username";
            // 
            // mssqlPasswordLabel
            // 
            this.mssqlPasswordLabel.AutoSize = true;
            this.mssqlPasswordLabel.Location = new System.Drawing.Point(205, 60);
            this.mssqlPasswordLabel.Name = "mssqlPasswordLabel";
            this.mssqlPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.mssqlPasswordLabel.TabIndex = 15;
            this.mssqlPasswordLabel.Text = "Password";
            // 
            // mssqlPasswordTextBox
            // 
            this.mssqlPasswordTextBox.Location = new System.Drawing.Point(208, 85);
            this.mssqlPasswordTextBox.Name = "mssqlPasswordTextBox";
            this.mssqlPasswordTextBox.Size = new System.Drawing.Size(113, 20);
            this.mssqlPasswordTextBox.TabIndex = 14;
            // 
            // mysqlUsernameLabel
            // 
            this.mysqlUsernameLabel.AutoSize = true;
            this.mysqlUsernameLabel.Location = new System.Drawing.Point(51, 175);
            this.mysqlUsernameLabel.Name = "mysqlUsernameLabel";
            this.mysqlUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.mysqlUsernameLabel.TabIndex = 17;
            this.mysqlUsernameLabel.Text = "Username";
            // 
            // mysqlUsernameTextBox
            // 
            this.mysqlUsernameTextBox.Location = new System.Drawing.Point(54, 200);
            this.mysqlUsernameTextBox.Name = "mysqlUsernameTextBox";
            this.mysqlUsernameTextBox.Size = new System.Drawing.Size(113, 20);
            this.mysqlUsernameTextBox.TabIndex = 16;
            // 
            // mysqlPasswordLabel
            // 
            this.mysqlPasswordLabel.AutoSize = true;
            this.mysqlPasswordLabel.Location = new System.Drawing.Point(206, 175);
            this.mysqlPasswordLabel.Name = "mysqlPasswordLabel";
            this.mysqlPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.mysqlPasswordLabel.TabIndex = 19;
            this.mysqlPasswordLabel.Text = "Password";
            // 
            // mysqlPasswordTextBox
            // 
            this.mysqlPasswordTextBox.Location = new System.Drawing.Point(208, 200);
            this.mysqlPasswordTextBox.Name = "mysqlPasswordTextBox";
            this.mysqlPasswordTextBox.Size = new System.Drawing.Size(113, 20);
            this.mysqlPasswordTextBox.TabIndex = 20;
            // 
            // configDbButton
            // 
            this.configDbButton.Location = new System.Drawing.Point(114, 257);
            this.configDbButton.Name = "configDbButton";
            this.configDbButton.Size = new System.Drawing.Size(156, 23);
            this.configDbButton.TabIndex = 21;
            this.configDbButton.Text = "Configure Databases";
            this.configDbButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.configDbButton.UseVisualStyleBackColor = true;
            this.configDbButton.Click += new System.EventHandler(this.configDbButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 325);
            this.Controls.Add(this.configDbButton);
            this.Controls.Add(this.mysqlPasswordLabel);
            this.Controls.Add(this.mysqlPasswordTextBox);
            this.Controls.Add(this.mysqlUsernameLabel);
            this.Controls.Add(this.mysqlUsernameTextBox);
            this.Controls.Add(this.mssqlPasswordLabel);
            this.Controls.Add(this.mssqlPasswordTextBox);
            this.Controls.Add(this.mssqlUsernameLabel);
            this.Controls.Add(this.mysqlConfigLabel);
            this.Controls.Add(this.mssqlUsernameTextBox);
            this.Controls.Add(this.mssqlConfigLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mssqlConfigLabel;
        private System.Windows.Forms.TextBox mssqlUsernameTextBox;
        private System.Windows.Forms.Label mysqlConfigLabel;
        private System.Windows.Forms.Label mssqlUsernameLabel;
        private System.Windows.Forms.Label mssqlPasswordLabel;
        private System.Windows.Forms.TextBox mssqlPasswordTextBox;
        private System.Windows.Forms.Label mysqlPasswordLabel;
        private System.Windows.Forms.TextBox mysqlPasswordTextBox;
        private System.Windows.Forms.Label mysqlUsernameLabel;
        private System.Windows.Forms.TextBox mysqlUsernameTextBox;
        private System.Windows.Forms.Button configDbButton;
    }
}

