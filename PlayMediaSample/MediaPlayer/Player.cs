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
using System.Windows.Media.Imaging;

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

					//using (WasapiCapture capture = new WasapiLoopbackCapture())
					//{
					//	capture.Initialize();
					//	using (WaveWriter wave = new WaveWriter(ms, capture.WaveFormat))
					//	{
					//		capture.DataAvailable += (s, e) =>
					//		{
					//			wave.Write(e.Data, e.Offset, e.ByteCount);
					//		};

					//		capture.Start();
					//		Thread.Sleep(10 * 1000);
					//		capture.Stop();
					//	}
					//}
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
				mp.Play();
				SavePlayerFrame(mp);
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

			return (long)0;
		}

		public void SavePlayerFrame(MediaPlayer mediaPlayer)

		{

			DrawingVisual drawingVisual = new DrawingVisual();

			DrawingContext drawingContext = drawingVisual.RenderOpen();

			drawingContext.DrawVideo(mediaPlayer, new Rect(0, 0, mediaPlayer.NaturalVideoWidth, mediaPlayer.NaturalVideoHeight));

			drawingContext.Close();

			RenderTargetBitmap bmp = new RenderTargetBitmap(mediaPlayer.NaturalVideoWidth, mediaPlayer.NaturalVideoHeight, 120, 96, PixelFormats.Pbgra32);

			bmp.Render(drawingVisual);
			System.Windows.Media.Imaging.BitmapImage img = new BitmapImage();

			var bitmapImage = new BitmapImage();
			var bitmapEncoder = new PngBitmapEncoder();
			bitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));

			using (var stream = new MemoryStream())
			{
				bitmapEncoder.Save(stream);
				stream.Seek(0, SeekOrigin.Begin);

				bitmapImage.BeginInit();
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.StreamSource = stream;
				bitmapImage.EndInit();
			}

			JpegBitmapEncoder encoder = new JpegBitmapEncoder();
			Guid photoID = System.Guid.NewGuid();
			String photolocation = photoID.ToString() + ".jpg";  //file name 

			encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

			using (var filestream = new FileStream(photolocation, FileMode.Create))
				encoder.Save(filestream);
			// Add Image to the UI

		}

	}
}
