using NUnit.Framework;
using System;
using MyGame;

namespace Tests
{
    [TestFixture ()]
    public class TimerTest
    {
        private Timer _timer;

        [Test ()]
        public void TestInitTimer ()
        {
            _timer = new Timer ();
            string testString = _timer.TimeToString ();
            Assert.AreEqual ("00:00", testString);
        }

        [Test ()]
        public void TestTickTimer ()
        {
            _timer = new Timer ();
            for (int i = 0; i < 60; i++) {
                _timer.Tick ();
            }
            string testString = _timer.TimeToString ();
            Assert.AreEqual ("00:01", testString);
        }

        [Test ()]
        public void TestLessThanOneMinute ()
        {
            _timer = new Timer ();
            for (int i = 0; i < 3000; i++) {
                _timer.Tick ();
            }
            string testString = _timer.TimeToString ();
            Assert.AreEqual ("00:50", testString);
        }

        [Test ()]
        public void TestOneMinute ()
        {
            _timer = new Timer ();
            for(int i=0; i < 3600; i++) {
                _timer.Tick ();
            }
            string testString = _timer.TimeToString ();
            Assert.AreEqual ("01:00", testString);
        }

        [Test ()]
        public void TestTenMinutes ()
        {
            _timer = new Timer ();
            for (int i = 0; i < 36000; i++) {
                _timer.Tick ();
            }
            string testString = _timer.TimeToString ();
            Assert.AreEqual ("10:00", testString);
        }

        [Test ()]
        public void TestOneHour ()
        {
            _timer = new Timer ();
            for (int i = 0; i < 216000; i++) {
                _timer.Tick ();
            }
            string testString = _timer.TimeToString ();
            Assert.AreEqual ("01:00:00", testString);
        }

    }
}
