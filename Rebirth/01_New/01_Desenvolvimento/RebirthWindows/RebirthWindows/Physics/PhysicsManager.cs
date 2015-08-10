using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Rebirth{
	public class PhysicsManager{

		const float GRAVITY = .4f/60f;
        const float ATRICT = .5f/60f;
        const float AIR_RESISTANCE = 0.05f/60f;

        List<MoveableObject> simulatedObjects;
		LinkedList<Collision> currentCollisions;
		QuadTree collisionTree;

		public PhysicsManager(){
            this.simulatedObjects = new List<MoveableObject>();
			currentCollisions = new LinkedList<Collision>();
			collisionTree = new QuadTree (0, new RectangleF (0, 0, 500, 500));
		}

        public void Update(GameTime gameTime){
            foreach (MoveableObject g in simulatedObjects) {
                g.applyGravity(GRAVITY);
                g.Update(gameTime);
                g.applyAtrict(ATRICT, AIR_RESISTANCE);
            }
        }

		public void checkCollisions(){

			List<GameObject> candidates = new List<GameObject>();

			foreach (MoveableObject g in simulatedObjects) {
				g.setGroundedState(false);
				collisionTree.remove(g);
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

		public void treatCollisions(){
			foreach (Collision c in currentCollisions) {
				c.treatCollision();
                c.a.collide(c.b, c.cd);
                c.b.collide(c.a, c.cd.reverse());
			}
		}

		public void integratePosition(){
			foreach (MoveableObject g in simulatedObjects) {
				g.integratePosition();
			}
		}

        public void restart(){ 
            currentCollisions.Clear();
			collisionTree.clear();
        }

        public void addObjects(SceneContainer left, SceneContainer center, SceneContainer right, Player p, bool reload){
            //reload = true;
            if (reload){
                simulatedObjects.Clear();
                simulatedObjects.Add(p);
                simulatedObjects.Add(p.standingChecker);
            }
            
            RectangleF simulatedZone;
            
            collisionTree.insert(p);
            
            if (left != null){
                simulatedZone = left.getHalfRightBounds();
                foreach (GameObject g in left.objects){ 
                    collisionTree.insert(g);
                    if (simulatedZone.intersects(g.BoundingBox) && g is MoveableObject && reload){
                        simulatedObjects.Add(g as MoveableObject);
                    }
                }
            }

            if (center != null){
                foreach (GameObject g in center.objects){ 
                    if (g is MoveableObject && reload) simulatedObjects.Add(g as MoveableObject);
                    collisionTree.insert(g);
                }
            }
            
            if (right != null){
                simulatedZone = right.getHalfLeftBounds();
                foreach (GameObject g in right.objects){ 
                    collisionTree.insert(g);
                    if (simulatedZone.intersects(g.BoundingBox) && g is MoveableObject && reload){
                        simulatedObjects.Add(g as MoveableObject);    
                    }
                }
            }

        }

	}
}

