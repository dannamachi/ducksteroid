using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    public class Joke : Shape
    {
        //fields
        private List<string> _texts;
        //constructors
        public Joke(string[] texts, float x, float y) : base()
        {
            string line;
            string[] segments;
            _texts = new List<string>();
            foreach (string st in texts)
            {
                line = BreakContentIntoLines(st);
                segments = line.Split('\n');
                foreach (string segment in segments) { _texts.Add(segment); }
            }
            X = x;
            Y = y;
        }
        public Joke() : this (new string[] { },0,0) { }
        //properties
        //methods
        public int GetLastIndexOnLine(string substr)
        {
            int result = -1;
            int end = substr.Length;
            int start = 0;
            int count = 0;
            int at = 0;
            while ((start <= end) && (at > -1))
            {
                count = end - start;
                at = substr.IndexOf(" ", start, count);
                if (at == -1) break;
                result = at;
                start = at + 1;
            }
            return result;
        }
        public string BreakContentIntoLines(string stuff)
        {
            string content = "";
            string temp;
            int lastIndex = 30;
            int firstIndex = 0;
            int n = stuff.Length;

            n = n / 30 + 1;
            for (int i = 0; i < n; i++)
            {
                if (i < n - 1)
                {
                    temp = stuff.Substring(firstIndex, 30);
                }
                else
                {
                    temp = stuff.Substring(firstIndex);
                }

                lastIndex = GetLastIndexOnLine(temp);
                if (lastIndex == -1)
                {
                    content += temp;
                    if (i < n - 1)
                        firstIndex += 30;
                }
                else if (i < n - 1)
                {
                    content += temp.Substring(0, GetLastIndexOnLine(temp)) + "\n";
                    firstIndex += lastIndex + 1;
                }
                else
                {
                    content += temp;
                }

            }
            return content;
        }
        public string GetLine(int index)
        {
            if (0 <= index && index < _texts.Count) { return _texts[index]; }
            return "Nothing here~";
        }
        public void AddLine(string st)
        {
            string line = BreakContentIntoLines(st);
            string[] segments = line.Split('\n');
            foreach (string segment in segments) { _texts.Add(segment); }
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
