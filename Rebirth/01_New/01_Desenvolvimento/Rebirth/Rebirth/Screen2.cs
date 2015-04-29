using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth{

	public class Screen2:GameScreen{

		List<GameObject> objects; 
		PhysicsManager screen2physx;

		public Screen2(SpriteBatch sb, ScreenManager sm){
			this.sb = sb;
			this.sm = sm;
			loaded = false;
			objects = new List<GameObject>();
			objects.Add(new Ground());
			objects.Add(new Box());
		}

		public override void LoadScreen(ContentManager Content){
			foreach (GameObject o in objects) {
				if (!o.loaded) o.Load(Content);
			}
			screen2physx = new PhysicsManager(objects);
			loaded = true;
		}

		public override void Update(){
			screen2physx.applyGravity();
			foreach (GameObject g in objects) {
				g.Update();
			}
			screen2physx.checkCollisions();
			screen2physx.treatCollisions();
			screen2physx.integratePosition();
		}

		public override void Draw(){
			foreach (GameObject g in objects) {
				g.Draw(sb, sm);
			}
		}

		public override void addObject(GameObject newObject){
			objects.Add(newObject);
		}
	}
}

