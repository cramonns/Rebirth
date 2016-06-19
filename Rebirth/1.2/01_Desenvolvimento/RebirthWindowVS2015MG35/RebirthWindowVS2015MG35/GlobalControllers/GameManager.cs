namespace Rebirth
{
    public static class GameManager {

        public static UserSettings userSettings;
        public static GlobalVariables globalVariables;
        public static Game1 game;
        private static bool updated = false;

        public static void initialize(Game1 g){
            GameManager.game = g;
            globalVariables = new GlobalVariables();
        }

        public static void gameOver(){
            Game1.currentScreen = Game1.ScreenID.menu;
            GameManager.game.getWorld().unLoad();
        }

        public static void addObjectToScene(GameObject g){
            game.getWorld().currentContainer().objects.AddFirst(g); 
            updated = true;
        }

        public static void removeObjectFromScene(GameObject g){
            game.getWorld().currentContainer().objects.Remove(g);
            updated = true;
        }

        public static void removeObject(GameObject g){
            game.getWorld().removeObject(g);
            updated = true;
        }

        public static bool wasUpdated(){
            bool returnValue = updated;
            updated = false;
            return returnValue;
        }

    }
}
