using System;
using System.IO;
using FFMpegCore;

namespace clipper.Tools;

public class Shrink
{
    public static void ShrinkFile(string[] args)
    {
        if (args.Length != 4)
        {
            Console.WriteLine("Usage: clipper.exe shrink <video path> <output path> <shrink percentage>");
            return;
        }
        
        if (!File.Exists(args[1]))
        {
            Console.WriteLine("Video at path {0} does not exist", args[1]);
            return;
        }

        int shrinkPercentage;

        if (!int.TryParse(args[3], out shrinkPercentage))
        {
            Console.WriteLine("Invalid shrink percentage. Should be a whole number");
            return;
        }

        var mediaInfo = FFProbe.Analyse(args[1]);
        
        var newVideoBitRate = (int)(mediaInfo.PrimaryVideoStream.BitRate * shrinkPercentage / 100);
        var newAudioBitRate = (int)(mediaInfo.PrimaryAudioStream.BitRate * shrinkPercentage / 100);
        
        FFMpegArguments
            .FromFileInput(args[1])
            .OutputToFile(args[2], true, options => options
                .WithVideoBitrate(newVideoBitRate)
                .WithAudioBitrate(newAudioBitRate))
            .ProcessSynchronously();
    }
}