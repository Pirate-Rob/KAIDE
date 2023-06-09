﻿using System;
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
        private BlobCFG Data;
        private bool OnlyRead = false;

        public CFGTab(string path, bool onlyread)
        {
            this.Text = Path.GetFileName(path);
            this.Tag = path;
            this.Data = new BlobCFG(path);
            this.OnlyRead = onlyread;
            Data.Load();
            

            var toolStrip = new ToolStrip();

            if (!OnlyRead)
            {
                var saveButton = new ToolStripButton("Save");
                toolStrip.Items.Add(saveButton);
                saveButton.Click += (sender, e) =>
                {
                    // Save the file
                    CommitSave(path);
                };
            }

            var closeButton = new ToolStripButton("Close");
            toolStrip.Items.Add(closeButton);
            closeButton.Alignment = ToolStripItemAlignment.Right;
            closeButton.Click += (sender, e) => {
                // Close the tab
                //Tabs.TabPages.Remove(Page);
                TabManager.CloseTab((string)this.Tag);
            };

            content = new CFGTabControl(Data);
            content.Dock = DockStyle.None;
            content.Location = new Point(0, toolStrip.Height); // Set the location below the ToolStrip

            Controls.Add(toolStrip);
            Controls.Add(content);
        }

        private bool CommitSave(string path)
        {
            if (!OnlyRead)
            {
                Data.Save();
                this.Text = Path.GetFileName((string)this.Tag);
                return true;
            }
            return false;
        }
    }
}
