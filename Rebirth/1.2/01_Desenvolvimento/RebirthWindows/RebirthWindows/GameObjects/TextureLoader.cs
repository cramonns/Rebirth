using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rebirth {
    [Serializable]
    public class TextureLoader:GameTrigger {

        public TextureLoader (Vector2 position, TextureManager.TextureID id):base(position, Treatment.Default, Treatment.Default, Treatment.Default){
            this.textureId = id;
            onEnter = preloadTexture;
        }

        private void preloadTexture(GameObject collider, CollisionDistance cd){
            TextureManager.load(textureId);
        }

        private void Default(GameObject collider, CollisionDistance cd){
        }

        public override void unLoad(){
        }

#if EDITOR
        /*public override void specificXML() { 
            
        }*/
#endif

    }
}
