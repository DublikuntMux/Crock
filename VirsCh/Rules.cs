using System;
using System.Windows.Forms;

namespace VirsCh
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
            FakeProgress.Start();
        }

        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void FakeProgress_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
        }
    }
}
