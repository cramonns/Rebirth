#if EDITOR
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Rebirth.EditorClasses {
    public class SceneContainerManager: SceneContainer {

        ContainerManager manager;

        public SceneContainerManager(ContainerManager cm):base(new RectangleF(0,0,0,0), -1){
            manager = cm;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime){
            manager.Draw(sb);
        }

    }
}
#endif