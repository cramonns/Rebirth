#if EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth.EditorClasses {

    public class Editor{

        ContainerManager cm;
        SceneContainerManager scm;

        public ContainerManager containerManager{
            get {return cm;}
        }

        List<int> containerTab;

        public Editor(string projectDirectory = ""){
            cm = LoadManager.LoadContainerManager(projectDirectory);
            scm = new SceneContainerManager(cm);
            containerTab = new List<int>();
            containerTab.Add(-1);
        }

        public SceneContainer newContainer(Project gameProject){
            SceneContainer sc = new SceneContainer(new RectangleF(cm.newPosition(), 40, 20), cm.lastContainerID+1);
            cm.addContainer(sc, gameProject);
            cm.LoadIdIndexes();
            sc.save(gameProject);
            cm.saveContainerManager(gameProject);
            return sc;
        }

        public int getContainerInTab(int tabIndex){
            return containerTab[tabIndex];
        }

        public void addContainerToNextTab(int containerID){
            containerTab.Add(containerID);
        }

        public void saveContainer(SceneContainer sc, Project gameProject){
            sc.save(gameProject);
            cm.updateContainer(sc, gameProject);
            cm.saveContainerManager(gameProject);
        }

        public void buildContainer(SceneContainer sc){
            sc.build();
            cm.updateContainer(sc);
            cm.buildContainerManager();
        }

        public void saveAll(Project gameProject){
            cm.saveAll(gameProject);
            cm.saveContainerManager(gameProject);
        }

        public void buildAll(Project gameProject){
            cm.buildAll(gameProject);
            cm.buildContainerManager();
        }

        public SceneContainer SceneManagerView{
            get {return scm;}
        }

        public int getTab(int id){
            for (int i = 0; i < containerTab.Count; i++){
                if (containerTab[i] == id) return i;
            }
            return -1;
        }

    }
}
#endif
