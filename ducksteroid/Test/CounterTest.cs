using NUnit.Framework;
using System;
namespace MyGame.src
{
    [TestFixture ()]
    public class CounterTest
    {
        private Counter _count;

        [Test ()]
        public void TestInitCounter ()
        {
            _count = new Counter ();
            Assert.AreEqual (_count.Value, 0);
        }

        [Test ()]
        public void TestIncrement()
        {
            _count = new Counter ();
            _count.Increment ();
            Assert.AreEqual (_count.Value, 1);
        }

        [Test ()]
        public void TestReset()
        {
            _count = new Counter ();
            _count.Increment ();
            _count.Reset ();
            Assert.AreEqual (_count.Value, 0);
        }
    }
}
