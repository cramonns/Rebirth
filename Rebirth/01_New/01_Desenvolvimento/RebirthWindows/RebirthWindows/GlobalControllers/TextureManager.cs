using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public static class TextureManager {

        public enum TextureID{
            player,
            ground,
            box,
            startButton,
            logo42bits,
            container,
            selectedContainer,
            white,
            Background,
            grass,
            cyan
        }

        private static ContentManager Content;
        public static Texture2D[] textures;
        public static int[] texturesCount;
        public static Texture2D blankTexture;

        public static void initialize(ContentManager cm){
            int count = Enum.GetNames(typeof(TextureID)).Length;
            textures = new Texture2D[count];
            texturesCount = new int[count];
            Content = cm;
            Color[] colors = new Color[] { Color.White };
            blankTexture = new Texture2D(GameManager.game.GraphicsDevice, 1, 1);
            blankTexture.SetData<Color>(colors);
        }

        public static bool isLoaded(TextureID id){
            return textures[(int)id] != null;
        }

        public static Texture2D load(TextureID id){
            if (textures[(int)id] == null){
                switch(id){
                    case TextureID.player:
                        textures[(int)id] = Content.Load<Texture2D>("Texture/red");
                        break;
                    case TextureID.ground:
                        textures[(int)id] = Content.Load<Texture2D>("Texture/ground");
                        break;
                    case TextureID.box:
                        textures[(int)id] = Content.Load<Texture2D>("Texture/Shale_rock_pxr128.tif");
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
                    case TextureID.white:
                        textures[(int)id] = Content.Load<Texture2D>("Texture/White_square");
                        break; 
                    case TextureID.Background:
                        textures[(int)id] = Content.Load<Texture2D>("Texture/Background");
                        break; 
                    case TextureID.grass:
                        textures[(int)id] = Content.Load<Texture2D>("Texture/Bowling_grass_pxr128.tif");
                        break; 
                    case TextureID.cyan:
                        textures[(int)id] = Content.Load<Texture2D>("Texture/cyan");
                        break; 
                }
            }
            texturesCount[(int)id]++;
            return textures[(int)id];
        }

        public static Texture2D getTexture(TextureID id){
            return textures[(int)id];
        }

        public static void unLoad(TextureID id){
            texturesCount[(int)id]--;
            if (texturesCount[(int)id] == 0){
                textures[(int)id].Dispose();
                textures[(int)id] = null;
            }
        }
    }
}
