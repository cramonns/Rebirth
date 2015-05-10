using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth {

    public class GameWorld:GameScreen {

        private bool editorMode = false;

        private int preloadAmount = 1;
        private SceneContainer[] scenes;
        private PhysicsManager worldPhysics;
        LoadManager lm;

        public Player player;

        public GameWorld(SpriteBatch sb, DisplayManager sm, TextureManager tm, VideoManager vm){
            this.sb = sb;
            this.sm = sm;

            lm = new LoadManager(tm, vm);
            scenes = new SceneContainer[preloadAmount*2+1];
            loaded = false;
            worldPhysics = new PhysicsManager();
            player = new Player();
            player.Load(tm);
        }

        public override void Update(GameTime gameTime){
            if (editorMode){
                                    
                
            }
            else {
                lm.Update(scenes,preloadAmount,new Vector2(0,0));
                worldPhysics.restart();
                worldPhysics.addObjects(scenes[preloadAmount-1], scenes[preloadAmount], scenes[preloadAmount+1], player);
                worldPhysics.applyGravity();
                worldPhysics.Update(gameTime);
			    worldPhysics.checkCollisions();
			    worldPhysics.treatCollisions();
			    worldPhysics.integratePosition();
                sm.Update(new Vector2(player.boundingBox.x, player.boundingBox.y));
            }
        }

		public override void Draw(GameTime gameTime){
            if (scenes[preloadAmount-1] != null){
                scenes[preloadAmount-1].Draw(sb, sm, gameTime);
            }
            if (scenes[preloadAmount] != null){
                scenes[preloadAmount].Draw(sb, sm, gameTime);
            }
            if (scenes[preloadAmount+1] != null){
                scenes[preloadAmount+1].Draw(sb, sm, gameTime);
            }
            player.Draw(sb, sm, gameTime);
        }

		public override void LoadScreen(TextureManager tm, VideoManager vm){
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
        }

        public void loadScene(SceneContainer sc){
            scenes[preloadAmount] = sc;
            /*sc.add(new Ground());
			sc.add(new Box());*/
            //sc.add(player);
            //player.setPosition(0,100f/60f);*/
        }

        public SceneContainer currentContainer(){
            return scenes[preloadAmount];
        }

    }
}
