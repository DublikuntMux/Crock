using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace VirsCh
{
    class Misc
    {
        // Регистрация DLL
        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        // Получение пути к файлу
        static public string MyLoacation()
        {
            return System.Reflection.Assembly.GetEntryAssembly().Location;
        }

        // Очстка экрана от GDI эфектов
        public static void clear_screen()
        {
            for (int num = 0; num < 10; num++)
            {
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                Thread.Sleep(10);
            }
        }
    }
}
