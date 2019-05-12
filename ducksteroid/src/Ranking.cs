using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyGame.src
{
    public class Ranking
    {
        //fields
        private List<Score> _scores;
        private StreamReader _reader;
        //constructors
        public Ranking()
        {
            _scores = new List<Score>();
            _reader = null;
        }
        //properties
        public List<Score> Scores { get => _scores; }
        //methods
        public void SaveFile(string filepath)
        {
            StreamReader
            foreach (Score sc in _scores)
            {

            }
        }
        public void LoadScores(string filepath)
        {
            if (CheckFile(filepath))
            {
                LoadFile();
                string line = GetLine();
                int num;
                Score score;
                while (line != null)
                {
                    num = Convert.ToInt32(line.TrimEnd());
                    score = new Score("", num);
                    _scores.Add(score);
                    line = GetLine();
                }
            }
        }
        public string GetLine()
        {
            return _reader.ReadLine();
        }
        public void LoadFile(string filepath)
        {
            _reader = new StreamReader(filepath);
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
            StreamReader reader;
            if (!File.Exists(filepath)) { return false; }
            try
            {
                reader = new StreamReader(filepath);
            }
            catch (Exception e) {
                return false;
            }
            reader = new StreamReader(filepath);
            string line = reader.ReadLine();
            int count = 0;
            while (line != null)
            {
                if (count == 11) { return false; }
                if (!OnlyHasDigit(line)) { return false; }
                line = reader.ReadLine();
                count += 1;
            }
            return true;
        }
        public void AddScore(Score sc)
        {
            _scores.Add(sc);
            Sort();
            if (Scores.Count > 10) {
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
