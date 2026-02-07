# Clipper
A command line tool for basic video file manipulation using FFMpeg. It currently supports clipping, transcoding, reducing file sizes, extracting audio and muting audio.

## Usage
Clipper is run through the command line and supports the following commands

- Clip: takes an input file path and outputs a file trimmed to the given start and end time

  `clipper.exe clip <video path> <output path> <start time> <end time>`

- Transcode: takes an input file and outputs a new file in another codec (H264, H265, AV1)
  
  `clipper.exe transcode <video path> <output path> <codec>`

- Shrink: takes an input file and reduces the bitrate by the given percentage

  `clipper.exe shrink <video path> <output path> <shrink percentage>`

- Extract Audio: takes an input file and outputs only the audio from it

  `clipper.exe extractaudio <video path> <output path>`

- Mute: takes an input file and outputs a video file without audio

  `clipper.exe mute <video path> <output path>`

## Setup
This project does *NOT* include FFMpeg or FFProbe binaries and they must be downloaded separately. `ffmpeg.exe` and `ffprobe.exe` can be downloaded from [FFBinaries](https://ffbinaries.com/downloads) and they should be placed in the same directory as `clipper.exe` before running.

## Building
The project can be built with `dotnet build`
