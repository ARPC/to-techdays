using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.String;

namespace CSharpFeaturesOverview
{
    [TestClass]
    public class UsingStaticDemo
    {
        [TestMethod]
        void CanCallStaticStringMethods()
        {
            bool result = IsNullOrEmpty("Hellow, World!");
            Assert.AreEqual(false, result);
        }
    }
}
