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
            //if this is being done from a unit test, the EntryAssemly will be null
            var assembly = Assembly.GetEntryAssembly();
            if (null != assembly)
            {
                DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                DocumentsPath = Path.Combine(DocumentsPath, assembly.GetName().Name);
            }
            else
            {
                DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                DocumentsPath = Path.Combine(DocumentsPath, "db");
            }
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

        public static void CopyEmbeddedDatabase(string dbName, bool force = false)
        {
            var path = Path.Combine(DocumentsPath, dbName);

            //If the requested folder doesnt exist, create it
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