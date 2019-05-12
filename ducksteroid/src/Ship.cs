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
        private Point2D _center;
        private int _radius;
        Point2D _p1, _p2, _p3;


        //Constructors
        public Ship (Color clr, float x, float y, int radius) : base (clr)
        {
            _angle = 180;
            _radius = radius;
            _center = new Point2D();
            _p1 = _p2 = _p3 = new Point2D ();
            _center.X = x;
            _center.Y = y;
            _bullets = new List<Bullet> ();
        }
        public Ship () : this (Color.White, 0,0,10)
        {
        }

        //Properties
        public Triangle TriangleShip { get => _triangle; set => _triangle = value; }
        public List<Bullet> Bullets { get => _bullets; }
        public int Angle { get => _angle; }
        public string CenterCoord { get => _center.X.ToString () + "-" + _center.Y.ToString (); }
        public List<Point2D> Positions {
            get {
                List<Point2D> p = new List<Point2D>();
                p.Add(_p1);
                p.Add(_p2);
                p.Add(_p3);
                return p;
            }
        }

        public Vector Direction {
            get {
                Vector direction = new Vector ();
                int angle = TrueAngle ();
                if (angle < 90) 
                    { direction.X = -1; direction.Y = -1; } 
                else if (angle < 180) 
                    { direction.X = +1; direction.Y = -1; } 
                else if (angle < 270) 
                    { direction.X = +1; direction.Y = +1; } 
                else 
                    { direction.X = -1; direction.Y = +1; }
                return direction;
            }
        }

        //Methods
        //Draw the the ship
        public override void Draw ()  {
            SwinGame.FillTriangle(Color, TriangleShip);
        }

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
        public void DecreaseAngle ()
        {
            _angle -= 5;
        }

        //Direction
        private int TrueAngle ()
        {
            int angle;
            angle = Angle / 2;
            if (angle < 0)
                angle = 360 + angle;
            return angle;
        }
        private int CritAngle ()
        {
            int angle, critangle;
            angle = TrueAngle ();

            if (angle < 90)
                critangle = angle;
            else if (angle < 180)
                critangle = 180 - angle;
            else if (angle < 270)
                critangle = angle - 180;
            else
                critangle = 360 - angle;
            return critangle;
        }

        //Move
        private void Move (int critangle, Vector direction)
        {
            Vector newpoint = new Vector ();
            newpoint.X = direction.X * 5 * (float)Math.Cos (Math.PI * critangle / 180);
            newpoint.Y = direction.Y * 5 * (float)Math.Sin (Math.PI * critangle / 180);
            _center = SwinGame.AddVectors (_center, newpoint);
        }
        public void MoveUp () => Move (CritAngle (), Direction);
        public void MoveDown ()
        {
            Vector direction = new Vector ();
            direction.X = Direction.X * -1;
            direction.Y = Direction.Y * -1;
            Move (CritAngle (), direction);
        }

        //Add bullet to the list of bullets 
        public void AddBullet () => _bullets.Add (new Bullet (Color.White, _p3, Direction, 3, CritAngle()));
        //Shot bullet
        public void Shoot ()
        {
            _bullets.ForEach (b => b.Draw ());
            _bullets.ForEach (b => b.Move ());
        }

        //Rotate ship
        private int [] Rotate (int angleIn, int radius, Point2D center)
        {
            int [] lr = new int [2];
            //angleIn %= 1440;
            if (angleIn >= 0 && angleIn <= 360) {
                lr [0] = (int)center.X + (int)(radius * Math.Sin (Math.PI * angleIn / 360));
                lr [1] = (int)center.Y - (int)(radius * Math.Cos (Math.PI * angleIn / 360));
            } else {
                lr [0] = (int)center.X - (int)(radius * -Math.Sin (Math.PI * angleIn / 360));
                lr [1] = (int)center.Y - (int)(radius * Math.Cos (Math.PI * angleIn / 360));
            }
            return lr;
        }
    }
}
