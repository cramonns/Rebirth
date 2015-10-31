using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Rebirth{

    [Serializable]
	public class Box:MoveableObject{

		public Box(Vector2 position){
			usePhysics = true;
			isFixed = false;
			speed = new Vector2 (0f, 0f);

            textureId = TextureManager.TextureID.box;

            if (position == null){
                boundingBox = new RectangleF(new Vector2 (10f, 10f), DefaultWidth, DefaultHeight);
            }
            else {
                boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);
            }
            
		}

		public override void Update(GameTime gameTime){

		}

		public override void collide(GameObject b, CollisionDistance cd){
			
		}

	}
}

