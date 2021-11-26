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
	public class PadAroundOk
	{
		[TestMethod]
		public void EqualLength()
		{
			var width = 10;
			var str = "1234567890";
			var expect = "1234567890";
			var actual = str.PadAround(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void Larger()
		{
			var width = 10;
			var str = "12345678901";
			var expect = "12345678901";
			var actual = str.PadAround(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void DefaultSmaller1()
		{
			var width = 10;
			var str = "123456789";
			var expect = "123456789 ";
			var actual = str.PadAround(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void DefaultSmaller2()
		{
			var width = 10;
			var str = "12345678";
			var expect = " 12345678 ";
			var actual = str.PadAround(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void DefaultSmaller3()
		{
			var width = 10;
			var str = "1234567";
			var expect = " 1234567  ";
			var actual = str.PadAround(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void DefaultSmaller4()
		{
			var width = 10;
			var str = "123456";
			var expect = "  123456  ";
			var actual = str.PadAround(width);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void OtherSmaller1()
		{
			var width = 10;
			var padCharacter = '#';
			var str = "123456789";
			var expect = "123456789#";
			var actual = str.PadAround(width, padCharacter);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void OtherSmaller2()
		{
			var width = 10;
			var padCharacter = '~';
			var str = "12345678";
			var expect = "~12345678~";
			var actual = str.PadAround(width, padCharacter);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void OtherSmaller3()
		{
			var width = 10;
			var padCharacter = '!';
			var str = "1234567";
			var expect = "!1234567!!";
			var actual = str.PadAround(width, padCharacter);
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void OtherSmaller4()
		{
			var width = 10;
			var padCharacter = '@';
			var str = "123456";
			var expect = "@@123456@@";
			var actual = str.PadAround(width, padCharacter);
			Assert.AreEqual(expect, actual);
		}

	}
}