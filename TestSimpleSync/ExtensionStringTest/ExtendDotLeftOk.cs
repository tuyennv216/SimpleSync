using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimpleSync.TestExtensionString
{
	[TestClass]
	public class ExtendDotLeftOk
	{
		[TestMethod]
		public void EqualLength()
		{
			var width = 10;
			var str = "1234567890";
			var expect = "1234567890";
			var actual = str.ExtendDotLeft(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void Smaller()
		{
			var width = 10;
			var str = "123456789";
			var expect = "123456789";
			var actual = str.ExtendDotLeft(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void Large1()
		{
			var width = 10;
			var str = "12345678901";
			var expect = "...5678901";
			var actual = str.ExtendDotLeft(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void Large2()
		{
			var width = 10;
			var str = "123456789012";
			var expect = "...6789012";
			var actual = str.ExtendDotLeft(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void Large3()
		{
			var width = 10;
			var str = "1234567890123";
			var expect = "...7890123";
			var actual = str.ExtendDotLeft(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void Large4()
		{
			var width = 10;
			var str = "12345678901234";
			var expect = "...8901234";
			var actual = str.ExtendDotLeft(width);
			Assert.AreEqual(expect, actual);
		}

	}
}