using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnitityLocator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Locator.Instance.Locate("CC");
        }
    }
}
