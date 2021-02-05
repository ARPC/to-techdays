using System;
using NUnit.Framework;

namespace RainWater
{
    [TestFixture]
    public class TestCases
    {
        public readonly Program _program = new Program();
        
        [Test]
        public void Example1()
        {
            int result = _program.Trap(new int[] {0,1,0,2,1,0,1,3,2,1,2,1});
            Assert.That(result, Is.EqualTo(6));
        }
        
        [Test]
        public void Example2()
        {
            int result = _program.Trap(new int[] {4,2,0,3,2,5});
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void Example3()
        {
            int result = _program.Trap(new int[] {4,2,0,5,5,3});
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Example4()
        {
            int result = _program.Trap(new int[] {0,1,2,1,2,1,2,3,4,3,2,1,2,0});
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Example5()
        {
            int result = _program.Trap(new int[] {5,0,5,5,5,5,1,5,5,2,5,5});
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Example6()
        {
            int result = _program.Trap(new int[] {1,2,3,4,5,4,3,4,5,5,4,3,2,1,2,3});
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Example7()
        {
            int result = _program.Trap(new int[] {5,5,5,5,5});
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
