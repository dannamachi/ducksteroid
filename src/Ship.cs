using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame.src
{
    public class Ship : Shape
    {
        private List<Bullet> _bullets;
        private Triangle _triangle;

        //Constructors
        public Ship (Color clr, float x, float y) : base (clr)
        {
            X = x;
            Y = y;
            _triangle = SwinGame.CreateTriangle (X, Y, X - 15, Y + 20, X + 15, Y + 20);
            _bullets = new List<Bullet> ();
        }
        public Ship () : this (Color.White, 0,0)
        {
        }

        //Properties
        public Triangle TriangleShip { get => _triangle; set => _triangle = value; }
        public List<Bullet> Bullets { get => _bullets; }
        //Methods
        //Draw the the ship
        public override void Draw () => SwinGame.FillTriangle(Color, TriangleShip);

        //If something touches within the ship's area
        public override bool IsAt (Point2D pt) => SwinGame.PointInTriangle (pt, TriangleShip);

        //Update the location of the ship
        public void Update ()
        {
            TriangleShip = SwinGame.CreateTriangle (X, Y, X - 15, Y + 20, X + 15, Y + 20);
        }

        //Add bullet to the list of bullets 
        public void AddBullet () => _bullets.Add (new Bullet (Color.White,X,Y,3));
        //Shot bullet
        public void Shoot ()
        {
            _bullets.ForEach (b => b.Draw ());
            _bullets.ForEach (b => b.Move (X, Y));
        }
    }
}
