using System;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth {
    public static class LoadManager {

        private static ContainerManager cm;

        private static void moveScenesLeft(SceneContainer[] scenes, int preloadAmount){
            int count = scenes.Length-1;
            int i;
            
            //Save the old scene to unload it later
            //The old scene must be unloaded only when the new scene has already been loaded
            SceneContainer aux = scenes[0];
            
            for (i = 0; i < count; i++){
                scenes[i] = scenes[i+1];
            }
            if (scenes[i-1] != null){
                count = scenes[i-1].nextScene;
                if (count != -1) scenes[i] = Load(count);
                else scenes[i] = null;
            }
            if (aux != null) aux.unLoad();
        }

        private static void moveScenesRight(SceneContainer[] scenes, int preloadAmount){
            int count = scenes.Length-1;
            
            //Save the old scene to unload it later
            //The old scene must be unloaded only when the new scene has already been loaded
            SceneContainer aux = scenes[count];

            for (int i = count; i > 0; i--){
                scenes[i] = scenes[i-1];
            }
            if (scenes[1] != null){
                count = scenes[1].previousScene;
                if (count != -1) scenes[0] = Load(count);
                else scenes[0] = null;
            }
            if (aux != null) aux.unLoad();
        }

        public static bool Update(SceneContainer[] scenes, int preloadAmount, Vector2 playerPosition){
            bool updated = false;
            int playerPosID = cm.positionID(playerPosition);
            if (playerPosID == -1) {
                GameManager.gameOver();
                return true;
            }
            if (scenes[preloadAmount] == null){
                updated = true;
                scenes[preloadAmount] = Load(playerPosID);
                for (int i = preloadAmount - 1, auxId = scenes[preloadAmount].previousScene; i >= 0 && auxId != -1; auxId = scenes[i].previousScene, i--){
                    scenes[i] = Load(auxId);
                }
                for (int i = preloadAmount + 1, auxId = scenes[preloadAmount].nextScene; i < preloadAmount*2+1 && auxId != -1; auxId = scenes[i].nextScene, i++){
                    scenes[i] = Load(auxId);
                }
            }
            else {
                if (playerPosID > scenes[preloadAmount].id){
                    updated = true;
                    while (playerPosID > scenes[preloadAmount].id){
                        moveScenesLeft(scenes, preloadAmount);
                    }
                }
                else {
                    if (playerPosID < scenes[preloadAmount].id){
                        updated = true;
                        while (playerPosID < scenes[preloadAmount].id){
                            moveScenesRight(scenes, preloadAmount);
                        }
                    }
                }
            }
            return updated;
        }

        public static SceneContainer Load(int id){
            SceneContainer loadedScene;
            BinaryFormatter binFormat = new BinaryFormatter();
            string fileName = "Lvl/" + id.ToString() + ".scn";
            using(Stream fStream = File.OpenRead(fileName)){
                loadedScene = (SceneContainer)binFormat.Deserialize(fStream);
            }
            foreach (GameObject g in loadedScene.objects){
                g.X += loadedScene.X;
                g.Y += loadedScene.Y;
                g.Load();
            }
            foreach (TextureHolder th in loadedScene.textureHolders){
                th.load();
            }
            return loadedScene;
        }

        public static void LoadObjects(SceneContainer scene){
            foreach (GameObject o in scene.objects) {
				o.Load();
			}
        }

        public static ContainerManager LoadContainerManager(){
            if (File.Exists("Lvl/Containers.info")){
                BinaryFormatter binFormat = new BinaryFormatter();
                string path = "Lvl/Containers.info";
                using ( Stream fStream = File.OpenRead(path) ){
                    cm = (ContainerManager)binFormat.Deserialize(fStream);
                }
                cm.texture = TextureManager.load(TextureManager.TextureID.container);
            } else cm = new ContainerManager();
            cm.LoadIdIndexes();
            return cm;
        }

    }
}
