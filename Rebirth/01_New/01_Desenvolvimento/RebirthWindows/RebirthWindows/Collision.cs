using System;

namespace Rebirth{
	public class Collision{

        //private const float contactError = 1E-4f;

		public GameObject a, b;
		public CollisionDistance cd;

		public Collision (GameObject a, GameObject b, CollisionDistance cd){
			this.a = a;
			this.b = b;
			this.cd = cd;
		}

        private void push(MoveableObject g, CollisionDistance d){
            switch (d.direction){
                case (CollisionDistance.CD_Direction.DOWN):
                    if (d.length < 0) g.speed.Y = -d.length;
                    else g.speed.Y = (g.speed.Y < -d.length) ? -d.length : g.speed.Y;
                    break;
                case (CollisionDistance.CD_Direction.UP):
                    if (d.length < 0) g.speed.Y = d.length;
                    else g.speed.Y = (g.speed.Y > d.length) ? d.length : g.speed.Y;
                    break;
                case (CollisionDistance.CD_Direction.WEST):
                    if (d.length < 0) g.speed.X = -d.length;
                    else g.speed.X = (g.speed.X < -d.length) ? -d.length : g.speed.X;
                    break;
                case (CollisionDistance.CD_Direction.EAST):
                    if (d.length < 0) g.speed.X = d.length;
                    else g.speed.X = (g.speed.X > d.length) ? d.length : g.speed.X;
                    break;
            }
        }

        private void swap(){
            GameObject aux = a;
            a = b;
            b = aux;
            cd = cd.reverse();
        }

        public void treatCollision(){
            if (b is MoveableObject){
                treatCollision(a as MoveableObject,b as MoveableObject,cd);
            }
            else treatCollision(a as MoveableObject, b, cd);
        }

		private void treatCollision(MoveableObject m, GameObject g, CollisionDistance cd){
            push(m, cd);
            if (cd.direction == CollisionDistance.CD_Direction.DOWN){
                m.setGroundedState(true);
            }
		}

        private void treatCollision(MoveableObject p, MoveableObject m, CollisionDistance cd){
            if (MathUtils.FLOAT_EQUALS(p.speed.Length(), 0)){
                push(m, cd.reverse());
            }
            else {
                if (MathUtils.FLOAT_EQUALS(m.speed.Length(), 0)){
                    push(p,cd);
                }
                else {
                    cd.length /= 2;
                    push(p,cd);
                    push(m,cd.reverse());
                }
            }
            if (cd.direction == CollisionDistance.CD_Direction.UP){
                m.setGroundedState(true);
            } else if (cd.direction == CollisionDistance.CD_Direction.DOWN){
                p.setGroundedState(true);
            }
        }
	}
}

