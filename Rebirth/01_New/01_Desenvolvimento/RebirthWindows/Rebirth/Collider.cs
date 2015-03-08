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
			//this.currentCollisions = new List<Collider>();
			//this.nextFrameCollisions = new List<Collider>();
		}
	}
}

