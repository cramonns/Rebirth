using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Rebirth{

    [Serializable]
	public abstract class GameObject{

		protected enum Bounds:byte{
			UPPER = 0,
			LOWER,
			EASTER,
			WESTERN
		}

		//public Vector2 position;
        [NonSerialized]
		public bool loaded;
		public bool isFixed;
		public RectangleF boundingBox;
        public TextureManager.TextureID textureId;
        [NonSerialized]
        public List<Collider> colliders;

        [NonSerialized]
		protected Texture2D texture;

		public GameObject(){
			isFixed = false;
            textureId = TextureManager.TextureID.ground;
            defaultValues();
		}

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(SpriteBatch sb, DisplayManager sm, GameTime gameTime);
		public abstract void collide(GameObject b);

		protected void createDefaultBounds(){
			RectangleF upper, lower, easter, western;

			upper = new RectangleF(0f, boundingBox.height , boundingBox.width, 0.1f);
			lower = new RectangleF(-0.1f, 0f, boundingBox.width, 0.1f);
			easter = new RectangleF(boundingBox.width, 0f, 0.1f, boundingBox.height);
			western = new RectangleF(-0.1f, 0f, 0.1f, boundingBox.height);

			colliders.Add(new Collider(upper, this));
			colliders.Add(new Collider(lower, this));
			colliders.Add(new Collider(easter, this));
			colliders.Add(new Collider(western, this));

		}

		public virtual bool isGrounded(){
			return true;
		}

		public virtual RectangleF getCollisionShape(){
			return boundingBox;
		}

        public virtual void Load(TextureManager tm){
            if (!tm.isLoaded(textureId)){
                texture = tm.load(textureId);
            }
            else texture = tm.textures[(int)textureId];
            loaded = true;
        }

        public virtual void defaultValues(){
            loaded = false;
			colliders = new List<Collider>();
        }
	}
}

