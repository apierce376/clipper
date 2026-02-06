using System;
using System.IO;
using FFMpegCore;

namespace clipper.Tools;

public class Clip
{
    public static void ClipVideo(String[] args)
    {
        if (args.Length != 5)
        {
            Console.WriteLine("Usage: clipper.exe clip <video path> <output path> <start time> <end time>");
            return;
        }
        
        if (!File.Exists(args[1]))
        {
                Console.WriteLine("Video at path {0} does not exist", args[1]);
                return;
        }
            
        var startTime = MatchTime(args[3]);
        var endTime = MatchTime(args[4]);

        if (startTime == TimeSpan.MinValue || endTime == TimeSpan.MinValue)
        {
            return;
        }

        if (startTime > endTime)
        {
            Console.WriteLine("Start time must be before end time");
            return;
        }
        
        FFMpeg.SubVideo(args[1], args[2], startTime, endTime);
    }

    private static TimeSpan MatchTime(string s)
    {
        var minutes = 0;
        var seconds = 0;
        var milliseconds = 0;

        var split = s.Split([':', '.']);

        try
        {
            if (split.Length == 3)
            {
                minutes = int.Parse(split[0]);
                seconds = int.Parse(split[1]);
                milliseconds = int.Parse(split[2]);
            }
            else if (split.Length == 2)
            {
                if (s.Contains(":"))
                {
                    minutes = int.Parse(split[0]);
                    seconds = int.Parse(split[1]);
                }
                else
                {
                    seconds = int.Parse(split[0]);
                    milliseconds = int.Parse(split[1]);
                }
            }
            else
            {
                seconds = int.Parse(split[0]);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Time should be formatted as (minutes):(seconds).(milliseconds)");
            return TimeSpan.MinValue;
        }

        return new TimeSpan(0, 0, minutes, seconds, milliseconds);
    }
}