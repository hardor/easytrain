using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Media;


namespace Raspisanie
{
    public class Music
    {
        [DllImport("winmm.dll")]
        public static extern long mciSendString(string strCommand, StringBuilder strReturn,
        int iReturnLength, IntPtr hwndCallback);

        private string sCommand = ""; 

        public void music_on()
        {
            sCommand = "open \"" + @"Voodoo People .mp3" + "\" type mpegvideo alias MediaFile";
            //посылаем команду
            mciSendString(sCommand, null, 0, IntPtr.Zero);
            //команда для воспроизведения файла
            sCommand = "play MediaFile";
            //посылаем команду
            mciSendString(sCommand, null, 0, IntPtr.Zero);
            
        }

        public void music_off()
        {
            mciSendString("stop MediaFile", null, 0, IntPtr.Zero);
            //// mciSendString("pause MediaFile", null, 1, IntPtr.Zero);
        }

    }
}
