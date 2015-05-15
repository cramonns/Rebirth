using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Rebirth{

    [Serializable]
    public class Ground:GameObject{

        public const float DefaultWidth = 10f;
        public const float DefaultHeight = 50/60f;

		public Ground(Vector2 position){
			loaded = false;

            if (position == null)
			    boundingBox = new RectangleF(new Vector2 (0f, 0f), DefaultWidth, DefaultHeight);
            else boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);

            textureId = TextureManager.TextureID.ground;
			createDefaultBounds();

		}

		public override void Update(GameTime gameTime){
		}

		public override void collide(GameObject B, CollisionDistance cd){

		}

	}
}
