using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public enum Orientation
    {
        Left,
        Right
    }
    class Duck
    {

        private Bitmap leftDuck;
        private Bitmap rightDuck;
        private bool _exists;
        private int _rad;
        private Vector _vel;
        private Point2D _pos;
        private Orientation _orientation;


        public bool Exist
        {
            get { return _exists; }
            set { _exists = value; }
        }
        public Duck(float x, float y, int radius)
        {
            _exists = true;
            _pos = new Point2D();

            _vel = new Vector();
            Random random = new Random();
            _vel.X = random.Next(-5, 5);
            _vel.Y = random.Next(-5, 5);

            _rad = radius;
            _pos.X = x;
            _pos.Y = y;
            _orientation = Orientation.Right;
            DuckLoad();

        }

        public Duck(float x, float y, int radius, SpawnSide side) : this(x,y,radius)
        {
            Random random = new Random();
            switch (side)
            {
                case SpawnSide.Top:
                    _vel.X = random.Next(-5, 5);
                    _vel.Y = random.Next(1, 5);
                    break;
                case SpawnSide.Right:
                    _vel.X = random.Next(1, 5);
                    _vel.Y = random.Next(-5, 5);
                    break;
                case SpawnSide.Left:
                    _vel.X = random.Next(-5, -1);
                    _vel.Y = random.Next(-5, 5);
                    break;
                case SpawnSide.Bottom:
                    _vel.X = random.Next(-5, 5);
                    _vel.Y = random.Next(-5, -1);
                    break;
            }
        }
        //Properties
        public int Radius { set => _rad = value; get => _rad; }

        public Orientation Orientation { get => _orientation; }

        public Point2D Position { get => _pos; }


        public void Killed ()
        {
            _exists = false;
        }
        public void FlipDuck()
        {
            if (_orientation == Orientation.Left) { _orientation = Orientation.Right; }
            else { _orientation = Orientation.Left; }

        }
        public void DuckLoad()
        {
            leftDuck = SwinGame.LoadBitmap("DuckLeft.png");
            rightDuck = SwinGame.LoadBitmap("DuckRight.png");
        }


        public void DrawDuckAnimation()
        {

            if (_orientation == Orientation.Left) { SwinGame.DrawBitmap(leftDuck, _pos.X, _pos.Y); }
            else { SwinGame.DrawBitmap(rightDuck, _pos.X, _pos.Y); }

        }

        public bool IsAt (Point2D pt)
        {
            return SwinGame.PointInCircle(pt, _pos.X, _pos.Y, _rad);
        }

        public Bitmap LeftDuck { get => leftDuck; }
        public Bitmap RightDuck { get => rightDuck; }

        //Update the location of the Ducks
        public void Update() { }


        public void MoveDuck()
        {
            _pos = SwinGame.AddVectors(_pos, _vel);

        }

        public void Spawn()
        {

        }

    }

}