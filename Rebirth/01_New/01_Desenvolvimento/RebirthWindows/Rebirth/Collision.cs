using System;

namespace Rebirth{
	public class Collision{

		public GameObject a, b;

		public Collision (GameObject a, GameObject b){
			this.a = a;
			this.b = b;
		}

		public void treatCollision(){
			a.collide(this.b);
			b.collide(this.a);
		}
	}
}

