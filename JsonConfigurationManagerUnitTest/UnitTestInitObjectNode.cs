using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonConfigurationManager;

namespace JsonConfigurationManagerUnitTest
{
    class TestClass2 : InitObjectNode
    {
        public TestClass2() { }
        public TestClass2(Type t) : base(t) { }
        public TestClass2(string s) : base(s) { }
    }

    [TestClass]
    public class UnitTestInitObjectNode
    {
        [TestMethod]
        public void TestMethod1()
        {
            var typeStr = new TestClass2(typeof(TestClass2)).TypeName;
            new TestClass2(typeStr);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var typeStr = nameof(JsonConfigurationManagerUnitTest) + "." + nameof(TestClass2);
            new TestClass2(typeStr);
        }

    }
}
