using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth{

	public class Screen2:GameScreen{

		List<GameObject> objects; 
		//PhysicsManager screen2physx;
        Player player;

		public Screen2(SpriteBatch sb, DisplayManager sm){
			this.sb = sb;
			this.sm = sm;
			loaded = false;
			objects = new List<GameObject>();
			objects.Add(new Ground());
			objects.Add(new Box());

            player = new Player();
            objects.Add(player);

		}

		public override void LoadScreen(TextureManager tm, VideoManager vm){
			foreach (GameObject o in objects) {
				if (!o.loaded) o.Load(tm);
			}
			//screen2physx = new PhysicsManager(objects);
			loaded = true;
		}

		public override void Update(GameTime gameTime){
			//screen2physx.applyGravity();
			foreach (GameObject g in objects) {
				g.Update(gameTime);
			}
			/*screen2physx.checkCollisions();
			screen2physx.treatCollisions();
			screen2physx.integratePosition();
            sm.Update(new Vector2(player.boundingBox.x, player.boundingBox.y));*/
		}

		public override void Draw(GameTime gameTime){
			foreach (GameObject g in objects) {
				g.Draw(sb, sm, gameTime);
			}
		}

		/*public override void addObject(GameObject newObject){
			objects.Add(newObject);
		}*/
	}
}

