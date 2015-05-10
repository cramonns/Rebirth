using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth{
	public class ScreenManager{

		private float WORLD_WIDTH = 20;
		private float ScreenWidth;
		private float ScreenHeight;
		private float Ratio;
        private float cameraPercentageToFollow = 0.4f;
        public Vector2 screenShift;

		public ScreenManager (Game1 game){
			game.graphics = new GraphicsDeviceManager(game);
			game.graphics.IsFullScreen = false;

            ScreenWidth = 1280;
            ScreenHeight = 720;

            game.graphics.PreferredBackBufferWidth = (int)ScreenWidth;
            game.graphics.PreferredBackBufferHeight = (int)ScreenHeight;

            Ratio = WORLD_WIDTH / ScreenWidth;

            screenShift = new Vector2(0, 0);
		}

		public Vector2 screenPosition(Vector2 WorldPosition){
			float screenX = (WorldPosition.X - screenShift.X) / Ratio;
			float screenY = (WorldPosition.Y - screenShift.Y) / Ratio;
			screenY = ScreenHeight - screenY;
			return new Vector2(screenX, screenY);
		}

		public Rectangle scaleTexture(Vector2 WorldPosition, float sourceWidth, float sourceHeight){
			float screenX = (WorldPosition.X - screenShift.X) / Ratio;
			float screenY = (WorldPosition.Y + sourceHeight) / Ratio;
			screenY = ScreenHeight - screenY;
			float screenW = sourceWidth / Ratio;
			float screenH = sourceHeight / Ratio;

			return new Rectangle ((int)screenX, (int)screenY, (int)screenW, (int)screenH);
		}

        public void Update(Vector2 playerPosition){
            if (playerPosition.X - screenShift.X >= (1 - cameraPercentageToFollow)*WORLD_WIDTH) screenShift.X = playerPosition.X - (1 - cameraPercentageToFollow)*WORLD_WIDTH;
            if (playerPosition.X - screenShift.X <= cameraPercentageToFollow*WORLD_WIDTH) screenShift.X = playerPosition.X -cameraPercentageToFollow*WORLD_WIDTH;
        }
	}
}

