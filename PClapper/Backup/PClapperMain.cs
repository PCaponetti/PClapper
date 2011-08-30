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
using System.Xml.Serialization;
using System.Diagnostics;

namespace PClapper
{
	/// <summary>
	/// Summary description for PClapperMain.
	/// </summary>
	public class PClapperMain : System.Windows.Forms.Form, ClapListener
    {
		public PluginManager pm;
		public ClapActionManager cam;
		public Listener listen;
        private ClapsSample clapsSample = new ClapsSample();
		private bool isListening = PClapper.Properties.Settings.Default.startListening;
		public static System.Timers.Timer someTimer = new System.Timers.Timer();
		public static System.Timers.Timer iconTimer = new System.Timers.Timer(200);
        private NotifyIcon sysTray;
        private ContextMenuStrip MainMenu;
        private ToolStripMenuItem mItemListen;
        private ToolStripMenuItem mItemSettings;
        private ToolStripMenuItem mItemActions;
        private ToolStripMenuItem mItemExit;
        private System.ComponentModel.IContainer components;

		public PClapperMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			pm = new PluginManager();
			cam = new ClapActionManager(pm);
			listen = new Listener();
			listen.addClapListener( this );
			someTimer.Elapsed +=new System.Timers.ElapsedEventHandler(someTimer_Elapsed);
			someTimer.AutoReset = false;
			iconTimer.Elapsed +=new System.Timers.ElapsedEventHandler(iconTimer_Elapsed);
			iconTimer.AutoReset = false;

            if (isListening)
            {
                listen.Start();
                mItemListen.Checked = true;
                sysTray.Icon = PClapper.Properties.Resources.trayIcon;
            }
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Debug.Listeners.Add(new TextWriterTraceListener("output.log"));
            Debug.AutoFlush = true;
            Debug.WriteLine("Application Start");
			Application.Run(new PClapperMain());
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			listen.Stop();
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
            Debug.WriteLine("Application End");
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PClapperMain));
            this.sysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemListen = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemActions = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysTray
            // 
            this.sysTray.ContextMenuStrip = this.MainMenu;
            this.sysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTray.Icon")));
            this.sysTray.Text = "PClapper";
            this.sysTray.Visible = true;
            this.sysTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sysTray_MouseDoubleClick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemListen,
            this.mItemSettings,
            this.mItemActions,
            this.mItemExit});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(137, 92);
            // 
            // mItemListen
            // 
            this.mItemListen.Name = "mItemListen";
            this.mItemListen.Size = new System.Drawing.Size(136, 22);
            this.mItemListen.Text = "Listen";
            this.mItemListen.Click += new System.EventHandler(this.mItemListen_Click);
            // 
            // mItemSettings
            // 
            this.mItemSettings.Name = "mItemSettings";
            this.mItemSettings.Size = new System.Drawing.Size(136, 22);
            this.mItemSettings.Text = "Settings...";
            this.mItemSettings.Click += new System.EventHandler(this.mItemSettings_Click);
            // 
            // mItemActions
            // 
            this.mItemActions.Name = "mItemActions";
            this.mItemActions.Size = new System.Drawing.Size(136, 22);
            this.mItemActions.Text = "Actions...";
            this.mItemActions.Click += new System.EventHandler(this.mItemActions_Click);
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.Size = new System.Drawing.Size(136, 22);
            this.mItemExit.Text = "Exit";
            this.mItemExit.Click += new System.EventHandler(this.mItemExit_Click);
            // 
            // PClapperMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "PClapperMain";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.MainMenu.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        public int maxPause {
            get {
                int silentBeats = Properties.Actions.Default.actionsSettings.longestSilence;
                if (Properties.Settings.Default.checkRythm && Properties.Settings.Default.checkTempo) {
                    return 300 * silentBeats * (100 + (int)Properties.Settings.Default.tempoTolerance) / (int)Properties.Settings.Default.tempo;
                }
                else {
                    return 30000 * silentBeats / (int)Properties.Settings.Default.minTempo;
                }
            }
        }

		public void clapActionPerformed(long sampleCount)
		{
			sysTray.Icon = PClapper.Properties.Resources.trayIconBlink;
            iconTimer.Start();

            clapsSample.claps.Add(sampleCount);
            someTimer.Stop();

            ActionGroup ag = cam.execute(clapsSample, true);
            
            if (maxPause == 0 || (ag != null && !ag.subPattern)) {
                clapsSample = new ClapsSample();
            }
            else {
                someTimer.Interval = maxPause;
                someTimer.Start();
            }
		}

		private void someTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			someTimer.Stop();
            cam.execute(clapsSample,false);
            clapsSample = new ClapsSample();
		}

		private void iconTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			sysTray.Icon = PClapper.Properties.Resources.trayIcon;
			sysTray.Visible = true;
		}

        private void mItemActions_Click(object sender, EventArgs e) {
            ActionsSettingsDialog dialog = new ActionsSettingsDialog(PClapper.Properties.Actions.Default.actionsSettings);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                PClapper.Properties.Actions.Default.actionsSettings = dialog.actionsSettings;
                PClapper.Properties.Actions.Default.Save();
            }
            dialog.Dispose();
        }

        private void mItemListen_Click(object sender, EventArgs e) {
            if (isListening) {
                listen.Stop();
                isListening = false;
                mItemListen.Checked = false;
                sysTray.Icon = PClapper.Properties.Resources.trayIconMuted;
            }
            else {
                listen.Start();
                isListening = true;
                mItemListen.Checked = true;
                sysTray.Icon = PClapper.Properties.Resources.trayIcon;
            }
        }

        private void mItemSettings_Click(object sender, EventArgs e) {
            SettingsDialog dialog = new SettingsDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                PClapper.Properties.Settings.Default.Save();
                if (isListening) {
                    listen.Stop();
                    listen.Start();
                }
            }
            else {
                PClapper.Properties.Settings.Default.Reload();
            }
            dialog.Dispose();
        }

        private void mItemExit_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void sysTray_MouseDoubleClick(object sender, MouseEventArgs e) {
            mItemListen_Click(sender, e);
        }
                
	}
}
