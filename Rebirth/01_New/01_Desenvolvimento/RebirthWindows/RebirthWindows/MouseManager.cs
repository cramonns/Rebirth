using System;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public static class MouseManager {
        public static bool leftButtonPressed;

        private static float mousePositionX;
        private static float mousePositionY;

        public static Vector2 mousePosition{
            get {return new Vector2(mousePositionX, mousePositionY);}
            set {
                mousePositionX = value.X;
                mousePositionY = value.Y;
            }
        }

        public static void Update(){
            leftButtonPressed = false;
        }

    }
}
