using System.Text;
using System.IO;
using System;

namespace Rebirth {
    public static class XMLManager {

        public static string tabs(int level){
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
                    StringBuilder aux = new StringBuilder("");
                    int test = level/2;
                    for (int i = 0; i < test; i++){
                        aux.Append("\t\t");
                    }
                    if ((level&1) == 1){
                        aux.Append("\t");
                    }
                    return aux.ToString();
            }
        }

        public static string instanceName(GameObject g){
            if (g is Ground) return "Ground";
            if (g is Box) return "Box";
            if (g is Canon) return "Canon";
            if (g is TextureLoader) return "TextureLoader";
            if (g is Trigger) return "Trigger";
            return "GameObject";
        }

        public static void saveXML(SceneContainer sc){
            int level = 0;
            string fileName = "Lvl/XML/" + sc.id.ToString() + ".xml";
            if (!Directory.Exists("Lvl/XML")){
                Directory.CreateDirectory("Lvl/XML");
            }
            StreamWriter xmlStream = new StreamWriter(fileName);
            StringBuilder openingTag = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmlStream.WriteLine(XMLManager.tabs(level) + openingTag.ToString());
            openingTag.Clear();
            openingTag.Append("<SceneContainer");
            openingTag.Append(" id=\"" + sc.id.ToString());
            openingTag.Append("\" previousScene=\""); 
            openingTag.Append(sc.previousScene.ToString());
            openingTag.Append("\" nextScene=\""); 
            openingTag.Append(sc.nextScene.ToString());
            openingTag.Append("\" Y=\""); 
            openingTag.Append(sc.Shape.y.ToString());
            openingTag.Append("\" Width=\""); 
            openingTag.Append(sc.Shape.width.ToString());
            openingTag.Append("\" Height=\""); 
            openingTag.Append(sc.Shape.height.ToString());
            openingTag.Append(">");
            xmlStream.WriteLine(XMLManager.tabs(level) + openingTag);
            level++;
                if (sc.objects != null && sc.objects.Count > 0){
                    xmlStream.WriteLine(XMLManager.tabs(level) + "<Objects>");
                    level++;
                        foreach (GameObject g in sc.objects){
                            saveXML(g, level, xmlStream);
                        }
                    level--;
                    xmlStream.WriteLine(tabs(level) + "</Objects>");
                }
            level--;
            xmlStream.WriteLine("</SceneContainer>");
            xmlStream.Close();
        }

        private static void saveXML(GameObject g, int level, StreamWriter xmlStream){
            
            StringBuilder currentTag = new StringBuilder(XMLManager.tabs(level));

            //atributes
            currentTag.Append("<");
            currentTag.Append(XMLManager.instanceName(g));
            currentTag.Append(" x=\"");
            currentTag.Append(g.X);
            currentTag.Append("\" y=\"");
            currentTag.Append(g.Y);
            currentTag.Append("\" width=\"");
            currentTag.Append(g.Width);
            currentTag.Append("\" height=\"");
            currentTag.Append(g.Height);
            currentTag.Append("\" textureId=\"");
            currentTag.Append(Enum.GetNames(typeof(TextureManager.TextureID))[(int)g.textureId]);

            if (g is MoveableObject){
                currentTag.Append("\" speedX=\"");
                currentTag.Append((g as MoveableObject).speed.X);
                currentTag.Append("\" speedY=\"");
                currentTag.Append((g as MoveableObject).speed.Y);
                
                if (g is Canon){
                    currentTag.Append("\" fireRate=\"");
                    currentTag.Append((g as Canon).fireRate);
                }

            }

            currentTag.Append("\">");

            xmlStream.WriteLine(currentTag.ToString());
            
            level++;
                
            level--;
            xmlStream.WriteLine(XMLManager.tabs(level) + "</"+XMLManager.instanceName(g)+">");
        }

        


    }
}
