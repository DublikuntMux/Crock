using System.Windows.Forms;

namespace Crock
{
    public partial class Rules : Form
    {
        // Запус окна с правилами
        public Rules()
        {
            InitializeComponent();
        }

        // Анти закрытие
        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
