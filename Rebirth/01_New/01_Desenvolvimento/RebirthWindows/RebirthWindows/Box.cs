using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Rebirth{

    [Serializable]
	public class Box:MoveableObject{

		public Box(){
			usePhysics = true;
			loaded = false;
			colliders = new List<Collider>();
			isFixed = false;
			speed = new Vector2 (0f, 0f);

            textureId = TextureManager.TextureID.box;

			boundingBox = new RectangleF(new Vector2 (10f, 10f), 2, 2);

			createDefaultBounds();
		}

		public override void Update(GameTime gameTime){

		}

		public override void Draw(SpriteBatch sb, DisplayManager sm, GameTime gameTime){
			sb.Draw(texture, sm.scaleTexture(new Vector2(this.boundingBox.x, this.boundingBox.y), 2, 2), Color.Black);
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

