using Microsoft.Xna.Framework;
using System;

namespace Rebirth {

    [Serializable]
    public class Canon:MoveableObject  {
        int fireRate; //miliseconds
        double time = 0;
        
        new public static float DefaultHeight {
            get {return 0.5f;}
        }

        public Canon(Vector2 position){
            colliders = null;
            usePhysics = true;
            isFixed = false;
            boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);
            fireRate = 3000;
            textureId = TextureManager.TextureID.black;
        }

        private void fire(){
            Projectile p = new Projectile(new Vector2(this.Position.X-0.6f, this.Position.Y), new Vector2(-0.13f,0));
            p.Load();
            GameManager.addObjectToScene(p);
        }

        public override void collide(GameObject b, CollisionDistance cd) {
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
