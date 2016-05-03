#if EDITOR
using System;
namespace Rebirth.EditorClasses {
    partial class LevelEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.gameBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxObjects = new System.Windows.Forms.GroupBox();
            this.buttonInsertObject = new System.Windows.Forms.Button();
            this.labelSelectObject = new System.Windows.Forms.Label();
            this.comboBoxObjectList = new System.Windows.Forms.ComboBox();
            this.tabControlContainer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildContainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pbBtnSaveScene = new System.Windows.Forms.PictureBox();
            this.pbBtnOpenProject = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbBtnNewScene = new System.Windows.Forms.PictureBox();
            this.pbBtnNewProject = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxObjects.SuspendLayout();
            this.tabControlContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSaveScene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnOpenProject)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnNewScene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnNewProject)).BeginInit();
            this.SuspendLayout();
            // 
            // gameBox
            // 
            this.gameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gameBox.Location = new System.Drawing.Point(197, 93);
            this.gameBox.Name = "gameBox";
            this.gameBox.Size = new System.Drawing.Size(712, 461);
            this.gameBox.TabIndex = 0;
            this.gameBox.TabStop = false;
            this.gameBox.Click += new System.EventHandler(this.gameBox_Click);
            this.gameBox.DoubleClick += new System.EventHandler(this.gameBox_DoubleClick);
            this.gameBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gameBox_MouseDown);
            this.gameBox.MouseEnter += new System.EventHandler(this.gameBox_MouseEnter);
            this.gameBox.MouseLeave += new System.EventHandler(this.gameBox_MouseLeave);
            this.gameBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gameBox_MouseMove);
            this.gameBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gameBox_MouseUp);
            this.gameBox.Resize += new System.EventHandler(this.gameBox_Resize);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.groupBoxObjects);
            this.panel1.Location = new System.Drawing.Point(1, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 486);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxObjects
            // 
            this.groupBoxObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxObjects.Controls.Add(this.buttonInsertObject);
            this.groupBoxObjects.Controls.Add(this.labelSelectObject);
            this.groupBoxObjects.Controls.Add(this.comboBoxObjectList);
            this.groupBoxObjects.Location = new System.Drawing.Point(3, 3);
            this.groupBoxObjects.Name = "groupBoxObjects";
            this.groupBoxObjects.Size = new System.Drawing.Size(184, 480);
            this.groupBoxObjects.TabIndex = 2;
            this.groupBoxObjects.TabStop = false;
            this.groupBoxObjects.Text = "Objects";
            // 
            // buttonInsertObject
            // 
            this.buttonInsertObject.Enabled = false;
            this.buttonInsertObject.Location = new System.Drawing.Point(50, 85);
            this.buttonInsertObject.Name = "buttonInsertObject";
            this.buttonInsertObject.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertObject.TabIndex = 3;
            this.buttonInsertObject.Text = "Insert";
            this.buttonInsertObject.UseVisualStyleBackColor = true;
            this.buttonInsertObject.Click += new System.EventHandler(this.buttonInsertObject_Click);
            // 
            // labelSelectObject
            // 
            this.labelSelectObject.AutoSize = true;
            this.labelSelectObject.Location = new System.Drawing.Point(8, 30);
            this.labelSelectObject.Name = "labelSelectObject";
            this.labelSelectObject.Size = new System.Drawing.Size(40, 13);
            this.labelSelectObject.TabIndex = 1;
            this.labelSelectObject.Text = "Select:";
            // 
            // comboBoxObjectList
            // 
            this.comboBoxObjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObjectList.FormattingEnabled = true;
            this.comboBoxObjectList.Location = new System.Drawing.Point(6, 49);
            this.comboBoxObjectList.Name = "comboBoxObjectList";
            this.comboBoxObjectList.Size = new System.Drawing.Size(172, 21);
            this.comboBoxObjectList.TabIndex = 0;
            this.comboBoxObjectList.SelectedIndexChanged += new System.EventHandler(this.comboBoxObjectList_SelectedIndexChanged);
            // 
            // tabControlContainer
            // 
            this.tabControlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlContainer.Controls.Add(this.tabPage1);
            this.tabControlContainer.Location = new System.Drawing.Point(197, 68);
            this.tabControlContainer.Name = "tabControlContainer";
            this.tabControlContainer.SelectedIndex = 0;
            this.tabControlContainer.Size = new System.Drawing.Size(715, 26);
            this.tabControlContainer.TabIndex = 2;
            this.tabControlContainer.SelectedIndexChanged += new System.EventHandler(this.tabControlContainer_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ContainerView";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(909, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.containToolStripMenuItem,
            this.containerToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // containToolStripMenuItem
            // 
            this.containToolStripMenuItem.Name = "containToolStripMenuItem";
            this.containToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.containToolStripMenuItem.Text = "Project";
            this.containToolStripMenuItem.Click += new System.EventHandler(this.containToolStripMenuItem_Click);
            // 
            // containerToolStripMenuItem
            // 
            this.containerToolStripMenuItem.Name = "containerToolStripMenuItem";
            this.containerToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.containerToolStripMenuItem.Text = "Scene";
            this.containerToolStripMenuItem.Click += new System.EventHandler(this.containerToolStripMenuItem_Click_1);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 6);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildProjectToolStripMenuItem,
            this.buildContainerToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildProjectToolStripMenuItem
            // 
            this.buildProjectToolStripMenuItem.Name = "buildProjectToolStripMenuItem";
            this.buildProjectToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.buildProjectToolStripMenuItem.Text = "Project";
            this.buildProjectToolStripMenuItem.Click += new System.EventHandler(this.buildProjectToolStripMenuItem_Click);
            // 
            // buildContainerToolStripMenuItem
            // 
            this.buildContainerToolStripMenuItem.Name = "buildContainerToolStripMenuItem";
            this.buildContainerToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.buildContainerToolStripMenuItem.Text = "Scene";
            this.buildContainerToolStripMenuItem.Click += new System.EventHandler(this.buildContainerToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.pbBtnSaveScene);
            this.panel2.Controls.Add(this.pbBtnOpenProject);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pbBtnNewScene);
            this.panel2.Controls.Add(this.pbBtnNewProject);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 38);
            this.panel2.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(151, 1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1, 34);
            this.panel7.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(170, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1, 38);
            this.panel8.TabIndex = 3;
            // 
            // pbBtnSaveScene
            // 
            this.pbBtnSaveScene.BackColor = System.Drawing.Color.LightGray;
            this.pbBtnSaveScene.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBtnSaveScene.BackgroundImage")));
            this.pbBtnSaveScene.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBtnSaveScene.Location = new System.Drawing.Point(114, 1);
            this.pbBtnSaveScene.Name = "pbBtnSaveScene";
            this.pbBtnSaveScene.Size = new System.Drawing.Size(32, 32);
            this.pbBtnSaveScene.TabIndex = 4;
            this.pbBtnSaveScene.TabStop = false;
            this.pbBtnSaveScene.Click += new System.EventHandler(this.pbBtnSaveScene_Click);
            this.pbBtnSaveScene.MouseEnter += new System.EventHandler(this.highLightOn);
            this.pbBtnSaveScene.MouseLeave += new System.EventHandler(this.highlight_Off);
            // 
            // pbBtnOpenProject
            // 
            this.pbBtnOpenProject.BackColor = System.Drawing.Color.LightGray;
            this.pbBtnOpenProject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBtnOpenProject.BackgroundImage")));
            this.pbBtnOpenProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBtnOpenProject.Location = new System.Drawing.Point(79, 1);
            this.pbBtnOpenProject.Name = "pbBtnOpenProject";
            this.pbBtnOpenProject.Size = new System.Drawing.Size(32, 32);
            this.pbBtnOpenProject.TabIndex = 3;
            this.pbBtnOpenProject.TabStop = false;
            this.pbBtnOpenProject.Click += new System.EventHandler(this.pbBtnOpenProject_Click);
            this.pbBtnOpenProject.MouseEnter += new System.EventHandler(this.highLightOn);
            this.pbBtnOpenProject.MouseLeave += new System.EventHandler(this.highlight_Off);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(74, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 34);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(0, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 34);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(170, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 38);
            this.panel6.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(170, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 38);
            this.panel4.TabIndex = 3;
            // 
            // pbBtnNewScene
            // 
            this.pbBtnNewScene.BackColor = System.Drawing.Color.LightGray;
            this.pbBtnNewScene.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBtnNewScene.BackgroundImage")));
            this.pbBtnNewScene.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBtnNewScene.Location = new System.Drawing.Point(38, 1);
            this.pbBtnNewScene.Name = "pbBtnNewScene";
            this.pbBtnNewScene.Size = new System.Drawing.Size(32, 32);
            this.pbBtnNewScene.TabIndex = 1;
            this.pbBtnNewScene.TabStop = false;
            this.pbBtnNewScene.Click += new System.EventHandler(this.pbBtnNewScene_Click);
            this.pbBtnNewScene.MouseEnter += new System.EventHandler(this.highLightOn);
            this.pbBtnNewScene.MouseLeave += new System.EventHandler(this.highlight_Off);
            // 
            // pbBtnNewProject
            // 
            this.pbBtnNewProject.BackColor = System.Drawing.Color.LightGray;
            this.pbBtnNewProject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBtnNewProject.BackgroundImage")));
            this.pbBtnNewProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBtnNewProject.Location = new System.Drawing.Point(3, 1);
            this.pbBtnNewProject.Name = "pbBtnNewProject";
            this.pbBtnNewProject.Size = new System.Drawing.Size(32, 32);
            this.pbBtnNewProject.TabIndex = 0;
            this.pbBtnNewProject.TabStop = false;
            this.pbBtnNewProject.Click += new System.EventHandler(this.pbBtnNewProject_Click);
            this.pbBtnNewProject.MouseEnter += new System.EventHandler(this.highLightOn);
            this.pbBtnNewProject.MouseLeave += new System.EventHandler(this.highlight_Off);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Rebirth Level Editor Project (*.rlep)|*.rlep";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 558);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControlContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gameBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelEditor_FormClosed);
            this.Resize += new System.EventHandler(this.LevelEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxObjects.ResumeLayout(false);
            this.groupBoxObjects.PerformLayout();
            this.tabControlContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSaveScene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnOpenProject)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnNewScene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnNewProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox gameBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxObjects;
        private System.Windows.Forms.TabControl tabControlContainer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBoxObjectList;
        private System.Windows.Forms.Label labelSelectObject;
        private System.Windows.Forms.Button buttonInsertObject;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem buildProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buildContainerToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbBtnNewScene;
        private System.Windows.Forms.PictureBox pbBtnNewProject;
        private System.Windows.Forms.PictureBox pbBtnOpenProject;
        private System.Windows.Forms.PictureBox pbBtnSaveScene;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
#endif