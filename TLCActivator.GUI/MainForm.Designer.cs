﻿namespace TLCActivator.GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxExePath = new System.Windows.Forms.TextBox();
            this.buttonBrowseExeFile = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonSaveShortcut = new System.Windows.Forms.Button();
            this.cbVerbose = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.BackColor = System.Drawing.Color.White;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(14, 54);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(348, 33);
            this.comboBoxType.TabIndex = 0;
            // 
            // textBoxExePath
            // 
            this.textBoxExePath.AllowDrop = true;
            this.textBoxExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxExePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxExePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxExePath.Location = new System.Drawing.Point(14, 14);
            this.textBoxExePath.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxExePath.Name = "textBoxExePath";
            this.textBoxExePath.Size = new System.Drawing.Size(314, 30);
            this.textBoxExePath.TabIndex = 1;
            this.textBoxExePath.TextChanged += new System.EventHandler(this.textBoxExePath_TextChanged);
            this.textBoxExePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxExePath_DragDrop);
            this.textBoxExePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxExePath_DragEnter);
            // 
            // buttonBrowseExeFile
            // 
            this.buttonBrowseExeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseExeFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonBrowseExeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseExeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonBrowseExeFile.Location = new System.Drawing.Point(327, 14);
            this.buttonBrowseExeFile.Margin = new System.Windows.Forms.Padding(5);
            this.buttonBrowseExeFile.Name = "buttonBrowseExeFile";
            this.buttonBrowseExeFile.Size = new System.Drawing.Size(35, 30);
            this.buttonBrowseExeFile.TabIndex = 2;
            this.buttonBrowseExeFile.Text = "...";
            this.buttonBrowseExeFile.UseVisualStyleBackColor = false;
            this.buttonBrowseExeFile.Click += new System.EventHandler(this.buttonBrowseExeFile_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::TLCActivator.GUI.Properties.Resources.TCLOnAltar;
            this.pictureBox.Location = new System.Drawing.Point(14, 97);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(571, 342);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.BackColor = System.Drawing.Color.White;
            this.buttonRun.Enabled = false;
            this.buttonRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonRun.Location = new System.Drawing.Point(469, 14);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(116, 73);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = false;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonSaveShortcut
            // 
            this.buttonSaveShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveShortcut.BackColor = System.Drawing.Color.White;
            this.buttonSaveShortcut.Enabled = false;
            this.buttonSaveShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonSaveShortcut.Location = new System.Drawing.Point(361, 54);
            this.buttonSaveShortcut.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSaveShortcut.Name = "buttonSaveShortcut";
            this.buttonSaveShortcut.Size = new System.Drawing.Size(100, 33);
            this.buttonSaveShortcut.TabIndex = 5;
            this.buttonSaveShortcut.Text = "Save shortcut";
            this.buttonSaveShortcut.UseVisualStyleBackColor = false;
            this.buttonSaveShortcut.Click += new System.EventHandler(this.buttonSaveShortcut_Click);
            // 
            // cbVerbose
            // 
            this.cbVerbose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVerbose.AutoSize = true;
            this.cbVerbose.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbVerbose.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbVerbose.Location = new System.Drawing.Point(368, 19);
            this.cbVerbose.Name = "cbVerbose";
            this.cbVerbose.Size = new System.Drawing.Size(93, 24);
            this.cbVerbose.TabIndex = 6;
            this.cbVerbose.Text = "Verbose";
            this.cbVerbose.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 453);
            this.Controls.Add(this.cbVerbose);
            this.Controls.Add(this.buttonSaveShortcut);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonBrowseExeFile);
            this.Controls.Add(this.textBoxExePath);
            this.Controls.Add(this.comboBoxType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(350, 400);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "TLCActivator - https://github.com/ElectroHeavenVN/TLCActivator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxExePath;
        private System.Windows.Forms.Button buttonBrowseExeFile;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonSaveShortcut;
        private System.Windows.Forms.CheckBox cbVerbose;
    }
}

