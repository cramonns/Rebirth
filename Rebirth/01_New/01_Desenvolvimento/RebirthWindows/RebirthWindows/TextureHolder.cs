using System;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth {
    public class TextureHolder {

        TextureManager.TextureID id;
        Texture2D texture;

        public TextureHolder(TextureManager.TextureID id){
            this.id  = id;
            texture = TextureManager.load(id);
        }

        public void unLoad(){
            TextureManager.unLoad(id);
        }

    }
}
