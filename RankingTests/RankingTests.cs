using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
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

        //test: add score to a ranking obj
        //expected: contain the score added (true)
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
        //test: check if file can be loaded from
        //expected: file is missing so cannot load (false)
        [Test]
        public void TestCheckFileMissing()
        {
            Ranking rank = new Ranking();
            bool actual = rank.CheckFile("scorenope.txt");

            Assert.AreEqual(false, actual, "Test ranking can detect missing file");
        }
        //test: check if file can be loaded from
        //expected: file has more than 11 lines so cannot load (false)
        [Test]
        public void TestCheckFileValid1()
        {
            Ranking rank = new Ranking();
            bool actual = rank.CheckFile("scoreover11.txt");

            Assert.AreEqual(false, actual, "Test ranking can check for file validity");
        }
        //test: check if file can be loaded from
        //expected: file has non-digit chars so cannot load (false)
        [Test]
        public void TestCheckFileValid2()
        {
            Ranking rank = new Ranking();
            bool actual = rank.CheckFile("scorenondigit.txt");

            Assert.AreEqual(false, actual, "Test ranking can check for file validity");
        }
        //test: check if ranking obj can read file content, line by line
        //expected: concatenated string of first 3 lines of file 
        [Test]
        public void TestGetContentFromFile()
        {
            Ranking rank = new Ranking();
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
        //test: check if file is saved correctly
        //expected: number of scores in the ranking obj 
        [Test]
        public void TestSaveFile1()
        {
            Ranking rank = Setup();
            rank.SaveFile("scores.txt");
            StreamReader reader = new StreamReader("scores.txt");
            int actual = Convert.ToInt32(reader.ReadLine());
            int num = rank.Scores.Count;
            Assert.AreEqual(num, actual, "Test ranking can save to file");
        }
        //test: check if file is saved correctly
        //expected: value of 2nd score from top
        [Test]
        public void TestSaveFile2()
        {
            Ranking rank = Setup();
            rank.SaveFile("scores.txt");
            StreamReader reader = new StreamReader("scores.txt");
            reader.ReadLine();
            reader.ReadLine();
            int actual = Convert.ToInt32(reader.ReadLine());
            int num = rank.Scores[1].Value;
            Assert.AreEqual(num, actual, "Test ranking can save to file");
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
                for (int j = i + 1; j < rank.Scores.Count; j++)
                {
                    if (rank.Scores[i].Value < rank.Scores[j].Value) { actual = false; break; }
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
            int num = rank.Scores.Count;
            bool sorted = true;
            for (int i = 0; i < rank.Scores.Count; i++)
            {
                for (int j = i + 1; j < rank.Scores.Count; j++)
                {
                    if (rank.Scores[i].Value < rank.Scores[j].Value) { sorted = false; break; }
                }
            }
            bool actual = (num == 10) && sorted;
            Assert.AreEqual(true, actual, "Test ranking can add score with score count above 10");
        }
    }
}