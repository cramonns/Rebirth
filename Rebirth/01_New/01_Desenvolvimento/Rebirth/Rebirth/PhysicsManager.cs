using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Rebirth{
	public class PhysicsManager{

		const float GRAVITY = .4f/60f;

		List<GameObject> objects;
		LinkedList<Collision> currentCollisions;
		QuadTree collisionTree;

		public PhysicsManager(List<GameObject> objectsFromScene){
			this.objects = new List<GameObject>();
			foreach (GameObject g in objectsFromScene) {
				if (g is MoveableObject)
					objects.Add (g as MoveableObject); //UsePhysics
				else
					objects.Add (g);
			}
			currentCollisions = new LinkedList<Collision>();
			collisionTree = new QuadTree (0, new RectangleF (0, 0, 500, 500));
		}

		public void applyGravity(){
			//Gravity
			foreach (GameObject h in objects) {
				if (h is MoveableObject) {
					MoveableObject g = h as MoveableObject;
					if (!g.isGrounded ())
						g.speed.Y -= GRAVITY;
					else
						g.speed.Y = 0;
				}
			}
		}

		public void checkCollisions(){
			//float collisionDistane = 0;
			currentCollisions.Clear();

			collisionTree.clear();

			List<GameObject> candidates = new List<GameObject>();

			foreach (GameObject g in objects) {
				collisionTree.insert (g);
			}

			foreach (GameObject j in objects) {
				if (j is MoveableObject) {
					MoveableObject g = j as MoveableObject;
					g.setGroundedState(false);
					//collisionTree.remove (g);
					candidates.Clear();
					candidates = collisionTree.retrieve(candidates, j.shape);
					foreach (GameObject h in candidates) {
						if (h != g) {
							if (g.getCollisionShape ().intersects (h.getCollisionShape ())) {
								CollisionDistance d = g.shape.AxisDistance(h.shape);
								if (d.direction == CollisionDistance.CD_Direction.DOWN) {
									if (d.length < 0) {
										g.speed.Y = -d.length;
										if (h.isGrounded ()) {
											g.setGroundedState (true);
										}
									} else {
										if (d.length == 0) {
											//g.shape.y = h.shape.y + h.shape.height;//position correction to reduce precision problems
											if (h.isGrounded ()) {
												g.setGroundedState (true);
											}
										}

										g.speed.Y = (g.speed.Y < -d.length) ? -d.length : g.speed.Y;
									}
								} else if (d.direction == CollisionDistance.CD_Direction.UP) {
									if (d.length < 0) {
										g.speed.Y = d.length;
									}
									else g.speed.Y = (g.speed.Y > d.length) ? d.length : g.speed.Y;
								} else if (d.direction == CollisionDistance.CD_Direction.WEST) {
									if (d.length < 0) {
										g.speed.X = -d.length;
									}
									else g.speed.X = (g.speed.X < -d.length) ? -d.length : g.speed.X;
								} else if (d.direction == CollisionDistance.CD_Direction.EAST) {
									if (d.length < 0) {
										g.speed.X = d.length;
									}
									else g.speed.X = (g.speed.X > d.length) ? d.length : g.speed.X;
								}
							}
						}
					}
				}
			}
		}

		public void treatCollisions(){
			foreach (Collision c in currentCollisions) {
				c.treatCollision();
			}
		}

		public void integratePosition(){
			foreach (GameObject j in objects) {
				if (j is MoveableObject) {
					MoveableObject g = j as MoveableObject;
					g.integratePosition();
				}
			}
		}
	}
}

