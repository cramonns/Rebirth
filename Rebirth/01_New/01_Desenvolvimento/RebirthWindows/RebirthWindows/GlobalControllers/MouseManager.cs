#if EDITOR
using System;
using Microsoft.Xna.Framework;

namespace Rebirth {
    public static class MouseManager {
        public static bool leftButtonPressed;

        public static Vector2 mousePosition = new Vector2(-1000,-1000);

        /*public static Vector2 mousePosition{
            get {return new Vector2(mousePositionX, mousePositionY);}
            set {
                mousePositionX = value.X;
                mousePositionY = value.Y;
            }
        }*/

        public static void Update(){
            leftButtonPressed = false;
        }

    }
}
#endif