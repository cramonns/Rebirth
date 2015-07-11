using System;

namespace Rebirth{
	public class CollisionDistance{

		public enum CD_Direction:byte{
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

		public CollisionDistance reverse(){
			CD_Direction dir = this.direction;
			switch (dir) {
				case CD_Direction.UP:
					dir = CD_Direction.DOWN;
					break;
				case CD_Direction.DOWN:
					dir = CD_Direction.UP;
					break;
				case CD_Direction.EAST:
					dir = CD_Direction.WEST;
					break;
				case CD_Direction.WEST:
					dir = CD_Direction.EAST;
					break;
			}
			return new CollisionDistance(dir, this.length);
		}
	}
}

