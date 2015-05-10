using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rebirth {
    public partial class LevelEditor : Form {
        
        public Game1 gameEntry;

        public Editor gameEditor;

        bool editMode = true;

        public LevelEditor() {
            InitializeComponent();
            InitializeExtra();
        }

        private void InitializeExtra(){
            foreach (string s in Enum.GetNames(typeof(Enumerations.ObjectTypes))) this.comboBoxObjectList.Items.Add(s);
        }

        private void LevelEditor_Resize(object sender, EventArgs e) {
            /*gameBox.Height = this.Height - 31;
            gameEntry.getScreenManager().DisplayHeight = (float)gameBox.Height;
            gameEntry.getScreenManager().DisplayWidth = (float)gameBox.Width;*/
        }

        private void containerToolStripMenuItem_Click(object sender, EventArgs e) {
            SceneContainer c = gameEditor.newContainer();
            gameEntry.getWorld().loadScene(c);
            gameEntry.loadCurrentScreen();
            tabControlContainer.TabPages.Add(c.Name);
            gameEditor.addContainerToNextTab(c.ID);
            tabControlContainer.SelectedIndex++;
        }

        private void LevelEditor_FormClosed(object sender, FormClosedEventArgs e) {
            gameEntry.Exit();
        }

        private void buttonPlay_Click(object sender, EventArgs e) {
            if (editMode) gameEntry.getWorld().leaveEditMode();
            else gameEntry.getWorld().editMode();
            editMode = !editMode;
        }

        private void tabControlContainer_SelectedIndexChanged(object sender, EventArgs e) {
            int index = tabControlContainer.SelectedIndex;
            gameEditor.getContainerInTab(index);

        }

        private void containerToolStripMenuItem1_Click(object sender, EventArgs e) {
            int index = tabControlContainer.SelectedIndex;
            if (index > 0){
                gameEditor.saveContainer(gameEntry.getWorld().currentContainer());
            }
        }
        
    }
}
