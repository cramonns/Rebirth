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
            this.groupBoxTest = new System.Windows.Forms.GroupBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.groupBoxObjects = new System.Windows.Forms.GroupBox();
            this.buttonInsertObject = new System.Windows.Forms.Button();
            this.labelSelectObject = new System.Windows.Forms.Label();
            this.comboBoxObjectList = new System.Windows.Forms.ComboBox();
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonTHolders = new System.Windows.Forms.Button();
            this.tabControlContainer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxTest.SuspendLayout();
            this.groupBoxObjects.SuspendLayout();
            this.groupBoxContainer.SuspendLayout();
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
            this.panel1.Controls.Add(this.groupBoxTest);
            this.panel1.Controls.Add(this.groupBoxObjects);
            this.panel1.Controls.Add(this.groupBoxContainer);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 558);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxTest
            // 
            this.groupBoxTest.Controls.Add(this.buttonPlay);
            this.groupBoxTest.Location = new System.Drawing.Point(3, 175);
            this.groupBoxTest.Name = "groupBoxTest";
            this.groupBoxTest.Size = new System.Drawing.Size(184, 68);
            this.groupBoxTest.TabIndex = 2;
            this.groupBoxTest.TabStop = false;
            this.groupBoxTest.Text = "Test";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Enabled = false;
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
            this.groupBoxObjects.Size = new System.Drawing.Size(184, 114);
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
            // groupBoxContainer
            // 
            this.groupBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxContainer.Controls.Add(this.buttonSave);
            this.groupBoxContainer.Controls.Add(this.buttonNew);
            this.groupBoxContainer.Controls.Add(this.buttonTHolders);
            this.groupBoxContainer.Location = new System.Drawing.Point(3, 3);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(184, 165);
            this.groupBoxContainer.TabIndex = 1;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "Container";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(50, 89);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.containerToolStripMenuItem1_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(50, 24);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.containerToolStripMenuItem_Click);
            // 
            // buttonTHolders
            // 
            this.buttonTHolders.Location = new System.Drawing.Point(35, 118);
            this.buttonTHolders.Name = "buttonTHolders";
            this.buttonTHolders.Size = new System.Drawing.Size(115, 23);
            this.buttonTHolders.TabIndex = 0;
            this.buttonTHolders.Text = "Texture Holders...";
            this.buttonTHolders.UseVisualStyleBackColor = true;
            this.buttonTHolders.Click += new System.EventHandler(this.buttonTHolders_Click);
            // 
            // tabControlContainer
            // 
            this.tabControlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlContainer.Controls.Add(this.tabPage1);
            this.tabControlContainer.Location = new System.Drawing.Point(197, 0);
            this.tabControlContainer.Name = "tabControlContainer";
            this.tabControlContainer.SelectedIndex = 0;
            this.tabControlContainer.Size = new System.Drawing.Size(684, 26);
            this.tabControlContainer.TabIndex = 2;
            this.tabControlContainer.SelectedIndexChanged += new System.EventHandler(this.tabControlContainer_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ContainerView";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(883, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 558);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControlContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelEditor_FormClosed);
            this.Resize += new System.EventHandler(this.LevelEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gameBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxTest.ResumeLayout(false);
            this.groupBoxObjects.ResumeLayout(false);
            this.groupBoxObjects.PerformLayout();
            this.groupBoxContainer.ResumeLayout(false);
            this.tabControlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox gameBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxObjects;
        private System.Windows.Forms.GroupBox groupBoxContainer;
        private System.Windows.Forms.TabControl tabControlContainer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBoxObjectList;
        private System.Windows.Forms.Label labelSelectObject;
        private System.Windows.Forms.GroupBox groupBoxTest;
        private System.Windows.Forms.Button buttonInsertObject;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonTHolders;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonNew;
    }
}
#endif