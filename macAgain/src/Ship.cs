using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class Ship : Shape
    {
        private List<Bullet> _bullets = new List<Bullet> ();
        private Triangle _triangle;

        //Constructors
        public Ship (Color clr, float x, float y) : base ("ship", clr)
        {
            X = x;
            Y = y;
            _triangle = SwinGame.CreateTriangle (X, Y, X - 15, Y + 20, X + 15, Y + 20);
        }
        public Ship () : this (Color.White, 0,0)
        {
        }

        //Properties
        public Triangle TriangleShip { 
            get => _triangle;
            set => _triangle = value;
        }

        //Methods
        //Draw the the ship
        public override void Draw () => SwinGame.FillTriangle(Color, TriangleShip);

        //If something touches within the ship's area
        public override bool IsAt (Point2D pt) => SwinGame.PointInTriangle (pt, TriangleShip);

        //Update the location of the ship
        public void Update ()
        {

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
