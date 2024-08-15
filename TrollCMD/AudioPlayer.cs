using WMPLib;
using System.IO;

public static class AudioPlayer
{
    private static WindowsMediaPlayer player = new WindowsMediaPlayer();

    public static void PlayAudio(byte[] audioData)
    {
        if (audioData == null || audioData.Length == 0)
        {
            throw new ArgumentException("Audio data cannot be null or empty", nameof(audioData));
        }

        // Save byte array to a temporary file
        string tempFilePath = Path.GetTempFileName() + ".mp3";
        File.WriteAllBytes(tempFilePath, audioData);

        player.URL = tempFilePath;
        player.controls.play();

        // Optionally delete the temporary file after playback
        // player.PlayStateChange += (state) =>
        // {
        //     if (state == (int)WMPPlayState.wmppsStopped)
        //     {
        //         File.Delete(tempFilePath);
        //     }
        // };
    }
}