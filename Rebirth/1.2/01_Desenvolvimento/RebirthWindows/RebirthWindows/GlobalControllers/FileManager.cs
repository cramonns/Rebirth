using System;
using System.IO;

namespace Rebirth {
    public static class FileManager {


#if EDITOR
        public static String tabs(int level){
            switch (level){
                case 0: return "";
                case 1: return "\t"; 
                case 2: return "\t\t";
                case 3: return "\t\t\t";
                case 4: return "\t\t\t\t";
                case 5: return "\t\t\t\t\t";
                case 6: return "\t\t\t\t\t\t";
                case 7: return "\t\t\t\t\t\t\t";
                case 8: return "\t\t\t\t\t\t\t\t";
                case 9: return "\t\t\t\t\t\t\t\t\t";
                case 10: return "\t\t\t\t\t\t\t\t\t\t";
                default:
                    String aux = "";
                    int test = level/2;
                    for (int i = 0; i < test; i++){
                        aux += "\t\t";
                    }
                    if ((level&1) == 1){
                        aux += "\t";
                    }
                    return aux;
            }
        }

        public static String instanceName(GameObject g){
            if (g is Ground) return "Ground";
            if (g is Box) return "Box";
            if (g is Canon) return "Canon";
            if (g is TextureLoader) return "TextureLoader";
            if (g is Trigger) return "Trigger";
            return "GameObject";
        }

#endif
    }
}
