using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SQLiteConnectionBuddy;
using System.Collections.Generic;

namespace SQLiteConnectionBuddyExample
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Catpants> data;

        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ////use "false" for things like high score tables, will be created in correct folder
            //using (var db = SQLiteConnectionHelper.GetConnection("Catpants2.db", false)) 
            using (var db = SQLiteConnectionHelper.GetConnection("Catpants2.db", true)) //use true for local development
            {
                //this will create the table if it doesn exist, upgrade if it has changed, or nothing if it is the same
                db.CreateTable<Catpants>();

                //get all the catpants values
                data = new List<Catpants>();
                foreach (var catpant in db.Table<Catpants>())
                {
                    data.Add(catpant);
                }
            }

            font = Content.Load<SpriteFont>("TestFont");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
#if !__IOS__
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
#endif
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            var position = new Vector2(8);
            foreach (var catpant in data)
            {
                spriteBatch.DrawString(font, $"{catpant.Name} {catpant.Number}", position, Color.White);
                position.Y += font.LineSpacing;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
