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
			var p = new Player();
			//var z = p.GetDurationMP(@"C:\Bogdan\Workfolder\tasks\Test Downloaded\G711M u-Law.WAV");

			foreach (var k in ConfigurationManager.AppSettings.AllKeys)
			{
				p.PlayWMP(ConfigurationManager.AppSettings[k]);
				Console.ReadLine();
			}
		}
	}
}
