using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth{
	public static class DisplayManager{

        //ScreenManager members
		private static float WORLD_WIDTH = 20;
		private static float screenWidth;
		private static float screenHeight;
		private static float Ratio;
        private static float cameraPercentageToFollow = 0.4f;
        public static Vector2 screenShift;

        //ScreenManager properties
        public static float DisplayWidth{
            get{ return screenWidth; }          
            set{
                //Ratio = WORLD_WIDTH / screenWidth;
                screenWidth = value; 
                Ratio = WORLD_WIDTH / screenWidth;
            }
        }
        public static float DisplayHeight{
            get{ return screenHeight; }          
            set{ screenHeight = value; }
        }
        public static float WorldWidth{
            get{ return WORLD_WIDTH; }
            set{ 
                WORLD_WIDTH = value;
                Ratio = WORLD_WIDTH / screenWidth;
            }
        }

        //constructors
		public static void initialize(Game1 game){
			initialize(game,1280,720);
		}

        public static void initialize(Game1 game, int sWidth, int sHeight){
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

        public static float screenLength(float worldLength){
            return worldLength/Ratio;
        }
        
        public static float getScreenX(float worldX){
            return (worldX - screenShift.X) / Ratio;
        }

        public static float getScreenY(float worldY){
            return screenHeight - (worldY - screenShift.Y) / Ratio;
        }

        public static Vector2 worldPosition(Vector2 ScreenPosition){
            float worldX = ScreenPosition.X*Ratio + screenShift.X;
            float worldY =  (screenHeight - ScreenPosition.Y)*Ratio + screenShift.Y;
            return new Vector2(worldX, worldY);
        }

		public static Vector2 screenPosition(Vector2 WorldPosition){
			float screenX = (WorldPosition.X - screenShift.X) / Ratio;
			float screenY = (WorldPosition.Y - screenShift.Y) / Ratio;
			screenY = screenHeight - screenY;
			return new Vector2(screenX, screenY);
		}

		public static Rectangle scaleTexture(Vector2 WorldPosition, float sourceWidth, float sourceHeight){
			float screenX = (WorldPosition.X - screenShift.X) / Ratio;
			float screenY = (WorldPosition.Y + sourceHeight) / Ratio;
			screenY = screenHeight - screenY;
			float screenW = sourceWidth / Ratio;
			float screenH = sourceHeight / Ratio;

			return new Rectangle ((int)screenX, (int)screenY, (int)screenW, (int)screenH);
		}

        public static void Update(Vector2 playerPosition){
            if (playerPosition.X - screenShift.X >= (1 - cameraPercentageToFollow)*WORLD_WIDTH) screenShift.X = playerPosition.X - (1 - cameraPercentageToFollow)*WORLD_WIDTH;
            if (playerPosition.X - screenShift.X <= cameraPercentageToFollow*WORLD_WIDTH) screenShift.X = playerPosition.X - cameraPercentageToFollow*WORLD_WIDTH;
        }
	}
}

