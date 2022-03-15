using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Crock
{
    class Misc
    {
        // Registration DLL
        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);
        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        // Getting the path to a file
        public static string MyLocation()
        {
            return System.Reflection.Assembly.GetEntryAssembly()?.Location;
        }

        // Clearing the screen from GDI effects
        public static void Clear_screen()
        {
            for (var num = 0; num < 10; num++)
            {
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                Thread.Sleep(10);
            }
        }
    }
}
