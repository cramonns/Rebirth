using System;

namespace Rebirth{
	public class Collision{

		public GameObject a, b;
		public CollisionDistance cd;

		public Collision (GameObject a, GameObject b, CollisionDistance cd){
			this.a = a;
			this.b = b;
			this.cd = cd;
		}

		public void treatCollision(){
			//a.collide(this.b, cd);
			//b.collide(this.a, cd.reverse());
		}
	}
}

