#if EDITOR
using System.Collections.Generic;
#endif
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Rebirth.EditorClasses;

namespace Rebirth
{

    public class GameWorld:GameScreen {

#if EDITOR
        public enum SelectionTransformType{
            None,
            Move,
            ExtendUp,
            ExtendDown,
            ExtendLeft,
            ExtendRight,
            ExtendTopLeft,
            ExtendTopRight,
            ExtendDownLeft,
            ExtendDownRight
        }

        private bool insertionMode = false;
        public bool insertPermit;
        private Enumerations.ObjectTypes insertionType;
        public GameObject selectedObject = null;
        public RectangleF boundingBoxBackup = new RectangleF(0,0,0,0);
        public SelectionTransformType selectionTransformType = SelectionTransformType.None;
#endif

        private int preloadAmount = 1;
        private SceneContainer[] scenes;
        private PhysicsManager worldPhysics;
        bool drawPlayer;

        public Player player;
        
        Effects.Rain rainEffect = new Effects.Rain(15,10);

        public GameWorld(SpriteBatch sb){
            this.sb = sb;

            scenes = new SceneContainer[preloadAmount*2+1];
            loaded = false;
            worldPhysics = new PhysicsManager();
            player = new Player();
            player.Load();
            drawPlayer = true;
            
        }

        public override void Update(GameTime gameTime){
#if EDITOR
            if (GameManager.globalVariables.editorMode){
                drawPlayer = false;
            }
            else {
#endif
                bool updated = LoadManager.Update(scenes,preloadAmount,player.Position);
                updated = updated || GameManager.wasUpdated();
                worldPhysics.restart();
                worldPhysics.addObjects(scenes[preloadAmount-1], scenes[preloadAmount], scenes[preloadAmount+1], player, updated);
                worldPhysics.Update(gameTime);
			    worldPhysics.checkCollisions();
			    worldPhysics.treatCollisions();
			    worldPhysics.integratePosition();
                DisplayManager.Update(player.Position);
                if (GameManager.globalVariables.currentWeather == Enumerations.Weather.Rain){
                    rainEffect.Update(gameTime);
                }
#if EDITOR
            }
#endif
        }

