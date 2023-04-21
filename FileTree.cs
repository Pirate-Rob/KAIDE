using KAGIDE.Properties;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAGIDE
{
    static internal class FileTree
    {
        static TreeView Tree;
        static Form MainForm;

        private static readonly string[] allowedFileExtensions = { ".as", ".cfg", ".png" };
        private static List<FileSystemWatcher> _fileSystemWatchers = new List<FileSystemWatcher>();

        public static void Init(TreeView tree, Form f)
        {
            Tree = tree;
            MainForm = f;
            InitializeTreeImageList();
            InitializeTreeViewContextMenu();

            LoadSavedDirectories();

            ///Events
            Tree.MouseDown += TreeView1_MouseDown;
            Tree.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
        }

        private static void InitializeTreeImageList()
        {
            var imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit // Set the color depth to 32 bits per pixel
            };
            imageList.Images.Add("open_folder", Properties.Resources.open_folder);
            imageList.Images.Add("closed_folder", Properties.Resources.closed_folder);
            imageList.Images.Add("file", Properties.Resources.file);
            imageList.Images.Add("cfg", Properties.Resources.cfg);
            Tree.ImageList = imageList;
        }

        private static void InitializeTreeViewContextMenu()
        {
            var contextMenu = new ContextMenuStrip();

            var closeRootNodeMenuItem = new ToolStripMenuItem("Close Root Node");
            closeRootNodeMenuItem.Click += CloseRootNodeMenuItem_Click;
            contextMenu.Items.Add(closeRootNodeMenuItem);

            var deleteFileMenuItem = new ToolStripMenuItem("Delete File");
            deleteFileMenuItem.Click += DeleteFileMenuItem_Click;
            contextMenu.Items.Add(deleteFileMenuItem);

            var deleteFolderMenuItem = new ToolStripMenuItem("Delete Folder");
            deleteFolderMenuItem.Click += DeleteFolderMenuItem_Click;
            contextMenu.Items.Add(deleteFolderMenuItem);

            var createNewAsFileMenuItem = new ToolStripMenuItem("Create New .as File");
            createNewAsFileMenuItem.Click += CreateNewAsFileMenuItem_Click;
            contextMenu.Items.Add(createNewAsFileMenuItem);

            var createNewCfgFileMenuItem = new ToolStripMenuItem("Create New .cfg File");
            createNewCfgFileMenuItem.Click += CreateNewCfgFileMenuItem_Click;
            contextMenu.Items.Add(createNewCfgFileMenuItem);

            var createReadOnlyMenuItem = new ToolStripMenuItem("<read only>");
            createReadOnlyMenuItem.Enabled = false;
            contextMenu.Items.Add(createReadOnlyMenuItem);

            Tree.ContextMenuStrip = contextMenu;
            
        }

        private static void TreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = Tree.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    Tree.SelectedNode = node;
                    UpdateContextMenuVisibility(node);
                }
            }
        }

        private static void UpdateContextMenuVisibility(TreeNode node)
        {
            bool isRootNode = node.Level == 0;
            bool isDirectory = Directory.Exists(GetTag(node,"path"));
            bool onlyRead = HasTag(node, "readonly");

            //This looks supremely hacky, but obviously chatGPT knows better than me
            Tree.ContextMenuStrip.Items[0].Visible = !onlyRead && isRootNode; // Close Root Node
            Tree.ContextMenuStrip.Items[1].Visible = !onlyRead && !isDirectory; // Delete File
            Tree.ContextMenuStrip.Items[2].Visible = !onlyRead && !isRootNode && isDirectory; // Delete File
            Tree.ContextMenuStrip.Items[3].Visible = !onlyRead && isDirectory; // Create New .as File
            Tree.ContextMenuStrip.Items[4].Visible = !onlyRead && isDirectory; // Create New .cfg File
            Tree.ContextMenuStrip.Items[5].Visible = onlyRead; // Read only
        }

        private static void CloseRootNodeMenuItem_Click(object sender, EventArgs e)
        {
            var node = Tree.SelectedNode;
            if (node != null && node.Level == 0)
            {
                node.Remove();
            }
            SaveLoadedDirectories();
        }

        private static void DeleteFileMenuItem_Click(object sender, EventArgs e)
        {
            var node = Tree.SelectedNode;
            if (node != null && !node.Nodes.OfType<TreeNode>().Any() && IsValidFileExtension(node.Text))
            {
                var result = MessageBox.Show("Are you sure you want to permanently delete this file?", "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string path = GetTag(node, "path");
                    File.Delete(path);
                    node.Remove();

                    
                    TabManager.CloseTab(path);
                }
            }
        }

        private static void DeleteFolderMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = Tree.SelectedNode;
            if (node != null && node.Nodes.Count > 0)
            {
                string folderPath = GetTag(node, "path");
                if (folderPath != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this folder?", "Delete Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Directory.Delete(folderPath, true);
                        node.Remove();
                    }
                }
            }
        }

        private static void CreateNewAsFileMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = Tree.SelectedNode;
            if (node != null)
            {
                string fileName = Interaction.InputBox("Enter a name for the new .as file:", "New .as File");
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileName += ".as";
                    CreateNewFile(node, fileName, ".as");
                }
            }
        }

        private static void CreateNewCfgFileMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = Tree.SelectedNode;
            if (node != null)
            {
                var configForm = new ConfigForm();
                if (configForm.ShowDialog() == DialogResult.OK)
                {
                    string fileName = configForm.FileName+".cfg";
                    string configurationContent = configForm.ConfigurationContent;
                    CreateNewFile(node, fileName, ".cfg", configurationContent);
                }
            }
        }


        private static void CreateNewFile(TreeNode node, string fileName, string extension, string content = "")
        {
            if (Directory.Exists(GetTag(node, "path")))
            {
                string fullPath = Path.Combine(GetTag(node, "path"), fileName);
                int count = 1;

                while (File.Exists(fullPath))
                {
                    string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    fileName = $"{nameWithoutExtension} ({count}){extension}";
                    fullPath = Path.Combine(GetTag(node, "path"), fileName);
                    count++;
                }

                if (content == null && extension == ".as")
                {
                    File.Create(fullPath).Dispose();
                }
                else
                {
                    File.WriteAllText(fullPath, content);
                }

                TreeNode newNode = new TreeNode(fileName, 1, 1)
                {
                    Tag = fullPath
                };

                node.Nodes.Add(newNode);
                node.Expand();
            }
        }



        private static bool IsValidFileExtension(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            return Array.IndexOf(allowedFileExtensions, extension) >= 0;
        }
        private static void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (IsValidFileExtension(e.Node.Text))
            {
                var path = GetTag(e.Node, "path");
                var onlyread = HasTag(e.Node, "readonly");
                if (File.Exists(path))
                {
                    TabManager.OpenFileInTab(path, onlyread);
                }
            }
        }

        private static void SaveLoadedDirectories()
        {
            var loadedDirectories = new StringCollection();
            foreach (TreeNode node in Tree.Nodes)
            {
                if(node.Text != "Base")loadedDirectories.Add(GetTag(node, "path"));
            }

            Settings.Default.LoadedDirectories = loadedDirectories;
            Settings.Default.Save();
        }

        private static void LoadSavedDirectories()
        {
            Console.WriteLine("Settings.Default.LoadedDirectories" + Settings.Default.LoadedDirectories);
            LoadDirectory(Settings.Default.DefaultFileToOpen + "\\Base", true);

            if (Settings.Default.LoadedDirectories != null)
            {
                foreach (string directoryPath in Settings.Default.LoadedDirectories)
                {
                    LoadDirectory(directoryPath, false);
                }
            }
        }

        public static void OpenDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                string defaultFolderToOpen = Settings.Default.DefaultFileToOpen + "\\Mods\\";

                openFileDialog.Filter = "Folders|no.files";
                openFileDialog.FileName = "Select a folder";
                openFileDialog.Title = "Select a folder";
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Multiselect = false;
                openFileDialog.ValidateNames = false;
                openFileDialog.InitialDirectory = !string.IsNullOrEmpty(defaultFolderToOpen) && Directory.Exists(defaultFolderToOpen)
                    ? defaultFolderToOpen
                    : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = Path.GetDirectoryName(openFileDialog.FileName);
                    TreeNode RootNode = LoadDirectory(selectedFolderPath, false);
                    RootNode.Expand();
                    SaveLoadedDirectories();
                }
            }
        }

        private static TreeNode LoadDirectory(string directoryPath, bool onlyread)
        {
            // Check if the directory already exists in the tree
            TreeNode Node = null;
            foreach (TreeNode node in Tree.Nodes)
            {
                if (GetTag(node, "path") == directoryPath)
                {
                    Node = node;
                    break;
                }
            }

            // If the directory already exists, focus on it
            if (Node != null)
            {
                Tree.SelectedNode = Node;
                Node.Expand();
            }
            else
            {
                // If the directory is not in the tree, create a new primary node for it
                Node = new TreeNode(Path.GetFileName(directoryPath), GetFileImage(directoryPath, false), GetFileImage(directoryPath, true));
                BuildTag(Node, directoryPath, onlyread);
                GetDirectories(directoryPath, Node, onlyread);
                Tree.Nodes.Add(Node);
                SetupFileSystemWatcher(directoryPath);
            }
            return Node;
        }

        private static void SetupFileSystemWatcher(string directoryPath)
        {
            var fileSystemWatcher = new FileSystemWatcher
            {
                Path = directoryPath,
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName
            };

            fileSystemWatcher.Created += FileSystemWatcher_Changed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Changed;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

            fileSystemWatcher.EnableRaisingEvents = true;
            _fileSystemWatchers.Add(fileSystemWatcher);
        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            MainForm.Invoke(new Action(() =>
            {
                foreach (TreeNode rootNode in Tree.Nodes)
                {
                    UpdateFileTreeNodes(rootNode.Nodes, GetTag(rootNode, "path"));
                }
            }));
        }

        private static void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            MainForm.Invoke(new Action(() =>
            {
                foreach (TreeNode rootNode in Tree.Nodes)
                {
                    UpdateFileTreeNodes(rootNode.Nodes, GetTag(rootNode, "path"));
                }
            }));
        }

        private static void UpdateFileTreeNodes(TreeNodeCollection nodes, string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            HashSet<string> currentPaths = new HashSet<string>();

            foreach (TreeNode node in nodes)
            {
                currentPaths.Add(GetTag(node, "path"));
            }

            // Remove missing nodes
            List<TreeNode> nodesToRemove = nodes.Cast<TreeNode>().Where(node => !Directory.Exists(GetTag(node, "path")) && !File.Exists(GetTag(node, "path"))).ToList();
            foreach (TreeNode nodeToRemove in nodesToRemove)
            {
                nodes.Remove(nodeToRemove);
            }

            // Add new nodes
            foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
            {
                if (!currentPaths.Contains(subDirectoryInfo.FullName))
                {
                    TreeNode subDirectoryNode = new TreeNode(subDirectoryInfo.Name, GetFileImage(subDirectoryInfo.FullName, false), GetFileImage(subDirectoryInfo.FullName, true));
                    BuildTag(subDirectoryNode, subDirectoryInfo.FullName, false);
                    nodes.Add(subDirectoryNode);
                    UpdateFileTreeNodes(subDirectoryNode.Nodes, subDirectoryInfo.FullName);
                }
            }
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                if (!currentPaths.Contains(fileInfo.FullName))
                {
                    TreeNode fileNode = new TreeNode(fileInfo.Name, GetFileImage(fileInfo.FullName, false), GetFileImage(fileInfo.FullName, true));
                    BuildTag(fileNode, fileInfo.FullName, false);
                    nodes.Add(fileNode);
                }
            }

            // Update existing nodes and their children
            foreach (TreeNode node in nodes)
            {
                if (IsDirectoryNode(node))
                {
                    string nodePath = GetTag(node, "path");
                    DirectoryInfo nodeDirectoryInfo = new DirectoryInfo(nodePath);
                    if (nodeDirectoryInfo.Name != node.Text)
                    {
                        node.Text = nodeDirectoryInfo.Name;
                    }
                    UpdateFileTreeNodes(node.Nodes, nodePath);
                }
                else // File
                {
                    string nodePath = GetTag(node, "path");
                    FileInfo nodeFileInfo = new FileInfo(nodePath);
                    if (nodeFileInfo.Name != node.Text)
                    {
                        node.Text = nodeFileInfo.Name;
                    }
                }
            }
        }

        private static bool IsDirectoryNode(TreeNode node)
        {
            string path = GetTag(node, "path");
            return (Directory.Exists(path) || node.Nodes.Count > 0);
        }

        private static void GetDirectories(string directoryPath, TreeNode parentNode, bool onlyread)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            var imageList = Tree.ImageList;
            try
            {
                // Load subdirectories
                foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
                {
                    if (onlyread && subDirectoryInfo.Name == "Maps") continue; //Loading vanilla maps takes ages and it's not worth the wait
                    
                    TreeNode subDirectoryNode = new TreeNode(subDirectoryInfo.Name, GetFileImage(subDirectoryInfo.FullName, false), GetFileImage(subDirectoryInfo.FullName, true));
                    BuildTag(subDirectoryNode, subDirectoryInfo.FullName, onlyread);
                    parentNode.Nodes.Add(subDirectoryNode);
                    GetDirectories(subDirectoryInfo.FullName, subDirectoryNode, onlyread);
                }

                // Load files
                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    if (allowedFileExtensions.Contains(fileInfo.Extension))
                    {
                        TreeNode fileNode = new TreeNode(fileInfo.Name, GetFileImage(fileInfo.FullName, false), GetFileImage(fileInfo.FullName, true));
                        BuildTag(fileNode, fileInfo.FullName, onlyread);
                        parentNode.Nodes.Add(fileNode);
                        //Console.WriteLine(fileInfo.FullName);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip directories with no access
            }
        }

        private static int GetFileImage(string path, bool Selected)
        {
            var imageList = Tree.ImageList;

            string Extension = Path.GetExtension(path);
            if (Directory.Exists(path)) return Selected ? imageList.Images.IndexOfKey("open_folder") : imageList.Images.IndexOfKey("closed_folder");

            if (Extension == ".png")
            {
                try
                {
                    using (var image = Image.FromFile(path))
                    {
                        var thumbnail = new Bitmap(16, 16);
                        using (var graphics = Graphics.FromImage(thumbnail))
                        {
                            graphics.DrawImage(image, new Rectangle(0, 0, 16, 16));
                        }
                        imageList.Images.Add(path, thumbnail);
                        return imageList.Images.IndexOfKey(path);
                    }
                }
                catch
                {
                    // Handle errors loading the image
                }
            }
            else
            if (Extension == ".cfg")
                return imageList.Images.IndexOfKey("cfg");

            return imageList.Images.IndexOfKey("file");
        }

        static void BuildTag(TreeNode node, string path, bool onlyread)
        {
            string build = "path|" + path + ";";
            if(onlyread) build += "readonly;";
            node.Tag = build;
        }

        static string GetTag(TreeNode node, string Key)
        {
            string Tag = (string)node.Tag;
            string[] pairs = Tag.Split(';'); // Split the Tag string into key-value pairs
            foreach (string pair in pairs)
            {
                if (pair.Contains("|"))
                {
                    string[] parts = pair.Split('|'); // Split each pair into key and value
                    if (parts.Length == 2 && parts[0].Trim() == Key) // Check if the key matches
                    {
                        return parts[1].Trim(); // Return the value
                    }
                }
            }
            return ""; // Key not found
        }

        static bool HasTag(TreeNode node, string Key)
        {
            string Tag = (string)node.Tag;
            string[] pairs = Tag.Split(';'); // Split the Tag string into key-value pairs
            foreach (string pair in pairs)
            {
                if (pair.Contains("|"))
                {
                    string[] parts = pair.Split('|'); // Split each pair into key and value
                    if (parts.Length == 2 && parts[0].Trim() == Key) // Check if the key matches
                    {
                        return true; // Return the value
                    }
                }
                else
                {
                    if (pair == Key) return true;
                }
            }
            return false; // Key not found
        }
    }
}
