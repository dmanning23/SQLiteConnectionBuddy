using SQLite.Net;
using SQLite.Net.Platform.Generic;
using System;
using System.IO;

namespace SQLiteConnectionBuddy.WindowsUniversal
{
	public class SQLiteConnectionHelper : ISQLiteConnectionHelper
	{
		#region Methods

		public SQLiteConnectionHelper()
		{
		}

		public SQLiteConnection GetConnection(string dbName)
		{
			//get the application data for the current project
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var path = Path.Combine(documentsPath, dbName);

			//This is where we copy in the prepopulated database
			if (!File.Exists(path))
			{
				File.Copy(dbName, path);
			}

			// Return the database connection 
			return new SQLiteConnection(new SQLitePlatformGeneric(), path);
		}

		#endregion //Methods
	}
}
