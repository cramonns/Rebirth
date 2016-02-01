using System;
#if EDITOR
using System.Windows.Forms;
using System.IO;
#endif
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections;

namespace Rebirth{

    /// <summary>
    /// Class representing an object from the game
    /// </summary>
    [Serializable]
	public abstract class GameObject{
   
        public static float DefaultWidth{
            get{return 2f;}
        }
        public static float DefaultHeight{
            get{return 2f;}
        }

		protected enum Bounds:byte{
			UPPER = 0,
			LOWER,
			EASTER,
			WESTERN
		}

		public bool isFixed;
		protected RectangleF boundingBox;
        public List<RectangleF> colliders;
        public TextureManager.TextureID textureId;
        protected LinkedList<Attachment> attachments;

        [NonSerialized]
		protected Texture2D texture;

        public RectangleF BoundingBox{
            get {return boundingBox;}
        }
        public Vector2 Position{
            get {return boundingBox.Position;}
            set {boundingBox.Position = value;}
        }
        public float Width{
            get {return boundingBox.width;}
            set {boundingBox.width = value;}
        }
        public float Height{
            get {return boundingBox.height;}
            set {boundingBox.height = value;}
        }
        public float X{
            get {return boundingBox.x;}
            set {boundingBox.x = value;}
        }
        public float Y{
            get {return boundingBox.y;}
            set {boundingBox.y = value;}
        }
        public LinkedList<Attachment> Attachments{
            get {return attachments;}
        }
       
		public GameObject(){
			isFixed = true;
            textureId = TextureManager.TextureID.ground;
            defaultValues();
            attachments = new LinkedList<Attachment>();
            colliders = null;
		}

		public abstract void Update(GameTime gameTime);
		public abstract void collide(GameObject b, CollisionDistance cd);

        public virtual void Draw(SpriteBatch sb, GameTime gameTime){
            sb.Draw(texture, DisplayManager.scaleTexture(boundingBox), Color.White);
#if DEV
            DrawBoundingBox(sb);
            DrawColliders(sb);
#endif
        }

		/*protected void createDefaultBounds(){
			RectangleF upper, lower, easter, western;

			upper = new RectangleF(0f, boundingBox.height , boundingBox.width, 0.1f);
			lower = new RectangleF(-0.1f, 0f, boundingBox.width, 0.1f);
			easter = new RectangleF(boundingBox.width, 0f, 0.1f, boundingBox.height);
			western = new RectangleF(-0.1f, 0f, 0.1f, boundingBox.height);

			colliders.Add(new Collider(upper, this));
			colliders.Add(new Collider(lower, this));
			colliders.Add(new Collider(easter, this));
			colliders.Add(new Collider(western, this));

		}*/

		public virtual bool isGrounded(){
			return true;
		}

		public virtual RectangleF getCollisionShape(){
			return boundingBox;
		}

        public virtual void Load(){
            texture = TextureManager.load(textureId);
        }

        public virtual void defaultValues(){
        }

        public virtual void unLoad(){
            TextureManager.unLoad(textureId);
        }

        public virtual void updateBoundingBox(){
            boundingBox.width = 0;
            boundingBox.height = 0;
            foreach (RectangleF c in colliders){
                if (c.width + c.x > boundingBox.width) boundingBox.width = c.width + c.x;
                if (c.height + c.y > boundingBox.height) boundingBox.height = c.height + c.y;
            }
        }

#if DEV
        public void DrawBoundingBox(SpriteBatch sb){
            if (DeveloperSettings.drawBoundingBoxes){
                Rectangle rectangle = DisplayManager.scaleTexture(boundingBox);
                sb.Draw(TextureManager.blankTexture,rectangle,Color.Yellow*0.5f);
            }
        }

        public void DrawColliders(SpriteBatch sb){
            if (DeveloperSettings.drawColliders && colliders != null){
                Rectangle rectangle;
                foreach (RectangleF c in colliders){
                    RectangleF auxR = new RectangleF(c.x + boundingBox.x, c.y + boundingBox.y, c.width, c.height);
                    rectangle = DisplayManager.scaleTexture(auxR);
                    sb.Draw(TextureManager.blankTexture,rectangle,Color.White*0.5f);
                }
            }
        }
#endif

#if EDITOR

        public void extendRight(float extension){
            Width += extension;
        }

        public void extendUp(float extension){
            Height += extension;
        }

        public void extendLeft(float extension){
            X -= extension;
            Width += extension;
        }

        public void extendDown(float extension){
            Y -= extension;
            Height += extension;
        }

        public void saveXML(int level, StreamWriter xmlStream){
            xmlStream.WriteLine(FileManager.tabs(level) + "<" + FileManager.instanceName(this)
                + " x=" + this.X.ToString()
                + " y=" + this.Y.ToString()
                + " width=" + this.Width.ToString()
                + " height=" + this.Height.ToString()
                + ">");
            level++;
                xmlStream.WriteLine(FileManager.tabs(level)
                    + "textureId=\"" + Enum.GetNames(typeof(TextureManager.TextureID))[(int)textureId]
                    + "\";");
                specificXML(level, xmlStream);
            level--;
            xmlStream.WriteLine(FileManager.tabs(level) + "</"+FileManager.instanceName(this)+">");
        }

        public virtual void specificXML(int level, StreamWriter xmlStream){
        }
#endif

	}
}

