using NUnit.Framework;
using System.Collections.Generic;
using System;
using MyGame.src;

namespace Tests
{
    public class RankingTests
    {
        //set-up method to return a ranking obj with 4 scores in it
        public Ranking Setup()
        {
            Ranking rank = new Ranking();
            Score score1 = new Score(20);
            Score score2 = new Score(15);
            Score score3 = new Score(2);
            Score score4 = new Score(15);
            rank.AddScore(score1);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score4);
            return rank;
        }

        //test: check if ranking adds the correct score
        //expected: contain the correct score reference (true)
        [Test]
        public void TestAddCorrectScore()
        {
            Ranking rank = Setup();
            Score score1 = new Score(20);
            rank.AddScore(score1);
            bool actual = rank.Scores.Contains(score1);

            Assert.AreEqual(true, actual, "Test ranking can add score");
        }
        //test: check if file is saved correctly
        //expected: number of scores in the ranking obj
        [Test]
        public void TestSaveFile1()
        {
            Ranking rank = Setup();
            rank.SaveScores("scores.txt");
            string actual = rank.GetLine("scores.txt", 1);
            string num = rank.Scores.Count.ToString();
            Assert.AreEqual(num, actual, "Test ranking can save to file");
        }
        //test: check if file is saved correctly
        //expected: value of 2nd score from top
        [Test]
        public void TestSaveFile2()
        {
            Ranking rank = Setup();
            rank.SaveScores("scores.txt");
            string actual = rank.GetLine("scores.txt", 3);
            string num = rank.Scores[1].Value.ToString();
            Assert.AreEqual(num, actual, "Test ranking can save to file");
        }
        //test: check if file exists and is in correct format to load from (less than 11 lines, contains only digit)
        //expected: file exists and is in correct format (true)
        [Test]
        public void TestCheckFileValid()
        {
            Ranking rank = new Ranking();
            bool actual = rank.CheckFile("scores.txt");

            Assert.AreEqual(true, actual, "Test ranking can check for file validity");
        }
        //test: check if ranking obj can read file content, line by line
        //expected: concatenated string of first 3 lines of file
        [Test]
        public void TestGetContentFromFile()
        {
            Ranking rank = new Ranking();
            rank.LoadScores("scores.txt");
            string line;
            string actual = "";
            for (int i = 0; i < 3; i++)
            {
                line = rank.GetLine("scores.txt",i + 1);
                actual += line;
            }
            Assert.AreEqual("42015", actual, "Test ranking can print file content");
        }
        //test: check if ranking obj can sort score objs by value
        //expected: list of scores is sorted (true)
        [Test]
        public void TestSort()
        {
            Ranking rank = Setup();
            rank.Sort();
            bool actual = true;
            for (int i = 0; i < rank.Scores.Count; i++)
            {
                if (i > 0)
                {
                    if (rank.Scores[i].Value > rank.Scores[i - 1].Value) { actual = false; break; }
                }
                if (i < rank.Scores.Count - 1)
                {
                    if (rank.Scores[i].Value < rank.Scores[i + 1].Value) { actual = false; break; }
                }
            }
            Assert.AreEqual(true, actual, "Test ranking can sort scores");
        }
        //test: check if ranking obj can remove and sort when there are more than 10 scores
        //expected: 10 scores after adding and list of scores is sorted (true)
        [Test]
        public void TestCheckScoreCount()
        {
            Ranking rank = Setup();
            Score score2 = new Score(15);
            Score score3 = new Score(2);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score2);
            rank.AddScore(score2);
            rank.AddScore(score3);
            rank.AddScore(score2);
            int num = rank.Scores.Count;

            bool actual = (num == 10);
            Assert.AreEqual(true, actual, "Test ranking can add score with score count above 10");
        }
    }
}
