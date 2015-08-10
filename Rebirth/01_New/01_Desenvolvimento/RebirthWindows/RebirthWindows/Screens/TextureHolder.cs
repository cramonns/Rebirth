using System;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth {
    [Serializable]
    public class TextureHolder {

        public TextureManager.TextureID id;
        [NonSerialized]
        Texture2D texture;

        public TextureHolder(TextureManager.TextureID id){
            this.id = id;
        }
        
        public void load(){
            texture = TextureManager.load(id);
        }

        public void unLoad(){
            TextureManager.unLoad(id);
        }

    }
}
