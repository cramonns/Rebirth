using System;
using Microsoft.Xna.Framework;

namespace Rebirth{

	public class VertexR{

		public float x, y;

		public VertexR(){
			x = 0;
			y = 0;
		}

		public VertexR(float x, float y){
			this.x = x;
			this.y = y;
		}

		public VertexR(Vector2 v){
			this.x = v.X;
			this.y = v.Y;
		}

		public float distance(VertexR v){
			return (float)(Math.Sqrt ((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y)));
		}

	}
}

