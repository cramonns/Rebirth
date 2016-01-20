using Microsoft.Xna.Framework;
using System;

namespace Rebirth {
    public class Projectile: MoveableObject{

        const float SIZE = 0.5f;
        public bool isDead = false;
        Vector2 startSpeed;

        public Projectile(Vector2 position, Vector2 startSpeed){
            
            textureId = TextureManager.TextureID.canonball;
            usePhysics = true;
			isFixed = false;
            
			speed = startSpeed;
            this.startSpeed = startSpeed;

            if (position == null){
                boundingBox = new RectangleF(new Vector2 (10f, 10f), SIZE, SIZE);
            }
            else {
                boundingBox = new RectangleF(position, SIZE, SIZE);
            }
            colliders = new System.Collections.Generic.List<RectangleF>(3);
            float side = SIZE*((float)Math.Sqrt(2))/3f;
            float side2 = (SIZE-side)/2;
            colliders.Add(new RectangleF(side2, side2, side, side));
            side /= 2.6f;
            side2 = (float)Math.Sqrt(Math.Pow(SIZE/2f,2)-Math.Pow(side/2f,2));
            colliders.Add(new RectangleF((SIZE - side)/2, (SIZE - side2)/2, side, side2));
            colliders.Add(new RectangleF((SIZE - side2)/2, (SIZE - side)/2, side2, side));
        }

        public override void applyGravity(float gravity) {
            if (isDead){
                base.applyGravity(gravity);
            }
        }

        public override void collide(GameObject b, CollisionDistance cd) {
            if (b is Umbrella)
                isDead = true;
            else {
                if (!(b is Canon)){
                    GameManager.removeObject(this);
                }
            }
        }

        public override void Update(GameTime gameTime){
            if (!isDead){
                speed = startSpeed;
            }
        }

    }
}
