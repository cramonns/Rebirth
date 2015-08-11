﻿using System;
#if EDITOR
using System.Collections.Generic;
#endif
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Rebirth {

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

        private bool editorMode = false;
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
            if (editorMode){
                drawPlayer = false;
            }
            else {
#endif
                bool updated = LoadManager.Update(scenes,preloadAmount,player.Position);
                worldPhysics.restart();
                worldPhysics.addObjects(scenes[preloadAmount-1], scenes[preloadAmount], scenes[preloadAmount+1], player, updated);
                worldPhysics.Update(gameTime);
			    worldPhysics.checkCollisions();
			    worldPhysics.treatCollisions();
			    worldPhysics.integratePosition();
                DisplayManager.Update(player.Position);
#if EDITOR
            }
#endif
        }

		public override void Draw(GameTime gameTime){
            
            //if (!editorMode) sb.Draw(TextureManager.getTexture(TextureManager.TextureID.Background), new Rectangle(0,0,1280,720), Color.White);
#if EDITOR
            Color color = Color.LightGray * 0.5f;
            Texture2D texture = TextureManager.load(TextureManager.TextureID.white);
            RectangleF rectangle = new RectangleF(0,0,0,0);
            List<GameObject> candidates = new List<GameObject>();
#endif
            SceneContainer currentScene = null;

            if (scenes[preloadAmount-1] != null){
                currentScene = scenes[preloadAmount-1];
                if (!(currentScene.Right < DisplayManager.screenShift.X)){
                    currentScene.Draw(sb, gameTime);
#if EDITOR
                    if (editorMode) {
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
                if (editorMode) scenes[preloadAmount].DrawBounds(sb, gameTime);
#endif
            }
            if (scenes[preloadAmount+1] != null){
                currentScene = scenes[preloadAmount+1];
                if (!(currentScene.X > DisplayManager.Right)){
                    currentScene.Draw(sb, gameTime);
#if EDITOR
                    if (editorMode) {
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
                        rectangle.set(MouseManager.mousePosition, Trigger.DefaultWidth, Ground.DefaultHeight);
                        break;
                    case Enumerations.ObjectTypes.TextureLoader:
                        rectangle.set(MouseManager.mousePosition, TextureLoader.DefaultWidth, Ground.DefaultHeight);
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
            texture = TextureManager.load(TextureManager.TextureID.cyan);
            
            if (scenes[preloadAmount] != null){
                foreach (GameObject g in scenes[preloadAmount].objects){
                    if (g is Trigger && DeveloperSettings.drawTriggers){
                        sb.Draw(texture, DisplayManager.scaleTexture(g.BoundingBox), color);
                    }
                }
            }

#endif
#endregion
        }

		public override void LoadScreen(){
            /*if (scenes[preloadAmount] != null)
            foreach (GameObject o in scenes[preloadAmount].objects) {
				if (!o.loaded) o.Load(tm);
			}
            player.Load(tm);*/
        }

        public void loadScene(SceneContainer sc){
            scenes[preloadAmount] = sc;
            if (sc.previousScene == -1){
                scenes[preloadAmount-1] = null;
            }
            else scenes[preloadAmount-1] = LoadManager.Load(sc.previousScene);
            if (sc.nextScene == -1){
                scenes[preloadAmount+1] = null;
            }
            else scenes[preloadAmount+1] = LoadManager.Load(sc.nextScene);
        }

        public void loadScene(int sceneId){
            if (File.Exists("Lvl/"+sceneId.ToString()+".scn"))
                loadScene(LoadManager.Load(sceneId));
        }

        public SceneContainer currentContainer(){
            return scenes[preloadAmount];
        }

        public void unLoad(){
            player.unLoad();
            scenes[preloadAmount] = null;
        }

#region EDITOR_FUNCTIONS
#if EDITOR
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

        private GameObject newObject(Enumerations.ObjectTypes objectType){
            switch (objectType){
                case Enumerations.ObjectTypes.Box:
                    return new Box(MouseManager.mousePosition - new Vector2(Box.DefaultWidth/2,Box.DefaultHeight/2));
                case Enumerations.ObjectTypes.Ground:
                    return new Ground(MouseManager.mousePosition - new Vector2(Ground.DefaultWidth/2,Ground.DefaultHeight/2));
                case Enumerations.ObjectTypes.Trigger:
                    return new Trigger(MouseManager.mousePosition - new Vector2(Ground.DefaultWidth/2,Ground.DefaultHeight/2), LogicalObject.Treatment.Default, LogicalObject.Treatment.Default, LogicalObject.Treatment.Default);
                case Enumerations.ObjectTypes.TextureLoader:
                    return new TextureLoader(MouseManager.mousePosition - new Vector2(Ground.DefaultWidth/2,Ground.DefaultHeight/2), TextureManager.TextureID.ground);
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

        public bool isInInsertMode(){
            return insertionMode;
        }

        public GameObject objectAt(Vector2 mousePosition){
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
            if (scenes[preloadAmount+1] != null) {
                diff = scenes[preloadAmount].X + scenes[preloadAmount].Width - scenes[preloadAmount + 1].X;
                scenes[preloadAmount+1].shiftHorizontal(diff);
            }
        }

#endif
#endregion

    }
}