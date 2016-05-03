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
using My_Explorer;

namespace Rebirth.EditorClasses {
    public partial class LevelEditor : Form {
        
        RectangleF auxBoundingBox = null;

        public Game1 gameEntry;

        //public Editor gameEditor;
        public Project gameProject;

        public GameObjectForm objectForm;

        bool editMode = true;

        int lastTabIndex = 0;

        Vector2 lastScreenShift;
        Vector2 lastMousePosition;
        Vector2 mouseSelectedObjectOffset;
        Vector2 mouseScreenShiftOffset;

        bool wasMouseClicked = false;

        public RectangleF getTopContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x + 2*worldPixel, boundingBox.y - worldPixel + boundingBox.height,boundingBox.width - 4*worldPixel,3*worldPixel);
        }

        public RectangleF getDownContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x + 2*worldPixel, boundingBox.y - worldPixel,boundingBox.width - 4*worldPixel,3*worldPixel);
        }

        public RectangleF getRightContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x + boundingBox.width - worldPixel, boundingBox.y + 2*worldPixel, 3*worldPixel, boundingBox.height - 4*worldPixel);
        }

        public RectangleF getLeftContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x - worldPixel, boundingBox.y + 2*worldPixel, 3*worldPixel, boundingBox.height - 4*worldPixel);
        }

        public RectangleF getTopLeftContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x - worldPixel, boundingBox.y - worldPixel + boundingBox.height,3*worldPixel,3*worldPixel);
        }

        public RectangleF getTopRightContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x - worldPixel + boundingBox.width, boundingBox.y - worldPixel + boundingBox.height,3*worldPixel,3*worldPixel);
        }

        public RectangleF getDownLeftContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x - worldPixel, boundingBox.y - worldPixel,3*worldPixel,3*worldPixel);
        }

        public RectangleF getDownRightContact(RectangleF boundingBox){
            float worldPixel = DisplayManager.ToWorldLength(1);
            return new RectangleF(boundingBox.x - worldPixel + boundingBox.width, boundingBox.y - worldPixel,3*worldPixel,3*worldPixel);
        }

        private void setContainerOperationsAvaiability(bool state){
            buttonInsertObject.Enabled = state;
            //buttonSave.Enabled = state;
            //buttonTHolders.Enabled = state;
        }

        private void enableContainerOperations(){
            setContainerOperationsAvaiability(true);
        }

        private void disableCointainerOperations(){
            setContainerOperationsAvaiability(false);
        }

        #region Functionalities
        
        public void newScene(){
            addSceneTab(gameProject.gameEditor.newContainer(gameProject));
        }

        public void saveCurrentScene(){
            int index = tabControlContainer.SelectedIndex;
            if (index > 0){
                gameProject.gameEditor.saveContainer(gameEntry.getWorld().currentContainer(), gameProject);
                gameProject.Save();
            }
        }

        public void buildCurrentScene(){
            int index = tabControlContainer.SelectedIndex;
            if (index > 0){
                gameProject.gameEditor.buildContainer(gameEntry.getWorld().currentContainer());
                gameProject.Save();
            }
        }

        public void createProject(string name, string path){
            gameProject = new Project(name, path);
            startEditor();
        }

        public void openProject(){
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gameProject = Project.Open(openFileDialog1.FileName);
                startEditor(gameProject.DirectoryPath);
            }
            else {
                //openFileDialog1.Dispose();
            }
        }

        public void newProject(){
            FormNewProject fmp = new FormNewProject();
            fmp.Caller = this;
            fmp.Show();
        }
        #endregion

        #region cameraSettings
        public void adjustCamera(SceneContainer sc){
            if (sc == gameProject.gameEditor.SceneManagerView){
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
            float multiplier = -0.001f;
            multiplier *= delta;
            Vector2 mp = new Vector2(MouseManager.mousePosition.X, MouseManager.mousePosition.Y);
            DisplayManager.WorldWidth *= (1f + multiplier);
            MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(PictureBox.MousePosition.X - gameBox.Left, PictureBox.MousePosition.Y - gameBox.Top));
            DisplayManager.screenShift += mp - MouseManager.mousePosition;
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

        public void startEditor(string path = ""){
            gameProject.gameEditor = new Editor(path);
            gameEntry.getWorld().loadScene(gameProject.gameEditor.SceneManagerView, gameProject);
            adjustCamera(gameProject.gameEditor.SceneManagerView);
            DisplayManager.followPlayer = false;
        }
        #endregion

        #region tabControls
        public void addSceneTab(SceneContainer c){
            tabControlContainer.TabPages.Add(gameProject.gameEditor.containerManager.getName(c.id));
            gameProject.gameEditor.addContainerToNextTab(c.id);
            tabControlContainer.SelectedIndex = tabControlContainer.TabCount - 1; //this line triggers SelectedIndexChanged event
        }

        private void tabControlContainer_SelectedIndexChanged(object sender, EventArgs e) {
            gameEntry.getWorld().selectedObject = null;
            int index = tabControlContainer.SelectedIndex;
            if (lastTabIndex != 0){
                gameEntry.getWorld().saveScene(gameProject);
            }
            if (index == 0){
                disableCointainerOperations();
                gameEntry.getWorld().leaveInsertMode();
                gameEntry.getWorld().loadScene(gameProject.gameEditor.SceneManagerView, gameProject);
                adjustCamera(gameProject.gameEditor.SceneManagerView);
            } else {
                enableContainerOperations();
                //SceneContainer scene = LoadManager.Load(gameEditor.getContainerInTab(index));
                SceneContainer scene = XMLManager.Load(gameProject.gameEditor.getContainerInTab(index),gameProject);
                scene.remakeObjectsTree();
                gameEntry.getWorld().loadScene(scene, gameProject);
                adjustCamera(scene);
            }
        }
        #endregion

        private void LevelEditor_Resize(object sender, EventArgs e) {
            
        }

        private void containerToolStripMenuItem_Click(object sender, EventArgs e) {
            newScene();
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
            saveCurrentScene();
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
            DisplayManager.DisplayHeight = gameBox.Height;
            DisplayManager.DisplayWidth = gameBox.Width;
        }

        private void gameBox_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left){
                gameEntry.getWorld().transformScene();
                gameEntry.getWorld().transformSelectedObject();
                MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(PictureBox.MousePosition.X - gameBox.Left, PictureBox.MousePosition.Y - gameBox.Top));
                wasMouseClicked = false;
            }
        }

        private void gameBox_DoubleClick(object sender, EventArgs e) {
            int index = tabControlContainer.SelectedIndex;
            if (index == 0){
                int id = gameProject.gameEditor.containerManager.positionID(MouseManager.mousePosition);
                if (id != -1){
                    int tab = gameProject.gameEditor.getTab(id);
                    if (tab == -1){
                        //addSceneTab(LoadManager.Load(id));
                        addSceneTab(XMLManager.Load(id,gameProject));
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
            MouseManager.mousePosition = DisplayManager.worldPosition(new Vector2(e.Location.X, e.Location.Y));
            if (wasMouseClicked){
                if (auxBoundingBox != null){
                    switch (gameEntry.getWorld().selectionTransformType){
                        case GameWorld.SelectionTransformType.Move:
                            selectedObject.Position = MouseManager.mousePosition - mouseSelectedObjectOffset;
                            break;
                        case GameWorld.SelectionTransformType.ExtendUp:
                            auxBoundingBox.extendUp();
                            break;
                        case GameWorld.SelectionTransformType.ExtendDown:
                            auxBoundingBox.extendDown();
                            break;
                        case GameWorld.SelectionTransformType.ExtendRight:
                            auxBoundingBox.extendRight();
                            break;
                        case GameWorld.SelectionTransformType.ExtendLeft:
                            auxBoundingBox.extendLeft();
                            break;
                        case GameWorld.SelectionTransformType.ExtendTopLeft:
                            auxBoundingBox.extendUp();
                            auxBoundingBox.extendLeft();
                            break;
                        case GameWorld.SelectionTransformType.ExtendTopRight:
                            auxBoundingBox.extendUp();
                            auxBoundingBox.extendRight();
                            break;
                        case GameWorld.SelectionTransformType.ExtendDownLeft:
                            auxBoundingBox.extendDown();
                            auxBoundingBox.extendLeft();
                            break;
                        case GameWorld.SelectionTransformType.ExtendDownRight:
                            auxBoundingBox.extendDown();
                            auxBoundingBox.extendRight();
                            break;
                    }
                }
                else {
                    updateScreenShift();
                }
            }
            else { 
                if (gameProject == null) return;
                if (selectedObject != null) {
                    auxBoundingBox = selectedObject.BoundingBox;
                } else auxBoundingBox = gameEntry.getWorld().currentContainer().Shape;
                if (getTopContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNS;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendUp;
                } else if (getDownContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNS;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendDown;
                } else if (getRightContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeWE;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendRight;
                } else if (getLeftContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeWE;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendLeft;
                } else if (getTopLeftContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNWSE;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendTopLeft;
                } else if (getTopRightContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNESW;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendTopRight;
                } else if (getDownLeftContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNESW;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendDownLeft;
                } else if (getDownRightContact(auxBoundingBox).intersects(MouseManager.mousePosition)){
                    gameBox.Cursor = Cursors.SizeNWSE;
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.ExtendDownRight;
                }else if (auxBoundingBox.intersects(MouseManager.mousePosition)){
                    if (selectedObject != null){
                        gameBox.Cursor = Cursors.SizeAll;
                        gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.Move;
                    }
                    else {
                        gameBox.Cursor = Cursors.Arrow;
                        gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.None;
                        auxBoundingBox = null;
                    }
                }
                else {
                    gameBox.Cursor = Cursors.Arrow;                     
                    gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.None;
                    auxBoundingBox = null;
                }
            }
            /*else {
                gameBox.Cursor = Cursors.Arrow;
                gameEntry.getWorld().selectionTransformType = GameWorld.SelectionTransformType.None;
            }*/
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
                //GameObject g = gameWorld.selectedObject;
                if (objectForm != null) {
                    objectForm.Close();
                    objectForm = null;
                }
                gameWorld.selectedObject = gameWorld.objectAt(MouseManager.mousePosition);
                if (gameWorld.selectedObject != null){
                    objectForm = new GameObjectForm(gameWorld.selectedObject);
                    objectForm.Show();
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

        private void buttonTHolders_Click(object sender, EventArgs e) {
            SceneContainer c = gameEntry.getWorld().currentContainer();
            FormTextureHolders formTextureHolders = new FormTextureHolders(c, gameProject.gameEditor.containerManager.getName(c.id), gameProject);
            formTextureHolders.Show();
        }

        private void containToolStripMenuItem_Click(object sender, EventArgs e) {
            newProject();
            /*
            Explorer formExp = new Explorer();
            formExp.Show();
            */
        }

        private void buildProjectToolStripMenuItem_Click(object sender, EventArgs e) {
            gameProject.build();
        }

        private void buildContainerToolStripMenuItem_Click(object sender, EventArgs e) {
            buildCurrentScene();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e) {
            saveCurrentScene();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e) {
            openProject();
        }

        private void containerToolStripMenuItem_Click_1(object sender, EventArgs e) {
            newScene();
        }
        
        private void highLightOn(object sender, EventArgs e){

            (sender as PictureBox).BackColor = System.Drawing.Color.LightGoldenrodYellow;
        }

        private void highlight_Off(object sender, EventArgs e){
            (sender as PictureBox).BackColor = System.Drawing.Color.LightGray;
        }

        private void pbBtnNewProject_Click(object sender, EventArgs e) {
            newProject();
        }

        private void pbBtnNewScene_Click(object sender, EventArgs e) {
            newScene();
        }

        private void pbBtnOpenProject_Click(object sender, EventArgs e) {
            openProject();
        }

        private void pbBtnSaveScene_Click(object sender, EventArgs e) {
            saveCurrentScene();
        }

    }
}
#endif