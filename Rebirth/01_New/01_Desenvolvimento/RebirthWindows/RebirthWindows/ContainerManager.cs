using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Rebirth {

    [Serializable]
    struct ContainerProperties{
        public float width, height, y;
        public int id;
    }

    [Serializable]
    public class ContainerManager {
        
        List<ContainerProperties> containers;
        public float startPositionX = 0;
        public int lastContainerID;
        public int firstContainerID;

        [NonSerialized]
        public Texture2D texture;

        [NonSerialized]
        public int[] IdIndexes;

        public ContainerManager(){
            firstContainerID = -1;
            lastContainerID = -1;
            containers = new List<ContainerProperties>();
            texture = TextureManager.load(TextureManager.TextureID.container);
        }

        public void addContainer(SceneContainer sc){
            ContainerProperties cp;
            cp.width = sc.Width;
            cp.height = sc.Height;
            cp.y = sc.Y;
            cp.id = sc.ID;
            sc.PreviousScene = lastContainerID;
            if (containers.Count == 0){
                startPositionX = sc.X;
                firstContainerID = sc.ID;
            }
            else{
                SceneContainer prevScene = LoadManager.Load(lastContainerID);
                prevScene.NextScene = sc.ID;
                prevScene.save();
            }
            containers.Add(cp);
            lastContainerID++;
        }

/*        public void addContainerAfter(SceneContainer sc, int index){
            ContainerProperties cp;
            cp.width = sc.Width;
            cp.height = sc.Height;
            cp.y = sc.Y;
            containers.Insert(index, cp);
            if (seqID.Count == 0){
                
            }
        }*/

        public void saveContainerManager(){
            BinaryFormatter binFormat = new BinaryFormatter();
            string path = "Lvl/Containers.info";
            using ( Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None) ){
                binFormat.Serialize(fStream, this);
            }
        }

        public void Draw(SpriteBatch sb){
            float x = startPositionX;
            foreach (ContainerProperties cp in containers){
                sb.Draw(texture, DisplayManager.scaleTexture(new Vector2(x, cp.y), cp.width, cp.height), Color.White);
                x += cp.width;
            }
        }

        public Vector2 newPosition(){
            float x = startPositionX;
            foreach (ContainerProperties cp in containers){
                x += cp.width;
            }
            return new Vector2(x,0);
        }

        private ContainerProperties getContainerProperties(int id){
            int index = IdIndexes[id];
            if (index == -1) return containers[id];
            else return containers[index];
        }

        public int positionID(float px){
            float x = startPositionX;
            int selectedId = containers[firstContainerID].id;
            if (px < x) return selectedId;
            ContainerProperties cp;
            int count = containers.Count;
            for (int i = 0; i < count; i++){
                cp = containers[i];
                if (px > x){
                    selectedId = cp.id;
                }
                else break;
                x += cp.width;
            }
            return selectedId;
        }

        public int positionID(Vector2 position){
            int selectedId = positionID(position.X);
            ContainerProperties cp = getContainerProperties(selectedId);
            cp = containers[selectedId];
            if (position.Y > cp.y && position.Y < cp.y + cp.height)
                return selectedId;
            else return -1;
        }

        public void LoadIdIndexes(){
            IdIndexes = new int[lastContainerID+1];
            for (int i = 0; i < lastContainerID; i++){
                IdIndexes[i] = -1;
            }
            for (int i = 0; i < containers.Count; i++){
                IdIndexes[containers[i].id] = i;
            }
        }

    }
}
