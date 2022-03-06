using System;
using System.Windows.Forms;

namespace VirsCh
{
    public partial class Rules : Form
    {
        // Запус окна с правилами
        public Rules()
        {
            InitializeComponent();
            FakeProgress.Start();
        }

        // Анти закрытие
        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        // Фейковый прогресс бар
        private void FakeProgress_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
        }
    }
}
