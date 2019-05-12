using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System;

namespace Tests
{
    public class RankingTests
    {
        public Ranking Setup()
        {
            Ranking rank = new Ranking();
            Score score1 = new Score("ducktrial1", 20);
            Score score2 = new Score("ducktrial2", 15);
            Score score3 = new Score("ducktrial3", 2);
            Score score4 = new Score("ducktrial4", 15);
            rank.AddScore(score1);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score4);
            return rank;
        }

        [Test]
        public void TestGetScore()
        {
            Ranking rank = new Ranking();
            Score score1 = new Score("ducktrial1", 20);
            Score score2 = new Score("ducktrial2", 15);
            rank.AddScore(score1);
            rank.AddScore(score2);

            bool actual = rank.Scores.Contains(score2);
            Assert.AreEqual(true, actual, "Test ranking can add score");
        }
        [Test]
        public void TestLoadFileFalse()
        {
            Ranking rank = new Ranking();
            bool actual = rank.LoadFile("scorenope.txt");
            Assert.AreEqual(false, actual, "Test ranking can load score from file");
        }
        [Test]
        public void TestLoadFileTrue()
        {
            Ranking rank = new Ranking();
            rank.LoadFile("scores.txt");
            bool actual = (rank.Scores.Length == 2);
            Assert.AreEqual(true, actual, "Test ranking can load score from file");
        }
        [Test]
        public void TestSaveFile1()
        {
            Ranking rank = Setup();
            rank.SaveFile("scores.txt");
            StreamReader reader = new StreamReader("scores.txt");
            int actual = Convert.ToInt32(reader.ReadLine());
            Assert.AreEqual(2, actual, "Test ranking can save to file");
        }
        [Test]
        public void TestSaveFile2()
        {
            Ranking rank = Setup();
            rank.SaveFile("scores.txt");
            StreamReader reader = new StreamReader("scores.txt");
            reader.ReadLine();
            reader.ReadLine();
            int actual = Convert.ToInt32(reader.ReadLine());
            Assert.AreEqual(15, actual, "Test ranking can save to file");
        }
    }
}