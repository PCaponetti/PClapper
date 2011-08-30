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

namespace ClapperPluginInterface
{
	/// <summary>
	/// Summary description for IClapperPlugin.
	/// </summary>
	public interface IClapperPlugin
	{
		string Name {get;}
		string Description {get;}
		string Author {get;}
		string Version {get;}

		bool Initialize();
		bool Execute();
		bool Dispose();
		string toString();
	}
}
