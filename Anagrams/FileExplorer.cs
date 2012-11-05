using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace RecursiveFileExplorer
{
	public class FileExplorer
	{
		public ArrayList FileList = new ArrayList();
		public ArrayList Extensions = null;
		private string Path = "";
		private bool Recursive = true;

		/// <summary>
		/// Constructor called if filepath argument given.
		/// </summary>
		/// <param name="filepath">Initial path to search from.</param>
		public FileExplorer( string path  )
		{
			this.Path = path;
			this.Recursive = false;
			this.FileList = this.getFiles();
		}

		/// <summary>
		/// Constructor called if filepath and extensions arguments given.
		/// </summary>
		/// <param name="filepath">Initial path to search from.</param>
		/// <param name="extensions">Arraylist of file extensions to filter results by.</param>
		public FileExplorer( string path, ArrayList extensions  )
		{
			this.Path = path;
			this.Extensions = extensions;
			this.Recursive = false;
			this.FileList = this.getFiles();
		}

		/// <summary>
		/// Constructor called if filepath and recursive arguments given.
		/// </summary>
		/// <param name="filepath">Initial path to search from.</param>
		/// <param name="recursive">Specifies whether to use recursion to search sub-folders.</param>
		public FileExplorer( string path, bool recursive  )
		{
			this.Path = path;
			this.Recursive = recursive;
			this.FileList = this.getFiles();
		}

		/// <summary>
		/// Constructor called if filepath, extensions and recursive arguments given.
		/// </summary>
		/// <param name="filepath">Initial path to search from.</param>
		/// <param name="extensions">Arraylist of file extensions to filter results by.</param>
		/// <param name="recursive">Specifies whether to use recursion to search sub-folders.</param>
		public FileExplorer( string path, ArrayList extensions, bool recursive  )
		{
			this.Path = path;
			this.Extensions = extensions;
			this.Recursive = recursive;
			this.FileList = this.getFiles();
		}

		/// <summary>
		/// Searches through directory and sub-directories for files.
		/// </summary>
		/// <returns>ArrayList of files found.</returns>
		public ArrayList getFiles()
		{
			DirectoryInfo   dir = new DirectoryInfo( this.Path );
			FileInfo[]      files;
			DirectoryInfo[] dirs;
			ArrayList List = new ArrayList();
        
			//if the source dir doesn't exist, throw
			if (! dir.Exists)
			{
				throw new Exception("Source directory doesn't exist: " + this.Path );
			}

			//get all files in the current dir
			files = dir.GetFiles();

			//loop through each file
			foreach(FileInfo file in files)
			{
				if( this.Extensions == null )
				{
					List.Add( new FileData( file.FullName, file.Name, file.Extension, file.Length ) );
				}
				else 
				{
					if( this.checkFile( file.Extension ) )
					{
						List.Add( new FileData( file.FullName, file.Name, file.Extension, file.Length ) );
					}
				}
			}

			//cleanup
			files = null;
        
			//if not recursive, all work is done
			if (! this.Recursive)
			{
				return List;
			}

			//otherwise, get dirs
			dirs = dir.GetDirectories();

			//loop through each sub directory in the current dir
			foreach(DirectoryInfo subdir in dirs)
			{
				this.Path = subdir.FullName;
				ArrayList temp = new ArrayList();
				temp = getFiles();
				for(int i=0; i < temp.Count; i++)
				{
					FileData TempData = (FileData)temp[i];
					List.Add( new FileData( TempData.FullName, TempData.Name, TempData.Extension, TempData.Length ) );
				}
			}
        
			//cleanup
			dirs = null;
        
			dir = null;

			return List;
		}

		/// <summary>
		/// Matches current file extension against given file extension.
		/// </summary>
		/// <param name="strExtension">Extension to match against.</param>
		/// <returns>Whether current file extension matches given file extension.</returns>
		private bool checkFile( string strExtension )
		{
			bool throwaway = true;
			for(int j=0; j<this.Extensions.Count; j++)
			{
				if( this.Extensions[j].ToString() == strExtension )
				{
					throwaway = false;
				}
			}

			if( throwaway )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

	}
}
