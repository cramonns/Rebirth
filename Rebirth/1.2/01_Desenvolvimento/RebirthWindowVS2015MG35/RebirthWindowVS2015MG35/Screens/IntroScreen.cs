using System;
//using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Storage;
//using Microsoft.Xna.Framework.Input;


namespace Rebirth {
    public class IntroScreen:GameScreen {
       // private Video video;
        //private VideoPlayer player;
        private Texture2D videoTexture;
        private double time;

        public IntroScreen(SpriteBatch sb){
            //player = new VideoPlayer();
            this.sb = sb;
            time = 0;
        }

        public override void LoadScreen(){
            //video = VideoManager.load(VideoManager.VideoID.intro);
           // if (video == null){
                videoTexture = TextureManager.load(TextureManager.TextureID.logo42bits);
            //}
        }

        public override void Update(GameTime gameTime) {
            //if (video != null){
                //player.Play(video);
                //if (player.State == MediaState.Stopped){
                    //Game1.currentScreen = Game1.ScreenID.menu;
                //}  
           // }
            //else {
                time += gameTime.ElapsedGameTime.Milliseconds;
                if (time >= 3000){
                    Game1.currentScreen = Game1.ScreenID.menu;
                }
            //}
        }

        public override void Draw(GameTime gameTime) {
            //if (video != null){
                //if (player.State != MediaState.Stopped)
                    //videoTexture = player.GetTexture();
            //}
            Rectangle screen = new Rectangle(0,0,(int)DisplayManager.DisplayWidth,(int)DisplayManager.DisplayHeight);
                         
            sb.Draw(videoTexture, screen, Color.White);
        }
    }
}
