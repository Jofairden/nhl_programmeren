using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Programmeren2Opdrachten
{
	internal class TestDll
	{
		[Test]
		public void TestDLL()
		{
			Version opdrachtVersion = Assembly.GetExecutingAssembly().GetName().Version;
			Assembly assembly = Assembly.LoadFrom("Programmeren2Tests.dll");
			Version testVersion = assembly.GetName().Version;

			Assert.AreEqual(opdrachtVersion, testVersion);
		}
	}
}
