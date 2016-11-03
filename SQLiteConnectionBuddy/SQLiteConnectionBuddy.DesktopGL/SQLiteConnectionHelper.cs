using SQLite.Net;
using SQLite.Net.Platform.Win32;
using System;
using System.IO;
using System.Reflection;

namespace SQLiteConnectionBuddy
{
	public class SQLiteConnectionHelper : SQLiteConnectionHelperBase
	{
		#region Methods

		static SQLiteConnectionHelper()
		{
			//if this is being done from a unit test, the EntryAssemly will be null
			var assembly = Assembly.GetEntryAssembly();
			if (null != assembly)
			{
				DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				DocumentsPath = Path.Combine(DocumentsPath, assembly.GetName().Name);
			}
			else
			{
				DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
				DocumentsPath = Path.Combine(DocumentsPath, "db");
			}
		}

		private SQLiteConnectionHelper()
		{
		}

		public static SQLiteConnection GetConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformWin32(), GetFilename(dbName));
		}

		#endregion //Methods
	}
}
