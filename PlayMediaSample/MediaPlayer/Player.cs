using Accord.Video.FFMPEG;
using CSCore.Codecs.WAV;
using CSCore.SoundIn;
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

		public void PlayWMP(string path)
		{
			MediaPlayer mp = new MediaPlayer();
			try
			{
				var uri = new Uri(path);
				mp.Open(uri);
				// sleep recomended to make sure it was time to open file
				Thread.Sleep(3000);
				mp.Play();
				using (var ms = new MemoryStream())
				{

					using (WasapiCapture capture = new WasapiLoopbackCapture())
					{
						capture.Initialize();
						using (WaveWriter wave = new WaveWriter(ms, capture.WaveFormat))
						{
							capture.DataAvailable += (s, e) =>
							{
								wave.Write(e.Data, e.Offset, e.ByteCount);
							};

							capture.Start();
							Thread.Sleep(10 * 1000);
							capture.Stop();
						}
					}
					mp.Stop();
					ms.Flush();
					var buffer = new ArraySegment<byte>();
					if (ms.TryGetBuffer(out buffer))
					{
						if (buffer.Count > 44)
						{

						}
						else
						{

						}
					} else
					{

					}
				}

			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (mp != null)
				{
					mp.Stop();
					mp.Close();
					mp = null;
				}
			}
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
					mp.Stop();
					mp.Close();
					mp = null;
				}
			}
		}

	}
}
