using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rebirth.Effects {
    public class Rain {

        MoveableObject[,] rainParticles;
        Texture2D rainTexture;


        public Rain(int horizontalDensity, int verticalDensity){
            rainParticles = new Particle[horizontalDensity, verticalDensity];

            Random rand = new Random();
            for (int i = 0; i < horizontalDensity; i++)
            {
                for (int j = 0; j < verticalDensity; j++)
                {
                    rainParticles[i, j] = new Particle();
                    rainParticles[i, j].X = i * (DisplayManager.DisplayWidth) / horizontalDensity - 400;
                    rainParticles[i, j].Y = j * (DisplayManager.DisplayHeight) / verticalDensity - 40;
                    rainParticles[i, j].speed.X = -1.2f - (float)rand.NextDouble();
                    rainParticles[i, j].speed.Y = 4f + 2 * (float)rand.NextDouble();
                }
            }

            rainTexture = TextureManager.load(TextureManager.TextureID.rain);
        }

        public void Draw(SpriteBatch sb, GameTime gameTime){
            foreach (MoveableObject r in rainParticles)
            {
                sb.Draw(rainTexture, new Rectangle((int)r.Position.X, (int)r.Position.Y, 640, 400), Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Particle p in rainParticles)
            {
                p.Update(gameTime);
            }
        }

    }
}
