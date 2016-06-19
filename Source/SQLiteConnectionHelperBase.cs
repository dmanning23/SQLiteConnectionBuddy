using System.IO;

namespace SQLiteConnectionBuddy
{
	public abstract class SQLiteConnectionHelperBase
	{
		#region Properties

		private static bool Initialized { get; set; }

		/// <summary>
		/// the application data folder for the current project
		/// </summary>
		protected static string DocumentsPath { get; set; }

		#endregion //Properties

		#region Methods

		static SQLiteConnectionHelperBase()
		{
			Initialized = false;
		}

		protected static string GetFilename(string dbName)
		{
			var path = Path.Combine(DocumentsPath, dbName);

			if (!Initialized)
			{
				//This is where we copy in the prepopulated database
				if (!File.Exists(path) && File.Exists(dbName))
				{
					Directory.CreateDirectory(DocumentsPath);
					File.Copy(dbName, path);
				}

				Initialized = true;
			}

			//Return the full path & filename to the database
			return path;
		}

		#endregion //Methods
	}
}
