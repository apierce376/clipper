using System;
using System.IO;
using FFMpegCore;

namespace clipper.Tools;

public class ExtractAudio
{
    public static void ExtractAudioFromVideo(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: clipper.exe extractaudio <video path> <output path>");
            return;
        }
        
        if (!File.Exists(args[1]))
        {
            Console.WriteLine("Video at path {0} does not exist", args[1]);
            return;
        }
        
        FFMpeg.ExtractAudio(args[1], args[2]);
    }
}