		public override void Draw(GameTime gameTime){
            
            //if (!GameManager.globalVariables.editorMode) sb.Draw(TextureManager.getTexture(TextureManager.TextureID.Background), new Rectangle(0,0,1280,720), Color.White);
#if EDITOR
            Color color = Color.LightGray * 0.5f;
            Texture2D texture = TextureManager.getTexture(TextureManager.TextureID.white);
            RectangleF rectangle = new RectangleF(0,0,0,0);
            List<GameObject> candidates = new List<GameObject>();
#endif
            SceneContainer currentScene = null;

            if (scenes[preloadAmount-1] != null){
                currentScene = scenes[preloadAmount-1];
                if (!(currentScene.Right < DisplayManager.screenShift.X)){
                    currentScene.Draw(sb, gameTime);
#if EDITOR
                    if (GameManager.globalVariables.editorMode) {
                        currentScene.DrawBounds(sb, gameTime);
                        rectangle.set(currentScene.Shape.Center, currentScene.Shape.width, currentScene.Shape.height);
                        sb.Draw(texture, DisplayManager.scaleTexture(rectangle), color);
                    }
#endif
                }
            }
            if (scenes[preloadAmount] != null){
                scenes[preloadAmount].Draw(sb, gameTime);
#if EDITOR
                if (GameManager.globalVariables.editorMode) scenes[preloadAmount].DrawBounds(sb, gameTime);
#endif
            }
            if (scenes[preloadAmount+1] != null){
                currentScene = scenes[preloadAmount+1];
                if (!(currentScene.X > DisplayManager.Right)){
                    currentScene.Draw(sb, gameTime);
#if EDITOR
                    if (GameManager.globalVariables.editorMode) {
                        currentScene.DrawBounds(sb, gameTime);
                        rectangle.set(currentScene.Shape.Center, currentScene.Shape.width, currentScene.Shape.height);
                        sb.Draw(texture, DisplayManager.scaleTexture(rectangle), color);
                    }
#endif
                }
            }
            if (drawPlayer) player.Draw(sb, gameTime);
            #region EDITOR_DRAWING
#if EDITOR
            color = Color.White * 0.5f;
            if (insertionMode){
                switch (insertionType){
                    case Enumerations.ObjectTypes.Box:
                        rectangle.set(MouseManager.mousePosition, Box.DefaultWidth, Box.DefaultHeight);
                        break;
                    case Enumerations.ObjectTypes.Ground:
                        rectangle.set(MouseManager.mousePosition, Ground.DefaultWidth, Ground.DefaultHeight);
                        break;
                    case Enumerations.ObjectTypes.Trigger:
                        rectangle.set(MouseManager.mousePosition, GameTrigger.DefaultWidth, Ground.DefaultHeight);
                        break;
                    case Enumerations.ObjectTypes.TextureLoader:
                        rectangle.set(MouseManager.mousePosition, TextureLoader.DefaultWidth, Ground.DefaultHeight);
                        break;
                    case Enumerations.ObjectTypes.Canon:
                        rectangle.set(MouseManager.mousePosition, Canon.DefaultWidth, Canon.DefaultHeight);
                        break;
                }
                if (rectangle.inside(scenes[preloadAmount].Shape)){
                    insertPermit = true;
                    color = Color.White * 0.5f;
                    
                    foreach (GameObject o in scenes[preloadAmount].objects){
                        if (rectangle.intersects(o.BoundingBox)){
                            insertPermit = false;
                            color = Color.Red*0.5f;
                            break;
                        }
                    }
                }
                else {
                    insertPermit = false;
                    color = Color.Red*0.5f;
                }
                sb.Draw(texture, DisplayManager.scaleTexture(rectangle), color);
            }
            if (selectedObject != null){
                color = Color.White * 0.5f;
                rectangle.set(selectedObject.Position, selectedObject.Width, selectedObject.Height);
                rectangle.x += rectangle.width/2;
                rectangle.y += rectangle.height/2;
                if (selectedObject != null){
                    candidates = scenes[preloadAmount].objectsTree.retrieve(candidates, selectedObject.getCollisionShape());
                    foreach (GameObject g in candidates){
                        if (g != selectedObject){
                            if (g.getCollisionShape().intersects(selectedObject.getCollisionShape())) {
							    color = Color.Red * 0.5f;
						    }
                        }
                    }
                }
                sb.Draw(texture, DisplayManager.scaleTexture(rectangle), color);
            }

            color = Color.White * 0.4f;
            
            /////////////////////////
            //texture = TextureManager.load(TextureManager.TextureID.black);
            /////////////////////////
#if DEV
            if (scenes[preloadAmount] != null){
                foreach (GameObject g in scenes[preloadAmount].objects){
                    if (g is GameTrigger && DeveloperSettings.drawTriggers){
                        sb.Draw(texture, DisplayManager.scaleTexture(g.BoundingBox), color);
                    }
                }
            }
#endif //DEV
#endif //EDITOR
#endregion
            if (GameManager.globalVariables.currentWeather == Enumerations.Weather.Rain){
                rainEffect.Draw(sb, gameTime);
            }
        }

		public override void LoadScreen(){
            /*if (scenes[preloadAmount] != null)
            foreach (GameObject o in scenes[preloadAmount].objects) {
				if (!o.loaded) o.Load(tm);
			}
            player.Load(tm);*/
        }

#if EDITOR
        public void loadScene(SceneContainer sc, Project gameProject){
            scenes[preloadAmount] = sc;
            if (sc.previousScene == -1)
            {
                scenes[preloadAmount - 1] = null;
            }
            else
            {
                scenes[preloadAmount - 1] = XMLManager.Load(sc.previousScene, gameProject);
                scenes[preloadAmount - 1].shiftHorizontal(-sc.Width);
            }
            if (sc.nextScene == -1)
            {
                scenes[preloadAmount + 1] = null;
            }
            else
            {
                scenes[preloadAmount + 1] = XMLManager.Load(sc.nextScene, gameProject);
                scenes[preloadAmount + 1].shiftHorizontal(sc.Width);
            }
        }

        public void loadScene(int sceneId, Project gameProject){
            if (File.Exists("Lvl/"+sceneId.ToString()+".scn"))
                loadScene(LoadManager.Load(sceneId), gameProject);
        }
#endif

        public SceneContainer currentContainer(){
            return scenes[preloadAmount];
        }

        public void unLoad(){
            player.unLoad();
            scenes[preloadAmount] = null;
        }

