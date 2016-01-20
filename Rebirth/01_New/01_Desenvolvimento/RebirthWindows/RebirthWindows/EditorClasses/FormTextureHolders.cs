#if EDITOR
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rebirth {
    public partial class FormTextureHolders : Form {
        
        SceneContainer container;

        public FormTextureHolders(SceneContainer sc, string containerName) {
            InitializeComponent();
            container = sc; 
            labelContainerName.Text = containerName;
            checkedListBox1.Items.Clear();
            foreach (string s in Enum.GetNames(typeof(TextureManager.TextureID))){
                checkedListBox1.Items.Add(s);
            }
            foreach (TextureManager.TextureID th in sc.textureHolders){
                checkedListBox1.SetItemChecked((int)th,true);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            foreach (int i in checkedListBox1.CheckedIndices){
                checkedListBox1.SetItemChecked(i,false);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            container.textureHolders.Clear();
            foreach (int i in checkedListBox1.CheckedIndices){
                container.textureHolders.AddFirst((TextureManager.TextureID)i);
            }
            container.save();
            Close();
        }

    }
}
#endif