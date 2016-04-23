using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Rebirth.EditorClasses;

namespace Rebirth {
    [Serializable]
    public class SceneContainer {

        private const int BACKGROUND_LEVELS = 7;
        private const int FRONT_LEVELS = 3;

        //class attributes
        public int id;
        public int previousScene = -1;
        public int nextScene = -1;
        RectangleF shapeBox;
        public LinkedList<TextureManager.TextureID> textureHolders;
       
        public LinkedList<GameObject> objects;
        public LinkedList<GameObject>[] backgroundObjects;
        public LinkedList<GameObject>[] frontObjects;

        public static float DefaultHeight{
            get {return 20;}
        }
        public static float DefaultWidth{
            get {return 40;}
        }

#if EDITOR
        [NonSerialized]
        public QuadTree objectsTree;
#endif

        //class properties
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
        public float Right{
            get {return shapeBox.x + shapeBox.width;}
            set {shapeBox.x = value - shapeBox.width;}
        }
        public float Top{
            get {return shapeBox.y + shapeBox.height;}
            set {shapeBox.y = value - shapeBox.height;}
        }
        public RectangleF Shape{
            get {return shapeBox;}
        }

        //class constructors
        public SceneContainer(RectangleF sb, int id){
            objects = new LinkedList<GameObject>(); 
            backgroundObjects = new LinkedList<GameObject>[BACKGROUND_LEVELS];
            frontObjects = new LinkedList<GameObject>[FRONT_LEVELS];
            for (int i = 0; i < BACKGROUND_LEVELS; i++)
                backgroundObjects[i] = new LinkedList<GameObject>();
            for (int i = 0; i < FRONT_LEVELS; i++)
                frontObjects[i] = new LinkedList<GameObject>();
            shapeBox = sb;
            this.id = id;
            textureHolders = new LinkedList<TextureManager.TextureID>();
#if EDITOR
            objectsTree = new QuadTree(0,sb);
#endif
        }

        public SceneContainer(RectangleF sb, int id, int prevScene):this(sb, id){
            previousScene = prevScene;
        }

        public SceneContainer(RectangleF sb, int id, int prevScene, int nextScene):this(sb, id, prevScene){
            this.nextScene = nextScene;
        }

        public void add(GameObject o){
            objects.AddFirst(o);
#if EDITOR
            objectsTree.insert(o);
#endif
        }

        public void unLoad(){
            foreach (GameObject g in objects) g.unLoad();
            foreach (TextureManager.TextureID t in textureHolders) TextureManager.unLoad(t);
            objects.Clear();
            textureHolders.Clear();
#if EDITOR
            if (objectsTree != null) objectsTree.clear();
#endif
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

#if EDITOR

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

        public void save(string projectDirectory){
            foreach (GameObject g in objects){
                g.X -= shapeBox.x;
            }
            //SAVE BINARY
            BinaryFormatter binFormat = new BinaryFormatter();
            projectDirectory += "/Lvl";
            string fileName = projectDirectory + "/" + id.ToString() + ".scn";
            if (!Directory.Exists(projectDirectory)){
                Directory.CreateDirectory(projectDirectory);
            }
            using(Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)){
                binFormat.Serialize(fStream, this);
            }
            //SAVE XML
            XMLManager.saveXML(this, projectDirectory);
        }

        public void remakeObjectsTree(){
            if (objectsTree != null) objectsTree.clear();
            objectsTree = new QuadTree(0, shapeBox);
            foreach (GameObject g in objects) objectsTree.insert(g);
        }

        public void extendWidth(float extension){
            shapeBox.width += extension;
            remakeObjectsTree();
        }

        public void extendHeight(float extension){
            shapeBox.height += extension;
            remakeObjectsTree();
        }

        /* There's no need of a shiftLeft function.
         * When extending to the left, the current scene will be shifted, not the previous scene.
         */
        public void shiftHorizontal(float extension){
            foreach (GameObject g in objects){
                g.X += extension;
            }
            this.X += extension;
        }

        public void moveObjects(float extension){
            foreach (GameObject g in objects){
                g.X += extension;
            }
        }

#endif

    }
}
