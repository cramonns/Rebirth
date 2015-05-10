using System;
using Microsoft.Xna.Framework;

namespace Rebirth{

    [Serializable]
	public abstract class MoveableObject:GameObject{

        [NonSerialized]
		public Vector2 speed;
		public bool usePhysics;

		private bool grounded = false;

		public virtual void setGroundedState(bool state){
			grounded = state;
		}

		public override bool isGrounded(){
			return grounded;
		}

		public override RectangleF getCollisionShape(){
			float colX = boundingBox.x;
			float colY = boundingBox.y;
			float colW = boundingBox.width;
			float colH = boundingBox.height;
			if (speed.X > 0) colW += speed.X;
			else colX += speed.X;
			if (speed.Y > 0) colH += speed.Y;
			else colY += speed.Y;
			return new RectangleF(colX, colY, colW, colH);
		}

		public void integratePosition(){
			//Update position after all movement is computed
			boundingBox.x += speed.X;
			boundingBox.y += speed.Y;
		}
	}
}

