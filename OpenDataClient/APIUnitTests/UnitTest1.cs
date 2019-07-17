using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIUnitTests
{
	[TestClass]
	public class UnitTest1
	{
		private const string uri = "http://testdate.gov.md/ckan/api/3/";

		[TestMethod]
		public void TestMethod1()
		{
			AGE.OpenData.Client client = new AGE.OpenData.Client(uri);
			Assert.AreEqual(uri, client.endpoint);
		}
	}
}
