using System;

namespace RecursiveFileExplorer
{
	/// <summary>
	/// This class holds data concerning individual files, and is used to 
	/// instantiate an object for each file that is then returned in the linked 
	/// list by the DirectorySearcher object.
	/// </summary>
	public class FileData
	{
		private string myFullName;
		private string myName;
		private string myExtension;
		private long myLength;

		public  FileData(){}

		public  FileData( string strFullName, string strName, string strExtension, long intLength )
		{
			this.myFullName = strFullName;
			this.myName = strName;
			this.myExtension = strExtension;
			this.myLength = intLength;
		}

		public string FullName
		{
			get
			{
				return this.myFullName;
			}
		}

		public string Name
		{
			get
			{
				return this.myName;
			}
		}

		public string Extension
		{
			get
			{
				return this.myExtension;
			}
		}

		public long Length
		{
			get
			{
				return this.myLength;
			}
		}

		public override string ToString()
		{
			return this.myFullName;
		}
	}
}
