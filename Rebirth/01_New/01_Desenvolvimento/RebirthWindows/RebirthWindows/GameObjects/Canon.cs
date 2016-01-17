using Microsoft.Xna.Framework;
using System;

namespace Rebirth {

    [Serializable]
    public class Canon:MoveableObject  {
        int fireRate; //miliseconds
        double time = 0;
        

        public Canon(Vector2 position){
            usePhysics = true;
            isFixed = false;
            boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);
            fireRate = 3000;
            texture = TextureManager.blackTexture;
        }

        private void fire(){
            Projectile p = new Projectile(this.Position, new Vector2(-0.1f,0));
            GameManager.addObjectToScene(p);
        }

        public override void collide(GameObject b, CollisionDistance cd) {
            //throw new System.NotImplementedException();
        }

        public override void Update(GameTime gameTime){
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time > fireRate){
                fire();
                time -= fireRate;
            }
        }
    }
}
