#if EDITOR
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace Rebirth.EditorClasses {

    [Serializable]
    struct NameRelation{
        public string name;
        public int ID;
    }

    [Serializable] 
    public class Project {

        #region Attributes
        private string _name;
        private string _directory;
        private List<NameRelation> _scene_name_relations;
        [NonSerialized]
        public Editor gameEditor;
        #endregion

        #region Contructors
        public Project(string name, string path){
            if (!(path.EndsWith("/") || path.EndsWith("\\"))){
                path += "\\";
            }
            _name = name;
            _directory = path + name;
            _scene_name_relations = new List<NameRelation>();
        }
        #endregion

        #region Properties
        public string DirectoryPath{
            get {return _directory;}
        }
        #endregion

        #region Methods
        public void Save(){
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(_directory+"/"+_name+".rlep", FileMode.Create, FileAccess.Write, FileShare.None) ){
                binFormat.Serialize(fStream, this);
            }
        }

        public static Project Open(string path){
            Project newProject;
            BinaryFormatter binFormat = new BinaryFormatter();
            using ( Stream fStream = File.OpenRead(path) ){
                newProject = (Project)binFormat.Deserialize(fStream);
            }
            newProject.gameEditor = new Editor(newProject._directory);
            return newProject;
        }

        public void Build(){
            gameEditor.buildAll(this);
            Save();
        }
        #endregion

    }

}
#endif