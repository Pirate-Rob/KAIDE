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
    static internal class TabManager
    {
        //TODO: add a 'Tab' subclass so we can seperate tab management and scintilla (+ have support for other tab types like cfg, png, etc)
        static TabControl Tabs;

        public static void Init(TabControl tabs)
        {
            Tabs = tabs;
        }

        public static void CloseTab(string ID) {
            // Close the associated tab
            foreach (TabPage tabpage in Tabs.TabPages)
            {
                if ((string)tabpage.Tag == ID)
                {
                    Tabs.TabPages.Remove(tabpage);
                    break;
                }
            }
        }

        public static void OpenFileInTab(string path)
        {

            foreach (TabPage tabpage in Tabs.TabPages)
            {
                if ((string)tabpage.Tag == path)
                {
                    Tabs.SelectedTab = tabpage;
                    return;
                }
            }

            TabPage tabPage;
            if(Path.GetExtension(path) == ".cfg") tabPage = new CFGTab(path);
            else if (Path.GetExtension(path) == ".png") tabPage = new PNGTab(path);
            else tabPage = new ASTab(path);
            tabPage.Text += "     ";

            Tabs.TabPages.Add(tabPage);
            Tabs.SelectedTab = tabPage;
        }
    }
}
