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

		public override bool isGrounded (){
			if (shape.y <= 50f/60f) {
				shape.y = 50f/60f;
				return true;
			} else return false;
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
			texture = Content.Load<Texture2D>("Textures/blackSquare");
			loaded = true;
		}

		public override void collide(GameObject b){

		}
	}
}

