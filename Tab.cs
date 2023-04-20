using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAGIDE
{
    internal class Tab
    {
        internal string ID; //An ID for the tab, usually the file path
        internal TabPage Page;

        public string Name
        {
            get { return Page.Text; }
            set { Page.Text = value; }
        }



    }
}
