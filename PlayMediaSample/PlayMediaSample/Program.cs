using PlayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMediaSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new Player();
			p.MPPlayAvi(@"F:\Distr\Interactions\2016101919312339601397088885502201.avi");
			p.MPPlayAvi(@"F:\Distr\Interactions\2016101223101001285500100000001002.wav");
		}
	}
}
