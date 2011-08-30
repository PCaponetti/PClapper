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
	/// Summary description for ClapNodeOptions.
	/// </summary>
	public class ClapNodeOptions : System.Windows.Forms.Form
	{
        private Button buttonOk;
        private Button buttonCancel;
        private Label label2;
        private Label label4;
        private TextBox textBoxName;
        private CheckBox checkBoxSubpattern;
        private ClapPatternControl clapPatternControl;
        private ToolTip toolTip;
        private IContainer components;

		public ClapNodeOptions()
		{
			InitializeComponent();
		}

        public ClapNodeOptions(ActionGroup ag) {
            InitializeComponent();
            this.actionGroup = ag;
        }

        public ActionGroup actionGroup {
            get { 
                ActionGroup ag = new ActionGroup();
                ag.name = textBoxName.Text;
                ag.pattern = clapPatternControl.pattern;
                ag.subPattern = checkBoxSubpattern.Checked;
                return ag; 
            }
            set { 
                clapPatternControl.pattern = value.pattern;
                textBoxName.Text = value.name;
                checkBoxSubpattern.Checked = value.subPattern;
            }
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
            this.components = new System.ComponentModel.Container();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBoxSubpattern = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.clapPatternControl = new PClapper.ClapPatternControl();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(124, 129);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(205, 129);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Pattern :";
            this.toolTip.SetToolTip(this.label4, "Each check box represents a quaver (eigth note)");
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(98, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(182, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // checkBoxSubpattern
            // 
            this.checkBoxSubpattern.AutoSize = true;
            this.checkBoxSubpattern.Location = new System.Drawing.Point(15, 87);
            this.checkBoxSubpattern.Name = "checkBoxSubpattern";
            this.checkBoxSubpattern.Size = new System.Drawing.Size(171, 17);
            this.checkBoxSubpattern.TabIndex = 3;
            this.checkBoxSubpattern.Text = "Trigger and continue detection";
            this.toolTip.SetToolTip(this.checkBoxSubpattern, "When a pattern is the beginning of another,\r\nuse this option to enable its trigge" +
                    "ring when you clap the longer one.\r\nBoth will be triggered in turns within the s" +
                    "ame clap sequence.");
            this.checkBoxSubpattern.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 60000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // clapPatternControl
            // 
            this.clapPatternControl.Location = new System.Drawing.Point(98, 47);
            this.clapPatternControl.Margin = new System.Windows.Forms.Padding(0);
            this.clapPatternControl.Name = "clapPatternControl";
            this.clapPatternControl.Size = new System.Drawing.Size(182, 26);
            this.clapPatternControl.TabIndex = 2;
            // 
            // ClapNodeOptions
            // 
            this.AcceptButton = this.buttonOk;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(292, 171);
            this.Controls.Add(this.clapPatternControl);
            this.Controls.Add(this.checkBoxSubpattern);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "ClapNodeOptions";
            this.Text = "Rythm patterns & Actions";
            this.Load += new System.EventHandler(this.ClapNodeOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void checkBoxImmediate_CheckedChanged(object sender, EventArgs e) {
            //checkBoxSubpattern.Enabled = checkBoxImmediate.Checked;
        }

        private void ClapNodeOptions_Load(object sender, EventArgs e) {

        }

	}
}
