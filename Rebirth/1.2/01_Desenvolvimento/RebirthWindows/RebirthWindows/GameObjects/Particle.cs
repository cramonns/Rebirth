using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebirth {
    public class Particle:MoveableObject {

        public override void collide(GameObject b, CollisionDistance cd) {
        //    throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            //throw new NotImplementedException();
            Position += speed;
            if (Position.X < -400) {
                boundingBox.x += DisplayManager.DisplayWidth;
            }
            if (Position.Y > DisplayManager.DisplayHeight-40) boundingBox.y -= DisplayManager.DisplayHeight;
        }

        public Particle (){
        boundingBox = new RectangleF(00,0,0,0);
        }

        
    }
}
