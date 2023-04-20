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
            using (var openFileDialog = new OpenFileDialog())
            {
                string defaultFolderToOpen = Settings.Default.DefaultFileToOpen;

                openFileDialog.Filter = "Folders|no.files";
                openFileDialog.FileName = "Select KAG folder";
                openFileDialog.Title = "Select KAG folder";
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Multiselect = false;
                openFileDialog.ValidateNames = false;
                openFileDialog.InitialDirectory = !string.IsNullOrEmpty(defaultFolderToOpen) && Directory.Exists(defaultFolderToOpen)
                    ? defaultFolderToOpen
                    : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelSelectedFile.Text = Path.GetDirectoryName(openFileDialog.FileName);
                }
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
