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
			DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			DocumentsPath = Path.Combine(DocumentsPath, Assembly.GetEntryAssembly().GetName().Name);
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
