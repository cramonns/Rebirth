#if EDITOR
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace Rebirth.EditorClasses {
    public class Properties:UserControl {
        public static int DefaultItemHeight{
            get {return 20;}
        }

        public Properties(){
            //Set resize event
            this.Resize += new System.EventHandler(this.properties_Resize);

            this.AutoSize = false;
            this.Width = 50;
            this.Height = 25;
            this.Visible = true;
        }

        public void AddItem(PropertiesItem pItem){
            if (this.Controls.Count == 0){
                pItem.Top = 1;
            }
            else {
                pItem.Top = DefaultItemHeight*Controls.Count + 1;
            }
            this.Controls.Add(pItem);
        }

        private void properties_Resize(object sender, EventArgs e) {
            foreach (PropertiesItem pi in Controls){
                pi.Width = this.Width;
            }
        }

    }
}

#endif