using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAGIDE
{
    public partial class CFGTabControl : UserControl
    {
        private BlobCFG Data;
        private SpriteDrawer InventoryIconSprite = new SpriteDrawer();

        public CFGTabControl(BlobCFG data)
        {
            Data = data;
            InitializeComponent();

            PopulateFields();
            UpdatePreviews();
        }

        private void SpriteFactory_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            SpriteBox.Enabled = cb.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PopulateFields() { 
            ///General
            NameBox.Text = Data.InventoryName;
            CFGNameBox.Text = Data.Name;
            InventoryIconLabel.Text = Data.InventoryIcon;
            FrameBox.Value = Data.InventoryIconFrame;
            IconSizeW.Text = "" + Data.InventoryIconFrameWidth;
            IconSizeH.Text = "" + Data.InventoryIconFrameHeight;
            SlotSizeW.Text = "" + Data.InventoryUsedWidth;
            SlotSizeH.Text = "" + Data.InventoryUsedHeight;
            MaxStacksBox.Value = Data.InventoryMaxStacks;
        }


        private void UpdatePreviews() {
            InventoryIconSprite.LoadSprite(FileTree.GetImagePath(Data.InventoryIcon));
            InventoryIconSprite.FrameWidth = Data.InventoryIconFrameWidth;
            InventoryIconSprite.FrameHeight = Data.InventoryIconFrameHeight;
            InventoryIconSprite.Frame = Data.InventoryIconFrame;
            IconSpriteBox.Image = InventoryIconSprite.Draw();
            IconSpriteBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void IconSizeW_TextChanged(object sender, EventArgs e) {
            int size = 1;
            try {
                size = int.Parse(IconSizeW.Text);
            }
            catch (FormatException) {
                (sender as TextBox).Text = "1";
            }
            Data.SetValue("u8 inventory_icon_frame_width", size);
            UpdatePreviews();
        }
    }
}
