﻿using System;
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
        private static int _count = 0;
        private static List<Joke> _jokes = new List<Joke>();
        private static string _fileName = "jokes.txt";
        private static Joke _joke = new Joke();
        //properties
        //methods
        public static Joke ReadJoke (StreamReader reader)
        {
            string line = reader.ReadLine().TrimEnd();
            Joke joke = new Joke();
            while (line != "?")
            {
                joke.AddLine(line);
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
                posNum = rand.Next(1, 4);
                switch (posNum)
                {
                    case 1:
                        joke.X = 100;
                        joke.Y = 75;
                        break;
                    case 2:
                        joke.X = 500;
                        joke.Y = 75;
                        break;
                    case 3:
                        joke.X = 100;
                        joke.Y = 375;
                        break;
                    case 4:
                        joke.X = 500;
                        joke.Y = 375;
                        break;
                }
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
            _joke = _jokes[_count];
        }
    }
}
