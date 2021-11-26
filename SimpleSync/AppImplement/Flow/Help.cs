using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSync.Flow
{
	public class Help
	{
		private static Help instance = new Help();
		public static Help i => instance;

		private Help() { }
		public void DisplayGuide()
		{
			Console.WriteLine();
			Console.WriteLine("Simple sync is a data backup application which help you synchronize files and folders");
			Console.WriteLine();
			Console.WriteLine("Usage:");
			Console.WriteLine("\t" + RunningExe.i.FullName + @" folder='source_folder' level='deep_level' savepath='save_folder'");
			Console.WriteLine();
			Console.WriteLine("Example:");
			Console.WriteLine("\t" + RunningExe.i.FullName + @" folder='E:\folder1' level=2 savepath='E:\backup1'");
			Console.WriteLine();
		}
		public void DisplayStatus()
		{
			Console.WriteLine();
			Console.WriteLine("Simple sync is a data backup application which help you synchronize files and folders");
			Console.WriteLine();
			Console.WriteLine("Usage:");
			Console.WriteLine("\t" + RunningExe.i.FullName + @" folder='source_folder' level='deep_level' savepath='save_folder'");
			Console.WriteLine();
			Console.WriteLine("Example:");
			Console.WriteLine("\t" + RunningExe.i.FullName + @" folder='E:\folder1' level=2 savepath='E:\backup1'");
			Console.WriteLine();
		}
		public void DisplayVersion()
		{
			Console.WriteLine("Current version is " + App.Version);
		}
	}
}
