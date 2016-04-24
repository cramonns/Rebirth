using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Rebirth.EditorClasses {

    [Serializable] 
    public class Project {

        private string _name;
        private string _directory;
        [NonSerialized]
        public Editor gameEditor;

        public Project(string name, string path){
            if (!path.EndsWith("/")){
                path += "/";
            }
            _name = name;
            _directory = path + name;
            gameEditor = new Editor(_directory);
        }

        public string DirectoryPath{
            get {return _directory;}
        }

        public void Save(){
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(_directory, FileMode.Create, FileAccess.Write, FileShare.None) ){
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

    }
}
