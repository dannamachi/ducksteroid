using System;
using System.Collections.Generic;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public abstract class Shape
    {
        //fields
        private Color _color;
        private float _x, _y;
        private bool _selected;
        //constructos
        public Shape(Color clr)
        {
            _color = clr;
            _x = 0;
            _y = 0;
            _selected = false;
        }
        public Shape() : this(Color.White) { }
        //properties
        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public bool Selected { get => _selected; set => _selected = value; }
        //methods
        public abstract void Draw();
        public abstract bool IsAt(Point2D pt);

    }
}
