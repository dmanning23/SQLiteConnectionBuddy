using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace SQLiteConnectionBuddy
{
	public class SQLiteConnectionHelper:SQLiteConnectionHelperBase
	{
		#region Methods

		static SQLiteConnectionHelper()
		{
			DocumentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
			//DocumentsPath = Path.Combine(DocumentsPath, Assembly.GetEntryAssembly().GetName().Name);
		}

		private SQLiteConnectionHelper()
		{
		}

		private static SQLiteConnection GetSqlConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformWinRT(), dbName);
		}

		public static SQLiteConnection GetConnection(string dbName, bool local = false)
		{
			return local ? GetSqlConnection(dbName) : GetSqlConnection(GetFilename(dbName));
		}

		#endregion //Methods
	}
}
