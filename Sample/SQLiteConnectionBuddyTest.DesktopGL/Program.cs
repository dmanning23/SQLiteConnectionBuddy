using SQLiteConnectionBuddy;
using System;

namespace SQLiteConnectionBuddyTest.DesktopGL
{
	/// <summary>
	/// The main class.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//initialize the database
			SQLiteConnectionHelper.CopyEmbeddedDatabase("Catpants.db", true);

			using (var game = new Game1())
				game.Run();
		}
	}
}
