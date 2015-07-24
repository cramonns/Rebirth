using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if DEV
using Microsoft.Xna.Framework.Graphics;
#endif
using Microsoft.Xna.Framework;

namespace Rebirth {
    [Serializable]
    public class Trigger:LogicalObject {
        
        protected collisionHandler onEnter;
        protected collisionHandler onLeave;

        public Trigger(Vector2 position, Treatment collidingTreatment, Treatment enterTreatment, Treatment leaveTreatment):base(position, collidingTreatment){
            switch (enterTreatment){
                
            }
            switch (leaveTreatment){
                
            }
        }

#if DEV
        public override void Draw(SpriteBatch sb, GameTime gameTime) {
            if (DeveloperSettings.drawTriggers){
                Texture2D auxTexture = TextureManager.load(TextureManager.TextureID.cyan);
                Color color = Color.White * 0.4f;
                sb.Draw(auxTexture, DisplayManager.scaleTexture(boundingBox), color);
            }
        }
#endif

    }
}
