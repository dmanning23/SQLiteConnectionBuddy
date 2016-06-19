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

		public static SQLiteConnection GetConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformWinRT(), GetFilename(dbName));
		}

		#endregion //Methods
	}
}
