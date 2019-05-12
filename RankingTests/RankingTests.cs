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
        public void TestAddScore()
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
            StreamReader actual = rank.LoadFile("scorenope.txt");
            Assert.IsNull(actual, "Test ranking can load score from file");
        }
        [Test]
        public void TestGetContentFromFile()
        {
            Ranking rank = new Ranking();
            rank.LoadFile("scores.txt");
            rank.LoadFile("scores.txt");
            string line = rank.GetLine();
            string actual = "";
            while (line != null)
            {
                actual += line;
                line = rank.GetLine();
            }
            Assert.AreEqual("22015", actual, "Test ranking can print file content");
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
        [Test]
        public void TestSort()
        {
            Ranking rank = Setup();
            rank.Sort();
            bool actual = true;
            for (int i = 0; i < rank.Scores.Length; i++)
            {
                for (int j = i + 1; j < rank.Scores.Length; i++)
                {
                    if (rank.Scores[i].Value > rank.Scores[j].Value) { actual = false; break; }
                }
            }
            Assert.AreEqual(true, actual, "Test ranking can sort scores");
        }
        [Test]
        public void TestCheckScoreCount()
        {
            Ranking rank = Setup();
            Score score2 = new Score("ducktrial2", 15);
            Score score3 = new Score("ducktrial3", 2);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score2);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score2);
            int num = rank.Scores.Length;
            bool sorted = true;
            for (int i = 0; i < rank.Scores.Length; i++)
            {
                for (int j = i + 1; j < rank.Scores.Length; i++)
                {
                    if (rank.Scores[i].Value > rank.Scores[j].Value) { sorted = false; break; }
                }
            }
            bool actual = (num == 10) && sorted;
            Assert.AreEqual(true, actual, "Test ranking can add score with score count above 10");
        }
    }
}