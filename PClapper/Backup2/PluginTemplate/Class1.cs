using System;

namespace PluginTemplate
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Class1 : ClapperPluginInterface.IClapperPlugin
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

		public Class1()
		{
		}

		public bool Initialize()
		{
			myAuthor = "Author Here";
			myDescription = "Description Here";
			myVersion = "1.0";
			myName = "Name of Plugin Here";
			return true;
		}
		public bool Dispose()
		{
			return true;
		}
		public bool Execute()
		{
			System.Windows.Forms.MessageBox.Show("TODO: Add execute code");
			return true;
		}
		public string toString()
		{
			return myName;
		}
	}
}
