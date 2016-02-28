#if EDITOR

using System.Windows.Forms;
using System;

namespace Rebirth.EditorClasses {
    public class PropertiesItem:UserControl {
        Panel property;
        TextBox fieldName;
        Control fieldValue;

        public PropertiesItem(int width, String name, Control fieldStyle){
            property = new Panel();
            fieldName = new TextBox();
            fieldValue = fieldStyle;
            this.Width = 0;

            fieldName.Text = name;

            property.AutoSize = false;
            fieldValue.AutoSize = false;
            fieldName.AutoSize = false;
            
            //set height
            this.Height = Properties.DefaultItemHeight;
            property.Height = Properties.DefaultItemHeight;
            fieldName.Height = Properties.DefaultItemHeight-1;
            fieldValue.Height = Properties.DefaultItemHeight-1;

            //Build objects tree
            property.Controls.Add(fieldName);
            property.Controls.Add(fieldValue);

            //Set resize event
            this.Resize += new System.EventHandler(this.propertyItem_Resize);

            //resize
            this.Width = width;

            fieldName.Visible = true;
            fieldValue.Visible = true;
            property.Visible = true;
        }

        private void propertyItem_Resize(object sender, EventArgs e) {
            property.Width = this.Width;
            fieldName.Width = (this.Width-3)/2;
            fieldValue.Width = this.Width - fieldName.Width - 3;
        }

    }
}

#endif