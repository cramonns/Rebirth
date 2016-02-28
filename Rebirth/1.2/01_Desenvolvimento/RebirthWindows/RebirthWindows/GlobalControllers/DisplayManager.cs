using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace Rebirth{
	public static class DisplayManager{

        //DisplayManager members
		private static float WORLD_WIDTH = 30;
		private static float screenWidth;
		private static float screenHeight;
		private static float Ratio;
        private static Vector2 cameraPercentageToFollow = new Vector2(0.4f,0.4f);
        public static bool followPlayer;
        public static Vector2 screenShift;

        private static bool loadDemo = false;

        //DisplayManager properties
        public static float DisplayWidth{
            get{ return screenWidth; }          
            set{
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
        public static float Right{
            get {return screenShift.X + WORLD_WIDTH;}
            set {screenShift.X = value - WORLD_WIDTH;}
        }

        //initializer
		public static void initialize(){
			initialize(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
		}

        public static void initialize(int sWidth, int sHeight){
            Game1 game = GameManager.game;
            if (loadDemo){
                cameraPercentageToFollow.X = 0.3f;
                cameraPercentageToFollow.Y = 0.4f;
                WORLD_WIDTH = 250;
            }
            
            game.graphics = new GraphicsDeviceManager(game);
			game.graphics.IsFullScreen = false;
            
            followPlayer = true;

            screenWidth = (float)sWidth;
            screenHeight = (float)sHeight;

            game.graphics.PreferredBackBufferWidth = (int)screenWidth;
            game.graphics.PreferredBackBufferHeight = (int)screenHeight;

            Ratio = WORLD_WIDTH / screenWidth;

            screenShift = new Vector2(0, 0);
		}

        public static float screenLength(float worldLength){
            return worldLength/Ratio;
        }

        public static float ToWorldLength(float screenLength){
            return screenLength*Ratio;
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
			float screenY = (WorldPosition.Y + sourceHeight - screenShift.Y) / Ratio;
			screenY = screenHeight - screenY;
			float screenW = sourceWidth / Ratio;
			float screenH = sourceHeight / Ratio;

			return new Rectangle ((int)screenX, (int)screenY, (int)screenW, (int)screenH);
		}

        public static Rectangle scaleTexture(RectangleF source){
            return scaleTexture(source.Position, source.width, source.height);
        }

        public static void Update(Vector2 playerPosition){
            if (followPlayer){
                if (playerPosition.X - screenShift.X >= (1 - cameraPercentageToFollow.X)*WORLD_WIDTH) screenShift.X = playerPosition.X - (1 - cameraPercentageToFollow.X)*WORLD_WIDTH;
                if (playerPosition.X - screenShift.X <= cameraPercentageToFollow.X*WORLD_WIDTH) screenShift.X = playerPosition.X - cameraPercentageToFollow.X*WORLD_WIDTH;
          
                if (playerPosition.Y - screenShift.Y >= (1 - cameraPercentageToFollow.Y)*screenHeight*Ratio) screenShift.Y = playerPosition.Y - (1 - cameraPercentageToFollow.Y)*screenHeight*Ratio;
                if (playerPosition.Y - screenShift.Y <= (cameraPercentageToFollow.Y)*screenHeight*Ratio) screenShift.Y = playerPosition.Y - (cameraPercentageToFollow.Y)*screenHeight*Ratio;
                
            }
        }

        public static void LoadingDemo(){
            loadDemo = true;
        }
	}
}

