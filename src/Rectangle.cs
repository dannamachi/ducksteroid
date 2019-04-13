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
    }
}
