using System;
using Microsoft.Xna.Framework;

namespace Rebirth{

	public abstract class MoveableObject:GameObject{

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
			float colX = shape.x;
			float colY = shape.y;
			float colW = shape.width;
			float colH = shape.height;
			if (speed.X > 0) colW += speed.X;
			else colX += speed.X;
			if (speed.Y > 0) colH += speed.Y;
			else colY += speed.Y;
			return new RectangleF(colX, colY, colW, colH);
		}

		public void integratePosition(){
			//Update position after all movement is computed
			shape.x += speed.X;
			shape.y += speed.Y;
		}
	}
}

