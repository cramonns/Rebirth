using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Rebirth{

	public abstract class GameScreen{

		protected SpriteBatch sb;
		protected ScreenManager sm;
		public bool loaded;

		public abstract void Update();
		public abstract void Draw();
		public abstract void LoadScreen(ContentManager Content);
		public abstract void addObject(GameObject newObject);

	}
}
