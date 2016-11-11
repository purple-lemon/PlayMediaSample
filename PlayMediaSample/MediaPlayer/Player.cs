using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
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
			try
			{
				var s = new VideoFileSource(path);
				var reader = new VideoFileReader();
				var uri = new Uri(path);
				reader.Open(uri.AbsolutePath);
				int framesToSkip = reader.FrameRate * 3600;
				var i = 0;

				while (true)
				{
					var screen = reader.ReadVideoFrame();
					Console.WriteLine(i);
					if (i % 25 == 0)
					{
						screen.Save(@"screen_" + i.ToString() + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
					}
					i++;
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
			try
			{
				var mp = new MediaPlayer();
				mp.Open(new Uri(path));
				var d = mp.NaturalDuration;
			}
			catch (Exception e)
			{

			}
		}
	}
}
