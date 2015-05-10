using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Rebirth{

    [Serializable]
    public class Ground:GameObject{

		public Ground(){
			loaded = false;

			boundingBox = new RectangleF(new Vector2 (0f, 0f), 30f, 50f/60f);

            textureId = TextureManager.TextureID.ground;
			createDefaultBounds();

		}

		public override void Update(GameTime gameTime){
		}

		public override void Draw(SpriteBatch sb, DisplayManager sm, GameTime gameTime){
			sb.Draw (texture, sm.scaleTexture(new Vector2(0,0), 30f, 50f/60f), null, Color.White);
		}

		/*public override void Load(ContentManager Content){
			texture = Content.Load<Texture2D>("Texture/ground");
			loaded = true;
		}*/

		public override void collide(GameObject B){

		}
	}
}
