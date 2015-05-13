using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth {
    [Serializable]
    public class SceneContainer {
        //class attributes
        int id;
        RectangleF shapeBox;
        int previousScene = -1;
        int nextScene = -1;
        string name;
        
        public LinkedList<GameObject> objects;

        //class properties
        public int ID{
            get{return id;}
            set{id = value;}
        }
        public float X{
            get {return shapeBox.x;}
            set {shapeBox.x = value;}
        }
        public float Y{
            get {return shapeBox.y;}
            set {shapeBox.y = value;}
        }
        public Vector2 position{
            get {return new Vector2(shapeBox.x,shapeBox.y);}
            set {shapeBox.x = value.X; shapeBox.y = value.Y;}
        }
        public float Width{
            get {return shapeBox.width;}
            set {shapeBox.width = value;}
        }
        public float Height{
            get {return shapeBox.height;}
            set {shapeBox.height = value;}
        }
        public string Name{
            get {return name;}
            set {name = value;}
        }
        public int PreviousScene{
            set {previousScene = value;}
            get {return previousScene;}
        }
        public int NextScene{
            get {return nextScene;}
            set {nextScene = value;}
        }
        public RectangleF Shape{
            get {return shapeBox;}
        }
        
        //class constructors
        public SceneContainer(RectangleF sb, int id){
            objects = new LinkedList<GameObject>();            
            shapeBox = sb;
            this.id = id;
            name = "Container_"+id.ToString();
        }

        public SceneContainer(RectangleF sb, int id, int prevScene):this(sb, id){
            previousScene = prevScene;
        }

        public SceneContainer(RectangleF sb, int id, int prevScene, int nextScene):this(sb, id, prevScene){
            this.nextScene = nextScene;
        }

        public void add(GameObject o){
            objects.AddFirst(o);
        }

        public void unLoad(){
            objects.Clear();
        }

        public void extendWidth(float extension){
            shapeBox.width += extension;
        }

        public void extendHeight(float extension){
            shapeBox.height += extension;
        }

        public RectangleF getHalfRightBounds(){
            return new RectangleF(shapeBox.x + shapeBox.width/2, shapeBox.y, shapeBox.width/2, shapeBox.height);
        }

        public RectangleF getHalfLeftBounds(){
            return new RectangleF(shapeBox.x, shapeBox.y, shapeBox.width/2, shapeBox.height);
        }

        public virtual void Draw(SpriteBatch sb, GameTime gameTime){ //MAKE NOT VIRTUAL WHEN DISABLING EDITOR
            foreach (GameObject g in objects) {
				g.Draw(sb, gameTime);
			}
        }

        public void DrawBounds(SpriteBatch sb, GameTime gameTime){
            Texture2D line = TextureManager.getTexture(TextureManager.TextureID.player);
            //leftLine
            sb.Draw(line, new Rectangle((int)DisplayManager.getScreenX(shapeBox.x),(int)DisplayManager.getScreenY(shapeBox.y + shapeBox.height),1,(int)DisplayManager.screenLength(shapeBox.height)),Color.White);
            //topLine
            sb.Draw(line, new Rectangle((int)DisplayManager.getScreenX(shapeBox.x),(int)DisplayManager.getScreenY(shapeBox.y + shapeBox.height),(int)DisplayManager.screenLength(shapeBox.width),1),Color.White);
            //rightLine
            sb.Draw(line, new Rectangle((int)DisplayManager.getScreenX(shapeBox.x + shapeBox.width),(int)DisplayManager.getScreenY(shapeBox.y + shapeBox.height),1,(int)DisplayManager.screenLength(shapeBox.height)),Color.White);
            //bottomLine
            sb.Draw(line, new Rectangle((int)DisplayManager.getScreenX(shapeBox.x),(int)DisplayManager.getScreenY(shapeBox.y),(int)DisplayManager.screenLength(shapeBox.width),1),Color.White);
        }

        public void save(){
            BinaryFormatter binFormat = new BinaryFormatter();
            string fileName = "Lvl/" + ID.ToString() + ".scn";
            if (!Directory.Exists("Lvl")){
                Directory.CreateDirectory("Lvl");
            }
            using(Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)){
                binFormat.Serialize(fStream, this);
            }
        }
        
    }
}
