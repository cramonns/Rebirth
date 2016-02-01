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

	}
}
