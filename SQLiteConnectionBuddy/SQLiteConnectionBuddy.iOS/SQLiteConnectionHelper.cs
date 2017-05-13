using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
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
			DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			//string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			DocumentsPath = Path.Combine(DocumentsPath, Assembly.GetEntryAssembly().GetName().Name);
		}

		private SQLiteConnectionHelper()
		{
		}

		private static SQLiteConnection GetSqlConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformIOS(), dbName);
		}

		public static SQLiteConnection GetConnection(string dbName, bool local = false)
		{
			return local ? GetSqlConnection(dbName) : GetSqlConnection(GetFilename(dbName));
		}

		#endregion //Methods
	}
}
