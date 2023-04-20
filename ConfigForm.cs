using KAGIDE.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAGIDE
{
    public partial class ConfigForm : Form
    {
        Image sprite;

        public ConfigForm()
        {
            InitializeComponent();

            this.KeyDown += ConfigForm_KeyDown;
        }

        private void ConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public string FileName
        {
            get { return cfgNameField.Text; }
        }

        //TODO: Have a way to insert space before equal signs so the files look nice like vanilla kag
        public string ConfigurationContent
        {
            get { return buildSpriteFactory(); }
        }

        private string buildSpriteFactory() {
            string str = "$sprite_factory =";

            if (spriteFactory.Checked) {
                str = "$sprite_factory = generic_sprite\n";

                str += "@$sprite_scripts = Wooden.as;\n";

                str += "$sprite_texture = "+ spritePath.Text + "\n";
                str += "s32_sprite_frame_width = "+frameWidth.Text+"\n";
                str += "s32_sprite_frame_height = " + frameHeight.Text + "\n";
                str += "f32 sprite_offset_x = 0\n";
                str += "f32 sprite_offset_y = 0\n";

                str += "\n";
                str += "$sprite_gibs_start = *start*\n";
                str += "$sprite_gibs_end = *end*\n";

                str += "\n";
                str += "$sprite_animation_start = *start*\n";
                str += "	$sprite_animation_default_name = default\n";
                str += "	u16_sprite_animation_default_time = 1\n";
                str += "	u8_sprite_animation_default_loop = 0\n";
                str += "	@u16_sprite_animation_default_frames = 0;\n";
                str += "$sprite_animation_end = *end*\n";

            }

            return str;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void spriteFactory_CheckedChanged(object sender, EventArgs e)
        {
            spriteFactoryPanel.Enabled = spriteFactory.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png", // Only allow PNG files to be selected
                Multiselect = false // Disable selecting multiple files
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                UpdateSpriteBox(filePath);
            }
        }

        private void UpdateSpriteBox(string path) {
            
            sprite = Image.FromFile(path);

            if (sprite != null)
            {
                spriteBox.Image = sprite;
                spriteBox.SizeMode = PictureBoxSizeMode.Normal;

                spritePath.Text = Path.GetFileName(path);
            }
        }
    }
}
