using PlayerLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMediaSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var pathToFile = ConfigurationManager.AppSettings[0];
			var p = new Player();
			Console.WriteLine("duration: " + p.GetDurationMP(pathToFile));
			p.SaveFrameAtSecond(pathToFile, 0);
			var snapshot = p.GetFrameAtSecond(pathToFile, 0);
		}
	}
}
