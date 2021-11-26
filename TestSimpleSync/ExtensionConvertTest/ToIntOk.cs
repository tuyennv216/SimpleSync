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
	public class ToIntOk
	{
		[TestMethod]
		public void Normal()
		{
			var str = "123";
			var expect = 123;
			var actual = str.ToInt();
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void PaddingLeft()
		{
			var str = "  123";
			var expect = 123;
			var actual = str.ToInt();
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void PaddingRight()
		{
			var str = "123  ";
			var expect = 123;
			var actual = str.ToInt();
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void PaddingAround()
		{
			var str = "  123  ";
			var expect = 123;
			var actual = str.ToInt();
			Assert.AreEqual(expect, actual);
		}

		[TestMethod]
		public void CutBeforePoint()
		{
			var str = "123.456";
			var expect = 123;
			var actual = str.ToInt();
			Assert.AreEqual(expect, actual);
		}

	}
}
