#if EDITOR
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

        int lastTabIndex = 0;

        Vector2 lastScreenShift;
        Vector2 lastMousePosition;
        Vector2 mouseSelectedObjectOffset;
        Vector2 mouseScreenShiftOffset;

        bool wasMouseClicked = false;

        #region cameraSettings
        public void adjustCamera(SceneContainer sc){
            if (sc == gameEditor.SceneManagerView){
                DisplayManager.screenShift.X = -50;
                DisplayManager.screenShift.Y = -100;
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

        private void Zoom(float delta){
            /*if (DisplayManager.WorldWidth < delta/3){
                Zoom(delta/3);
            }
            else {*/
                DisplayManager.WorldWidth += delta;//*DisplayManager.WorldWidth/10f;
                DisplayManager.screenShift -= new Vector2(delta/2);
            //}
        }

        public void updateScreenShift(){
            DisplayManager.screenShift = lastScreenShift - (MouseManager.mousePosition - lastMousePosition);
        }
        #endregion

        #region Initialization
        public LevelEditor() {
            InitializeComponent();
            InitializeExtra();
        }

        private void InitializeExtra(){
            foreach (string s in Enum.GetNames(typeof(Enumerations.ObjectTypes))) this.comboBoxObjectList.Items.Add(s);
            this.gameBox.MouseWheel += gameBox_MouseWheel;
        }

        public void startEditor(){
            gameEditor = new Editor();
            gameEntry.getWorld().loadScene(gameEditor.SceneManagerView);
            adjustCamera(gameEditor.SceneManagerView);
            DisplayManager.followPlayer = false;
        }
        #endregion

        #region tabControls
        public void addSceneTab(SceneContainer c){
            tabControlContainer.TabPages.Add(gameEditor.containerManager.getName(c.id));
            gameEditor.addContainerToNextTab(c.id);
            tabControlContainer.SelectedIndex = tabControlContainer.TabCount - 1; //this line triggers SelectedIndexChanged event
        }

        private void tabControlContainer_SelectedIndexChanged(object sender, EventArgs e) {
            int index = tabControlContainer.SelectedIndex;
            if (lastTabIndex != 0){
                gameEntry.getWorld().saveScene();
            }
            if (index == 0){
                buttonInsertObject.Enabled = false;
                gameEntry.getWorld().leaveInsertMode();
                gameEntry.getWorld().loadScene(gameEditor.SceneManagerView);
                adjustCamera(gameEditor.SceneManagerView);
            } else {
                buttonInsertObject.Enabled = true;
                SceneContainer scene = LoadManager.Load(gameEditor.getContainerInTab(index));
                scene.remakeObjectsTree();
                gameEntry.getWorld().loadScene(scene);
                adjustCamera(scene);
            }
        }
        #endregion

        private void LevelEditor_Resize(object sender, EventArgs e) {
            
        }

        private void containerToolStripMenuItem_Click(object sender, EventArgs e) {
            addSceneTab(gameEditor.newContainer());    
        }

        private void LevelEditor_FormClosed(object sender, FormClosedEventArgs e) {
            gameEntry.Exit();
        }

        private void buttonPlay_Click(object sender, EventArgs e) {
            if (editMode) gameEntry.getWorld().leaveEditMode();
            else gameEntry.getWorld().editMode();
            editMode = !editMode;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void comboBoxObjectList_SelectedIndexChanged(object sender, EventArgs e) {
            GameWorld gameWorld = gameEntry.getWorld();
            if (gameWorld.insertPermit){
                gameEntry.getWorld().insertMode((Enumerations.ObjectTypes)comboBoxObjectList.SelectedIndex);
            }
        }

        #region gameBoxEvents

        private void gameBox_Resize(object sender, EventArgs e) {
            
        }

        private void gameBox_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left){
                gameEntry.getWorld().transformSelectedObject();
                MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(PictureBox.MousePosition.X - gameBox.Left, PictureBox.MousePosition.Y - gameBox.Top));
                wasMouseClicked = false;
            }
        }

        private void gameBox_DoubleClick(object sender, EventArgs e) {
            int index = tabControlContainer.SelectedIndex;
            if (index == 0){
                int id = gameEditor.containerManager.positionID(MouseManager.mousePosition);
                if (id != -1){
                    int tab = gameEditor.getTab(id);
                    if (tab == -1){
                        addSceneTab(LoadManager.Load(id));
                    }
                    else this.tabControlContainer.SelectedIndex = tab;
                }
            }
        }
     
        private void gameBox_MouseEnter(object sender, EventArgs e) {
            this.gameBox.Focus();
            MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(PictureBox.MousePosition.X - gameBox.Left, PictureBox.MousePosition.Y - gameBox.Top));
        }

        private void gameBox_MouseMove(object sender, MouseEventArgs e) {
            GameObject selectedObject = gameEntry.getWorld().selectedObject;
            MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(PictureBox.MousePosition.X - gameBox.Left, PictureBox.MousePosition.Y - gameBox.Top));
            if (wasMouseClicked) {
                if (selectedObject != null){
                    switch (gameEntry.getWorld().selectionTransformType){
                        case GameWorld.SelectionTransformType.Move:
                            selectedObject.Position = MouseManager.mousePosition - mouseSelectedObjectOffset;
                            break;
                        case GameWorld.SelectionTransformType.ExtendUp:
                            if (MouseManager.mousePosition.Y >= selectedObject.BoundingBox.y)
                                selectedObject.BoundingBox.height = MouseManager.mousePosition.Y - selectedObject.BoundingBox.y;
                            else selectedObject.BoundingBox.height = 0;
                            break;
                        case GameWorld.SelectionTransformType.ExtendDown:
                            float top = selectedObject.BoundingBox.y + selectedObject.BoundingBox.height;
                            if (MouseManager.mousePosition.Y <= top){
                                selectedObject.BoundingBox.y = MouseManager.mousePosition.Y;
                                selectedObject.BoundingBox.height = top - selectedObject.BoundingBox.y;
                            }
                            else {
                                selectedObject.BoundingBox.height = 0;
                                selectedObject.BoundingBox.y = top;
                            }
                            break;
                        case GameWorld.SelectionTransformType.ExtendRight:
                            if (MouseManager.mousePosition.X >= selectedObject.BoundingBox.x)
                                selectedObject.BoundingBox.width = MouseManager.mousePosition.X - selectedObject.BoundingBox.x;
                            else selectedObject.BoundingBox.width = 0;
                            break;
                        case GameWorld.SelectionTransformType.ExtendLeft:
                            float right = selectedObject.BoundingBox.x + selectedObject.BoundingBox.width;
                            if (MouseManager.mousePosition.X <= right){
                                selectedObject.BoundingBox.x = MouseManager.mousePosition.X;
                                selectedObject.BoundingBox.width = right - selectedObject.BoundingBox.x;
                            }
                            else {
                                selectedObject.BoundingBox.width = 0;
                                selectedObject.BoundingBox.x = right;
                            }
                            break;
                    }
                }
                else {
                    updateScreenShift();
                }
            }
            else if (selectedObject != null) {
                if (selectedObject.getTopContact().intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNS;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendUp;
                } else if (selectedObject.getDownContact().intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNS;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendDown;
                } else if (selectedObject.getRightContact().intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeWE;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendRight;
                } else if (selectedObject.getLeftContact().intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeWE;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendLeft;
                }else if (selectedObject.BoundingBox.intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeAll;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.Move;
                }
                else {
                    gameBox.Cursor = Cursors.Arrow;                    
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.None;
                }
            }
            else {
                gameBox.Cursor = Cursors.Arrow;
                gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.None;
            }
        }

        private void gameBox_MouseLeave(object sender, EventArgs e) {
            MouseManager.mousePosition = DisplayManager.screenShift - new Vector2(1000,1000);
        }

        private void gameBox_Click(object sender, EventArgs e) {
            gameBox.Focus();
            GameWorld gameWorld = gameEntry.getWorld();
            RectangleF auxShape;
            if (gameWorld.isInInsertMode()){
                if (gameWorld.insertPermit){
                    gameWorld.createObject((Enumerations.ObjectTypes)comboBoxObjectList.SelectedIndex);
                }
            }
            else {
                GameObject g = gameWorld.selectedObject;
                gameWorld.selectedObject = gameWorld.objectAt(MouseManager.mousePosition);
                if (gameWorld.selectedObject != null && g != gameWorld.selectedObject){
                    auxShape = gameWorld.selectedObject.BoundingBox;
                    gameWorld.boundingBoxBackup.set(auxShape.Center, auxShape.width, auxShape.height);
                }
            }
        }

        private void gameBox_MouseDown(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left){
                if (!wasMouseClicked){
                    GameObject selectedObject = gameEntry.getWorld().selectedObject;
                    wasMouseClicked = true;
                    lastMousePosition = MouseManager.mousePosition;
                    lastScreenShift = DisplayManager.screenShift;
                    if (selectedObject != null){
                        
                        if (selectedObject.BoundingBox.intersects(MouseManager.mousePosition)){
                            mouseSelectedObjectOffset = MouseManager.mousePosition - selectedObject.Position;
                        }
                    }
                }
            } else {
                if (e.Button == MouseButtons.Right){
                    gameEntry.getWorld().leaveInsertMode();
                }
            }
        }
        
        private void gameBox_MouseWheel(object sender, MouseEventArgs e){
            Zoom(e.Delta);
        }

        #endregion

    }
}
#endif