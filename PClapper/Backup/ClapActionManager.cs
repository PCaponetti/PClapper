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
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace PClapper
{
	/// <summary>
	/// Summary description for ClapActionManager.
	/// </summary>
	public class ClapActionManager
	{
		private PluginManager pm;

		public ClapActionManager(PluginManager pmer)
		{
			pm = pmer;
		}
        
        // return group of actions or null if no match
		public ActionGroup execute(ClapsSample sample, bool immediate)
		{
            ActionGroup groupToExecute = null;
            int closestTempoDelta = 0;
            int tempo = (int)PClapper.Properties.Settings.Default.tempo;
            foreach (ActionGroup g in PClapper.Properties.Actions.Default.actionsSettings.actionGroups) {
                if ((immediate == g.immediate) && g.pattern.match(sample)) {
                    int tempoDelta = Math.Abs( tempo - g.pattern.tempo(sample) );
                    if (groupToExecute == null || tempoDelta < closestTempoDelta ) {
                        groupToExecute = g;
                        closestTempoDelta = tempoDelta;
                    }
                }
            }
            if (groupToExecute == null) return null;

            // Execute group
            foreach (ActionSetting a in groupToExecute.actions) {
                if (a.action.IndexOf("Launch") == 0)
                    new OpenFileProgAction("\"" + a.action.Replace("Launch ", "") + "\"", "").Execute();
                else if (a.action.IndexOf("Open") == 0) {
                    new OpenFileProgAction(a.action.Replace("Open ", ""), a.parameters).Execute();
                }
                else if (pm.ClapperPlugins[a.action] != null) {
                    ((ClapperPluginInterface.IClapperPlugin)pm.ClapperPlugins[a.action]).Execute();
                }
                else {
                    MessageBox.Show("Error: Cannot find action '" + a.action + "'");
                }
            }

            return groupToExecute;
		}

	}
}
