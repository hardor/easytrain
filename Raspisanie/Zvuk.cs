using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Raspisanie
{
    public class Zvuk
    {
        ///////////////////////////////////////////////////////////////////////////////
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public void zvukon1()
        {
            int NewVolume;
            // By the default set the volume to 0
            uint CurrVol = 0;
            // At this point, CurrVol gets assigned the volume
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            // Calculate the volume
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            // Get the volume on a scale of 1 to 10 (to fit the trackbar)
            NewVolume = CalcVol;

            //увеличиваем
            if (NewVolume < ushort.MaxValue - 1000)
                NewVolume += 1000;
            else MessageBox.Show("За пределами диапазона");

            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        //уменьшаем звук
        public void zvukoff1()
        {
            int NewVolume;
            // By the default set the volume to 0
            uint CurrVol = 0;
            // At this point, CurrVol gets assigned the volume
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            // Calculate the volume
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            // Get the volume on a scale of 1 to 10 (to fit the trackbar)
            NewVolume = CalcVol;

            //уменьшаем
            if (NewVolume > ushort.MinValue + 1000)
                NewVolume -= 1000;
            else MessageBox.Show("За пределами диапазона");

            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }
        // выключение звука
        //public void off1()
        //{
        //    waveOutSetVolume(IntPtr.Zero, 0);
        //}
    }
}
