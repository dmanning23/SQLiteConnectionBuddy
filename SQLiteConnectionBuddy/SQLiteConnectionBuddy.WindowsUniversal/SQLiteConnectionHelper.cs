using SQLite.Net;
using SQLite.Net.Platform.WinRT;
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
			string documentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
			var path = Path.Combine(documentsPath, dbName);

			//This is where we copy in the prepopulated database
			if (!File.Exists(path))
			{
				File.Copy(dbName, path);
			}

			// Return the database connection 
			return new SQLiteConnection(new SQLitePlatformWinRT(), path);
		}

		#endregion //Methods
	}
}
