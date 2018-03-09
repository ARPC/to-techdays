using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    [TestClass]
    public class NullOperatorsDemo
    {
        //  ?. ,  ?[] and ??
        [TestMethod]
        public void NullConditionalOperatorDemo()
        {
            //string s1 = GimmeTheFirstFiveCharacters("Hello, World");
            //Assert.AreEqual("Hello", s1);

            string s2 = GimmeTheFirstFiveCharacters(null);
            Assert.AreEqual(null, s2);

            //  available as both a member operator (?.) and an index operator (?[…])
        }

        //  ??
        [TestMethod]
        public void NullCoalescingOperatorDemo()
        {
            string s1 = GimmeMeTheArgumentOrDefault("Hello, World!");
            Assert.AreEqual("Hello, World!", s1);

            string s2 = GimmeMeTheArgumentOrDefault(null);
            Assert.AreEqual("Default", s2);
        }

        public string GimmeTheFirstFiveCharacters(string s)
        {
            //  Null conditional operator
            //  equivalent to s != null ? s.Substring(0, 5) : s

            return s?.Substring(0, 5).Substring(0, 5) + "Hello!";
        }

        public string GimmeMeTheArgumentOrDefault(string s)
        {
            //  null coalescing operator
            //  equivalent to s != null ? s :"Default"
            return s ?? "Default";
        }
    }
}
