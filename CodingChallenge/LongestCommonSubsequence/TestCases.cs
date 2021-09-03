using System;
using NUnit.Framework;

/*
    In VS Code run "dotnet test"
    OR  dotnet test --logger:"console;verbosity=normal" to capture run time.
*/

namespace LongestCommonSubsequence
{
    [TestFixture]
    public class TestCases
    {
        public readonly Program _program = new Program();

        [TestCase("abcde", "abcde", 5)]
        [TestCase("abcde", "ace", 3)]
        [TestCase("abcde", "bde", 3)]
        [TestCase("abcde", "a", 1)]
        [TestCase("abcde", "xaax", 1)]
        [TestCase("abcde", "xaex", 2)]
        [TestCase("abcde", "xaex", 2)]
        [TestCase("abcde", "edcba", 1)]
        [TestCase("abcde", "xyz", 0)]
        [TestCase("", "", 0)]
        public void TestMe(string text1, string text2, int expected)
        {
            int result = _program.LongestCommonSubsequence(text1, text2);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void BenchmarkMe()
        {
            const string text1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            const string text2 = "Duis reprehenderit velit esse cillum dolore. cupidatat non proident, sunt in culpa. Lorem ipsum dolor sit amet, consectetur adipiscing elit, , sunt in culpa qui officia, sit amet, consectetur adipiscing elit, , quis nostrud exercitation. . Excepteur sint occaecat eu fugiat nulla pariatur, excepteur sint occaecat cupidatat non proident, sunt in culpa. Ut enim ad minim veniam, eu fugiat nulla pariatur, sunt in culpa qui officia id est laborum.";
            int result = _program.LongestCommonSubsequence(text1, text2);
            Assert.That(result, Is.EqualTo(250));
        }
    }
}
