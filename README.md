# SQLiteConnectionBuddy
Simplify opening SQLite databases for cross-platform .Net projects.

To use:
1. add the nuget package to your Android/iOS/Win32/UQP project
2. add a seeded database as a AndroidAsset/Content file to the project
3. use the following to get a connection to the DB:

using (var db = SQLiteConnectionHelper.GetConnection("YourDatabaseName.db"))
{
	//sqlite stuff
}

to see a sample project using this package:
https://github.com/dmanning23/SQLiteConnectionBuddyTest