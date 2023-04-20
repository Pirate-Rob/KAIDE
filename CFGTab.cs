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
    internal class CFGTab : TabPage
    {

        public CFGTab(string path)
        {
            this.Text = Path.GetFileName(path);
            this.Tag = path;

            /*
            ToolStrip toolStrip = CreateTabToolStrip(
            saveButtonAction: () =>
            {
                // Save the file
                File.WriteAllText(path, "");
                this.Text = Path.GetFileName((string)this.Tag);
            },
            closeButtonAction: () =>
            {
                // Close the tab
                //Tabs.TabPages.Remove(Page);
                TabManager.CloseTab((string)this.Tag);
            });

            Panel panel = new Panel { Dock = DockStyle.Fill };
            panel.Controls.Add(toolStrip);


            panel.Controls.Add(toolStrip);
            this.Controls.Add(panel);
            */

            InitializeComponent();
            

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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
