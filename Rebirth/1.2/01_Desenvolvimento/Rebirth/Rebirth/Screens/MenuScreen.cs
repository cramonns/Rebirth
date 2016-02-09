using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public class MenuScreen:GameScreen {

        Texture2D startButton;

        public MenuScreen(SpriteBatch sb){
            this.sb = sb;
        }

        public override void Update(GameTime gameTime){
            if (ControllerManager.TriggerStart){
                Game1.currentScreen = Game1.ScreenID.world;
                GameManager.game.getWorld().player = new Player();
                GameManager.game.getWorld().player.Load();
            }
        }

		public override void Draw(GameTime gameTime){
            sb.Draw(startButton, new Rectangle((int)(DisplayManager.DisplayWidth-390)/2,(int)(DisplayManager.DisplayHeight*0.4),390,137), Color.White);
        }

		public override void LoadScreen(){
            startButton = TextureManager.load(TextureManager.TextureID.startButton);
        }
    }
}
