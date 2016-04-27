using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Rebirth.EditorClasses;

namespace Rebirth {

    [Serializable]
    class ContainerProperties{
        public float width, height, y;
        public string name;
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

#if EDITOR
        public void addContainer(SceneContainer sc, Project gameProject){
            ContainerProperties cp = new ContainerProperties();
            cp.width = sc.Width;
            cp.height = sc.Height;
            cp.y = sc.Y;
            cp.id = sc.id;
            cp.name = "Container_"+sc.id.ToString();
            sc.previousScene = lastContainerID;
            if (containers.Count == 0){
                startPositionX = sc.X;
                firstContainerID = sc.id;
            }
            else{
                //SceneContainer prevScene = LoadManager.Load(lastContainerID);
                SceneContainer prevScene = XMLManager.Load(lastContainerID, gameProject);
                prevScene.nextScene = sc.id;
                prevScene.save(gameProject);
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

        public void updateContainer(SceneContainer sc, Project gameProject = null){
            int index = IdIndexes[sc.id];
            ContainerProperties cp = containers[index];
            if (firstContainerID == sc.id){
                startPositionX = sc.X;
            }
            if (cp.width != sc.Width) {
                float extension = sc.Width - cp.width;
                cp.width = sc.Width;
                for (index++; index < containers.Count; index++ ){
                    if (gameProject != null){
                        SceneContainer scene = XMLManager.Load(containers[index].id, gameProject);
                        scene.shiftHorizontal(extension);                
                        scene.save(gameProject);
                    }
                    else {
                        SceneContainer scene = LoadManager.Load(containers[index].id);
                        if (scene != null){
                            scene.shiftHorizontal(extension);                
                            scene.build();
                        }
                    }
                }
            }
            cp.height = sc.Height;
            cp.y = sc.Y;
        }

        public void saveAll(Project gameProject){
            foreach (ContainerProperties cp in containers){
                SceneContainer sc = XMLManager.Load(cp.id, gameProject);
                sc.save(gameProject);
                updateContainer(sc);
            }
        }

        public void buildAll(Project gameProject){
            foreach (ContainerProperties cp in containers){
                SceneContainer sc = XMLManager.Load(cp.id, gameProject);
                sc.build();
                updateContainer(sc);
            }
        }

        public void saveContainerManager(Project gameProject){
            BinaryFormatter binFormat = new BinaryFormatter();
            string path = gameProject.DirectoryPath + "/Lvl/Containers.info";
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None) ){
                binFormat.Serialize(fStream, this);
            }
        }

        public void buildContainerManager(){
            BinaryFormatter binFormat = new BinaryFormatter();
            string path = "/Lvl/Containers.info";
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None) ){
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
#endif

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

        public string getName(int id){
            int index = IdIndexes[id];
            return containers[index].name;
        }

        

    }
}
