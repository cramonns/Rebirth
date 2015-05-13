﻿using System;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth {
    public static class LoadManager {

        private static ContainerManager cm;

        private static void moveScenesLeft(SceneContainer[] scenes, int preloadAmount){
            int count = scenes.Length-1;
            int i;
            if (scenes[0] != null){
                scenes[0].unLoad();
            }
            for (i = 0; i < count; i++){
                scenes[i] = scenes[i+1];
            }
            if (scenes[i-1] != null){
                count = scenes[i-1].NextScene;
                if (count != -1) scenes[i] = Load(count);
            }
            else scenes[i] = null;
        }

        private static void moveScenesRight(SceneContainer[] scenes, int preloadAmount){
            
        }

        public static void Update(SceneContainer[] scenes, int preloadAmount, Vector2 playerPosition){
            int playerPosID = cm.positionID(playerPosition);
            if (scenes[preloadAmount] == null){
                scenes[preloadAmount] = Load(playerPosID);
                //LoadObjects(scenes[preloadAmount]);
                for (int i = preloadAmount - 1, auxId = scenes[preloadAmount].PreviousScene; i >= 0 && auxId != -1; auxId = scenes[i].PreviousScene, i--){
                    scenes[i] = Load(auxId);
                    //LoadObjects(scenes[i]);
                }
                for (int i = preloadAmount + 1, auxId = scenes[preloadAmount].NextScene; i < preloadAmount*2+1 && auxId != -1; auxId = scenes[i].NextScene, i++){
                    scenes[i] = Load(auxId);
                    //LoadObjects(scenes[i]);
                }
            }
            else {
                if (playerPosID > scenes[preloadAmount].ID){
                    while (playerPosID > scenes[preloadAmount].ID){
                        moveScenesLeft(scenes, preloadAmount);
                    }
                }
                else {
                    if (playerPosID < scenes[preloadAmount].ID){
                        while (playerPosID < scenes[preloadAmount].ID){
                            moveScenesRight(scenes, preloadAmount);
                        }
                    }
                }
            }
        }

        public static SceneContainer Load(int id){
            SceneContainer loadedScene;
            BinaryFormatter binFormat = new BinaryFormatter();
            string fileName = "Lvl/" + id.ToString() + ".scn";
            using(Stream fStream = File.OpenRead(fileName)){
                loadedScene = (SceneContainer)binFormat.Deserialize(fStream);
            }
            foreach (GameObject g in loadedScene.objects){
                g.Load();
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
            return cm;
        }

    }
}