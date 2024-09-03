using WMPLib;
using System.IO;

namespace Tool
{
    public static class AudioPlayer
    {
        private static WindowsMediaPlayer player = new WindowsMediaPlayer();

        public static void PlayAudio(byte[] audioData)
        {
            if (audioData == null || audioData.Length == 0)
            {
                throw new ArgumentException("Audio data cannot be null or empty", nameof(audioData));
            }

            string tempFilePath = Path.GetTempFileName() + ".mp3";
            File.WriteAllBytes(tempFilePath, audioData);

            player.URL = tempFilePath;
            player.controls.play();
        }
    }
}