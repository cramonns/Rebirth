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
    public class GameTrigger:LogicalObject {

        List<GameObject> lastFrameColliders;
        List<GameObject> currentFrameColliders;
        public Treatment enterTreatment;
        public Treatment leaveTreatment;
        
        protected collisionHandler onEnter;
        protected collisionHandler onLeave;

        public override void Update(GameTime gameTime) {
            foreach (GameObject g in lastFrameColliders){
                if (!currentFrameColliders.Contains(g)){
                    onLeave.Invoke(g, new CollisionDistance(CollisionDistance.CD_Direction.DOWN, 0));
                }
            }
            lastFrameColliders.Clear();
            lastFrameColliders = currentFrameColliders;
            currentFrameColliders = new List<GameObject>();
        }

        public GameTrigger(Vector2 position, Treatment collidingTreatment, Treatment enterTreatment, Treatment leaveTreatment):base(position, collidingTreatment){
            this.enterTreatment = enterTreatment;
            this.leaveTreatment = leaveTreatment;
            
            lastFrameColliders = new List<GameObject>();
            currentFrameColliders = new List<GameObject>();
            switch (enterTreatment){
                case Treatment.droppedUmprellaEnter:
                    onEnter = enterUmbrella;
                    break;
            }
            switch (leaveTreatment){
                case Treatment.droppedUmbrellaLeave:
                    onLeave = leaveUmbrella;
                    break;
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


        public void enterUmbrella(GameObject collider, CollisionDistance cd){
            if (collider is Player){
                GameManager.globalVariables.overUmbrella = true;
            }
        }

        public void leaveUmbrella(GameObject collider, CollisionDistance cd){
            if (collider is Player){
                GameManager.globalVariables.overUmbrella = false;
            }
        }

        public override void collide(GameObject g, CollisionDistance cd) {
            
            if (!lastFrameColliders.Contains(g)){
                onEnter.Invoke(g, cd);
            }

            currentFrameColliders.Add(g);
        }
    }
}
