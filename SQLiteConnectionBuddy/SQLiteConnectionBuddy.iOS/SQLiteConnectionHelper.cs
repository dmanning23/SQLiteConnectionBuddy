using SQLite;
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
			DocumentsPath = Path.Combine(DocumentsPath, Assembly.GetEntryAssembly().GetName().Name);
		}

		private SQLiteConnectionHelper()
		{
		}

		private static SQLiteConnection GetSqlConnection(string dbName)
		{
			return new SQLiteConnection(dbName);
		}

		public static SQLiteConnection GetConnection(string dbName, bool local = false)
		{
			return local ? GetSqlConnection(dbName) : GetSqlConnection(GetFilename(dbName));
		}

		/// <summary>
		/// This method copies a pre-seeded database from the Assets folder to the local filesystem
		/// </summary>
		/// <param name="dbName"></param>
		public static void CopyEmbeddedDatabase(string dbName, bool force = false)
		{
			//check if the db exists on the local filesystem
			var path = Path.Combine(DocumentsPath, dbName);
			if (!Directory.Exists(DocumentsPath))
			{
				Directory.CreateDirectory(DocumentsPath);
			}

			//If there is a prepopulated database, copy it over and use that one
			if (force || (!File.Exists(path) && File.Exists(dbName)))
			{
				File.Copy(dbName, path, true);
			}
		}

		#endregion //Methods
	}
}
