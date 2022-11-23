using System;
using Foundation;
using SQLiteConnectionBuddy;
using UIKit;

namespace SQLiteConnectionBuddyTest.iOS
{
	[Register("AppDelegate")]
	class Program : UIApplicationDelegate
	{
		private static Game1 game;

		internal static void RunGame()
		{
			//initialize the database
			SQLiteConnectionHelper.CopyEmbeddedDatabase("Catpants.db", true);

			game = new Game1();
			game.Run();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}

		public override void FinishedLaunching(UIApplication app)
		{
			RunGame();
		}
	}
}
