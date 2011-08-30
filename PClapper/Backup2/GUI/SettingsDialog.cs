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
using System.Windows.Forms.ComponentModel;
using System.Configuration;

namespace PClapper
{
	/// <summary>
	/// Summary description for ClapListenerOptions.
	/// </summary>
	public class SettingsDialog : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TrackBar trkListenerBar;
		private System.Windows.Forms.Label lblMain;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
        private CheckBox checkBoxListen;
        private GroupBox groupBoxGeneral;
        private GroupBox groupBoxListener;
        private CheckBox checkBoxBackgroundAdapt;
        private GroupBox groupBoxPatterns;
        private CheckBox checkBoxTempo;
        private NumericUpDown numericUpDownTempo;
        private Label label1;
        private NumericUpDown numericUpDownRythmTolerance;
        private Label label2;
        private CheckBox checkBoxRythm;
        private NumericUpDown numericUpDownTempoTolerance;
        private Label label3;
        private Label label4;
        private PClapper.GUI.AudioDevicePicker audioDevicePicker1;
        private ToolTip toolTip;
        private IContainer components;

		public SettingsDialog()
		{
            InitializeComponent();
            this.audioDevicePicker1.SelectedIndexChanged += new System.EventHandler(this.audioDevicePicker1_SelectedIndexChanged);
            audioDevicePicker1.selectedDeviceId = PClapper.Properties.Settings.Default.inputDevice;
            setEnabledComponents();
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
            this.lblMain = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.checkBoxListen = new System.Windows.Forms.CheckBox();
            this.groupBoxListener = new System.Windows.Forms.GroupBox();
            this.checkBoxBackgroundAdapt = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trkListenerBar = new System.Windows.Forms.TrackBar();
            this.groupBoxPatterns = new System.Windows.Forms.GroupBox();
            this.checkBoxRythm = new System.Windows.Forms.CheckBox();
            this.checkBoxTempo = new System.Windows.Forms.CheckBox();
            this.numericUpDownTempoTolerance = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRythmTolerance = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownTempo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.audioDevicePicker1 = new PClapper.GUI.AudioDevicePicker();
            this.groupBoxGeneral.SuspendLayout();
            this.groupBoxListener.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkListenerBar)).BeginInit();
            this.groupBoxPatterns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempoTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRythmTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Location = new System.Drawing.Point(6, 56);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(60, 13);
            this.lblMain.TabIndex = 3;
            this.lblMain.Text = "Sensitivity :";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lblMain, "Sets the volume threshold for a clap to be detected.\r\nThe lower the sensitivity, " +
                    "the harder you need to clap.");
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(101, 314);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(181, 314);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Controls.Add(this.checkBoxListen);
            this.groupBoxGeneral.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(324, 47);
            this.groupBoxGeneral.TabIndex = 1;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General";
            // 
            // checkBoxListen
            // 
            this.checkBoxListen.AutoSize = true;
            this.checkBoxListen.Checked = global::PClapper.Properties.Settings.Default.startListening;
            this.checkBoxListen.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PClapper.Properties.Settings.Default, "StartListening", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxListen.Location = new System.Drawing.Point(9, 19);
            this.checkBoxListen.Name = "checkBoxListen";
            this.checkBoxListen.Size = new System.Drawing.Size(139, 17);
            this.checkBoxListen.TabIndex = 1;
            this.checkBoxListen.Text = "Start listening on startup";
            this.checkBoxListen.UseVisualStyleBackColor = true;
            // 
            // groupBoxListener
            // 
            this.groupBoxListener.Controls.Add(this.audioDevicePicker1);
            this.groupBoxListener.Controls.Add(this.checkBoxBackgroundAdapt);
            this.groupBoxListener.Controls.Add(this.label4);
            this.groupBoxListener.Controls.Add(this.lblMain);
            this.groupBoxListener.Controls.Add(this.trkListenerBar);
            this.groupBoxListener.Location = new System.Drawing.Point(12, 65);
            this.groupBoxListener.Name = "groupBoxListener";
            this.groupBoxListener.Size = new System.Drawing.Size(324, 134);
            this.groupBoxListener.TabIndex = 2;
            this.groupBoxListener.TabStop = false;
            this.groupBoxListener.Text = "Listener";
            // 
            // checkBoxBackgroundAdapt
            // 
            this.checkBoxBackgroundAdapt.AutoSize = true;
            this.checkBoxBackgroundAdapt.Checked = global::PClapper.Properties.Settings.Default.adaptToBackground;
            this.checkBoxBackgroundAdapt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBackgroundAdapt.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PClapper.Properties.Settings.Default, "adaptToBackground", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxBackgroundAdapt.Location = new System.Drawing.Point(9, 103);
            this.checkBoxBackgroundAdapt.Name = "checkBoxBackgroundAdapt";
            this.checkBoxBackgroundAdapt.Size = new System.Drawing.Size(154, 17);
            this.checkBoxBackgroundAdapt.TabIndex = 4;
            this.checkBoxBackgroundAdapt.Text = "Adapt to background noise";
            this.toolTip.SetToolTip(this.checkBoxBackgroundAdapt, "When checked, sensivity is automatically reduced \r\nwhen ambiant noise becomes too" +
                    " loud (is likely to be detected as a clap).");
            this.checkBoxBackgroundAdapt.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Input Device :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trkListenerBar
            // 
            this.trkListenerBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PClapper.Properties.Settings.Default, "breaker", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trkListenerBar.LargeChange = 10;
            this.trkListenerBar.Location = new System.Drawing.Point(82, 52);
            this.trkListenerBar.Maximum = 124;
            this.trkListenerBar.Name = "trkListenerBar";
            this.trkListenerBar.Size = new System.Drawing.Size(236, 45);
            this.trkListenerBar.TabIndex = 3;
            this.trkListenerBar.TickFrequency = 5;
            this.trkListenerBar.Value = global::PClapper.Properties.Settings.Default.breaker;
            // 
            // groupBoxPatterns
            // 
            this.groupBoxPatterns.Controls.Add(this.checkBoxRythm);
            this.groupBoxPatterns.Controls.Add(this.checkBoxTempo);
            this.groupBoxPatterns.Controls.Add(this.numericUpDownTempoTolerance);
            this.groupBoxPatterns.Controls.Add(this.numericUpDownRythmTolerance);
            this.groupBoxPatterns.Controls.Add(this.label3);
            this.groupBoxPatterns.Controls.Add(this.numericUpDownTempo);
            this.groupBoxPatterns.Controls.Add(this.label2);
            this.groupBoxPatterns.Controls.Add(this.label1);
            this.groupBoxPatterns.Location = new System.Drawing.Point(12, 205);
            this.groupBoxPatterns.Name = "groupBoxPatterns";
            this.groupBoxPatterns.Size = new System.Drawing.Size(324, 103);
            this.groupBoxPatterns.TabIndex = 5;
            this.groupBoxPatterns.TabStop = false;
            this.groupBoxPatterns.Text = "Pattern Recognition";
            // 
            // checkBoxRythm
            // 
            this.checkBoxRythm.AutoSize = true;
            this.checkBoxRythm.Checked = global::PClapper.Properties.Settings.Default.checkRythm;
            this.checkBoxRythm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRythm.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PClapper.Properties.Settings.Default, "checkRythm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxRythm.Location = new System.Drawing.Point(9, 46);
            this.checkBoxRythm.Name = "checkBoxRythm";
            this.checkBoxRythm.Size = new System.Drawing.Size(85, 17);
            this.checkBoxRythm.TabIndex = 6;
            this.checkBoxRythm.Text = "Check rythm";
            this.toolTip.SetToolTip(this.checkBoxRythm, "When checked, the claps rythm must match the pattern.\r\nWhen unchecked, only the n" +
                    "umber of claps must match.");
            this.checkBoxRythm.UseVisualStyleBackColor = true;
            this.checkBoxRythm.CheckedChanged += new System.EventHandler(this.checkBoxRythm_CheckedChanged);
            // 
            // checkBoxTempo
            // 
            this.checkBoxTempo.AutoSize = true;
            this.checkBoxTempo.Checked = global::PClapper.Properties.Settings.Default.checkTempo;
            this.checkBoxTempo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTempo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PClapper.Properties.Settings.Default, "checkTempo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxTempo.Location = new System.Drawing.Point(9, 72);
            this.checkBoxTempo.Name = "checkBoxTempo";
            this.checkBoxTempo.Size = new System.Drawing.Size(89, 17);
            this.checkBoxTempo.TabIndex = 8;
            this.checkBoxTempo.Text = "Check tempo";
            this.toolTip.SetToolTip(this.checkBoxTempo, "When checked, clapping must be performed at the specific tempo defined above.\r\nWh" +
                    "en unchecked, clapping can be performed at any speed.");
            this.checkBoxTempo.UseVisualStyleBackColor = true;
            this.checkBoxTempo.CheckedChanged += new System.EventHandler(this.checkBoxTempo_CheckedChanged);
            // 
            // numericUpDownTempoTolerance
            // 
            this.numericUpDownTempoTolerance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PClapper.Properties.Settings.Default, "tempoTolerance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownTempoTolerance.Location = new System.Drawing.Point(260, 71);
            this.numericUpDownTempoTolerance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownTempoTolerance.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownTempoTolerance.Name = "numericUpDownTempoTolerance";
            this.numericUpDownTempoTolerance.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownTempoTolerance.TabIndex = 9;
            this.numericUpDownTempoTolerance.Value = global::PClapper.Properties.Settings.Default.tempoTolerance;
            // 
            // numericUpDownRythmTolerance
            // 
            this.numericUpDownRythmTolerance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PClapper.Properties.Settings.Default, "rythmTolerance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownRythmTolerance.Location = new System.Drawing.Point(260, 45);
            this.numericUpDownRythmTolerance.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRythmTolerance.Name = "numericUpDownRythmTolerance";
            this.numericUpDownRythmTolerance.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownRythmTolerance.TabIndex = 7;
            this.numericUpDownRythmTolerance.Value = global::PClapper.Properties.Settings.Default.rythmTolerance;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tolerance (%) :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label3, "Percentage of the tempo value (defined above)");
            // 
            // numericUpDownTempo
            // 
            this.numericUpDownTempo.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PClapper.Properties.Settings.Default, "tempo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownTempo.DataBindings.Add(new System.Windows.Forms.Binding("Minimum", global::PClapper.Properties.Settings.Default, "minTempo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownTempo.Location = new System.Drawing.Point(260, 19);
            this.numericUpDownTempo.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownTempo.Minimum = global::PClapper.Properties.Settings.Default.minTempo;
            this.numericUpDownTempo.Name = "numericUpDownTempo";
            this.numericUpDownTempo.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownTempo.TabIndex = 5;
            this.numericUpDownTempo.Value = global::PClapper.Properties.Settings.Default.tempo;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tolerance (%) :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label2, "Percentage of a beat duration.\r\nDetermines the time window within which the clap " +
                    "must occur.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tempo (BPM) :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label1, "Used:\r\n- To play back a rythm pattern (\"play\" button)\r\n- To check tempo");
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 60000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // audioDevicePicker1
            // 
            this.audioDevicePicker1.AutoSize = true;
            this.audioDevicePicker1.Location = new System.Drawing.Point(89, 19);
            this.audioDevicePicker1.Name = "audioDevicePicker1";
            this.audioDevicePicker1.selectedDeviceId = -1;
            this.audioDevicePicker1.Size = new System.Drawing.Size(229, 22);
            this.audioDevicePicker1.TabIndex = 2;
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(348, 352);
            this.Controls.Add(this.groupBoxPatterns);
            this.Controls.Add(this.groupBoxListener);
            this.Controls.Add(this.groupBoxGeneral);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnReset);
            this.Name = "SettingsDialog";
            this.Text = "Settings";
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            this.groupBoxListener.ResumeLayout(false);
            this.groupBoxListener.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkListenerBar)).EndInit();
            this.groupBoxPatterns.ResumeLayout(false);
            this.groupBoxPatterns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempoTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRythmTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnReset_Click(object sender, System.EventArgs e)
		{
            PClapper.Properties.Settings.Default.ResetNoSave();
            audioDevicePicker1.selectedDeviceId = PClapper.Properties.Settings.Default.inputDevice;
		}

        private void setEnabledComponents() {
            numericUpDownRythmTolerance.Enabled = checkBoxRythm.Checked;
            checkBoxTempo.Enabled = checkBoxRythm.Checked;
            numericUpDownTempoTolerance.Enabled = checkBoxRythm.Checked && checkBoxTempo.Checked;
        }

        private void checkBoxRythm_CheckedChanged(object sender, EventArgs e) {
            setEnabledComponents();
        }

        private void checkBoxTempo_CheckedChanged(object sender, EventArgs e) {
            setEnabledComponents();
        }

        private void audioDevicePicker1_SelectedIndexChanged(object sender, EventArgs e) {
            PClapper.Properties.Settings.Default.inputDevice = audioDevicePicker1.selectedDeviceId;
        }
	}
}
