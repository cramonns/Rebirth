using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Rebirth{
	public class PhysicsManager{

		const float GRAVITY = .4f/60f;

        List<GameObject> simulatedObjects;
		LinkedList<Collision> currentCollisions;
		QuadTree collisionTree;

		public PhysicsManager(){
            this.simulatedObjects = new List<GameObject>();
			currentCollisions = new LinkedList<Collision>();
			collisionTree = new QuadTree (0, new RectangleF (0, 0, 500, 500));
		}

		public void applyGravity(){
			//Gravity
			foreach (GameObject h in simulatedObjects) {
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

			List<GameObject> candidates = new List<GameObject>();

			foreach (GameObject j in simulatedObjects) {
				if (j is MoveableObject) {
					MoveableObject g = j as MoveableObject;
                    //bool grounded = false;
					g.setGroundedState(false);
					collisionTree.remove(j);
					candidates.Clear();
					candidates = collisionTree.retrieve(candidates, g.getCollisionShape());
					foreach (GameObject h in candidates) {
						if (h != g) {
							if (g.getCollisionShape().intersects(h.getCollisionShape())) {
								CollisionDistance d = g.BoundingBox.AxisDistance(h.BoundingBox);
				                currentCollisions.AddFirst(new Collision(g,h,d));
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
			foreach (GameObject j in simulatedObjects) {
				if (j is MoveableObject) (j as MoveableObject).integratePosition();
			}
		}

        public void restart(){ 
            simulatedObjects.Clear();
            currentCollisions.Clear();
			collisionTree.clear();
        }

        public void addObjects(SceneContainer left, SceneContainer center, SceneContainer right, Player p){
            RectangleF simulatedZone;
            
            simulatedObjects.Add(p);
            collisionTree.insert(p);
            
            if (left != null){
                simulatedZone = left.getHalfRightBounds();
                foreach (GameObject g in left.objects){ 
                    collisionTree.insert(g);
                    if (simulatedZone.intersects(g.BoundingBox)){
                        simulatedObjects.Add(g);
                    }
                }
            }

            if (center != null){
                foreach (GameObject g in center.objects){ 
                    simulatedObjects.Add(g);
                    collisionTree.insert(g);
                }
            }
            
            if (right != null){
                simulatedZone = right.getHalfLeftBounds();
                foreach (GameObject g in right.objects){ 
                    collisionTree.insert(g);
                    if (simulatedZone.intersects(g.BoundingBox)){
                        simulatedObjects.Add(g);    
                    }
                }
            }

        }

        public void Update(GameTime gameTime){
            foreach (GameObject g in simulatedObjects){
                g.Update(gameTime);
            }
        }

	}
}

