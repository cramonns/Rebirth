using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Rebirth{
	public class PhysicsManager{

		const float GRAVITY = .4f/60f;

		List<MoveableObject> objects;
		LinkedList<Collision> currentCollisions;

		public PhysicsManager(List<GameObject> objectsFromScene){
			this.objects = new List<MoveableObject>();
			foreach (GameObject g in objectsFromScene) {
				if (g is MoveableObject)
					objects.Add(g as MoveableObject); //UsePhysics
			}
			currentCollisions = new LinkedList<Collision>();
		}

		public void applyGravity(){
			//Gravity
			foreach (MoveableObject g in objects) {
				if (!g.isGrounded ()) g.speed.Y -= GRAVITY;
				else g.speed.Y = 0;
			}
		}

		public void checkCollisions(){
			//float collisionDistane = 0;
			currentCollisions.Clear();
			foreach (MoveableObject g in objects) {
				foreach (GameObject h in objects) {
					if (h != g) {
						if (g.shape.intersects (h.shape))
							currentCollisions.AddLast (new Collision (g, h));
					}
				}
			}
		}

		public void treatCollisions(){
			foreach (Collision c in currentCollisions) {
				c.treatCollision();
			}
		}
	}
}

