using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAGIDE
{
    public partial class CFGTabControl : UserControl
    {
        public CFGTabControl()
        {
            InitializeComponent();
        }

        private void SpriteFactory_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            SpriteBox.Enabled = cb.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
