using System;
using NUnit.Framework;

/*
    In VS Code run dotnet test --logger:"console;verbosity=normal" to capture run time.
*/

namespace DecodeWays
{
    [TestFixture]
    public class TestCases
    {
        public readonly Program _program = new Program();

        [TestCase("1", 1)]           //  A or 1
        [TestCase("27", 1)]          //  BG or 27
        [TestCase("25", 2)]          //  BE, Y or 25 | 2,5 
        [TestCase("2525", 4)]        //  BEBE, YBE, BEY, YY or 2,5,2,5 | 25,2,5 | 2,5,25 | 25,25
        [TestCase("2222", 5)]        //  BBBB, VBB, BVB, BBV, VV or 2,2,2,2 | 22,2,2 | 2,22,2 | 2,2,22 | 22,22
        [TestCase("22722722", 8)]
        [TestCase("1202121210", 8)]
        [TestCase("1302121210", 0)]  //  30 - no way to decode
        [TestCase("012345", 0)]      //  leading zero - no way to decode
        [TestCase("0", 0)]           //  leading zero - no way to decode
        public void TestMe(string input, int expected)
        {
            int result = _program.NumDecodings(input);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void BenchmarkMe()
        {
            const string input = "12121212121212121212121212121212121212121212";
            int result = _program.NumDecodings(input);
            Assert.That(result, Is.EqualTo(1134903170));
        }
    }
}
