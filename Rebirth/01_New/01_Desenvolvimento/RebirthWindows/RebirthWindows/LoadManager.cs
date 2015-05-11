using System;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth {
    public static class LoadManager {

        public static void Update(SceneContainer[] scenes, int preloadAmount, Vector2 playerPosition){
            int playerPosID = 0;
            if (scenes[preloadAmount] == null){
                scenes[preloadAmount] = Load(playerPosID);
                LoadObjects(scenes[preloadAmount]);
                for (int i = preloadAmount - 1, auxId = scenes[preloadAmount].PreviousScene; i >= 0 && auxId != -1; i--, auxId = scenes[i].PreviousScene){
                    scenes[i] = Load(auxId);
                    LoadObjects(scenes[i]);
                }
                for (int i = preloadAmount + 1, auxId = scenes[preloadAmount].NextScene; i < preloadAmount*2+1 && auxId != -1; i++, auxId = scenes[i].NextScene){
                    scenes[i] = Load(auxId);
                    LoadObjects(scenes[i]);
                }
            }
        }

        public static SceneContainer Load(int id){
            BinaryFormatter binFormat = new BinaryFormatter();
            string fileName = "Lvl/" + id.ToString() + ".scn";
            using(Stream fStream = File.OpenRead(fileName)){
                return (SceneContainer)binFormat.Deserialize(fStream);
            }
        }

        public static void LoadObjects(SceneContainer scene){
            foreach (GameObject o in scene.objects) {
				o.Load();
			}
        }

    }
}
