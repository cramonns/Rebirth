namespace Rebirth {
    partial class GameObjectForm {
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
            this.tabPageMove = new System.Windows.Forms.TabPage();
            this.numericUpDownSpeedY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownSpeedX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPageTextures = new System.Windows.Forms.TabPage();
            this.comboBoxTexture = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.groupBoxDimensions = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLogical = new System.Windows.Forms.TabPage();
            this.comboBoxLogicalOnCollide = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageTriggers = new System.Windows.Forms.TabPage();
            this.comboBoxTriggerOnEnter = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBoxTriggerOnCollide = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxTriggerOnLeave = new System.Windows.Forms.ComboBox();
            this.tabPageMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.tabPageTextures.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.groupBoxDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageLogical.SuspendLayout();
            this.tabPageTriggers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageMove
            // 
            this.tabPageMove.Controls.Add(this.numericUpDownSpeedY);
            this.tabPageMove.Controls.Add(this.label8);
            this.tabPageMove.Controls.Add(this.numericUpDownSpeedX);
            this.tabPageMove.Controls.Add(this.label7);
            this.tabPageMove.Controls.Add(this.label6);
            this.tabPageMove.Controls.Add(this.groupBox2);
            this.tabPageMove.Location = new System.Drawing.Point(4, 22);
            this.tabPageMove.Name = "tabPageMove";
            this.tabPageMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMove.Size = new System.Drawing.Size(218, 234);
            this.tabPageMove.TabIndex = 3;
            this.tabPageMove.Text = "Basic Properties";
            this.tabPageMove.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSpeedY
            // 
            this.numericUpDownSpeedY.DecimalPlaces = 2;
            this.numericUpDownSpeedY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownSpeedY.Location = new System.Drawing.Point(146, 136);
            this.numericUpDownSpeedY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownSpeedY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownSpeedY.Name = "numericUpDownSpeedY";
            this.numericUpDownSpeedY.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownSpeedY.TabIndex = 7;
            this.numericUpDownSpeedY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSpeedY.ValueChanged += new System.EventHandler(this.numericUpDownSpeedY_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Y:";
            // 
            // numericUpDownSpeedX
            // 
            this.numericUpDownSpeedX.DecimalPlaces = 2;
            this.numericUpDownSpeedX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownSpeedX.Location = new System.Drawing.Point(36, 136);
            this.numericUpDownSpeedX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownSpeedX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownSpeedX.Name = "numericUpDownSpeedX";
            this.numericUpDownSpeedX.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownSpeedX.TabIndex = 5;
            this.numericUpDownSpeedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSpeedX.ValueChanged += new System.EventHandler(this.numericUpDownSpeedX_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Initial Speed:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.numericUpDown5);
            this.groupBox2.Controls.Add(this.numericUpDown6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.numericUpDown7);
            this.groupBox2.Controls.Add(this.numericUpDown8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 96);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimensions";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Height:";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 2;
            this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown5.Location = new System.Drawing.Point(143, 29);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown5.TabIndex = 6;
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.DecimalPlaces = 2;
            this.numericUpDown6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown6.Location = new System.Drawing.Point(143, 55);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown6.TabIndex = 5;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(99, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Width:";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.DecimalPlaces = 2;
            this.numericUpDown7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown7.Location = new System.Drawing.Point(33, 55);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown7.TabIndex = 3;
            this.numericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown7.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown8.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericUpDown8.DecimalPlaces = 2;
            this.numericUpDown8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown8.Location = new System.Drawing.Point(33, 29);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown8.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown8.TabIndex = 2;
            this.numericUpDown8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown8.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Y:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "X: ";
            // 
            // tabPageTextures
            // 
            this.tabPageTextures.Controls.Add(this.comboBoxTexture);
            this.tabPageTextures.Controls.Add(this.label5);
            this.tabPageTextures.Location = new System.Drawing.Point(4, 22);
            this.tabPageTextures.Name = "tabPageTextures";
            this.tabPageTextures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTextures.Size = new System.Drawing.Size(218, 234);
            this.tabPageTextures.TabIndex = 1;
            this.tabPageTextures.Text = "Texture";
            this.tabPageTextures.UseVisualStyleBackColor = true;
            // 
            // comboBoxTexture
            // 
            this.comboBoxTexture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTexture.FormattingEnabled = true;
            this.comboBoxTexture.Location = new System.Drawing.Point(11, 45);
            this.comboBoxTexture.Name = "comboBoxTexture";
            this.comboBoxTexture.Size = new System.Drawing.Size(198, 21);
            this.comboBoxTexture.TabIndex = 1;
            this.comboBoxTexture.SelectedIndexChanged += new System.EventHandler(this.comboBoxTexture_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Texture:";
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.groupBoxDimensions);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(218, 234);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic Properties";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // groupBoxDimensions
            // 
            this.groupBoxDimensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDimensions.Controls.Add(this.label4);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownWidth);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownHeight);
            this.groupBoxDimensions.Controls.Add(this.label3);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownY);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownX);
            this.groupBoxDimensions.Controls.Add(this.label2);
            this.groupBoxDimensions.Controls.Add(this.label1);
            this.groupBoxDimensions.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDimensions.Name = "groupBoxDimensions";
            this.groupBoxDimensions.Size = new System.Drawing.Size(209, 96);
            this.groupBoxDimensions.TabIndex = 0;
            this.groupBoxDimensions.TabStop = false;
            this.groupBoxDimensions.Text = "Dimensions";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height:";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.DecimalPlaces = 2;
            this.numericUpDownWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownWidth.Location = new System.Drawing.Point(143, 29);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownWidth.TabIndex = 6;
            this.numericUpDownWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.DecimalPlaces = 2;
            this.numericUpDownHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownHeight.Location = new System.Drawing.Point(143, 55);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownHeight.TabIndex = 5;
            this.numericUpDownHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Width:";
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.DecimalPlaces = 2;
            this.numericUpDownY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownY.Location = new System.Drawing.Point(33, 55);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownY.TabIndex = 3;
            this.numericUpDownY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownX.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericUpDownX.DecimalPlaces = 2;
            this.numericUpDownX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownX.Location = new System.Drawing.Point(33, 29);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownX.TabIndex = 2;
            this.numericUpDownX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageBasic);
            this.tabControl1.Controls.Add(this.tabPageMove);
            this.tabControl1.Controls.Add(this.tabPageTextures);
            this.tabControl1.Controls.Add(this.tabPageLogical);
            this.tabControl1.Controls.Add(this.tabPageTriggers);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(226, 260);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageLogical
            // 
            this.tabPageLogical.Controls.Add(this.comboBoxLogicalOnCollide);
            this.tabPageLogical.Controls.Add(this.label9);
            this.tabPageLogical.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogical.Name = "tabPageLogical";
            this.tabPageLogical.Size = new System.Drawing.Size(218, 234);
            this.tabPageLogical.TabIndex = 4;
            this.tabPageLogical.Text = "Events";
            this.tabPageLogical.UseVisualStyleBackColor = true;
            // 
            // comboBoxLogicalOnCollide
            // 
            this.comboBoxLogicalOnCollide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLogicalOnCollide.FormattingEnabled = true;
            this.comboBoxLogicalOnCollide.Location = new System.Drawing.Point(8, 40);
            this.comboBoxLogicalOnCollide.Name = "comboBoxLogicalOnCollide";
            this.comboBoxLogicalOnCollide.Size = new System.Drawing.Size(201, 21);
            this.comboBoxLogicalOnCollide.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "OnCollide:";
            // 
            // tabPageTriggers
            // 
            this.tabPageTriggers.Controls.Add(this.comboBoxTriggerOnLeave);
            this.tabPageTriggers.Controls.Add(this.label16);
            this.tabPageTriggers.Controls.Add(this.comboBoxTriggerOnEnter);
            this.tabPageTriggers.Controls.Add(this.label15);
            this.tabPageTriggers.Controls.Add(this.comboBoxTriggerOnCollide);
            this.tabPageTriggers.Controls.Add(this.label14);
            this.tabPageTriggers.Location = new System.Drawing.Point(4, 22);
            this.tabPageTriggers.Name = "tabPageTriggers";
            this.tabPageTriggers.Size = new System.Drawing.Size(218, 234);
            this.tabPageTriggers.TabIndex = 5;
            this.tabPageTriggers.Text = "Events";
            this.tabPageTriggers.UseVisualStyleBackColor = true;
            // 
            // comboBoxTriggerOnEnter
            // 
            this.comboBoxTriggerOnEnter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerOnEnter.FormattingEnabled = true;
            this.comboBoxTriggerOnEnter.Location = new System.Drawing.Point(7, 107);
            this.comboBoxTriggerOnEnter.Name = "comboBoxTriggerOnEnter";
            this.comboBoxTriggerOnEnter.Size = new System.Drawing.Size(202, 21);
            this.comboBoxTriggerOnEnter.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "OnEnter:";
            // 
            // comboBoxTriggerOnCollide
            // 
            this.comboBoxTriggerOnCollide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerOnCollide.FormattingEnabled = true;
            this.comboBoxTriggerOnCollide.Location = new System.Drawing.Point(8, 40);
            this.comboBoxTriggerOnCollide.Name = "comboBoxTriggerOnCollide";
            this.comboBoxTriggerOnCollide.Size = new System.Drawing.Size(201, 21);
            this.comboBoxTriggerOnCollide.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "OnCollide:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 149);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "OnLeave:";
            // 
            // comboBoxTriggerOnLeave
            // 
            this.comboBoxTriggerOnLeave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerOnLeave.FormattingEnabled = true;
            this.comboBoxTriggerOnLeave.Location = new System.Drawing.Point(8, 173);
            this.comboBoxTriggerOnLeave.Name = "comboBoxTriggerOnLeave";
            this.comboBoxTriggerOnLeave.Size = new System.Drawing.Size(201, 21);
            this.comboBoxTriggerOnLeave.TabIndex = 7;
            // 
            // GameObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 261);
            this.Controls.Add(this.tabControl1);
            this.Name = "GameObjectForm";
            this.Text = "Properties";
            this.tabPageMove.ResumeLayout(false);
            this.tabPageMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            this.tabPageTextures.ResumeLayout(false);
            this.tabPageTextures.PerformLayout();
            this.tabPageBasic.ResumeLayout(false);
            this.groupBoxDimensions.ResumeLayout(false);
            this.groupBoxDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogical.ResumeLayout(false);
            this.tabPageLogical.PerformLayout();
            this.tabPageTriggers.ResumeLayout(false);
            this.tabPageTriggers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageMove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPageTextures;
        private System.Windows.Forms.ComboBox comboBoxTexture;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.GroupBox groupBoxDimensions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeedY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeedX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPageLogical;
        private System.Windows.Forms.ComboBox comboBoxLogicalOnCollide;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageTriggers;
        private System.Windows.Forms.ComboBox comboBoxTriggerOnEnter;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBoxTriggerOnCollide;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxTriggerOnLeave;
        private System.Windows.Forms.Label label16;

    }
}