        public void removeObject(GameObject g){
            if (scenes[preloadAmount-1] != null) scenes[preloadAmount-1].objects.Remove(g);
            scenes[preloadAmount].objects.Remove(g);
            if (scenes[preloadAmount+1] != null) scenes[preloadAmount+1].objects.Remove(g);
        }

#region EDITOR_FUNCTIONS
#if EDITOR
        public void editMode(){
            GameManager.globalVariables.editorMode = true;
        }

        public void leaveEditMode(){
            GameManager.globalVariables.editorMode = false;
            drawPlayer = true;
        }

        public void insertMode(Enumerations.ObjectTypes type){
            insertionMode = true;
            insertionType = type;
        }

        public void insertPlayer(){
            insertionMode = true;
        }

        public void leaveInsertMode(){
            insertionMode = false;
        }

        private GameObject newObject(Enumerations.ObjectTypes objectType){
            switch (objectType){
                case Enumerations.ObjectTypes.Box:
                    return new Box(MouseManager.mousePosition - new Vector2(Box.DefaultWidth/2,Box.DefaultHeight/2));
                case Enumerations.ObjectTypes.Ground:
                    return new Ground(MouseManager.mousePosition - new Vector2(Ground.DefaultWidth/2,Ground.DefaultHeight/2));
                case Enumerations.ObjectTypes.Trigger:
                    return new GameTrigger(MouseManager.mousePosition - new Vector2(Ground.DefaultWidth/2,Ground.DefaultHeight/2), LogicalObject.Treatment.Default, LogicalObject.Treatment.Default, LogicalObject.Treatment.Default);
                case Enumerations.ObjectTypes.TextureLoader:
                    return new TextureLoader(MouseManager.mousePosition - new Vector2(Ground.DefaultWidth/2,Ground.DefaultHeight/2), TextureManager.TextureID.ground);
                case Enumerations.ObjectTypes.Canon:
                    return new Canon(MouseManager.mousePosition - new Vector2(Canon.DefaultWidth/2,Canon.DefaultHeight/2));

            }
            return null;
        }

        public void createObject(Enumerations.ObjectTypes objectType){
            GameObject g = newObject(objectType);
            scenes[preloadAmount].add(g);
            g.Load();
        }

#if EDITOR
        public void saveScene(Project gameProject){
            scenes[preloadAmount].save(gameProject);
        }
#endif

        public bool isInInsertMode(){
            return insertionMode;
        }

        public GameObject objectAt(Vector2 mousePosition){
            if (scenes[preloadAmount] == null) return null;
            foreach (GameObject g in scenes[preloadAmount].objects){
                if (g.BoundingBox.intersects(mousePosition)){
                    return g;
                }
            }
            return null;
        }

        public void transformSelectedObject(){
            if (selectedObject == null) return;
            SceneContainer currentScene = scenes[preloadAmount];
            if (selectedObject.X < currentScene.X ||
                selectedObject.Y < currentScene.Y || 
                selectedObject.X + selectedObject.Width > currentScene.Right || 
                selectedObject.Y + selectedObject.Height > currentScene.Top)
            {
                selectedObject.Position = boundingBoxBackup.Position;
                selectedObject.Width = boundingBoxBackup.width;
                selectedObject.Height = boundingBoxBackup.height;
                return;
            }
            if (selectedObject is LogicalObject) return;
            List<GameObject> candidates = new List<GameObject>();
            candidates = currentScene.objectsTree.retrieve(candidates, selectedObject.getCollisionShape());
            foreach (GameObject g in candidates){
                if (g != selectedObject){
                    if (g.getCollisionShape().intersects(selectedObject.getCollisionShape())){
						selectedObject.Position = boundingBoxBackup.Position;
                        selectedObject.Width = boundingBoxBackup.width;
                        selectedObject.Height = boundingBoxBackup.height;
                        return;
					}
                }
            }
            boundingBoxBackup.set(selectedObject.BoundingBox.Center, selectedObject.Width, selectedObject.Height);
        }

        public void transformScene(){
            float diff = 0;
            if (scenes[preloadAmount - 1] != null){
                diff = scenes[preloadAmount - 1].X + scenes[preloadAmount - 1].Width - scenes[preloadAmount].X;
                scenes[preloadAmount].shiftHorizontal(diff);
                DisplayManager.screenShift.X += diff;
            }
            if (scenes[preloadAmount + 1] != null) {
                diff = scenes[preloadAmount].X + scenes[preloadAmount].Width - scenes[preloadAmount + 1].X;
                scenes[preloadAmount+1].shiftHorizontal(diff);
            }
        }

#endif
#endregion

    }
}
