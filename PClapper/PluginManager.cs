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

namespace PClapper
{
	/// <summary>
	/// Summary description for PluginManager.
	/// </summary>
	public class PluginManager
	{
		public System.Collections.Hashtable ClapperPlugins;

		public PluginManager()
		{
			getPlugins();
		}

		private void getPlugins()
		{
			ClapperPlugins = new System.Collections.Hashtable();
			foreach (string fileOn in System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "Plugins"))
			{
				System.IO.FileInfo file = new System.IO.FileInfo(fileOn);
				
				//Preliminary check, must be .dll
				if (file.Extension.Equals(".dll"))
				{	
					//Add the 'plugin'
					this.AddPlugin(fileOn);				
				}
			}
		}

		private void AddPlugin(string file)
		{
			System.Reflection.Assembly pluginAsm = System.Reflection.Assembly.LoadFrom(file);
			foreach (Type pluginType in pluginAsm.GetTypes())
			{
				if (pluginType.IsPublic)
				{
					if (!pluginType.IsAbstract)
					{
						Type typeInterface = pluginType.GetInterface("ClapperPluginInterface.IClapperPlugin", true);
						if (typeInterface != null)
						{
							ClapperPluginInterface.IClapperPlugin newPlugin;
							newPlugin = (ClapperPluginInterface.IClapperPlugin)Activator.CreateInstance(pluginAsm.GetType(pluginType.ToString()));
							newPlugin.Initialize();
							this.ClapperPlugins.Add(newPlugin.Name, newPlugin);
							newPlugin = null;
						}	
						typeInterface = null;
					}				
				}
			}
			pluginAsm = null;
		}
	}
}
