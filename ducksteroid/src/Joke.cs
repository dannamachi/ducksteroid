using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public class Joke : Shape
    {
        //fields
        private List<string> _texts;
        //constructors
        public Joke(string[] texts, float x, float y) : base()
        {
            _texts = new List<string>();
            foreach (string st in texts)
            {
                _texts.Add(st);
            }
            X = x;
            Y = y;
        }
        public Joke() : this (new string[] { },0,0) { }
        //properties
        //methods
        public string GetLine(int index)
        {
            if (0 <= index && index < _texts.Count) { return _texts[index]; }
            return "Nothing here~";
        }
        public void AddLine(string st)
        {
            _texts.Add(st);
        }
        public override bool IsAt(Point2D pt)
        {
            return false;
        }
        public override void Draw()
        {
            Point2D pos = new Point2D();
            for (int i = 0; i < _texts.Count; i++)
            {
                pos.X = X;
                pos.Y = Y + i * 25;
                SwinGame.DrawText(_texts[i], Color.Red, pos);
            }
        }
    }
}
