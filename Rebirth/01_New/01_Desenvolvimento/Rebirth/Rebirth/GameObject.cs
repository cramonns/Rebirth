using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Rebirth{

	public abstract class GameObject{

		protected enum Bounds:byte{
			UPPER = 0,
			LOWER,
			EASTER,
			WESTERN
		}

		//public Vector2 position;
		public bool loaded;
		public List<Collider> colliders;
		public bool isFixed;
		//public float width;
		//public float height;
		public RectangleF shape;

		protected Texture2D texture;

		public GameObject(){
			//usePhysics = true;
			loaded = false;
			colliders = new List<Collider>();
			isFixed = false;
		}

		public abstract void Update();
		public abstract void Draw(SpriteBatch sb, ScreenManager sm);
		public abstract void Load(ContentManager Content);
		public abstract void collide(GameObject b);

		protected void createDefaultBounds(){
			RectangleF upper, lower, easter, western;

			upper = new RectangleF(0f, shape.height , shape.width, 0.1f);
			lower = new RectangleF(-0.1f, 0f, shape.width, 0.1f);
			easter = new RectangleF(shape.width, 0f, 0.1f, shape.height);
			western = new RectangleF(-0.1f, 0f, 0.1f, shape.height);

			colliders.Add(new Collider(upper, this));
			colliders.Add(new Collider(lower, this));
			colliders.Add(new Collider(easter, this));
			colliders.Add(new Collider(western, this));

		}

		/*protected void updateBounds(){
			foreach (Collider c in colliders) {
				c.shape.x = 
			}
		}*/

		public virtual bool isGrounded(){
			return true;
		}

		public virtual RectangleF getCollisionShape(){
			return shape;
		}
	}
}

