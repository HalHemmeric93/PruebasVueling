using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System.Configuration;
using Control;

namespace UnitTestPruebasVueling
{
    [TestClass]
    public class UnitTestExamen1
    {
        static public Container container;
        public UnitTestExamen1()
        {
            container = new Container();
            container.Register<IControlExamen1, ControlExamen1>();
            container.Verify();
        }

        [TestMethod]
        public void TestMethodDivisbleTres()
        {
            var control = container.GetInstance<IControlExamen1>();
            Assert.IsTrue(control.DivisbleTres(3));
        }
        [TestMethod]
        public void TestMethodDivisbleCinco()
        {
            var control = container.GetInstance<IControlExamen1>();
            Assert.IsTrue(control.DivisbleCinco(5));
        }
       
    }
}
