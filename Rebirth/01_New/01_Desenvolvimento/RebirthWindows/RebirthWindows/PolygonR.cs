using System;
using System.Collections.Generic;

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
	}
}

