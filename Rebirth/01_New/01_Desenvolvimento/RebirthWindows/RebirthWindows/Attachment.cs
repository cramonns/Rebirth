using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public class Attachment:LogicalObject {

        private GameObject owner;

        public Attachment(Treatment treatment, GameObject owner){
            this.owner = owner;
            switch (treatment){
                case Treatment.standingCheck:
                    handler = standingCheck;
                    break;
            }
            
        }

        private void standingCheck(GameObject collider, CollisionDistance cd){
            Player p = owner as Player;
            p.allowStanding = false;
        }

        public override void Update(GameTime gameTime) {
            
        }
    }
}
