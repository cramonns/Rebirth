using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Rebirth{

	public class Box:MoveableObject{

		public Box(){
			usePhysics = true;
			loaded = false;
			colliders = new List<Collider>();
			isFixed = false;
			speed = new Vector2 (0f, 0f);

			/*position = new Vector2 (10f, 10f);
			width = 2;
			height = 2;*/
			shape = new RectangleF(new Vector2 (10f, 10f), 2, 2);

			createDefaultBounds();
		}

		public override void Update(){
			//Update position after all movement is computed
			shape.x += speed.X;
			shape.y += speed.Y;
		}

		public override void Draw(SpriteBatch sb, ScreenManager sm){
			sb.Draw(texture, sm.scaleTexture(new Vector2(this.shape.x, this.shape.y), 2, 2), Color.Black);
		}

		public override void Load(ContentManager Content){
			texture = Content.Load<Texture2D>("Texture/blackSquare");
			loaded = true;
		}

		public override void collide(GameObject b){
			VertexR c1 = this.shape.getCenter();
			VertexR c2 = b.shape.getCenter();

			/*c1.x -= shape.x;
			c2.x -= shape.x;
			c1.y -= shape.y;
			c2.y -= shape.y;*/

			c2.x = c1.x;

			if (colliders [(int)Bounds.LOWER].getColliderShape().intersects (c1, c2)) {
				shape.y = b.shape.y + b.shape.height;

				if (b.isGrounded ()) {
					setGroundedState (true);
				} else setGroundedState (false);


			} else setGroundedState (false);
		}
	}
}

