using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    [TestClass]
    public class CSharp4
    {
        [TestMethod]
        public void DynamicDemo()
        {
            dynamic example = new ExampleClass();
            example.ThisMethidDoesNotExist();   //  no compilation error
        }

        [TestMethod]
        public void NamedArgumentsDemo()
        {
            ExampleClass example = new ExampleClass();
            string s = example.PrintSecondArgument(
                s2: "Second argument",
                s1: "First argument");
            Assert.AreEqual(s, "Second argument");
        }

        [TestMethod]
        public void OptionalParametersDemo()
        {
            ExampleClass example = new ExampleClass();
            string s = example.Print("test");
            Assert.AreEqual(s, "Hello, World!");
        }
    }

    class ExampleClass
    {
        public string Print(string s = "Hello, World!")
        {
            return s;
        }

        public string PrintSecondArgument(string s1, string s2)
        {
            return s2;
        }
    }
}
