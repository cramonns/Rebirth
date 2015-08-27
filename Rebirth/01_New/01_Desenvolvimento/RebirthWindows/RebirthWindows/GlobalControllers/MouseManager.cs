using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Rebirth {
    public static class MouseManager {
        public static bool leftButtonPressed;

        public static bool mouseWaiting;
        public static Vector2 mousePosition = new Vector2(-1000,-1000);
        private static Vector2 previousPosition = new Vector2(-1000,-1000);

        public static Vector2 mouseSource = new Vector2(0,0);

        /*public static Vector2 mousePosition{
            get {return new Vector2(mousePositionX, mousePositionY);}
            set {
                mousePositionX = value.X;
                mousePositionY = value.Y;
            }
        }*/

        public static void Update(){
            previousPosition = mousePosition;
            mousePosition = DisplayManager.worldPosition(Mouse.GetState().Position.ToVector2());
            if (MathUtils.FLOAT_EQUALS(previousPosition.X, mousePosition.X) &&
                MathUtils.FLOAT_EQUALS(previousPosition.Y, mousePosition.Y))
            {
                mouseWaiting = true;
            }
            else mouseWaiting = false;
            leftButtonPressed = Mouse.GetState().LeftButton == ButtonState.Pressed;
        }

        public static void updateSource(float rotation){
            Vector2 v = new Vector2(0,1.3f);
            v = Vector2.Transform(v, Matrix.CreateRotationZ(-rotation));
            mouseSource = mousePosition - v;
        }

    }
}
