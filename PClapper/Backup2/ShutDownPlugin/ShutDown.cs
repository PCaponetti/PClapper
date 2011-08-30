using System;

namespace ShutDownPlugin
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ShutDown : ClapperPluginInterface.IClapperPlugin
	{
		string myName;
		string myDescription;
		string myAuthor;
		string myVersion;
		
		public string Description
		{
			get {return myDescription;}
		}
		public string Author
		{
			get	{return myAuthor;}
		
		}
		public string Version
		{
			get {return myVersion;}
		}
		public string Name
		{
			get	{return myName;}
		
		}

		public ShutDown()
		{
		}

		public bool Initialize()
		{
			myAuthor = "Paul Caponetti & Code Project";
			myDescription = "ShutDown your computer";
			myVersion = "1.0";
			myName = "Shutdown computer";
			return true;
		}
		public bool Dispose()
		{
			return true;
		}
		public bool Execute()
		{
			System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/Plugins/shutdown.bat");
			return true;
		}
		public string toString()
		{
			return myName;
		}
	}
}