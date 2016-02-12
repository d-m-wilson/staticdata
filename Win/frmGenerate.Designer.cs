namespace StaticGenerator
{
    partial class frmGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerate));
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnGenerateScripts = new System.Windows.Forms.Button();
            this.fbdDropFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkCreateIndex = new System.Windows.Forms.CheckBox();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScriptFilenameSuffix = new System.Windows.Forms.TextBox();
            this.chkOmitSchemaFromFileNames = new System.Windows.Forms.CheckBox();
            this.lblServerLabel = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabaseLabel = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clbTables
            // 
            this.clbTables.CheckOnClick = true;
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Location = new System.Drawing.Point(12, 71);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(361, 139);
            this.clbTables.TabIndex = 1;
            this.clbTables.ThreeDCheckBoxes = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select tables to script:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select drop folder:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(15, 264);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(326, 20);
            this.txtFolder.TabIndex = 4;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(347, 265);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(25, 19);
            this.btnSelectFolder.TabIndex = 5;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnGenerateScripts
            // 
            this.btnGenerateScripts.Location = new System.Drawing.Point(15, 393);
            this.btnGenerateScripts.Name = "btnGenerateScripts";
            this.btnGenerateScripts.Size = new System.Drawing.Size(121, 30);
            this.btnGenerateScripts.TabIndex = 10;
            this.btnGenerateScripts.Text = "Generate Scripts";
            this.btnGenerateScripts.UseVisualStyleBackColor = true;
            this.btnGenerateScripts.Click += new System.EventHandler(this.btnGenerateScripts_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(304, 399);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 24);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkCreateIndex
            // 
            this.chkCreateIndex.AutoSize = true;
            this.chkCreateIndex.Location = new System.Drawing.Point(15, 361);
            this.chkCreateIndex.Name = "chkCreateIndex";
            this.chkCreateIndex.Size = new System.Drawing.Size(265, 17);
            this.chkCreateIndex.TabIndex = 9;
            this.chkCreateIndex.Text = "Create index script (to paste into post deploy script)";
            this.chkCreateIndex.UseVisualStyleBackColor = true;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(15, 216);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(70, 17);
            this.selectAllCheckBox.TabIndex = 2;
            this.selectAllCheckBox.Text = "Select &All";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Script File Name Suffix:";
            // 
            // txtScriptFilenameSuffix
            // 
            this.txtScriptFilenameSuffix.Location = new System.Drawing.Point(15, 303);
            this.txtScriptFilenameSuffix.Name = "txtScriptFilenameSuffix";
            this.txtScriptFilenameSuffix.Size = new System.Drawing.Size(176, 20);
            this.txtScriptFilenameSuffix.TabIndex = 7;
            // 
            // chkOmitSchemaFromFileNames
            // 
            this.chkOmitSchemaFromFileNames.AutoSize = true;
            this.chkOmitSchemaFromFileNames.Location = new System.Drawing.Point(15, 333);
            this.chkOmitSchemaFromFileNames.Name = "chkOmitSchemaFromFileNames";
            this.chkOmitSchemaFromFileNames.Size = new System.Drawing.Size(188, 17);
            this.chkOmitSchemaFromFileNames.TabIndex = 8;
            this.chkOmitSchemaFromFileNames.Text = "Omit schema from script file names";
            this.chkOmitSchemaFromFileNames.UseVisualStyleBackColor = true;
            // 
            // lblServerLabel
            // 
            this.lblServerLabel.AutoSize = true;
            this.lblServerLabel.Location = new System.Drawing.Point(12, 9);
            this.lblServerLabel.Name = "lblServerLabel";
            this.lblServerLabel.Size = new System.Drawing.Size(41, 13);
            this.lblServerLabel.TabIndex = 12;
            this.lblServerLabel.Text = "Server:";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(74, 9);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(54, 13);
            this.lblServer.TabIndex = 13;
            this.lblServer.Text = "[lblServer]";
            // 
            // lblDatabaseLabel
            // 
            this.lblDatabaseLabel.AutoSize = true;
            this.lblDatabaseLabel.Location = new System.Drawing.Point(12, 26);
            this.lblDatabaseLabel.Name = "lblDatabaseLabel";
            this.lblDatabaseLabel.Size = new System.Drawing.Size(56, 13);
            this.lblDatabaseLabel.TabIndex = 14;
            this.lblDatabaseLabel.Text = "Database:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(74, 26);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(69, 13);
            this.lblDatabase.TabIndex = 15;
            this.lblDatabase.Text = "[lblDatabase]";
            // 
            // frmGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 438);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblDatabaseLabel);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.lblServerLabel);
            this.Controls.Add(this.chkOmitSchemaFromFileNames);
            this.Controls.Add(this.txtScriptFilenameSuffix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectAllCheckBox);
            this.Controls.Add(this.chkCreateIndex);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerateScripts);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Static Data Script Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGenerate_Closing);
            this.Load += new System.EventHandler(this.frmGenerate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnGenerateScripts;
        private System.Windows.Forms.FolderBrowserDialog fbdDropFolder;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkCreateIndex;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScriptFilenameSuffix;
        private System.Windows.Forms.CheckBox chkOmitSchemaFromFileNames;
        private System.Windows.Forms.Label lblServerLabel;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabaseLabel;
        private System.Windows.Forms.Label lblDatabase;
    }
}