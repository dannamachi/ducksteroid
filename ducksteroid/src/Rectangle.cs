using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    public class Rectangle : Shape
    {
        //fields
        private int _width;
        private int _height;
        //constructors
        public Rectangle (Color clr, float x, float y, int w, int h) : base (clr)
        {
            X = x;
            Y = y;
            _width = w;
            _height = h;
        }
        public Rectangle () : this (Color.Black,0,0,50,50) { }
        //properties
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        //methods
        public override void Draw()
        {
            SwinGame.FillRectangle(Color, X, Y, _width, _height);
        }
        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, X, Y, _width, _height);
        }

    }
}
