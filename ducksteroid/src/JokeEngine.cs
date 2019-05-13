using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SwinGameSDK;

namespace MyGame.src
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
        private static int _count;
        private static List<Text> _jokes = new List<Text>();
        private static string _fileName = "jokes.txt";
        private static Text _lastjoke = new Text();
        private static Text _joke;
        //properties
        public static Text LastJoke { get => _lastjoke; }
        //methods
        public static void LoadJokes()
        {
            Random rand = new Random();
            int posNum;
            StreamReader reader = new StreamReader(_fileName);
            string line = reader.ReadLine();
            while (line != null)
            {
                Text text = new Text(Color.Red, reader.ReadLine(), SwinGame.LoadFont("Arial", 30));
                posNum = rand.Next(1, 4);
                switch (posNum)
                {
                    case 1:
                        text.X = 100;
                        text.Y = 75;
                        break;
                    case 2:
                        text.X = 500;
                        text.Y = 75;
                        break;
                    case 3:
                        text.X = 100;
                        text.Y = 375;
                        break;
                    case 4:
                        text.X = 500;
                        text.Y = 375;
                        break;
                }
                _jokes.Add(text);
                line = reader.ReadLine();
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
            Random rand = new Random();
            int num = rand.Next(0, _jokes.Count - 1);
            Text joke = _jokes[num];
            while (joke == _lastjoke)
            {
                num = rand.Next(0, _jokes.Count - 1);
                joke = _jokes[num];
            }
            _lastjoke = joke;
            _joke = joke;
        }
    }
}
