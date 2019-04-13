using System;
using System.Collections.Generic;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public abstract class Shape
    {
        //fields
        private Color color;
        private float x, y;
        private bool selected;
        //constructos
        public Shape(Color clr)
        {
            color = clr;
            x = 0;
            y = 0;
            selected = false;
        }
        public Shape() : this(Color.White) { }
        //properties
        public Color Color { get => color; set => color = value; }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public bool Selected { get => selected; set => selected = value; }
        //methods
        public abstract void Draw();
        public abstract bool IsAt(Point2D pt);

    }
}
