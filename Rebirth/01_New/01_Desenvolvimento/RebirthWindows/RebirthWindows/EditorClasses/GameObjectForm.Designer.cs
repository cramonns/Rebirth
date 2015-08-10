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
            this.tabPageTextures = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTexture = new System.Windows.Forms.ComboBox();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.groupBoxDimensions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageMove.SuspendLayout();
            this.tabPageTextures.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.groupBoxDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageMove
            // 
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Texture:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X: ";
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
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownX.TabIndex = 2;
            this.numericUpDownX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
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
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownY.TabIndex = 3;
            this.numericUpDownY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageBasic);
            this.tabControl1.Controls.Add(this.tabPageMove);
            this.tabControl1.Controls.Add(this.tabPageTextures);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(226, 260);
            this.tabControl1.TabIndex = 1;
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
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown7.TabIndex = 3;
            this.numericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown8.TabIndex = 2;
            this.numericUpDown8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Speed:";
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
            this.tabPageTextures.ResumeLayout(false);
            this.tabPageTextures.PerformLayout();
            this.tabPageBasic.ResumeLayout(false);
            this.groupBoxDimensions.ResumeLayout(false);
            this.groupBoxDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
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

    }
}