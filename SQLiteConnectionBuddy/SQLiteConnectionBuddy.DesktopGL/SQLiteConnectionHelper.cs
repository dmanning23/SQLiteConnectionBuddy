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

		private static SQLiteConnection GetSqlConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformWin32(), dbName);
		}

		public static SQLiteConnection GetConnection(string dbName, bool local = false)
		{
			return local ? GetSqlConnection(dbName) : GetSqlConnection(GetFilename(dbName));
		}

		#endregion //Methods
	}
}
