using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PlayerLib
{
	public class Player
	{
		public void PlayAvi(string path, bool saveScreen = false)
		{
			var i = 0;
			try
			{
				var s = new VideoFileSource(path);
				var reader = new VideoFileReader();
				var uri = new Uri(path);
				reader.Open(uri.AbsolutePath);
				int framesToSkip = reader.FrameRate * 3600;

				var seconds = reader.FrameCount / reader.FrameRate;
				
				for (i = 0; i < reader.FrameCount; i++)
				{
					try
					{
						var screen = reader.ReadVideoFrame();
						Console.WriteLine(i);
						if (i % 25 == 0)
						{
							screen.Save(@"screen_" + i.ToString() + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
						}
					} catch { }
				}
			}
			catch (Exception e)
			{

			}
			finally
			{
			}
		}

		public void MPPlayAvi(string path, bool saveScreen = false)
		{
			var mp = new MediaPlayer();
			try
			{
				
				mp.Open(new Uri(path));
				
				mp.Play();

				while (true)
				{
					Thread.Sleep(10000);
				}
			}
			catch (Exception e)
			{

			}
			finally
			{
				mp.Close();
			}
		}

		public long GetDuration(string path)
		{
			var s = new VideoFileSource(path);
			var reader = new VideoFileReader();
			var uri = new Uri(path);
			var fi = new FileInfo(path);
			if (fi.Exists)
			{
				reader.Open(path);
				var seconds = reader.FrameCount / reader.FrameRate;
				return seconds;
			}
			return -1;
		}

		public long GetDurationMP(string path)
		{
			MediaPlayer mp = new MediaPlayer();
			try
			{
				var uri = new Uri(path);
				mp.Open(uri);
				var d = mp.NaturalDuration.TimeSpan.TotalSeconds;
				return (long)d;
			}
			finally
			{
				if (mp != null)
				{
					mp.Close();
				}
			}
		}

	}
}
