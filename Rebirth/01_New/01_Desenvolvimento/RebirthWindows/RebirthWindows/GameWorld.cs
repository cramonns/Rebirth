using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Rebirth {

    public class GameWorld:GameScreen {

        private bool editorMode = false;
        private bool prevFramePressed = false;
        private Vector2 mouseStartDragPos;
        private Vector2 worldStartDragPos;
        private Vector2 mouseDragDisplacement;
        private bool insertionMode = false;
        public bool insertPermit;
        private Enumerations.ObjectTypes insertionType;

        private int preloadAmount = 1;
        private SceneContainer[] scenes;
        private PhysicsManager worldPhysics;
        bool drawPlayer;

        public Player player;

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
            
            if (editorMode){
                drawPlayer = false;

                /*if (Mouse.GetState().LeftButton == ButtonState.Pressed){
                    if (!prevFramePressed) {
                        mouseStartDragPos = Mouse.GetState().Position.ToVector2();
                        worldStartDragPos = DisplayManager.screenShift;
                    }
                    mouseDragDisplacement = Mouse.GetState().Position.ToVector2() - mouseStartDragPos;
                    DisplayManager.screenShift += DisplayManager.worldPosition(mouseDragDisplacement);
                    prevFramePressed = true;
                } else {
                    prevFramePressed = false;
                }*/
            }
            else {
                bool updated = LoadManager.Update(scenes,preloadAmount,player.Position);
                worldPhysics.restart();
                worldPhysics.addObjects(scenes[preloadAmount-1], scenes[preloadAmount], scenes[preloadAmount+1], player, updated);
                worldPhysics.Update(gameTime);
			    worldPhysics.checkCollisions();
			    worldPhysics.treatCollisions();
			    worldPhysics.integratePosition();
                DisplayManager.Update(player.Position);
            }
        }

		public override void Draw(GameTime gameTime){
            
            if (!editorMode) sb.Draw(TextureManager.getTexture(TextureManager.TextureID.Background), new Rectangle(0,0,1280,720), Color.White);

            if (scenes[preloadAmount-1] != null){
                if (!(scenes[preloadAmount-1].Right < DisplayManager.screenShift.X)){
                    scenes[preloadAmount-1].Draw(sb, gameTime);
                    if (editorMode) scenes[preloadAmount-1].DrawBounds(sb, gameTime);
                }
            }
            if (scenes[preloadAmount] != null){
                scenes[preloadAmount].Draw(sb, gameTime);
                if (editorMode) scenes[preloadAmount].DrawBounds(sb, gameTime);
            }
            if (scenes[preloadAmount+1] != null){
                if (!(scenes[preloadAmount+1].X > DisplayManager.Right)){
                    scenes[preloadAmount+1].Draw(sb, gameTime);
                    if (editorMode) scenes[preloadAmount+1].DrawBounds(sb, gameTime);
                }
            }
            if (drawPlayer) player.Draw(sb, gameTime);
            if (insertionMode){
                Color color = Color.White * 0.5f;
                Texture2D texture = TextureManager.load(TextureManager.TextureID.white);
                RectangleF rectangle = new RectangleF(0,0,0,0);
                switch (insertionType){
                    case Enumerations.ObjectTypes.Box:
                        rectangle.set(MouseManager.mousePosition, Box.DefaultWidth, Box.DefaultHeight);
                        break;
                    case Enumerations.ObjectTypes.Ground:
                        rectangle.set(MouseManager.mousePosition, Ground.DefaultWidth, Ground.DefaultHeight);
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
        }

		public override void LoadScreen(){
            /*if (scenes[preloadAmount] != null)
            foreach (GameObject o in scenes[preloadAmount].objects) {
				if (!o.loaded) o.Load(tm);
			}
            player.Load(tm);*/
        }

        public void editMode(){
            editorMode = true;
        }

        public void leaveEditMode(){
            editorMode = false;
            drawPlayer = true;
        }

        public void insertMode(Enumerations.ObjectTypes type){
            insertionMode = true;
            insertionType = type;
        }

        public void leaveInsertMode(){
            insertionMode = false;
        }

        public void loadScene(SceneContainer sc){
            scenes[preloadAmount] = sc;
        }

        public void loadScene(int sceneId){
            if (File.Exists("Lvl/"+sceneId.ToString()+".scn"))
                loadScene(LoadManager.Load(sceneId));
        }

        public SceneContainer currentContainer(){
            return scenes[preloadAmount];
        }

        private GameObject newObject(Enumerations.ObjectTypes objectType){
            switch (objectType){
                case Enumerations.ObjectTypes.Box:
                    return new Box(MouseManager.mousePosition - new Vector2(Box.DefaultWidth/2,Box.DefaultHeight/2));
                case Enumerations.ObjectTypes.Ground:
                    return new Ground(MouseManager.mousePosition - new Vector2(Ground.DefaultWidth/2,Ground.DefaultHeight/2));
            }
            return null;
        }

        public void createObject(Enumerations.ObjectTypes objectType){
            GameObject g = newObject(objectType);
            scenes[preloadAmount].add(g);
            g.Load();
        }

        public void saveScene(){
            scenes[preloadAmount].save();
        }

    }
}
