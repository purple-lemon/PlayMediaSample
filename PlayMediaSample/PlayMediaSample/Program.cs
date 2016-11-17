﻿using PlayerLib;
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
				var value = ConfigurationManager.AppSettings[k];
				p.SaveFrameAtSecond(value, 0);
				p.SaveFrameAtSecond(value, 1);
				p.SaveFrameAtSecond(value, 2);
				p.SaveFrameAtSecond(value, 3);
				Console.ReadLine();
			}
		}
	}
}
