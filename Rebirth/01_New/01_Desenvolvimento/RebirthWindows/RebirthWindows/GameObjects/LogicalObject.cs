using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Rebirth {
    [Serializable]
    public class LogicalObject: MoveableObject {

        public enum Treatment{
            Default,
            standingCheck
        }

        protected delegate void collisionHandler(GameObject collider, CollisionDistance cd);

        protected collisionHandler handler;

        protected LogicalObject(){
        }

        public LogicalObject(Vector2 position, Treatment treatment){

            if (position == null)
			    boundingBox = new RectangleF(new Vector2 (10f, 10f), DefaultWidth, DefaultHeight);
            else boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);

            switch (treatment){
                case Treatment.Default:
                    handler = Default;
                    break;
            }
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime) {
        }

        public override void collide(GameObject g, CollisionDistance cd){
            handler.Invoke(g, cd);
        }

        public override void Update(GameTime gameTime) {
            
        }


        private void Default(GameObject collider, CollisionDistance cd){
        }

        public override void Load() {
        }

        public override void unLoad() {
        }

        public override void applyGravity(float gravity){
        }

        protected collisionHandler getDefaultTreatment(Treatment t){
            return Default;
        }

    }

}
