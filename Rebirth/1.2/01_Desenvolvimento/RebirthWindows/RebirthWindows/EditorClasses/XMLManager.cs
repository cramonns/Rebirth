using System.Text;
using System.IO;
using System;
using System.Xml.Linq;
using System.Collections.Generic;

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
            if (g is GameTrigger) return "Trigger";
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
            openingTag.Append("\" y=\""); 
            openingTag.Append(sc.Shape.y.ToString());
            openingTag.Append("\" width=\""); 
            openingTag.Append(sc.Shape.width.ToString());
            openingTag.Append("\" height=\""); 
            openingTag.Append(sc.Shape.height.ToString());
            openingTag.Append("\">");
            xmlStream.WriteLine(tabs(level) + openingTag.ToString());
            level++;
                if (sc.objects != null && sc.objects.Count > 0){
                    xmlStream.WriteLine(tabs(level) + "<Objects>");
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
            
            bool subTree = false;
            StringBuilder currentTag = new StringBuilder(XMLManager.tabs(level));

            //atributes
            currentTag.Append("<");
            currentTag.Append(instanceName(g));
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
                else if (g is LogicalObject) {
                    currentTag.Append("\" collideEvent=\"");
                    currentTag.Append(Enum.GetNames(typeof(LogicalObject.Treatment))[(int)(g as LogicalObject).treatment]);
                    
                    if (g is GameTrigger){
                        currentTag.Append("\" onEnter=\"");
                        currentTag.Append(Enum.GetNames(typeof(LogicalObject.Treatment))[(int)(g as GameTrigger).enterTreatment]);
                        currentTag.Append("\" onLeave=\"");
                        currentTag.Append(Enum.GetNames(typeof(LogicalObject.Treatment))[(int)(g as GameTrigger).leaveTreatment]);
                    }
                }
            }

            xmlStream.Write(currentTag.ToString());
            currentTag.Clear();

            level++;
                if (g.colliders != null){
                    xmlStream.Write("\">\n");
                    subTree = true;
                    xmlStream.WriteLine(tabs(level) + "<Colliders>");
                    level++;
                    foreach (RectangleF c in g.colliders){
                        currentTag.Append(tabs(level));
                        currentTag.Append("<Collider x=\"");
                        currentTag.Append(c.x);
                        currentTag.Append("\" y=\"");
                        currentTag.Append(c.y);
                        currentTag.Append("\" width=\"");
                        currentTag.Append(c.width);
                        currentTag.Append("\" height=\"");
                        currentTag.Append(c.height);
                        currentTag.Append("\"/>");
                        xmlStream.WriteLine(currentTag.ToString());
                    }
                    level--;
                    xmlStream.WriteLine(tabs(level) + "</Colliders>");
                }
            level--;
            if (subTree) xmlStream.WriteLine(tabs(level) + "</"+ instanceName(g)+">");
            else xmlStream.WriteLine("\"/>");
        }

        public static SceneContainer Load(int id){
            XElement xSC;
            SceneContainer loadedScene;
            float y = 0, width = 40, height = 20;
            int nextScene = -1, previousScene = -1;
            string fileName = "Lvl/XML/" + id.ToString() + ".xml";
            xSC = XElement.Load(fileName);
            LinkedList<GameObject> objects = new LinkedList<GameObject>();

            nextScene = int.Parse(xSC.Attribute("nextScene").Value);
            previousScene = int.Parse(xSC.Attribute("previousScene").Value);
            loadedScene =  new SceneContainer(new RectangleF(0,y,width,height), nextScene, previousScene);
            loadedScene.id = id;
            foreach (XElement x in xSC.Elements()){
                switch (x.Name.ToString()){
                    case "Objects":
                        foreach (XElement xGameObject in x.Elements()){
                            objects.AddFirst(loadFromXElement(xGameObject));
                        }
                        break;
                    case "TextureHolders":
                        break;
                }
            }
            loadedScene.objects = objects;
            foreach (GameObject g in loadedScene.objects){
                g.X += loadedScene.X;
                g.Load();
            }
            foreach (TextureManager.TextureID th in loadedScene.textureHolders){
                TextureManager.load(th);
            }
            LoadManager.includePlayerModifications(loadedScene);
            return loadedScene;
        }

        private static GameObject loadFromXElement(XElement xObj){
            GameObject newObj = null;
            switch (xObj.Name.ToString()){
                case "Canon":
                    newObj = new Canon();
                    (newObj as Canon).fireRate = int.Parse(xObj.Attribute("fireRate").Value);
                    goto case "MoveableObject";
                case "Box":
                    newObj = new Box();
                    goto case "MoveableObject";
                case "MoveableObject":
                    (newObj as MoveableObject).speed.X = float.Parse(xObj.Attribute("speedX").Value);
                    (newObj as MoveableObject).speed.Y = float.Parse(xObj.Attribute("speedY").Value);
                    goto case "GameObject";
                case "Ground":
                    newObj = new Ground();
                    goto case "GameObject";
                case "GameObject":
                    (newObj as GameObject).X = float.Parse(xObj.Attribute("x").Value);
                    (newObj as GameObject).Y = float.Parse(xObj.Attribute("y").Value);
                    (newObj as GameObject).Width = float.Parse(xObj.Attribute("width").Value);
                    (newObj as GameObject).Height = float.Parse(xObj.Attribute("height").Value);
                    (newObj as GameObject).textureId = 
                        (TextureManager.TextureID)Enum.Parse(
                            typeof(TextureManager.TextureID),
                            xObj.Attribute("textureId").Value
                            );
                    break;
            }

            return newObj;
        }


    }

    
}
