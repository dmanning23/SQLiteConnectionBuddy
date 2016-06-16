using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;

namespace SQLiteConnectionBuddy.Android
{
	public class SQLiteConnectionHelper : ISQLiteConnectionHelper
	{
		#region Methods

		public SQLiteConnectionHelper()
		{
		}

		public SQLiteConnection GetConnection(string dbName)
		{
			//get the Documents folder
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, dbName);

			// Create the connection
			var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);

			//This is where we copy in the prepopulated database
			if (!File.Exists(path))
			{
				File.Copy(dbName, path);
			}

			// Return the database connection
			return conn;
		}

		#endregion //Methods
	}
}
