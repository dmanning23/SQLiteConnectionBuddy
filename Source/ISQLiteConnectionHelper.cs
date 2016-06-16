using SQLite.Net;

namespace SQLiteConnectionBuddy
{
	public interface ISQLiteConnectionHelper
	{
		/// <summary>
		/// Get a sqlite connection to the specified database.
		/// If it doesn exist, copy the one from the application resources
		/// </summary>
		/// <param name="dbName">TodoSQLite.db3</param>
		/// <returns></returns>
		SQLiteConnection GetConnection(string dbName);
	}
}
