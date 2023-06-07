using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            login forUser = new Auth();
            var actual = forUser.authU("lee", "2");
            var expected = "Успешно!";
            Assert.AreEqual(expected, actual);
        }
    }
}
