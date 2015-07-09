using System;
using Microsoft.Xna.Framework;

namespace Rebirth{

    [Serializable]
	public class RectangleF{

		public float x, y;
		public float width, height;

        public Vector2 Position{
            get { return new Vector2(x,y); }
            set {
                x = value.X;
                y = value.Y;
            }
        }
        public Vector2 Center{
            get { return new Vector2(x+width/2,y+height/2); }
            set {
                x = value.X - width/2;
                y = value.Y - height/2;
            }
        }

		public RectangleF(float x, float y, float width, float height){
			this.x = x;
			this.y = y;
			this.height = height;
			this.width = width;
		}

		public RectangleF(Vector2 position, float width, float height){
			this.x = position.X;
			this.y = position.Y;
			this.height = height;
			this.width = width;
		}

		public bool intersects(RectangleF rect){

			float rx = rect.x;
			float ry = rect.y;
			float rw = rect.width;
			float rh = rect.height;

			if (( MathUtils.FLOAT_GREATEQ(rx, x) && MathUtils.FLOAT_LESSEQ(rx, x + width) ) || 
                ( MathUtils.FLOAT_GREATEQ(rx + rw, x) && MathUtils.FLOAT_LESSEQ(rx + rw, x + width) )) 
            {
				if (( MathUtils.FLOAT_GREATEQ(ry, y) && MathUtils.FLOAT_LESSEQ(ry, y + height) ) || 
                    ( MathUtils.FLOAT_GREATEQ(ry + rh, y) && MathUtils.FLOAT_LESSEQ(ry + rh, y + height) )) 
                {
					return true;
				} else {
					if (( MathUtils.FLOAT_GREATEQ(y, ry) && MathUtils.FLOAT_LESSEQ(y, ry + rh) ) || 
                        ( MathUtils.FLOAT_GREATEQ(y + height, ry) && MathUtils.FLOAT_LESSEQ(y + height, ry + rh) )) 
                    {
						return true;
					}
				}
			} else {
				if ((MathUtils.FLOAT_GREATEQ(x, rx) && MathUtils.FLOAT_LESSEQ(x, rx + rw) ) || 
                    (MathUtils.FLOAT_GREATEQ(x + width, rx) && MathUtils.FLOAT_LESSEQ(x + width, rx + rw) )) {
					if ((MathUtils.FLOAT_GREATEQ(ry, y) && MathUtils.FLOAT_LESSEQ(ry, y + height) ) || 
                        (MathUtils.FLOAT_GREATEQ(ry + rh, y) && MathUtils.FLOAT_LESSEQ(ry + rh, y + height) )) {
						return true;
					} else {
						if ( (MathUtils.FLOAT_GREATEQ(y, ry) && MathUtils.FLOAT_LESSEQ(y, ry + rh)) || 
                            (MathUtils.FLOAT_GREATEQ(y + height, ry) && MathUtils.FLOAT_LESSEQ(y + height, ry + rh) ) ) {
							return true;
						}
					}
				}
			}
			return false;
		}

		public bool intersects(Vector2 source, RectangleF rect, Vector2 sourceR){
			float rx = rect.x;
			float ry = rect.y;
			float rw = rect.width;
			float rh = rect.height;
			rx += sourceR.X - source.X;
			ry += sourceR.Y - source.Y;
			if ((rx > x && rx < x + width) || (rx + rw > x && rx + rw < x + width)) {
				if ((ry > y && ry < y + height) || (ry + rh > y && ry + rh < y + height)) {
					return true;
				} else {
					if ((y > ry && y < ry + rh) || (y + height > ry && y + height < ry + rh)) {
						return true;
					}
				}
			} else {
				if ((x > rx && x < rx + rw) || (x + width > rx && x + width < rx + rw)) {
					if ((ry > y && ry < y + height) || (ry + rh > y && ry + rh < y + height)) {
						return true;
					} else {
						if ((y > ry && y < ry + rh) || (y + height > ry && y + height < ry + rh)) {
							return true;
						}
					}
				}
			}
			return false;
		}

		public bool intersects(VertexR v1, VertexR v2){

			float x1 = v1.x;
			float x2 = v2.x;
			float y1 = v1.y;
			float y2 = v2.y;

			float minX = this.x;
			float minY = this.y;
			float maxX = minX + width;
			float maxY = minY + height;

			// Completely outside.
			if ((MathUtils.FLOAT_LESSEQ(x1, minX) && MathUtils.FLOAT_LESSEQ(x2, minX) ) || 
                (MathUtils.FLOAT_LESSEQ(y1, minY) && MathUtils.FLOAT_LESSEQ(y2, minY) ) || 
                (MathUtils.FLOAT_GREATEQ(x1, maxX) && MathUtils.FLOAT_GREATEQ(x2, maxX) ) || 
                (MathUtils.FLOAT_GREATEQ(y1, maxY) && MathUtils.FLOAT_GREATEQ(y2, maxY) ) )
            {
				return false;
            }

			float m = (y2 - y1) / (x2 - x1);

			float y = m * (minX - x1) + y1;
			if (y > minY && y < maxY) return true;

			y = m * (maxX - x1) + y1;
			if (y > minY && y < maxY) return true;

			float x = (minY - y1) / m + x1;
			if (x > minX && x < maxX) return true;

			x = (maxY - y1) / m + x1;
			if (x > minX && x < maxX) return true;

			return false;
		}

