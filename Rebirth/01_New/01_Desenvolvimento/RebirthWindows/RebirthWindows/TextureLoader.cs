using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebirth {
    public class TextureLoader:Trigger {

        TextureManager.TextureID id;

        TextureLoader (TextureManager.TextureID id):base(Treatment.Default, Treatment.Default, Treatment.Default){
            this.id = id;
            onEnter = preloadTexture;
        }

        private void preloadTexture(GameObject collider, CollisionDistance cd){
            TextureManager.load(id);
        }

        private void Default(GameObject collider, CollisionDistance cd){
        }

    }
}
