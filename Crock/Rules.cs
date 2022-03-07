using System.Threading;
using System.Windows.Forms;

namespace Crock
{
    public partial class Rules : Form
    {
        // Запус окна с правилами
        public Rules()
        {
            InitializeComponent();
            new Thread(() => FakeProgress()).Start();
        }

        // Анти закрытие
        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        //Фейковй удоление системы
        private void FakeProgress()
        {
            progressBar1.Value++;
            Thread.Sleep(3600);
        }
    }
}
