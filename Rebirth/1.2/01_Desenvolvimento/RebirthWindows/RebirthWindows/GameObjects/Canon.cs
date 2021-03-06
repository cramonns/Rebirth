﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Rebirth {

    [Serializable]
    public class Canon:MoveableObject  {
        public int fireRate = DefaultFireRate; //miliseconds
        
        double time = 0;
        
        new public static float DefaultHeight {
            get {return 0.5f;}
        }
        public static int DefaultFireRate{
            get {return 3000;}
        }

        public Canon():this(new Vector2(0,0)){

        }

        public Canon(Vector2 position){
            colliders = null;
            usePhysics = true;
            isFixed = false;
            boundingBox = new RectangleF(position, DefaultWidth, DefaultHeight);
            textureId = TextureManager.TextureID.black;
            attachments = new LinkedList<Attachment>();
        }

        public Canon(Vector2 position, int fireRate):this(position){
            this.fireRate = fireRate;
        }

        private void fire(){
            Projectile p = new Projectile(new Vector2(this.Position.X-0.6f, this.Position.Y), new Vector2(-0.13f,0));
            p.Load();
            GameManager.addObjectToScene(p);
        }

        public override void collide(GameObject b, CollisionDistance cd) {
        }

        public override void Update(GameTime gameTime){
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time > fireRate){
                fire();
                time -= fireRate;
            }
        }

    }
}
