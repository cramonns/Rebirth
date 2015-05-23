using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public class LogicalObject: MoveableObject {

        public enum Treatment{
            Default,
            standingCheck
        }

        protected delegate void collisionHandler(GameObject collider, CollisionDistance cd);

        protected collisionHandler handler;

        protected LogicalObject(){
        }

        public LogicalObject(Treatment treatment){
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

    }
}
