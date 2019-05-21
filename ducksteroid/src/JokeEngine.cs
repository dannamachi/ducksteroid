using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
    //public enum JokePos
    //{
    //    TopLeft,
    //    TopRight,
    //    BottomLeft,
    //    BottomRight
    //}
    public static class JokeEngine
    {
        //fields
        private static int _count = 0;
        private static List<Joke> _jokes = new List<Joke>();
        private static string _fileName = "jokes.txt";
        private static Joke _joke = new Joke();
        //properties
        public static Joke Joke { get => _joke; }
        public static int JokeCount { get => _jokes.Count; }
        //methods
        private static Joke ReadJoke (StreamReader reader)
        {
            string line = reader.ReadLine().TrimEnd();
            Joke joke = new Joke();
            while (line != "?")
            {
                joke.AddLine(line);
                line = reader.ReadLine().TrimEnd();
            }
            return joke;
        }
        public static void LoadJokes()
        {
            Random rand = new Random();
            int posNum;
            StreamReader reader = new StreamReader(_fileName);
            int num = Convert.ToInt32(reader.ReadLine().TrimEnd());
            Joke joke;
            for (int i = 0; i < num; i++)
            {
                joke = ReadJoke(reader);
                _jokes.Add(joke);
            }
            reader.Close();
            _count = 0;
        }
        public static void DrawJoke()
        {
            if (_joke != null) { _joke.Draw(); }
        }
        public static void GetJoke()
        {
            _count += 1;
            if (_count == _jokes.Count) { _count = 0; }
            _joke = _jokes[_count];
            Random rand = new Random();
            int posNum = rand.Next(1, 4);
            switch (posNum)
            {
                case 1:
                    _joke.X = 100;
                    _joke.Y = 75;
                    break;
                case 2:
                    _joke.X = 500;
                    _joke.Y = 75;
                    break;
                case 3:
                    _joke.X = 100;
                    _joke.Y = 375;
                    break;
                case 4:
                    _joke.X = 500;
                    _joke.Y = 375;
                    break;
            }
        }
    }
}
