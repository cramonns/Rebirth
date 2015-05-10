using System;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth {
    public class LoadManager {

        TextureManager tm;
        VideoManager vm;

        public LoadManager(TextureManager tm, VideoManager vm){
            this.tm = tm;
            this.vm = vm;
        }

        public void Update(SceneContainer[] scenes, int preloadAmount, Vector2 playerPosition){
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

        public SceneContainer Load(int id){
            BinaryFormatter binFormat = new BinaryFormatter();
            string fileName = "Lvl/" + id.ToString() + ".scn";
            using(Stream fStream = File.OpenRead(fileName)){
                return (SceneContainer)binFormat.Deserialize(fStream);
            }
        }

        public void LoadObjects(SceneContainer scene){
            foreach (GameObject o in scene.objects) {
				o.Load(tm);
			}
        }

        public ContainerManager loadContainerManager(){
            BinaryFormatter binFormat = new BinaryFormatter();
            string path = "Lvl/Containers.info";
            using ( Stream fStream = File.OpenRead(path) ){
                return (ContainerManager)binFormat.Deserialize(fStream);
            }
        }

    }
}
