using System;

namespace Rebirth{
	public class CollisionDistance{

		public enum CD_Direction{
			UP = 0,
			DOWN,
			EAST,
			WEST
		}

		public CD_Direction direction;
		public float length;

		public CollisionDistance (CD_Direction direction, float length){
			this.direction = direction;
			this.length = length;
		}
	}
}

