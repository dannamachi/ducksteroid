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

        private int _x;
        private int _y;

        public bool Exist
        {
            get { return _exists; }
            set { _exists = value; }
        }
        public Duck(float x, float y, int radius)
        {
            _rad = radius;
            _pos.X = x;
            _pos.Y = y;
            _orientation = Orientation.Right;
            DuckLoad();
            
        }
        //Properties
        public int Radius { set => _rad = value; get => _rad; }

        public Orientation Orientation { get => _orientation; set => _orientation = value; }

        public void DuckLoad()
        {
            leftDuck = SwinGame.LoadBitmap("DuckLeft.png");
            rightDuck = SwinGame.LoadBitmap("DuckRight.png");
        }

        
        public void DrawDuckAnimation()
        {
         
            if (_orientation == Orientation.Left) { SwinGame.DrawBitmap(leftDuck, _x, _y); }
            else { SwinGame.DrawBitmap(rightDuck, _x, _y); }

        }
        
        public Bitmap LeftDuck { get => leftDuck; }
        public Bitmap RightDuck { get => rightDuck; }

        //Update the location of the Ducks
        public void Update() { }
              

        public void MoveDuck(float x, float y)
        {
            _vel.Y = -1;
            _vel.X = 0;
            _pos = SwinGame.AddVectors(_pos, _vel);

        }

        public void Spawn()
        {

        }

    }

}
