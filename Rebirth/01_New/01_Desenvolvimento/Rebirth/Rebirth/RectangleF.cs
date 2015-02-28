using System;
using Microsoft.Xna.Framework;

namespace Rebirth{

	public class RectangleF{

		public float x, y;
		public float width, height;

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

			if ((rx >= x && rx <= x + width) || (rx + rw >= x && rx + rw <= x + width)) {
				if ((ry >= y && ry <= y + height) || (ry + rh >= y && ry + rh <= y + height)) {
					return true;
				} else {
					if ((y >= ry && y <= ry + rh) || (y + height >= ry && y + height <= ry + rh)) {
						return true;
					}
				}
			} else {
				if ((x >= rx && x <= rx + rw) || (x + width >= rx && x + width <= rx + rw)) {
					if ((ry >= y && ry <= y + height) || (ry + rh >= y && ry + rh <= y + height)) {
						return true;
					} else {
						if ((y >= ry && y <= ry + rh) || (y + height >= ry && y + height <= ry + rh)) {
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
	}
}

