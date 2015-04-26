using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Rebirth{
	public class Ground:GameObject{

		public Ground(){
			loaded = false;

			shape = new RectangleF(new Vector2 (0f, 0f), 1600f/60f, 50f/60f);
			createDefaultBounds();

		}

		public override void Update(){
		}

		public override void Draw(SpriteBatch sb, ScreenManager sm){
			sb.Draw (texture, sm.scaleTexture(new Vector2(0,0), 1600f/60f,50f/60f), null, Color.White);
		}

		public override void Load(ContentManager Content){
			texture = Content.Load<Texture2D>("Texture/ground");
			loaded = true;
		}

		public override void collide(GameObject B){

		}
	}
}
