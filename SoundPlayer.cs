using System;
using System.IO;
using NAudio.Wave;

class SoundPlayer
{
    WaveOutEvent outputDevice;
    public SoundPlayer()
    {
    }

    public void Play(string filePath, float volume = 0.005f)
    {
        filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\" + filePath;
        var reader = new Mp3FileReader(filePath);
        var waveOut = new WaveOutEvent();
        waveOut.Volume = volume;
        waveOut.Init(reader);
        waveOut.Play();
    }

    public void Stop()
    {
        using (outputDevice)
        {
            outputDevice.Stop();
        }
    }
}