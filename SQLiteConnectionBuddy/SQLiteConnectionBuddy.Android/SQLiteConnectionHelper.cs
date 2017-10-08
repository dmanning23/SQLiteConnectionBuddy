using Android.App;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;

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

		private static SQLiteConnection GetSqlConnection(string dbName)
		{
			return new SQLiteConnection(new SQLitePlatformAndroidN(), dbName);
		}

		public static SQLiteConnection GetConnection(string dbName, bool local = false)
		{
			return local ? GetSqlConnection(dbName) : GetSqlConnection(GetFilename(dbName));
		}

		/// <summary>
		/// This method copies a pre-seeded database from the Assets folder to the local filesystem
		/// </summary>
		/// <param name="dbName"></param>
		public static void CopyEmbeddedDatabase(string dbName, Activity activity, bool force = false)
		{
			//check if the db exists on the local filesystem
			var path = Path.Combine(DocumentsPath, dbName);
			if (!Directory.Exists(DocumentsPath))
			{
				Directory.CreateDirectory(DocumentsPath);
			}

			if (!File.Exists(path) || force)
			{
				//get the assets object
				var assets = activity.Assets;

				//get the file stream
				using (var embeddedDb = assets.Open(dbName))
				{
					using (var localDb = new FileStream(path, FileMode.Create))
					{
						//copy to the local filesystem
						embeddedDb.CopyTo(localDb);
					}
				}
			}
		}

		#endregion //Methods
	}
}
