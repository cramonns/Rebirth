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
			position = new Vector2 (10f, 10f);
			speed = new Vector2 (0f, 0f);
			width = 2;
			height = 2;

			createDefaultBounds();
		}

		public override bool isGrounded (){
			if (position.Y <= 50f/60f) {
				position.Y = 50f/60f;
				return true;
			} else return false;
		}

		public override void Update(){
			//Update position after all movement is computed
			position.X += speed.X;
			position.Y += speed.Y;
		}

		public override void Draw(SpriteBatch sb, ScreenManager sm){
			sb.Draw (texture, sm.scaleTexture(this.position, 2, 2), Color.Black);
		}

		public override void Load(ContentManager Content){
			texture = Content.Load<Texture2D>("Texture/blackSquare");
			loaded = true;
		}

		public override void treatCollisions(){

		}
	}
}

