using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using System;
using System.IO;

namespace SQLiteConnectionBuddy.iOS
{
	public class SQLiteConnectionHelper : ISQLiteConnectionHelper
	{
		#region Methods

		public SQLiteConnectionHelper()
		{
		}

		public SQLiteConnection GetConnection(string dbName)
		{
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, dbName);

			//This is where we copy in the prepopulated database
			if (!File.Exists(path))
			{
				File.Copy(dbName, path);
			}

			// Return the database connection 
			return new SQLiteConnection(new SQLitePlatformIOS(), path);
		}

		#endregion //Methods
	}
}
