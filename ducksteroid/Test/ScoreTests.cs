using NUnit.Framework;
using System.Collections.Generic;
using System;
using MyGame.src;

namespace Tests
{
    public class ScoreTests
    {

        [Test]
        public void TestContainsCounter()
        {
            Score One = new Score(0);
            int a = 0;
            Assert.AreEqual(a, One.Value);
        }
        [Test]
        public void TestValue()
        {
            Score start = new Score(40);
           
            Assert.AreEqual(40, start.Value);
        }
        [Test]
        public void TestMultipleScores()
        {
            Score start = new Score(20);
            Score second = new Score(20);
            Assert.AreEqual(second.Value , start.Value);
        }
        [Test]
        public void TestScoreIs0()
        {
            Score start = new Score(0);

            Assert.AreEqual(0, start.Value);
        }
        [Test]
        public void TestScoreIs10()
        {
            Score start = new Score(20);
            Score changed = new Score(start.Value - 10);

            Assert.AreEqual(10, changed.Value);
        }
 
    }

}
