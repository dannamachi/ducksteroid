using System;
using System.Collections.Generic;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        protected string _thing;

        //Constructors
        public Shape(string thing, Color color)
        {
            _thing = thing;
            _color = color;
            _x = 0;
            _y = 0;
        }
        public Shape(): this ("text",Color.White)
        {
        }

        //Properties
        public string Thing { get => _thing; }
        public Color Color { set => _color = value; get => _color; }
        public float X { set => _x = value; get => _x; }
        public float Y { set => _y = value; get => _y; }

        //Methods

        //Abstract Methods
        public abstract void Draw ();
        public abstract bool IsAt (Point2D pt);
    }
}
