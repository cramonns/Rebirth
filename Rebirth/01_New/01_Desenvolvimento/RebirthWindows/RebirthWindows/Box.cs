using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Rebirth{

    [Serializable]
	public class Box:MoveableObject{

        public const float DefaultWidth = 2f;
        public const float DefaultHeight = 2f;

		public Box(Vector2 position){
			usePhysics = true;
			loaded = false;
			colliders = new List<Collider>();
			isFixed = false;
			speed = new Vector2 (0f, 0f);

            textureId = TextureManager.TextureID.box;

            if (position == null)
			    boundingBox = new RectangleF(new Vector2 (10f, 10f), DefaultWidth, DefaultHeight);
            else boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);

			createDefaultBounds();
		}

		public override void Update(GameTime gameTime){

		}

		public override void Draw(SpriteBatch sb, GameTime gameTime){
			sb.Draw(texture, DisplayManager.scaleTexture(new Vector2(this.boundingBox.x, this.boundingBox.y), boundingBox.width, boundingBox.height), Color.Black);
		}

		public override void collide(GameObject b){
			VertexR c1 = this.boundingBox.getCenter();
			VertexR c2 = b.boundingBox.getCenter();

			c2.x = c1.x;

			if (colliders [(int)Bounds.LOWER].getColliderShape().intersects (c1, c2)) {
				boundingBox.y = b.boundingBox.y + b.boundingBox.height;

				if (b.isGrounded ()) {
					setGroundedState (true);
				} else setGroundedState (false);

			} else setGroundedState (false);
		}

	}
}

