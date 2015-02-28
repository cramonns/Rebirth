using System;
using Microsoft.Xna.Framework;

namespace Rebirth{
	public class ScreenManager{

		private const float WORLD_WIDTH = 20;
		private float ScreenWidth;
		private float ScreenHeight;
		private float Ratio;

		public ScreenManager (Game1 game){
			game.graphics = new GraphicsDeviceManager(game);
			game.graphics.IsFullScreen = false;

			ScreenWidth = game.Window.ClientBounds.Width;
			ScreenHeight = game.Window.ClientBounds.Height;
			Ratio = WORLD_WIDTH / ScreenWidth;
		}

		public Vector2 screenPosition(Vector2 WorldPosition){
			float screenX = WorldPosition.X / Ratio;
			float screenY = WorldPosition.Y / Ratio;
			screenY = ScreenHeight - screenY;
			return new Vector2(screenX, screenY);
		}

		public Rectangle scaleTexture(Vector2 WorldPosition, float sourceWidth, float sourceHeight){
			float screenX = WorldPosition.X / Ratio;
			float screenY = (WorldPosition.Y + sourceHeight) / Ratio;
			screenY = ScreenHeight - screenY;
			float screenW = sourceWidth / Ratio;
			float screenH = sourceHeight / Ratio;

			return new Rectangle ((int)screenX, (int)screenY, (int)screenW, (int)screenH);
		}
	}
}

