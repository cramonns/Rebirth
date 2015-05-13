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

        public ContainerManager containerManager{
            get {return cm;}
        }

        List<int> containerTab;

        public Editor(){
            cm = LoadManager.LoadContainerManager();
            scm = new SceneContainerManager(cm);
            containerTab = new List<int>();
            containerTab.Add(-1);
        }

        public SceneContainer newContainer(){
            SceneContainer sc = new SceneContainer(new RectangleF(cm.newPosition(), 40, 20), cm.lastContainerID+1);
            cm.addContainer(sc);
            sc.save();
            cm.saveContainerManager();
            return sc;
        }

        public int getContainerInTab(int tabIndex){
            return containerTab[tabIndex];
        }

        public void addContainerToNextTab(int containerID){
            containerTab.Add(containerID);
        }

        public void saveContainer(SceneContainer sc){
            sc.save();
            if (cm.firstContainerID == sc.ID){
                cm.startPositionX = sc.X;
            }
            cm.saveContainerManager();
        }

        public SceneContainer SceneManagerView{
            get {return scm;}
        }

    }
}
