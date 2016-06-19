using Microsoft.Xna.Framework;

namespace Rebirth
{

    public class Collider{

		public RectangleF shape;
		public GameObject owner; 

		public Collider(RectangleF shape, GameObject owner){
			this.shape = shape;
			this.owner = owner;
		}

		public RectangleF getColliderShape(){
			return new RectangleF (new Vector2(shape.x + owner.X, shape.y + owner.Y), shape.width, shape.height);
		}
	}
}

