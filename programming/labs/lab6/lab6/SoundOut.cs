using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class SoundOut
    {
        public static void PlayWavFile(string soundFilePath)
        {
            string fullPath = Path.Combine(@"C:\Users\REDMI\university\programming\labs\lab6\lab6\", soundFilePath);
            SoundPlayer player = new SoundPlayer(fullPath);
            player.Play();
        }
    }
}
