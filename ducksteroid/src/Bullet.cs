using System;
using SwinGameSDK;

namespace MyGame
{
    public class Bullet : Shape
    {
        private int _radius;
        private Vector _velocity = new Vector();
        private Point2D _position = new Point2D();

        //Constructors
        public Bullet (Color clr, Point2D position, Vector direction, int radius, int critangle) : base (clr)
        {
            _radius = radius;
            _position = position;
            _velocity.X = direction.X * 5 * (float)Math.Cos (Math.PI * critangle / 180);
            _velocity.Y = direction.Y * 5 * (float)Math.Sin (Math.PI * critangle / 180);
        }
        public Bullet (Point2D position, Vector direction, int critangle) : this (Color.White, position, direction, 3, critangle)
        {
        }

        //Properties
        public int Radius { set => _radius = value; get => _radius; }
        public Point2D Position { get => _position; }

        //Methods
        //Draw a bullet
        public override void Draw () => SwinGame.FillCircle (Color, _position.X, _position.Y, Radius);

        //Bullet hits something
        public override bool IsAt (Point2D pt) => SwinGame.PointInCircle (pt, X, Y, Radius);

        //Bullet move
        public void Move ()
        {
            _position = SwinGame.AddVectors (_position, _velocity);
        }
    }
}
