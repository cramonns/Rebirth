using System;
namespace Rebirth {
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
            this.groupBoxTest = new System.Windows.Forms.GroupBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.groupBoxObjects = new System.Windows.Forms.GroupBox();
            this.labelSelectObject = new System.Windows.Forms.Label();
            this.comboBoxObjectList = new System.Windows.Forms.ComboBox();
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlContainer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonInsertObject = new System.Windows.Forms.Button();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxTest.SuspendLayout();
            this.groupBoxObjects.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameBox
            // 
            this.gameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gameBox.Location = new System.Drawing.Point(197, 27);
            this.gameBox.Name = "gameBox";
            this.gameBox.Size = new System.Drawing.Size(712, 531);
            this.gameBox.TabIndex = 0;
            this.gameBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.groupBoxTest);
            this.panel1.Controls.Add(this.groupBoxObjects);
            this.panel1.Controls.Add(this.groupBoxContainer);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 558);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxTest
            // 
            this.groupBoxTest.Controls.Add(this.buttonPlay);
            this.groupBoxTest.Location = new System.Drawing.Point(9, 175);
            this.groupBoxTest.Name = "groupBoxTest";
            this.groupBoxTest.Size = new System.Drawing.Size(178, 68);
            this.groupBoxTest.TabIndex = 2;
            this.groupBoxTest.TabStop = false;
            this.groupBoxTest.Text = "Test";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(14, 24);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(30, 30);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // groupBoxObjects
            // 
            this.groupBoxObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxObjects.Controls.Add(this.buttonInsertObject);
            this.groupBoxObjects.Controls.Add(this.labelSelectObject);
            this.groupBoxObjects.Controls.Add(this.comboBoxObjectList);
            this.groupBoxObjects.Location = new System.Drawing.Point(3, 249);
            this.groupBoxObjects.Name = "groupBoxObjects";
            this.groupBoxObjects.Size = new System.Drawing.Size(184, 306);
            this.groupBoxObjects.TabIndex = 2;
            this.groupBoxObjects.TabStop = false;
            this.groupBoxObjects.Text = "Objects";
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
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxContainer.Location = new System.Drawing.Point(3, 27);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(184, 141);
            this.groupBoxContainer.TabIndex = 1;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "Container";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(190, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.containerToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // containerToolStripMenuItem
            // 
            this.containerToolStripMenuItem.Name = "containerToolStripMenuItem";
            this.containerToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.containerToolStripMenuItem.Text = "Container";
            this.containerToolStripMenuItem.Click += new System.EventHandler(this.containerToolStripMenuItem_Click);
            // 
            // tabControlContainer
            // 
            this.tabControlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlContainer.Controls.Add(this.tabPage1);
            this.tabControlContainer.Location = new System.Drawing.Point(197, 0);
            this.tabControlContainer.Name = "tabControlContainer";
            this.tabControlContainer.SelectedIndex = 0;
            this.tabControlContainer.Size = new System.Drawing.Size(712, 26);
            this.tabControlContainer.TabIndex = 2;
            this.tabControlContainer.SelectedIndexChanged += new System.EventHandler(this.tabControlContainer_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(704, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ContainerView";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.containerToolStripMenuItem1});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // containerToolStripMenuItem1
            // 
            this.containerToolStripMenuItem1.Name = "containerToolStripMenuItem1";
            this.containerToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.containerToolStripMenuItem1.Text = "Container";
            this.containerToolStripMenuItem1.Click += new System.EventHandler(this.containerToolStripMenuItem1_Click);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 558);
            this.Controls.Add(this.tabControlContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gameBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelEditor_FormClosed);
            this.Resize += new System.EventHandler(this.LevelEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxTest.ResumeLayout(false);
            this.groupBoxObjects.ResumeLayout(false);
            this.groupBoxObjects.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox gameBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containerToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxObjects;
        private System.Windows.Forms.GroupBox groupBoxContainer;
        private System.Windows.Forms.TabControl tabControlContainer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBoxObjectList;
        private System.Windows.Forms.Label labelSelectObject;
        private System.Windows.Forms.GroupBox groupBoxTest;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonInsertObject;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containerToolStripMenuItem1;
    }
}