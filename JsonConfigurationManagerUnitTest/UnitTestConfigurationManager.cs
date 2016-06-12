using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonConfigurationManager;

namespace JsonConfigurationManagerUnitTest
{
    class TestClass1
    {
        public bool hasRunConfigurationInit = false;

        public void ConfigurationInit()
        {
            hasRunConfigurationInit = true;
        }
    }

    [TestClass]
    public class UnitTestConfigurationManagerAuto
    {
        [TestInitialize]
        public void init()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            var obj = ConfigurationManagerAuto.GetConfiguration<TestClass1>();
            Assert.AreEqual(true, obj.hasRunConfigurationInit);
        }


        [TestMethod]
        public void TestMethod2()
        {
            bool test = true;
            var obj1 = ConfigurationManagerAuto.GetConfiguration<TestClass1>("", out test);
            Assert.AreEqual(true, obj1.hasRunConfigurationInit, "test1");

            // test = false;
            // var obj2 = ConfigurationManagerAuto.GetConfiguration<TestClass1>("", out test);
            // Assert.AreEqual(true, obj2.hasRunConfigurationInit, "test2");
        }



    }
}
