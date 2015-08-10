using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebirth {
    public static class GameManager {

        public static UserSettings userSettings;
        public static GlobalVariables globalVariables;
        public static Game1 game;

        public static void initialize(Game1 g){
            GameManager.game = g;
        }

        public static void gameOver(){
            Game1.currentScreen = Game1.ScreenID.menu;
            GameManager.game.getWorld().unLoad();
        }

    }
}
