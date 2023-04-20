using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAGIDE
{
    internal class PNGTab : TabPage
    {
        Image sprite;
        
        public PNGTab(string path)
        {
            this.Text = Path.GetFileName(path);
            this.Tag = path;

            this.sprite = Image.FromFile(path);

            ToolStrip toolStrip = CreateTabToolStrip(
            saveButtonAction: () =>
            {
                sprite.Save(path);
                this.Text = Path.GetFileName((string)this.Tag);
            },
            closeButtonAction: () =>
            {
                TabManager.CloseTab((string)this.Tag);
            });

            Panel panel = new Panel { Dock = DockStyle.Fill };
            panel.Controls.Add(toolStrip);

            PictureBox pictureBox = new PictureBox { Dock = DockStyle.Fill };
            panel.Controls.Add(pictureBox);
            pictureBox.Image = sprite;
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            this.Controls.Add(panel);

        }

        private static ToolStrip CreateTabToolStrip(Action saveButtonAction, Action closeButtonAction)
        {
            var saveButton = new ToolStripButton("Save");
            saveButton.Click += (sender, e) => saveButtonAction();

            // Add more buttons as needed

            var closeButton = new ToolStripButton("Close");
            closeButton.Alignment = ToolStripItemAlignment.Right;
            closeButton.Click += (sender, e) => closeButtonAction();

            var toolStrip = new ToolStrip();
            toolStrip.Items.Add(saveButton);
            // Add more buttons to the ToolStrip
            toolStrip.Items.Add(closeButton);

            return toolStrip;
        }
    }
}
