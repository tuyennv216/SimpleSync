using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimpleSync.TestExtensionConvert
{
	[TestClass]
	public class ToIntNg
	{
		[TestMethod]
		public void OnlyAnphabet()
		{
			var str = "abcde";
			var expect = 0;
			var actual = str.ToInt();
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void StatWithAnphabet()
		{
			var str = "a123";
			var expect = 0;
			var actual = str.ToInt();
			Assert.AreEqual(expect, actual);
		}
	}
}
