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
			p.PlayAvi(@"F:\Distr\Interactions\2016101919312339601397088885502201.avi");
			p.PlayAvi(@"F:\Distr\Interactions\2016102623103122885500100000001802.avi");
		}
	}
}
