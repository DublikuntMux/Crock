using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace VirsCh
{
    class Misc
    {
        static public string MyLoacation()
        {
            return System.Reflection.Assembly.GetEntryAssembly().Location;
        }

        static public void DownloadFileUrl(string URL, string patch)
        {
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(URL, patch);
        }

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

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
