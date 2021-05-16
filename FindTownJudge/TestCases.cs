using System;
using NUnit.Framework;

namespace FindTownJudge
{
    [TestFixture]
    public class TestCases
    {
        public readonly Program _program = new Program();
        
        [Test]
        public void TwoPeople_JudgeExists()
        {
            int n = 2;
            int[,] trust = new[,] { {1,2} };            
            int result = _program.FindTownJudge(n, trust);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void ThreePeople_JudgeExists()
        {
            int n = 3;
            int[,] trust = new[,] { {1,3}, {2,3} };
            int result = _program.FindTownJudge(n, trust);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void FourPeople_JudgeExists()
        {
            int n = 4;
            int[,] trust = new[,] { {1,3},{1,4},{2,3},{2,4},{4,3} };
            int result = _program.FindTownJudge(n, trust);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ThreePeople_JudgeDoesNotExist1()
        {
            int n = 3;
            int[,] trust = new[,] { {1,2}, {2,3} };
            int result = _program.FindTownJudge(n, trust);
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void ThreePeople_JudgeDoesNotExis2()
        {
            int n = 3;
            int[,] trust = new[,] { {1,3}, {2,3}, {3,1} };
            int result = _program.FindTownJudge(n, trust);
            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
