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
    }

    [Serializable]
    public class ContainerManager {
        
        List<ContainerProperties> containers;
        float startPositionX = 0;
        public int lastContainerID;

        [NonSerialized]
        public Texture2D texture;

        List<int> seqID;

        public ContainerManager(){
            lastContainerID = -1;
            seqID = new List<int>();
            containers = new List<ContainerProperties>();
            texture = TextureManager.load(TextureManager.TextureID.container);
        }

        public void addContainer(SceneContainer sc){
            ContainerProperties cp;
            cp.width = sc.Width;
            cp.height = sc.Height;
            cp.y = sc.Y;
            containers.Add(cp);
            if (seqID.Count == 0){
                startPositionX = sc.X;
            }
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

    }
}
