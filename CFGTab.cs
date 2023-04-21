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
    internal class CFGTab : TabPage
    {

        private CFGTabControl content;

        public CFGTab(string path)
        {
            this.Text = Path.GetFileName(path);
            this.Tag = path;

            ToolStrip toolStrip = CreateTabToolStrip(
            saveButtonAction: () =>
            {
                // Save the file
                this.Text = Path.GetFileName((string)this.Tag);
            },
            closeButtonAction: () =>
            {
                // Close the tab
                //Tabs.TabPages.Remove(Page);
                TabManager.CloseTab((string)this.Tag);
            });

            this.Controls.Add(toolStrip);

            content = new CFGTabControl();
            content.Dock = DockStyle.Fill;
            Controls.Add(content);
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
