using System;
using clipper.Tools;

namespace  clipper
{
	class MainClass
	{
		private static string tutorialText = "Valid arguments are clip, transcode, shrink, extractaudio, mute";
		
		public static void Main(string[] args)
		{
			
			if (args.Length == 0)
			{
				Console.WriteLine(tutorialText);
			}
			switch (args[0])
			{
				case "clip":
					Clip.ClipVideo(args);
					break;
				case "transcode":
					Transcode.TranscodeVideo(args);
					break;
				case "shrink":
					Shrink.ShrinkFile(args);
					break;
				case "extractaudio":
					ExtractAudio.ExtractAudioFromVideo(args);
					break;
				case "mute":
					Mute.MuteAudio(args);
					break;
				default:
					Console.WriteLine(tutorialText);
					break;
			}
		}
	}
}