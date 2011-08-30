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
	/// Summary description for OpenFileProgAction.
	/// </summary>
	public class OpenFileProgAction : Action
	{
		private string path;
        private string args = "";
        private string myName = "Open File or Program Action";

		public string Name
		{
			get	{return myName;}
		}

		public OpenFileProgAction(string path, string args)
		{
			this.path = path;
            this.args = args;
		}

		public bool Execute()
		{
			System.Diagnostics.Process.Start(path,args);
			return true;
		}

		public string toString()
		{
			return this.myName;
		}
	}
}
