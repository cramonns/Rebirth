using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth {
    public class Editor{

        ContainerManager cm;
        SceneContainerManager scm;

        List<int> containerTab;

        public Editor(){
            if (File.Exists("Lvl/Containers.info")){
                BinaryFormatter binFormat = new BinaryFormatter();
                string path = "Lvl/Containers.info";
                using ( Stream fStream = File.OpenRead(path) ){
                    cm = (ContainerManager)binFormat.Deserialize(fStream);
                }
                cm.texture = TextureManager.load(TextureManager.TextureID.container);
            } else cm = new ContainerManager();
            scm = new SceneContainerManager(cm);
            containerTab = new List<int>();
            containerTab.Add(-1);
        }

        private Vector2 newPosition(){
            float newX = 0;
            if (cm.lastContainerID == -1) newX = 0;
            return new Vector2(newX, 0);
        }

        public SceneContainer newContainer(){
            SceneContainer sc = new SceneContainer(new RectangleF(newPosition(), 40, 20), cm.lastContainerID+1);
            cm.addContainer(sc);
            return sc;
        }

        public int getContainerInTab(int tabIndex){
            return containerTab[tabIndex];
        }

        public void addContainerToNextTab(int containerID){
            containerTab.Add(containerID);
        }

        public void saveContainer(SceneContainer sc){
            BinaryFormatter binFormat = new BinaryFormatter();
            string fileName = "Lvl/" + sc.ID.ToString() + ".scn";
            if (!Directory.Exists("Lvl")){
                Directory.CreateDirectory("Lvl");
            }
            using(Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)){
                binFormat.Serialize(fStream, sc);
            }
            cm.lastContainerID++;
            cm.saveContainerManager();
        }

        public SceneContainer SceneManagerView{
            get {return scm;}
        }

    }
}
