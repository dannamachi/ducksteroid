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
            Assert.AreEqual (0, _count.Value);
        }

        [Test ()]
        public void TestIncrement()
        {
            _count = new Counter ();
            _count.Increment ();
            Assert.AreEqual (1, _count.Value);
        }

        [Test ()]
        public void TestReset()
        {
            _count = new Counter ();
            _count.Increment ();
            _count.Reset ();
            Assert.AreEqual (0, _count.Value);
        }
    }
}
