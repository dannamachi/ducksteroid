using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame.src
{
    public class Ship : Shape
    {
        private List<Bullet> _bullets;
        private Triangle _triangle;
        private int _angle;
        private int _center;
        private int _radius;
        Point2D _p1, _p2, _p3;


        //Constructors
        public Ship (Color clr, int center, int radius) : base (clr)
        {
            _angle = 180;
            _radius = radius;
            _center = center;
            _bullets = new List<Bullet> ();
        }
        public Ship () : this (Color.White, 0,0)
        {
        }

        //Properties
        public Triangle TriangleShip { get => _triangle; set => _triangle = value; }
        public List<Bullet> Bullets { get => _bullets; }
        public int Angle { get => _angle; }

        //Methods
        //Draw the the ship
        public override void Draw () => SwinGame.FillTriangle(Color, TriangleShip);

        //If something touches within the ship's area
        public override bool IsAt (Point2D pt) => SwinGame.PointInTriangle (pt, TriangleShip);

        //Update the location of the ship
        public void Update ()
        {
            _p1.X = Rotate (Angle, _radius, _center) [0];
            _p1.Y = Rotate (Angle, _radius, _center) [1] - 100;
            _p2.X = Rotate (Angle + 360, _radius, _center) [0];
            _p2.Y = Rotate (Angle + 360, _radius, _center) [1] - 100;
            _p3.X = Rotate (Angle + 540 , _radius, _center) [0];
            _p3.Y = Rotate (Angle + 540, _radius, _center) [1] - 100;

            if (Angle > 360 ){
                _angle = -Angle + 10;
            }
            if (Angle < -360) {
                _angle = -Angle - 10;
            }

            TriangleShip = SwinGame.CreateTriangle (_p1, _p2, _p3);
        }

        // Update angle
        public void IncreaseAngle ()
        {
            _angle += 5;
        }
        public void DecreaseAngle()
        {
            _angle -= 5;
        }

        //Add bullet to the list of bullets 
        public void AddBullet () => _bullets.Add (new Bullet (Color.White,X,Y,3));
        //Shot bullet
        public void Shoot ()
        {
            _bullets.ForEach (b => b.Draw ());
            _bullets.ForEach (b => b.Move (X, Y));
        }

        //Rotate ship
        private int [] Rotate (int angleIn, int radius, int center)
        {
            int [] lr = new int [2];
            angleIn %= 1440;
            if (angleIn >= 0 && angleIn <= 360) {
                lr [0] = center + (int)(radius * Math.Sin (Math.PI * angleIn / 360));
                lr [1] = center - (int)(radius * Math.Cos (Math.PI * angleIn / 360));
            } else {
                lr [0] = center - (int)(radius * -Math.Sin (Math.PI * angleIn / 360));
                lr [1] = center - (int)(radius * Math.Cos (Math.PI * angleIn / 360));
            }
            return lr;
        }
    }
}
