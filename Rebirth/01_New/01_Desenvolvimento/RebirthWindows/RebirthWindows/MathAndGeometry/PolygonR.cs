using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Rebirth{

	public class PolygonR{

		public LinkedList<Edge> edges;
		public LinkedList<VertexR> vertices;
		private int verticesCount;
		VertexR center;

		public PolygonR (LinkedList<VertexR> vertices){
			center = new VertexR (0, 0);
			/*center.x = 0;
			center.y = 0;*/
			verticesCount = vertices.Count;
			this.vertices = vertices;
			vertices = new LinkedList<VertexR> ();
			VertexR aux = null;
			foreach (VertexR v in vertices) {
				if (aux != null) {
					this.edges.AddLast(new Edge(aux, v));
				}
				center.x += v.x;
				center.y += v.y;
				aux = v;	
			}
			center.x /= (float)verticesCount;
			center.y /= (float)verticesCount;
			this.edges.AddLast(new Edge(aux, vertices.First.Value as VertexR));
		}

		public int getFacesCount(){
			return verticesCount;
		}

		public bool detectCollision(PolygonR b){
			return true;
		}

        /*public abstract bool intersects(RectangleF r);
        public abstract bool intersects(Circle c);
        public abstract bool intersects(Vector2 source, RectangleF r, Vector2 source2);
        public abstract bool intersects(Vector2 source, Circle c, Vector2 source2);*/
	}
}

