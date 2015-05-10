using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public class MenuScreen:GameScreen {

        Texture2D startButton;

        public MenuScreen(SpriteBatch sb,  DisplayManager sm){
            this.sb = sb;
            this.sm = sm;
        }

        public override void Update(GameTime gameTime){
            if (ControllerManager.TriggerStart){
                Game1.currentScreen = Game1.ScreenID.world;
            }
        }

		public override void Draw(GameTime gameTime){
            sb.Draw(startButton, new Rectangle((int)(sm.DisplayWidth-390)/2,(int)(sm.DisplayHeight*0.4),390,137), Color.White);
        }

		public override void LoadScreen(TextureManager tm, VideoManager vm){
            startButton = tm.load(TextureManager.TextureID.startButton);
        }
    }
}
