#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Rebirth{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game{
		public GraphicsDeviceManager graphics;
		public SpriteBatch spriteBatch;		
		Player player;
		GameScreen currentScreen;
		ScreenManager screenManager;

		public Game1(){
			//this.Content = new Microsoft.Xna.Framework.Content.ContentManager(null, "Content");
			Content.RootDirectory = "Content";	            
			screenManager = new ScreenManager(this);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize(){
			// TODO: Add your initialization logic here
			base.Initialize();

		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent(){
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			player = new Player();
			currentScreen = new Screen2(spriteBatch,screenManager);
			currentScreen.addObject(player);
			currentScreen.LoadScreen(Content); 
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime){
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			/*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed){
				Exit();
			}*/

			ControllerManager.Update ();
			currentScreen.Update ();

			// TODO: Add your update logic here			
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime){
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			currentScreen.Draw();
			//TODO: Add your drawing code here

			spriteBatch.End();
			base.Draw(gameTime);
		}

		public ScreenManager getScreenManager(){
			return screenManager;
		}
	}
}
