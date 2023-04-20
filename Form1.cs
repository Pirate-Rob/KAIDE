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


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                var tabPage = tabControl1.TabPages[e.Index];
                var tabRect = tabControl1.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                {
                    var closeImage = Properties.Resources.Cancel;
                    e.Graphics.DrawImage(closeImage,
                        (tabRect.Right - closeImage.Width),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                    TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                        tabRect, tabPage.ForeColor, TextFormatFlags.Left);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            // Process MouseDown event only till (tabControl.TabPages.Count - 1) excluding the last TabPage
            for (var i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var tabRect = tabControl1.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var closeImage = Properties.Resources.Cancel;
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }


    }
}
