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
			var z = p.GetDurationMP(@"C:\Bogdan\Workfolder\tasks\Test Downloaded\G711M u-Law.WAV");
			var seconds = p.GetDuration(@"C:\Bogdan\Workfolder\tasks\Test Downloaded\G711M u-Law.WAV");
			seconds = p.GetDuration(@"C:\Bogdan\Workfolder\tasks\Test Downloaded\decScn.scn");
		}
	}
}
