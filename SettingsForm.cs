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
using WK.Libraries.BetterFolderBrowserNS;

namespace KAGIDE
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            labelSelectedFile.Text = Settings.Default.DefaultFileToOpen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click_1(object sender, EventArgs e)
        {
            string defaultFolderToOpen = Settings.Default.DefaultFileToOpen;

            var betterFolderBrowser = new BetterFolderBrowser();

            betterFolderBrowser.Title = "Select folder...";
            betterFolderBrowser.RootFolder = !string.IsNullOrEmpty(defaultFolderToOpen) && Directory.Exists(defaultFolderToOpen)
                ? defaultFolderToOpen
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            betterFolderBrowser.Multiselect = false;

            if (betterFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                labelSelectedFile.Text = betterFolderBrowser.SelectedFolder;

                // If you've disabled multi-selection, use 'SelectedFolder'.
                // string selectedFolder = betterFolderBrowser1.SelectedFolder;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.DefaultFileToOpen = labelSelectedFile.Text;
            Settings.Default.Save();
            Close();
        }
    }
}
