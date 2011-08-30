//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  This material may not be duplicated in whole or in part, except for 
//  personal use, without the express written consent of the author. 
//
//  Email:  paul.caponetti@gmail.com
//
//  Copyright (C) 2006-2008 Ianier Munoz. All Rights Reserved.
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PClapper
{
	/// <summary>
	/// Summary description for ClapActionOptions.
	/// </summary>
	public class ClapActionOptions : System.Windows.Forms.Form
	{
		private PluginManager pm;

		private System.Windows.Forms.ComboBox comboBoxType;
		private System.Windows.Forms.Label fileLabel;
		private System.Windows.Forms.Label urlLabel;
		private System.Windows.Forms.Label pluginLabel;
		private System.Windows.Forms.ComboBox plugins;
		private System.Windows.Forms.Label headerLabel;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.Button launch;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fileArgsTextBox; //RWA
        private System.Windows.Forms.Label fileArgsLabel; //RWA
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private void UserInitializeComponent() {
            plugins.Items.Clear();
            pm = new PluginManager();
            foreach (ClapperPluginInterface.IClapperPlugin p in pm.ClapperPlugins.Values) {
                plugins.Items.Add(p.Name);
            }
            plugins.SelectedIndex = 0;
            comboBoxType.SelectedIndex = 0;
        }

        public ClapActionOptions() {
            InitializeComponent();
            UserInitializeComponent();
        }

        public ClapActionOptions(ActionSetting setting) {
            InitializeComponent();
            UserInitializeComponent();
            action = setting;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.fileLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.pluginLabel = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.launch = new System.Windows.Forms.Button();
            this.plugins = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fileArgsTextBox = new System.Windows.Forms.TextBox();
            this.fileArgsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(12, 42);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(83, 13);
            this.fileLabel.TabIndex = 2;
            this.fileLabel.Text = "File or Program :";
            this.fileLabel.Visible = false;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 42);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(58, 13);
            this.urlLabel.TabIndex = 2;
            this.urlLabel.Text = "Open URL";
            this.urlLabel.Visible = false;
            // 
            // pluginLabel
            // 
            this.pluginLabel.AutoSize = true;
            this.pluginLabel.Location = new System.Drawing.Point(12, 42);
            this.pluginLabel.Name = "pluginLabel";
            this.pluginLabel.Size = new System.Drawing.Size(42, 13);
            this.pluginLabel.TabIndex = 2;
            this.pluginLabel.Text = "Plugin :";
            this.pluginLabel.Visible = false;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.CausesValidation = false;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(356, 93);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(88, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(275, 93);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "OK";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(95, 40);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(273, 20);
            this.fileTextBox.TabIndex = 2;
            this.fileTextBox.Visible = false;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(95, 40);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(273, 20);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Visible = false;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(376, 40);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(68, 20);
            this.browse.TabIndex = 3;
            this.browse.Text = "Browse";
            this.browse.Visible = false;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // launch
            // 
            this.launch.Location = new System.Drawing.Point(376, 40);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(68, 21);
            this.launch.TabIndex = 3;
            this.launch.Text = "Launch";
            this.launch.Visible = false;
            this.launch.Click += new System.EventHandler(this.launch_Click);
            // 
            // plugins
            // 
            this.plugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plugins.Location = new System.Drawing.Point(95, 39);
            this.plugins.Name = "plugins";
            this.plugins.Size = new System.Drawing.Size(273, 21);
            this.plugins.TabIndex = 2;
            this.plugins.Visible = false;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Items.AddRange(new object[] {
            "Open File or Program",
            "Open URL",
            "Use Plugin"});
            this.comboBoxType.Location = new System.Drawing.Point(95, 8);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(12, 11);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(37, 13);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Type :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Test";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileArgsTextBox
            // 
            this.fileArgsTextBox.Location = new System.Drawing.Point(95, 66);
            this.fileArgsTextBox.Name = "fileArgsTextBox";
            this.fileArgsTextBox.Size = new System.Drawing.Size(349, 20);
            this.fileArgsTextBox.TabIndex = 4;
            this.fileArgsTextBox.Visible = false;
            // 
            // fileArgsLabel
            // 
            this.fileArgsLabel.AutoSize = true;
            this.fileArgsLabel.Location = new System.Drawing.Point(12, 69);
            this.fileArgsLabel.Name = "fileArgsLabel";
            this.fileArgsLabel.Size = new System.Drawing.Size(63, 13);
            this.fileArgsLabel.TabIndex = 4;
            this.fileArgsLabel.Text = "Parameters:";
            this.fileArgsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileArgsLabel.Visible = false;
            // 
            // ClapActionOptions
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(456, 128);
            this.Controls.Add(this.fileArgsTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.plugins);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.fileArgsLabel);
            this.Controls.Add(this.pluginLabel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.headerLabel);
            this.Name = "ClapActionOptions";
            this.Text = "Action";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(comboBoxType.SelectedIndex == 0)
			{
				pluginLabel.Visible = false;
				plugins.Visible = false;
				button1.Visible = false;
				fileLabel.Visible = true;
				fileTextBox.Visible = true;
                fileArgsLabel.Visible = true;
                fileArgsTextBox.Visible = true;
                urlLabel.Visible = false;
				urlTextBox.Visible = false;
				browse.Visible = true;
				launch.Visible = false;
			}
			else if(comboBoxType.SelectedIndex == 1)
			{
				pluginLabel.Visible = false;
				plugins.Visible = false;
				button1.Visible = false;
				fileLabel.Visible = false;
				fileTextBox.Visible = false;
                fileArgsLabel.Visible = false;
                fileArgsTextBox.Visible = false;
                urlLabel.Visible = true;
				urlTextBox.Visible = true;
				browse.Visible = false;
				launch.Visible = true;
			}
			else
			{
				pluginLabel.Visible = true;
				plugins.Visible = true;
				button1.Visible = true;
				fileLabel.Visible = false;
				fileTextBox.Visible = false;
                fileArgsLabel.Visible = false;
                fileArgsTextBox.Visible = false;
                urlLabel.Visible = false;
				urlTextBox.Visible = false;
				browse.Visible = false;
				launch.Visible = false;
				button1.Visible = true;
			}
	    }


        public ActionSetting action {
            get {
                switch(comboBoxType.SelectedIndex) {
                    case 0: return new ActionSetting("Open " + fileTextBox.Text,fileArgsTextBox.Text);
                    case 1: return new ActionSetting("Launch " + urlTextBox.Text,"");
                    case 2:
                    default: return new ActionSetting(plugins.SelectedItem.ToString(),"");
                }
            }
            set {
                if (value.action.Substring(0, 4) == "Open") {
                    comboBoxType.SelectedIndex = 0;
                    fileTextBox.Text = value.action.Substring(5);
                    fileArgsTextBox.Text = value.parameters;
                }
                else if (value.action.Substring(0, 6) == "Launch") {
                    comboBoxType.SelectedIndex = 1;
                    urlTextBox.Text = value.action.Substring(7);
                }
                else {
                    comboBoxType.SelectedIndex = 2;
                    plugins.Text = value.action;
                }
            }
        }

		private void launch_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start(urlTextBox.Text,fileArgsTextBox.Text);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			// TODO: Execute Selected Plugin
			string name = plugins.SelectedItem.ToString();
			if(((ClapperPluginInterface.IClapperPlugin)pm.ClapperPlugins[name]).Execute())
			{
				MessageBox.Show("Execution was successful");
			}
			else
			{
				MessageBox.Show("Execution was not successful");
			}
		}

		private void browse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog f = new OpenFileDialog();
			f.ShowDialog(this);
			fileTextBox.Text = f.FileName;
		}

	}
}
