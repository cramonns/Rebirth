using Microsoft.Xna.Framework;

namespace Rebirth {
    public class Projectile: MoveableObject{

        const float SIZE = 0.5f;
        bool isDead = false;

        public Projectile(Vector2 position, Vector2 startSpeed){
            textureId = TextureManager.TextureID.cannonball;
            usePhysics = true;
			isFixed = false;
            
			speed = startSpeed;

            textureId = TextureManager.TextureID.box;

            if (position == null){
                boundingBox = new RectangleF(new Vector2 (10f, 10f), SIZE, SIZE);
            }
            else {
                boundingBox = new RectangleF(position, SIZE, SIZE);
            }
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
                GameManager.removeObject(this);
            }
        }

        public override void Update(GameTime gameTime){
            
        }

    }
}
