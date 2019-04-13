using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public class Rectangle : Shape
    {
        //fields
        private int width;
        private int height;
        //constructors
        public Rectangle (Color clr, float x, float y, int w, int h) : base (clr)
        {
            X = x;
            Y = y;
            width = w;
            height = h;
        }
        public Rectangle () : this (Color.Red,0,0,0,0) { }
        //properties
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        //methods
        public override void Draw()
        {
            SwinGame.FillRectangle(Color, X, Y, width, height);
        }
        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, X, Y, width, height);
        }

    }
}
