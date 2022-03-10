using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Crock
{
    class Misc
    {
        // Регистрация DLL
        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);
        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        // Получение пути к файлу
        public static string MyLoacation()
        {
            return System.Reflection.Assembly.GetEntryAssembly().Location;
        }

        // Очстка экрана от GDI эфектов
        public static void Clear_screen()
        {
            for (int num = 0; num < 10; num++)
            {
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                Thread.Sleep(10);
            }
        }
    }
}
