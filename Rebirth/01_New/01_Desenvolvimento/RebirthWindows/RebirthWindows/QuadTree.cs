using System;
using System.Collections.Generic;

namespace Rebirth{

	public class QuadTree{

		private const int MAX_OBJECTS = 10;
		private const int MAX_LEVELS = 10;

		private int level;
		private List<GameObject> objects;
		private RectangleF bounds;
		private QuadTree[] nodes;

		/*
  		* Constructor
  		*/
		public QuadTree(int pLevel, RectangleF pBounds) {
			level = pLevel;
			objects = new List<GameObject>();
			bounds = pBounds;
			nodes = new QuadTree[4];
			nodes [0] = null;
			nodes [1] = null;
			nodes [2] = null;
			nodes [3] = null;
		}

		/*
 		* Clears the quadtree
 		*/
		public void clear() {
			objects.Clear();

			for (int i = 0; i < 4; i++) {
				if (nodes[i] != null) {
					nodes[i].clear();
					nodes[i] = null;
				}
			}
		}

		/*
 		* Splits the node into 4 subnodes
 		*/
		private void split() {
			float subWidth = bounds.width / 2;
			float subHeight = bounds.height / 2;
			float x = bounds.x;
			float y = bounds.y;

			nodes [0] = new QuadTree (level + 1, new RectangleF (x + subWidth, y, subWidth, subHeight));
			nodes [1] = new QuadTree (level + 1, new RectangleF (x, y, subWidth, subHeight));
			nodes [2] = new QuadTree (level + 1, new RectangleF (x, y + subHeight, subWidth, subHeight));
			nodes [3] = new QuadTree (level + 1, new RectangleF (x + subWidth, y + subHeight, subWidth, subHeight));
		}

		/*
 		* Determine which node the object belongs to. -1 means
 		* object cannot completely fit within a child node and is part
		* of the parent node
 		*/
		private int getIndex(RectangleF pRect) {
			int index = -1;
			float verticalMidpoint = bounds.x + (bounds.width / 2);
			float horizontalMidpoint = bounds.y + (bounds.height / 2);

			// Object can completely fit within the top quadrants
			bool topQuadrant = (pRect.y < horizontalMidpoint && pRect.y + pRect.height < horizontalMidpoint);
			// Object can completely fit within the bottom quadrants
			bool bottomQuadrant = (pRect.y > horizontalMidpoint);

			// Object can completely fit within the left quadrants
			if (pRect.x < verticalMidpoint && pRect.x + pRect.width < verticalMidpoint) {
				if (topQuadrant) {
					index = 1;
				}
				else if (bottomQuadrant) {
					index = 2;
				}
			}
			// Object can completely fit within the right quadrants
			else if (pRect.x > verticalMidpoint) {
				if (topQuadrant) {
					index = 0;
				}
				else if (bottomQuadrant) {
					index = 3;
				}
			}

			return index;
		}

		/*
 		* Insert the object into the quadtree. If the node
 		* exceeds the capacity, it will split and add all
 		* objects to their corresponding nodes.
 		*/
		public void insert(GameObject g) {
			RectangleF pRect = g.getCollisionShape();
			if (nodes[0] != null) {
				int index = getIndex(pRect);

				if (index != -1) {
					nodes[index].insert(g);
					return;
				}
			}

			objects.Add(g);

			if (objects.Count > MAX_OBJECTS && level < MAX_LEVELS) {
				if (nodes[0] == null) {
					split();
				}

                List<GameObject> removeObjects = new List<GameObject>();

				foreach (GameObject h in objects){
                    
					int index = getIndex(h.BoundingBox);
					if (index != -1) {
						nodes[index].insert(h);
						removeObjects.Add(h);
					}
				}

                foreach (GameObject h in removeObjects){
                    objects.Remove(h);
                }
                removeObjects.Clear();
			}
		}

		/*
 		* Return all objects that could collide with the given object
 		*/
		public List<GameObject> retrieve(List<GameObject> returnObjects, RectangleF pRect) {
			int index = getIndex(pRect);
			if (index != -1 && nodes[0] != null) {
				nodes[index].retrieve(returnObjects, pRect);
			}

			returnObjects.AddRange(objects);

			return returnObjects;
		}

		public void remove (GameObject g){
			RectangleF pRect = g.getCollisionShape();
			if (nodes[0] != null) {
				int index = getIndex(pRect);

				if (index != -1) {
					nodes[index].remove(g);
					return;
				}
			}

			objects.Remove(g);
		}

	}
}

