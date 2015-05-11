using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

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

        public void startEditor(){
            gameEditor = new Editor();
            gameEntry.getWorld().loadScene(gameEditor.SceneManagerView);
            adjustCamera(gameEditor.SceneManagerView);
            DisplayManager.followPlayer = false;
        }
        


        public void adjustCamera(SceneContainer sc){
            if (sc == gameEditor.SceneManagerView){
                DisplayManager.screenShift.X = -50;
                DisplayManager.screenShift.Y = -200;
                DisplayManager.WorldWidth = 300;
            }
            else {
                if (sc.Width >= sc.Height){
                    DisplayManager.WorldWidth = sc.Width*1.1f;
                    DisplayManager.screenShift.X = sc.X - sc.Width*0.05f;
                    DisplayManager.screenShift.Y = sc.Y - (DisplayManager.ToWorldLength(DisplayManager.DisplayHeight) - sc.Height)/2;
                }
                else {
                    DisplayManager.WorldWidth = sc.Width*1.1f;
                    DisplayManager.screenShift.X = sc.X - 50;
                    DisplayManager.screenShift.Y = sc.Y - sc.Height*0.05f;
                }
            }
        }

        private void LevelEditor_Resize(object sender, EventArgs e) {
            
        }

        private void containerToolStripMenuItem_Click(object sender, EventArgs e) {
            SceneContainer c = gameEditor.newContainer();
            tabControlContainer.TabPages.Add(c.Name);
            gameEditor.addContainerToNextTab(c.ID);
            tabControlContainer.SelectedIndex++;
            gameEntry.getWorld().loadScene(c);
            gameEntry.loadCurrentScreen();
            adjustCamera(c);
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
            if (index == 0){
                buttonInsertObject.Enabled = false;
                gameEntry.getWorld().leaveInsertMode();
                gameEntry.getWorld().loadScene(gameEditor.SceneManagerView);
                adjustCamera(gameEditor.SceneManagerView);
            } else {
                buttonInsertObject.Enabled = true;
                gameEntry.getWorld().loadScene(gameEditor.getContainerInTab(index));
            }
        }

        private void containerToolStripMenuItem1_Click(object sender, EventArgs e) {
            int index = tabControlContainer.SelectedIndex;
            if (index > 0){
                gameEditor.saveContainer(gameEntry.getWorld().currentContainer());
            }
        }

        private void buttonInsertObject_Click(object sender, EventArgs e) {
            gameEntry.getWorld().insertMode((Enumerations.ObjectTypes)comboBoxObjectList.SelectedIndex);
        }

        private void gameBox_MouseEnter(object sender, EventArgs e) {
            this.gameBox.Focus();
            MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(PictureBox.MousePosition.X - gameBox.Left, PictureBox.MousePosition.Y - gameBox.Top));
        }

        private void gameBox_MouseMove(object sender, MouseEventArgs e) {
            MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(PictureBox.MousePosition.X - gameBox.Left, PictureBox.MousePosition.Y - gameBox.Top));
        }

        private void gameBox_MouseLeave(object sender, EventArgs e) {
            MouseManager.mousePosition = DisplayManager.screenShift - new Vector2(1000,1000);
        }

        private void gameBox_Click(object sender, EventArgs e) {
            GameWorld gameWorld = gameEntry.getWorld();
            if (gameWorld.insertPermit){
                gameWorld.createObject((Enumerations.ObjectTypes)comboBoxObjectList.SelectedIndex);
            }
        }

        private void gameBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left){
                
            } else {
                if (e.Button == MouseButtons.Right){
                    gameEntry.getWorld().leaveInsertMode();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        
    }
}
