using System;

namespace Rebirth{
	public class Collision{

		public GameObject a, b;
		public float distance;

		public Collision (GameObject a, GameObject b, float collisionDistance){
			this.a = a;
			this.b = b;
			distance = collisionDistance;
		}
	}
}

