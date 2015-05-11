using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Rebirth{

	public abstract class GameScreen{

		protected SpriteBatch sb;
        public bool loaded;

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime);
		public abstract void LoadScreen();
		//public abstract void addObject(GameObject newObject);

	}
}
