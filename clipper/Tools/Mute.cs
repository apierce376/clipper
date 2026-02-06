using System;
using System.IO;
using FFMpegCore;
using FFMpegCore.Enums;

namespace clipper.Tools;

public class Mute
{
    public static void MuteAudio(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: clipper.exe mute <video path> <output path>");
            return;
        }
        
        if (!File.Exists(args[1]))
        {
            Console.WriteLine("Video at path {0} does not exist", args[1]);
            return;
        }
        
        FFMpegArguments
            .FromFileInput(args[1])
            .OutputToFile(args[2], true, options => options
                .DisableChannel(Channel.Audio))
            .ProcessSynchronously();
    }
}