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
	/// Summary description for ClapListener.
	/// </summary>
	public interface ClapListener
	{
		void clapActionPerformed(long sampleCount);
	}
}
