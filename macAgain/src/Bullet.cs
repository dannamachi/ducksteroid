using System;
using SwinGameSDK;

namespace MyGame
{
    public class Bullet : Shape
    {
        private int _radius;
        private Vector _velocity;
        private Point2D _position;

        //Constructors
        public Bullet (Color clr, float x, float y, int radius) : base ("bullet", clr)
        {
            _radius = radius;
            _position.X = x;
            _position.Y = y;
        }
        public Bullet () : this (Color.White,0,0, 3)
        {
        }

        //Properties
        public int Radius { set => _radius = value; get => _radius; }

        //Methods
        //Draw a bullet
        public override void Draw () => SwinGame.FillCircle (Color, _position.X, _position.Y, Radius);

        //Bullet hits something
        public override bool IsAt (Point2D pt) => SwinGame.PointInCircle (pt, X, Y, Radius);

        //Bullet move
        public void Move (float x, float y)
        {
            _velocity.Y = -5;
            _position = SwinGame.AddVectors (_position, _velocity);
        }
    }
}
