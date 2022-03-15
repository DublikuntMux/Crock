using System;
using System.Windows.Forms;

namespace Crock
{
    public partial class Rules : Form
    {
        // Start rule window
        public Rules()
        {
            InitializeComponent();
        }

        // Anti close
        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
