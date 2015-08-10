using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public class Attachment:LogicalObject {

        private GameObject owner;

        float relativeX, relativeY;

        public Attachment(Treatment treatment, GameObject owner, float relativeX, float relativeY, float width, float height){
            this.boundingBox = new RectangleF(owner.X + relativeX, owner.Y + relativeY, width, height);
            this.speed = new Vector2(0,0);
            this.relativeX = relativeX;
            this.relativeY = relativeY;
            this.owner = owner;
            switch (treatment){
                case Treatment.standingCheck:
                    handler = standingCheck;
                    break;
            }
        }

        public override void Update(GameTime gameTime) {
            
        }

        public override void integratePosition(){
            boundingBox.x = owner.X + relativeX;
            boundingBox.y = owner.Y + relativeY;
        }

        public override void applyGravity(float gravity) {
        }

        private void standingCheck(GameObject collider, CollisionDistance cd){
            Player p = owner as Player;
            if (!(collider is LogicalObject)) p.allowStanding = false;
        }
                
    }
}
