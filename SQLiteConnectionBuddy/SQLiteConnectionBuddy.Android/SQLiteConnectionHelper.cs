using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace SQLiteConnectionBuddy
{
	public class SQLiteConnectionHelper : SQLiteConnectionHelperBase
	{
		#region Methods

		static SQLiteConnectionHelper()
		{
			DocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		}

		private SQLiteConnectionHelper()
		{
		}

		public static SQLiteConnection GetConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformAndroid(), GetFilename(dbName));
		}

		#endregion //Methods
	}
}
