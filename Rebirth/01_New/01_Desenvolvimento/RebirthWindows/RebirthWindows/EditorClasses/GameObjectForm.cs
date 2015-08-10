using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rebirth {
    public partial class GameObjectForm : Form {

        GameObject editingObject;

        public GameObjectForm(GameObject g) {
            InitializeComponent();
            editingObject = g;
            
            string[] textures = Enum.GetNames(typeof(TextureManager.TextureID));
            foreach (string texture in textures){
                comboBoxTexture.Items.Add(texture);
            }

            comboBoxTexture.SelectedIndex = (int)editingObject.textureId;

            numericUpDownX.Value = (decimal)editingObject.X;
            numericUpDownY.Value = (decimal)editingObject.Y;
            numericUpDownWidth.Value = (decimal)editingObject.Width;
            numericUpDownHeight.Value = (decimal)editingObject.Height;
            
        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e) {
            editingObject.X = (float)numericUpDownX.Value;
            GameManager.game.getWorld().transformSelectedObject();
            numericUpDownX.Value = (decimal)editingObject.X;
        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e) {
            editingObject.Y = (float)numericUpDownY.Value;
            GameManager.game.getWorld().transformSelectedObject();
            numericUpDownY.Value = (decimal)editingObject.Y;
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e) {
            editingObject.Width = (float)numericUpDownWidth.Value;
            GameManager.game.getWorld().transformSelectedObject();
            numericUpDownWidth.Value = (decimal)editingObject.Width;
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e) {
            editingObject.Height = (float)numericUpDownHeight.Value;
            GameManager.game.getWorld().transformSelectedObject();
            numericUpDownHeight.Value = (decimal)editingObject.Height;
        }

        private void comboBoxTexture_SelectedIndexChanged(object sender, EventArgs e) {
            editingObject.unLoad();
            editingObject.textureId = (TextureManager.TextureID)comboBoxTexture.SelectedIndex;
            editingObject.Load();
        }
    }
}