        public bool intersects(VertexR v){
            return (v.x >= this.x && v.x <= this.x + this.width && v.y >= this.y && v.y <= this.y + this.height);
        }

        public bool intersects(Vector2 v){
            return intersects(new VertexR(v.X, v.Y));
        }

		public CollisionDistance internalDistance(RectangleF r){
			if ( MathUtils.FLOAT_EQUALS(y, r.y + r.height) ) {
				return new CollisionDistance (CollisionDistance.CD_Direction.DOWN, 0);
			} else if ( MathUtils.FLOAT_EQUALS(y + height, r.y) ) {
				return new CollisionDistance (CollisionDistance.CD_Direction.UP, 0);
			} else if ( MathUtils.FLOAT_EQUALS(x, r.x + r.width) ) {
				return new CollisionDistance (CollisionDistance.CD_Direction.WEST, 0);
			} else if ( MathUtils.FLOAT_EQUALS(x + width, r.x) ) {
				return new CollisionDistance (CollisionDistance.CD_Direction.EAST, 0);
			} else {
				float distYD, distYU, distXW, distXE;
				float distY, distX;
				distYD = r.y + r.height - y;
				distYU = y + height - r.y;
				distXW = r.x + r.width - x;
				distXE = x + width - r.x;

				CollisionDistance.CD_Direction dirY, dirX;

				if (distYD < distYU) {
					dirY = CollisionDistance.CD_Direction.DOWN;
					distY = distYD;
				} else {
					dirY = CollisionDistance.CD_Direction.UP;
					distY = distYU;
				}
				if (distXW < distXE) {
					dirX = CollisionDistance.CD_Direction.WEST;
					distX = distXW;
				} else {
					dirX = CollisionDistance.CD_Direction.EAST;
					distX = distXE;
				}

				if (distY < distX) {
					return new CollisionDistance(dirY, -distY);
				} else return new CollisionDistance(dirX, -distX);
			}
		}

		public CollisionDistance AxisDistance(RectangleF r){

			float distX = 0, distY = 0;
			bool x_dir = true, y_dir = true;
			CollisionDistance.CD_Direction xDir = CollisionDistance.CD_Direction.EAST, yDir = CollisionDistance.CD_Direction.UP;

			if (this.intersects(r)) {
				return this.internalDistance(r);
			} 

			if (r.x > this.x + width) {
				distX = r.x - this.x + width;
				xDir = CollisionDistance.CD_Direction.EAST;
			}
			else {
				if (r.x + r.width < this.x) {
					distX = r.x + r.width - this.x;
					xDir = CollisionDistance.CD_Direction.WEST;
				}
				else x_dir = false;
			}

			if (r.y > this.y + height) {
				distY = r.y - this.y + height;
				yDir = CollisionDistance.CD_Direction.UP;
			}
			else {
				if (r.y + r.height < this.y) {
					distY = r.y + r.height - this.y;
					yDir = CollisionDistance.CD_Direction.DOWN;
				}
				else y_dir = false;
			}

			if (!x_dir) {
				return new CollisionDistance (yDir, Math.Abs (distY));
			} else if (!y_dir) {
				return new CollisionDistance (xDir, Math.Abs (distX));
			} else if (Math.Abs (distX) > Math.Abs (distY)) {
				return new CollisionDistance (yDir, Math.Abs (distY));
			} else return new CollisionDistance (xDir, Math.Abs (distX));
		}

        public bool inside(RectangleF rect){
            return (this.x >= rect.x && 
                    this.y >= rect.y && 
                    MathUtils.FLOAT_LESSEQ(this.x + this.width, rect.x + rect.width) && 
                    MathUtils.FLOAT_LESSEQ(this.y + this.height, rect.y + rect.height)
                    );
        }

        public Rectangle ToRectangle(){
            return new Rectangle((int)x,(int)(y+height),(int)width,(int)height);
        }

        public void set(Vector2 position, float width, float height){
			this.height = height;
			this.width = width;
            Center = position;
			//center = new VertexR ((x + width) / 2, (y + height) / 2);
		}
	}

}

