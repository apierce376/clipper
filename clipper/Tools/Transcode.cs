using System;
using System.IO;
using FFMpegCore;
using FFMpegCore.Enums;

namespace clipper.Tools;

public class Transcode
{
    public static void TranscodeVideo(String[] args)
    {
        if (args.Length != 4)
        {
            Console.WriteLine("Usage: clipper.exe transcode <video path> <output path> <codec>");
            return;
        }
        
        if (!File.Exists(args[1]))
        {
            Console.WriteLine("Video at path {0} does not exist", args[1]);
            return;
        }
        
        Codec codec = null;

        switch (args[3])
        {
            case "h264":
                codec = VideoCodec.LibX264;
                break;
            case "h265":
                codec = VideoCodec.LibX265;
                break;
            case "av1":
                codec = VideoCodec.LibaomAv1;
                break;
            default:
                Console.WriteLine("Invalid codec chosen. Valid options are H264, H265, and AV1");
                return;
        }

        FFMpegArguments
            .FromFileInput(args[1])
            .OutputToFile(args[2], true, options => options
                .WithVideoCodec(codec))
            .ProcessSynchronously();
    }
}