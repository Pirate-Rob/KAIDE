using KAGIDE.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using System.Collections.Specialized;

namespace KAGIDE
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            InitializeMenuStrip();

            FileTree.Init(treeView1,this);
            KAGScraper.Init();
            TabManager.Init(tabControl1);
        }

        

        private void InitializeMenuStrip()
        {
            var fileMenuItem = new ToolStripMenuItem("File");
            var openDirectoryMenuItem = new ToolStripMenuItem("Open Mod", null, FileTree.OpenDirectoryMenuItem_Click);
            fileMenuItem.DropDownItems.Add(openDirectoryMenuItem);
            var settingsMenuItem = new ToolStripMenuItem("Settings", null, SettingsMenuItem_Click);
            menuStrip1.Items.Add(settingsMenuItem);
            menuStrip1.Items.Add(fileMenuItem); // Replace 'menuStrip1' with the name of your MenuStrip control
        }


        

        

        

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }
    }
}
