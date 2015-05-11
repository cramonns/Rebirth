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
                drawPlayer = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed){
                    if (!prevFramePressed) {
                        mouseStartDragPos = Mouse.GetState().Position.ToVector2();
                        worldStartDragPos = DisplayManager.screenShift;
                    }
                    mouseDragDisplacement = Mouse.GetState().Position.ToVector2() - mouseStartDragPos;
                    DisplayManager.screenShift += DisplayManager.worldPosition(mouseDragDisplacement);
                    prevFramePressed = true;
                } else {
                    prevFramePressed = false;
                }
    
                
            }
            else {
                LoadManager.Update(scenes,preloadAmount,new Vector2(0,0));
                worldPhysics.restart();
                worldPhysics.addObjects(scenes[preloadAmount-1], scenes[preloadAmount], scenes[preloadAmount+1], player);
                worldPhysics.applyGravity();
                worldPhysics.Update(gameTime);
			    worldPhysics.checkCollisions();
			    worldPhysics.treatCollisions();
			    worldPhysics.integratePosition();
                DisplayManager.Update(new Vector2(player.boundingBox.x, player.boundingBox.y));
            }
        }

		public override void Draw(GameTime gameTime){
            
            if (scenes[preloadAmount-1] != null){
                scenes[preloadAmount-1].Draw(sb, gameTime);
                if (editorMode) scenes[preloadAmount-1].DrawBounds(sb, gameTime);
            }
            if (scenes[preloadAmount] != null){
                scenes[preloadAmount].Draw(sb, gameTime);
                if (editorMode) scenes[preloadAmount].DrawBounds(sb, gameTime);
            }
            if (scenes[preloadAmount+1] != null){
                scenes[preloadAmount+1].Draw(sb, gameTime);
                if (editorMode) scenes[preloadAmount+1].DrawBounds(sb, gameTime);
            }
            if (drawPlayer) player.Draw(sb, gameTime);
            if (insertionMode){
                switch (insertionType){
                    case Enumerations.ObjectTypes.Box:
                        sb.Draw(TextureManager.load(TextureManager.TextureID.box), DisplayManager.scaleTexture(MouseManager.mousePosition, Box.DefaultWidth, Box.DefaultHeight), Color.White);
                        break;
                    case Enumerations.ObjectTypes.Ground:
                        sb.Draw(TextureManager.load(TextureManager.TextureID.ground), DisplayManager.scaleTexture(MouseManager.mousePosition, Ground.DefaultWidth, Ground.DefaultHeight), Color.White);
                        break;
                }
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

        public void loadScene(SceneContainer sc){
            scenes[preloadAmount] = sc;
            /*sc.add(new Ground());
			sc.add(new Box());*/
            //sc.add(player);
            //player.setPosition(0,100f/60f);*/
        }

        public void loadScene(int sceneId){
            if (File.Exists("Lvl/"+sceneId.ToString()+".scn"))
                loadScene(LoadManager.Load(sceneId));
        }

        public SceneContainer currentContainer(){
            return scenes[preloadAmount];
        }

    }
}
