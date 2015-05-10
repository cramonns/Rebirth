using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Rebirth {
    public class TextureManager {

        public enum TextureID{
            player,
            ground,
            box,
            startButton,
            logo42bits,
            container,
            selectedContainer
        }

        private ContentManager Content;
        public Texture2D[] textures;

        public TextureManager(ContentManager cm){
            textures = new Texture2D[Enum.GetNames(typeof(TextureID)).Length];
            Content = cm;
        }

        public bool isLoaded(TextureID id){
            return textures[(int)id] != null;
        }

        public Texture2D load(TextureID id){
            switch(id){
                case TextureID.player:
                    textures[(int)id] = Content.Load<Texture2D>("Texture/red");
                    break;
                case TextureID.ground:
                    textures[(int)id] = Content.Load<Texture2D>("Texture/ground");
                    break;
                case TextureID.box:
                    textures[(int)id] = Content.Load<Texture2D>("Texture/blackSquare");
                    break;
                case TextureID.startButton:
                    textures[(int)id] = Content.Load<Texture2D>("Texture/startButton");
                    break;
                case TextureID.logo42bits:
                    textures[(int)id] = Content.Load<Texture2D>("Texture/LogoVideo");
                    break;
                case TextureID.container:
                    textures[(int)id] = Content.Load<Texture2D>("Texture/Container");
                    break;
                case TextureID.selectedContainer:
                    textures[(int)id] = Content.Load<Texture2D>("Texture/SelectedContainer");
                    break;            
            }
            return textures[(int)id];
        }

        public void unLoad(TextureID id){
            textures[(int)id].Dispose();
            textures[(int)id] = null;
        }
    }
}
