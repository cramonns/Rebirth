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

		public Screen2(SpriteBatch sb){
			this.sb = sb;
			loaded = false;
			objects = new List<GameObject>();
			objects.Add(new Ground(new Vector2(0,0)));
			objects.Add(new Box(new Vector2(0,0)));

            player = new Player();
            objects.Add(player);

		}

		public override void LoadScreen(){
			foreach (GameObject o in objects) {
				if (!o.loaded) o.Load();
			}
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
				g.Draw(sb, gameTime);
			}
		}

		/*public override void addObject(GameObject newObject){
			objects.Add(newObject);
		}*/
	}
}

