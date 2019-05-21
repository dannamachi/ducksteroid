using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyGame
{
    public class Ranking
    {
        //fields
        private List<Score> _scores;
        //constructors
        public Ranking()
        {
            _scores = new List<Score>();
        }
        //properties
        public List<Score> Scores { get => _scores; }
        //methods
        public bool SaveScores(string filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath, false))
            {
                writer.WriteLine(_scores.Count);
                foreach (Score sc in _scores)
                {
                    writer.WriteLine(sc.Value);
                }
            }
            return true;
        }
        public void LoadScores(string filepath)
        {
            if (CheckFile(filepath))
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line = reader.ReadLine();
                    int num;
                    Score score;
                    while (line != null)
                    {
                        num = Convert.ToInt32(line.TrimEnd());
                        score = new Score(num);
                        _scores.Add(score);
                        line = reader.ReadLine();
                    }
                }
            }
        }
        public string GetLine(string filepath, int index)
        {
            if (index == 0) { return null; }
            using (StreamReader reader = new StreamReader(filepath))
            {
                int i = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (i == index) { return line; }
                    line = reader.ReadLine();
                    i += 1;
                }
            }
            return null;
        }
        private bool OnlyHasDigit(string line)
        {
            foreach (char letter in line)
            {
                if (letter < '0' || letter > '9') { return false; }
            }
            return true;
        }
        public bool CheckFile(string filepath)
        {
            bool result = true;
            if (!File.Exists(filepath)) { return false; }
            using (StreamReader reader = new StreamReader(filepath))
            {
                string line = reader.ReadLine();
                int count = 0;
                while (line != null)
                {
                    if (count == 11) { result = false; break; }
                    if (!OnlyHasDigit(line)) { result = false; break; }
                    line = reader.ReadLine();
                    count += 1;
                }
            }
            return result;
        }
        public void AddScore(Score sc)
        {
            _scores.Add(sc);
            Sort();
            if (Scores.Count > 10)
            {
                List<Score> scores = new List<Score>();
                for (int i = 0; i < 10; i++)
                {
                    scores.Add(Scores[i]);
                }
                _scores = scores;
            }
        }
        public void Sort()
        {
            Score temp;
            for (int i = 0; i < Scores.Count; i++)
            {
                for (int j = i + 1; j < Scores.Count; j++)
                {
                    if (Scores[i].Value < Scores[j].Value)
                    {
                        temp = Scores[i];
                        Scores[i] = Scores[j];
                        Scores[j] = temp;
                    }
                }
            }
        }
    }
}
