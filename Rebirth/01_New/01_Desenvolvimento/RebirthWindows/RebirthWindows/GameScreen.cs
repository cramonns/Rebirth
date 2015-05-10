using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Rebirth{

	public abstract class GameScreen{

		protected SpriteBatch sb;
		protected DisplayManager sm;
        public bool loaded;

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime);
		public abstract void LoadScreen(TextureManager tm, VideoManager vm);
		//public abstract void addObject(GameObject newObject);

	}
}
