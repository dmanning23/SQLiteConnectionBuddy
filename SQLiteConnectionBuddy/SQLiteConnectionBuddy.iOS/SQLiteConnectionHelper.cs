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

		public static SQLiteConnection GetConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformIOS(), GetFilename(dbName));
		}

		#endregion //Methods
	}
}
