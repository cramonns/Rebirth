using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth{
	public class DisplayManager{

        //ScreenManager attributes
		private float WORLD_WIDTH = 20;
		private float screenWidth;
		private float screenHeight;
		private float Ratio;
        private float cameraPercentageToFollow = 0.4f;
        public Vector2 screenShift;

        //ScreenManager properties
        public float DisplayWidth{
            get{ return screenWidth; }          
            set{
                //Ratio = WORLD_WIDTH / screenWidth;
                screenWidth = value; 
                Ratio = WORLD_WIDTH / screenWidth;
            }
        }
        public float DisplayHeight{
            get{ return screenHeight; }          
            set{ screenHeight = value; }
        }
        public float WorldWidth{
            get{ return WORLD_WIDTH; }
            set{ 
                WORLD_WIDTH = value;
                Ratio = WORLD_WIDTH / screenWidth;
            }
        }

        //constructors
		public DisplayManager (Game1 game):this(game,1280,720){
			
		}

        public DisplayManager (Game1 game, int sWidth, int sHeight){
			game.graphics = new GraphicsDeviceManager(game);
			game.graphics.IsFullScreen = false;

            screenWidth = (float)sWidth;
            screenHeight = (float)sHeight;

            game.graphics.PreferredBackBufferWidth = (int)screenWidth;
            game.graphics.PreferredBackBufferHeight = (int)screenHeight;

            Ratio = WORLD_WIDTH / screenWidth;
            //RatioH = WORLD_WIDTH / screenHeight;

            screenShift = new Vector2(0, 0);
		}

		public Vector2 screenPosition(Vector2 WorldPosition){
			float screenX = (WorldPosition.X - screenShift.X) / Ratio;
			float screenY = (WorldPosition.Y - screenShift.Y) / Ratio;
			screenY = screenHeight - screenY;
			return new Vector2(screenX, screenY);
		}

		public Rectangle scaleTexture(Vector2 WorldPosition, float sourceWidth, float sourceHeight){
			float screenX = (WorldPosition.X - screenShift.X) / Ratio;
			float screenY = (WorldPosition.Y + sourceHeight) / Ratio;
			screenY = screenHeight - screenY;
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

