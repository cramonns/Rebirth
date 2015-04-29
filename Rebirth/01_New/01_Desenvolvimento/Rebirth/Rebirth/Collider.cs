using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Rebirth{

	public class Collider{

		public RectangleF shape;
		public GameObject owner; 

		public Collider(RectangleF shape, GameObject owner){
			this.shape = shape;
			this.owner = owner;
		}

		public RectangleF getColliderShape(){
			return new RectangleF (new Vector2(shape.x + owner.shape.x, shape.y + owner.shape.y), shape.width, shape.height);
		}
	}
}

