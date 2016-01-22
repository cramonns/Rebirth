using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Rebirth{

    [Serializable]
    public class Ground:GameObject{

		public Ground(Vector2 position){
            colliders = null;
            if (position == null){
                boundingBox = new RectangleF(new Vector2 (0f, 0f), DefaultWidth, DefaultHeight);
            }
            else {
                boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);
            }

            textureId = TextureManager.TextureID.ground;

		}

		public override void Update(GameTime gameTime){
		}

		public override void collide(GameObject B, CollisionDistance cd){

		}

#if EDITOR
        public override void saveXML(int level, System.IO.StreamWriter xmlStream) {
            xmlStream.WriteLine(FileManager.tabs(level) + "<Ground"
                + " x=" + this.X.ToString()
                + " y=" + this.Y.ToString()
                + " width=" + this.Width.ToString()
                + " height=" + this.Height.ToString()
                + ">");
            level++;
                xmlStream.WriteLine(FileManager.tabs(level)
                    + "textureId=\"" + Enum.GetNames(typeof(TextureManager.TextureID))[(int)textureId]
                    + "\";");
            level--;
            xmlStream.WriteLine(FileManager.tabs(level) + "</Ground>");
        }
#endif
	}
}
