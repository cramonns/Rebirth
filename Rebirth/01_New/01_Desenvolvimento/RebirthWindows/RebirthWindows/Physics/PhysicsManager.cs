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

            CollisionDistance d;

			foreach (MoveableObject g in simulatedObjects) {
				bool confirmCollision = false;
                g.setGroundedState(false);
				collisionTree.remove(g);
				candidates.Clear();
				candidates = collisionTree.retrieve(candidates, g.getCollisionShape());
				foreach (GameObject h in candidates) {
                    d = new CollisionDistance(1000);
					if (h != g) {
						if (g.getCollisionShape().intersects(h.getCollisionShape())) {
                            if (g.colliders != null){
                                if (h.colliders != null){
                                    foreach (RectangleF r in g.colliders){
                                        foreach (RectangleF s in h.colliders){
                                            if (r.intersects(g.Position,s,h.Position)){
                                                confirmCollision = true;
                                                CollisionDistance aux = r.AxisDistance(g.BoundingBox.Position, s, h.BoundingBox.Position);
                                                if (aux < d) d = aux;
                                            }
                                        }
                                    }
                                }
                                else {
                                    foreach (RectangleF r in g.colliders){
                                        if (r.intersects(g.Position,h.getCollisionShape(),Vector2.Zero)){
                                            confirmCollision = true;
                                            CollisionDistance aux = r.AxisDistance(g.BoundingBox.Position,h.BoundingBox,Vector2.Zero);
                                            if (aux < d) d = aux;
                                        }
                                    }
                                }
                            }
                            else if (h.colliders != null){
                                foreach (RectangleF r in h.colliders){
                                    if (g.getCollisionShape().intersects(Vector2.Zero,r,h.Position)){
                                        confirmCollision = true;
                                        CollisionDistance aux = g.BoundingBox.AxisDistance(Vector2.Zero, r, h.BoundingBox.Position);
                                        if (aux < d) d = aux;
                                    }
                                }
                            }
                            else {
                                confirmCollision = true;
							    d = g.BoundingBox.AxisDistance(h.BoundingBox);
                            }
				            if (confirmCollision) currentCollisions.AddFirst(new Collision(g,h,d));
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
                foreach (Attachment a in p.Attachments){
                    collisionTree.insert(a);
                }
            }
            
            RectangleF simulatedZone;
            
            collisionTree.insert(p);
            if (p.umbrella != null && p.umbrella.open) collisionTree.insert(p.umbrella);
            
            if (left != null){
                simulatedZone = left.getHalfRightBounds();
                foreach (GameObject g in left.objects){ 
                    collisionTree.insert(g);
                    foreach (Attachment a in g.Attachments){
                        collisionTree.insert(a);
                    }
                    if (simulatedZone.intersects(g.BoundingBox) && g is MoveableObject && reload){
                        simulatedObjects.Add(g as MoveableObject);
                    }
                }
            }

            if (center != null){
                foreach (GameObject g in center.objects){ 
                    foreach (Attachment a in g.Attachments){
                        collisionTree.insert(a);
                    }
                    if (g is MoveableObject && reload) simulatedObjects.Add(g as MoveableObject);
                    collisionTree.insert(g);
                }
            }
            
            if (right != null){
                simulatedZone = right.getHalfLeftBounds();
                foreach (GameObject g in right.objects){ 
                    foreach (Attachment a in g.Attachments){
                        collisionTree.insert(a);
                    }
                    collisionTree.insert(g);
                    if (simulatedZone.intersects(g.BoundingBox) && g is MoveableObject && reload){
                        simulatedObjects.Add(g as MoveableObject);    
                    }
                }
            }

        }

	}
}

